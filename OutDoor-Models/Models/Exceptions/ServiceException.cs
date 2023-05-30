namespace OutDoor_Models.Models
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;


    [Serializable]
    public class ServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public ServiceException(string mensagem) : base(mensagem)
        {
        }

    }
}