using BlogLab.Models.Photo;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BlogLab.Repository
{
    public class PhotoRepository : IPhotoRepository
    {

        private readonly IConfiguration _config;

        public PhotoRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<int> DeleteAsync(int photoId)
        {
            int affectedRows = 0;
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();

                affectedRows = await connection.ExecuteAsync(
                    "Photo_Delete",
                    new { PhotoId = photoId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
            return affectedRows;
        }

        public async Task<List<Photo>> GetAllByUserIdAsync(int applicationUserId)
        {
            IEnumerable<Photo> photos;
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();
                photos = await connection.QueryAsync<Photo>(
                    "Photo_GetByUserId",
                    new { ApplicationUserId = applicationUserId },
                    commandType: CommandType.StoredProcedure
                    );
            }

            return photos.AsList();
        }

        public async Task<Photo> GetAsync(int photoId)
        {
            Photo photo;
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();
                photo = await connection.QueryFirstOrDefaultAsync<Photo>(
                    "Photo_GetByUserId",
                    new { PhotoId = photoId },
                    commandType: CommandType.StoredProcedure
                    );
            }

            return photo;
        }

        public async Task<Photo> InsertAsync(PhotoCreate photocreate, int applicationUserId)
        {
            var datatable = new DataTable();
            datatable.Columns.Add("PublicId", typeof(string));
            datatable.Columns.Add("ImageUrl", typeof(string));
            datatable.Columns.Add("Description", typeof(string));

            datatable.Rows.Add(photocreate.PublicId, photocreate.ImageUrl, photocreate.Description);

            int newPhotoId;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();
                newPhotoId = await connection.ExecuteScalarAsync<int>(
                    "Photo_Insert",
                    new { Photo = datatable.AsTableValuedParameter("dbo.PhotoType")
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }

            Photo photo = await GetAsync(newPhotoId);

            return photo;
        }
    }
}
