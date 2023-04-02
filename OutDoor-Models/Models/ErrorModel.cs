using System.Net;

namespace LOG.Plataforma.BFF.WebApi.Filters.FiltroExcecoes
{
    public class ErroModel
    {
        public string Origem { get; set; }
        public string Mensagem { get; set; }
    }
}