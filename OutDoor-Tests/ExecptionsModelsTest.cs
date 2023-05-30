using LOG.Plataforma.BFF.WebApi.Filters.FiltroExcecoes;
using OutDoor_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Tests
{
    public class ExecptionsModelsTest
    {
        [Fact]
        public void ServiceExceptionModelTest()
        {
            var ServiceException = new ServiceException("teste")
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            Assert.Equal("teste", ServiceException.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ServiceException.StatusCode);
        }

        [Fact]
        public void ControllerExceptionModelTest()
        {
            var ServiceException = new ControllerException("teste")
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            Assert.Equal("teste", ServiceException.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ServiceException.StatusCode);
        }

        [Fact]
        public void RepositoryExceptionModelTest()
        {
            var ServiceException = new RepositoryException("teste")
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            Assert.Equal("teste", ServiceException.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ServiceException.StatusCode);
        }

        [Fact]
        public void ModelExceptionModelTest()
        {
            var ServiceException = new ModelException("teste")
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            Assert.Equal("teste", ServiceException.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ServiceException.StatusCode);
        }

        [Fact]
        public void ErroModelTest()
        {
            var erroModel = new ErroModel()
            {
                Origem = "origemTest",
                Mensagem = "MsgTest"
            };

            Assert.Equal("origemTest", erroModel.Origem);
            Assert.Equal("MsgTest", erroModel.Mensagem);
        }
    }
}
