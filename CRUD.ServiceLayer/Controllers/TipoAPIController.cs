using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUD.BusinessLayer.Implementation;
using CRUD.BusinessLayer.Interfaces;
using CRUD.DataLayer.Entities;


namespace CRUD.ServiceLayer.Controllers
{
    public class TipoAPIController : ApiController
    {
        ITipo objTipo = new Tipo();

        [HttpGet]
        [Route("TipoDetails")]
        public IEnumerable<TipoEmployee> GetTiposData()
        {


            IEnumerable<TipoEmployee> empDetail = new List<TipoEmployee>();
            try
            {
                empDetail = objTipo.TipoGet();
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return empDetail;
        }


        [HttpPost]
        [Route("InsertTipoDetails")]
        public string InserTipo(TipoEmployee paremeter)
        {
            string objAddress;
            try
            {
                objAddress = this.objTipo.TipoInsert(paremeter);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return objAddress;
        }

        [HttpPut]
        [Route("UpdateTipoDetails")]
        public string UpdateTipo(TipoEmployee parameter)
        {
            string objAddress;
            try
            {
                objAddress = this.objTipo.TipoUpdate(parameter);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return objAddress;
        }
        [HttpDelete]
        [Route("DeleteTipoData/{id}")]
        public string DeleteTipoData(int id)
        {
            string objAddress;
            try
            {
                objAddress = this.objTipo.TipoDelete(id);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return objAddress;
        }

    }
}