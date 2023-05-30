namespace OutDoor_Models.Models
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;

    [Serializable]
    public class ControllerException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public ControllerException(string mensagem) : base(mensagem)
        {
        }
    }
}