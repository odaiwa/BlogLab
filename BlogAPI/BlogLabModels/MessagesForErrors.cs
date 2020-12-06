using System;
using System.Collections.Generic;
using System.Text;

namespace BlogLabModels
{
    public class MessagesForErrors
    {
        public const string InValidEmailRegex = "Email format is Invalid";
        public const string EmailRequired = "Email is required";
        public const string CharactersLimit10_30 = "Must be 10-30 characters";
        public const string MaxCharactersLimit30 = "Can be at must 30 characters";
        public const string MaxCharactersLimit50 = "Can be at must 50 characters";


        public const string CharactersLimit10_300 = "Must be 10-300 characters";

        public const string MinCharactersLimit10 = "Must be at least 10 characters";


        public const string TitleRequired = "Title is required";
        public const string TitleLength = "Title must be between 10-50 characters";
        public const string TitleRequired1 = "Title is required";


        public const string ContentRequired = "Content is required";
        public const string ContentTextLimits = "must be at least 300-3000 characters";

        public const string UsernameRequired = "Username is required";
        public const string UsernameLengthLimit = "Username must be between 5-20 characters";


        public const string PasswordRequired = "Password is required";
        public const string PasswordLengthLimit = "Password must be between 10-50 characters";

    }
}
