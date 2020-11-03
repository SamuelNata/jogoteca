using System;

namespace Jogoteca.Models.Exceptions
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException(string message) : base(message){
            
        }
    }
}