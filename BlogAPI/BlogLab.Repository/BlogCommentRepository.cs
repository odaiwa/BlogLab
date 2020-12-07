using BlogLabModels.BlogComment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BlogLab.Repository
{
    public class BlogCommentRepository : IBlogCommentRepository
    {

        private readonly IConfiguration _config;

        public BlogCommentRepository(IConfiguration config)
        {
            _config = config;
        }


        public async Task<int> DeleteAsync(int blogCommentId)
        {
            int affectedRows = 0;
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();

                affectedRows = await connection.ExecuteAsync(
                    "BlogComment_Delete",
                    new { BlogCommentId = blogCommentId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
            return affectedRows;
        }

        public async Task<List<BlogComment>> GetAllAsync(int blogId)
        {
            IEnumerable<BlogComment> blogComments;
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();
                blogComments = await connection.QueryAsync<BlogComment>(
                    "BlogComment_GetAll",
                    new { BlogId = blogId },
                    commandType: CommandType.StoredProcedure
                    );
            }

            return blogComments.ToList();
        }

        public async Task<BlogComment> GetAsync(int blogCommentId)
        {
            BlogComment blogComment;
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();
                blogComment = await connection.QueryFirstOrDefaultAsync<BlogComment>(
                    "BlogComment_Get",
                    new { BlogCommentId = blogCommentId },
                    commandType: CommandType.StoredProcedure
                    );
            }

            return blogComment;
        }

        public async Task<BlogComment> UpsertAsync(BlogCommentCreate blogCommentCreate, int applicationUserId)
        {
            var datatable = new DataTable();
            datatable.Columns.Add("BlogCommentId", typeof(int));
            datatable.Columns.Add("ParentBlogCommentId", typeof(int));
            datatable.Columns.Add("BlogId", typeof(int));
            datatable.Columns.Add("Content", typeof(string));

            datatable.Rows.Add(blogCommentCreate.BlogCommentId, blogCommentCreate.ParentCommentId, blogCommentCreate.BlogId, blogCommentCreate.Content);

            int? newBlogCommentId;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();


                newBlogCommentId = await connection.ExecuteScalarAsync<int?>(
                    "BlogComment_Upsert",
                    new
                    {
                        BlogComment = datatable.AsTableValuedParameter("dbo.BlogCommentType")
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }

            newBlogCommentId = newBlogCommentId ?? blogCommentCreate.BlogCommentId;

            BlogComment blogcomment = await GetAsync(newBlogCommentId.Value);
            return blogcomment;
        }
    }
}
