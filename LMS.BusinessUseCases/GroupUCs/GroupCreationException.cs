using System.Runtime.Serialization;

namespace LMS.BusinessUseCases.GroupUCs
{
    [Serializable]
    internal class GroupCreationException : Exception
    {
        public GroupCreationException()
        {
        }

        public GroupCreationException(string? message) : base(message)
        {
        }

        public GroupCreationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GroupCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}