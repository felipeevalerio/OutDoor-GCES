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

    }
}