namespace OutDoor_Models.Models
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;

    [Serializable]
    public class RepositoryException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public RepositoryException(string mensagem) : base(mensagem)
        {
        }

        public RepositoryException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }

        protected RepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}