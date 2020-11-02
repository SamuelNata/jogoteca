using System;

namespace Jogoteca.Model.Exceptions
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException(string message) : base(message){
            
        }
    }
}