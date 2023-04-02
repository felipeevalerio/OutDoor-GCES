using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using LOG.Plataforma.BFF.WebApi.Filters.FiltroExcecoes;
using OutDoor_Models.Models;

namespace OutDoor_Backend.ExceptionHanlder
{

    public sealed class ExceptionProcessor : IExceptionFilter
    {
        private static readonly string DEFAULT_ERROR_MESSAGE = "Erro interno";
        private static readonly string DEFAULT_ERROR_SOURCE = "Fonte do erro não identificada";

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ModelException)
            {
                CatchModelException(context);
            }
            else if (context.Exception is ServiceException)
            {
                CatchServiceException(context);
            }
            else if (context.Exception is ControllerException)
            {
                CatchControllerException(context);
            }
            else if (context.Exception is RepositoryException)
            {
                CatchRepositoryException(context);
            }
            else
            {
                var errorModel = new ErroModel()
                {
                    Origem = !string.IsNullOrWhiteSpace(context.Exception?.Source) ? context.Exception?.Source : DEFAULT_ERROR_SOURCE,
                    Mensagem = (context.Exception?.Message) ?? DEFAULT_ERROR_MESSAGE
                };

                context.Result = new ObjectResult(errorModel)
                {
                    StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
                };
            }
        }

        private static void CatchModelException(ExceptionContext context)
        {
            var domainExeption = (ModelException)context.Exception;

            var errorModel = new ErroModel()
            {
                Mensagem = domainExeption.Message,
                Origem = !string.IsNullOrWhiteSpace(domainExeption.Source) ? domainExeption.Source : DEFAULT_ERROR_SOURCE
            };

            context.Result = new ObjectResult(errorModel)
            {
                StatusCode = domainExeption.StatusCode.GetHashCode()
            };
        }

        private static void CatchServiceException(ExceptionContext context)
        {
            var reposityException = (ServiceException)context.Exception;

            var errorModel = new ErroModel()
            {
                Mensagem = reposityException.Message,
                Origem = !string.IsNullOrWhiteSpace(reposityException.Source) ? reposityException.Source : DEFAULT_ERROR_SOURCE
            };

            context.Result = new ObjectResult(errorModel)
            {
                StatusCode = reposityException.StatusCode.GetHashCode()
            };
        }

        private static void CatchControllerException(ExceptionContext context)
        {
            var excecaoAplicacao = (ControllerException)context.Exception;

            var errorModel = new ErroModel()
            {
                Mensagem = excecaoAplicacao.Message,
                Origem = !string.IsNullOrWhiteSpace(excecaoAplicacao.Source) ? excecaoAplicacao.Source : DEFAULT_ERROR_SOURCE
            };

            context.Result = new ObjectResult(errorModel)
            {
                StatusCode = excecaoAplicacao.StatusCode.GetHashCode()
            };
        }

        private static void CatchRepositoryException(ExceptionContext context)
        {
            var excecaoAplicacao = (RepositoryException)context.Exception;

            var errorModel = new ErroModel()
            {
                Mensagem = excecaoAplicacao.Message,
                Origem = !string.IsNullOrWhiteSpace(excecaoAplicacao.Source) ? excecaoAplicacao.Source : DEFAULT_ERROR_SOURCE
            };

            context.Result = new ObjectResult(errorModel)
            {
                StatusCode = excecaoAplicacao.StatusCode.GetHashCode()
            };
        }
    }
}