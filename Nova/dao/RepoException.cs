using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nova.dao
{
    public class RepoException : Exception
    {

        public RepoException(string? message) : base(message)
        {
            Console.WriteLine($"Error presentado {message}");
        }

        public RepoException(string? message, Exception? innerException) : base(message, innerException)
        {
            Console.WriteLine($"Error presentado {innerException.Message}");
        }

        protected RepoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
