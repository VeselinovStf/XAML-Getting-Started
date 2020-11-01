using System;

namespace WiredBrainCoffee.Data.Exceptions
{
    public class LocalFileDbException : Exception
    {
        public LocalFileDbException(string message) : base(message)
        {
        }
    }
}
