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

    }
}