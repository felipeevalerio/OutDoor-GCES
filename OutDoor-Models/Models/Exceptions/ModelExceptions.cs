namespace OutDoor_Models.Models
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;

    [Serializable]
    public class ModelException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public ModelException(string mensagem) : base(mensagem)
        {
        }

        public ModelException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }

        protected ModelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}