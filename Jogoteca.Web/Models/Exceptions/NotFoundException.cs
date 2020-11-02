using System;

namespace Jogoteca.Models.Exceptions
{
    /// <summary>
    /// Exception that, when throwed, will return a 404 to the client
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message){

        }
    }
}