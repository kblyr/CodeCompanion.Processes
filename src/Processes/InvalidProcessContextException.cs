using System.Runtime.Serialization;

namespace CodeCompanion.Processes
{
    public class InvalidProcessContextException : Exception
    {
        public Type ExpectedType { get; }

        public InvalidProcessContextException(Type expectedType)
        {
            ExpectedType = expectedType;
        }

        public InvalidProcessContextException(string? message, Type expectedType) : base(message)
        {
            ExpectedType = expectedType;
        }

        public InvalidProcessContextException(string? message, Exception? innerException, Type expectedType) : base(message, innerException)
        {
            ExpectedType = expectedType;
        }

        protected InvalidProcessContextException(SerializationInfo info, StreamingContext context, Type expectedType) : base(info, context)
        {
            ExpectedType = expectedType;
        }

        public static InvalidProcessContextException Expects<TProcessContext>() where TProcessContext : IProcessContext
        {
            return new(typeof(TProcessContext));
        }
    }
}