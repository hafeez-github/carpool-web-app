using System;
namespace Carpool.API.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string msg) : base(msg)
        {

        }
    }
}

