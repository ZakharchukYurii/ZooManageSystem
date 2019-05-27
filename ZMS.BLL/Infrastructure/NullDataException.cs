using System;

namespace ZMS.BLL.Infrastructure
{
    public class NullDataException : Exception
    {
        public NullDataException() { }
        public NullDataException(string message) : base(message) { }
        public NullDataException(string message, Exception inner) : base(message, inner) { }
        protected NullDataException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
