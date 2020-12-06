using System;
using System.Collections.Generic;
using System.Text;

namespace BlogLabModels
{
    public class MessagesForErrors
    {
        public const string InValidEmailRegex = "Email format is Invalid";
        public const string EmailRequired = "Email is required";
        public const string CharactersLimit = "Must be at least 10-30 characters";
        public const string MaxCharactersLimit30 = "Can be at must 30 characters";
        public const string MaxCharactersLimit50 = "Can be at must 50 characters";
        public const string MaxCharactersLimit3000 = "Can be at must 3000 characters";

        public const string MinCharactersLimit10 = "Must be at least 10 characters";


        public const string TitleRequired = "Title is required";
        public const string TitleLength = "Title must be between 10-50 characters";
        public const string TitleRequired1 = "Title is required";
        public const string TitleRequired2 = "Title is required";


        public const string ContentRequired = "Content is required";


    }
}
