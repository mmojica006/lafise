using System;
using System.Web.Mvc;
using PersentationLayer.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace PersentationLayer.Controllers
{
    public class TipoController : Controller
    {

        private RestClient restClient = new RestClient();
        // GET: Address
        public ActionResult TipoDetails()
        {
            return this.View();
        }
        public async Task<ActionResult> TipoInfoData()
        {
            try
            {

                return this.Json(await this.restClient.RunAsyncGetAll<TipoViewModel, TipoViewModel>("api/Tipo/TipoDetails"), JsonRequestBehavior.AllowGet);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }

        public async Task<ActionResult> TipoInsertData(TipoViewModel parameter)
        {
            try
            {
                return this.Json(await this.restClient.RunAsyncPost<TipoViewModel, string>("api/ConfigSetting/InsertConfigSetting", parameter));
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }

        public async Task<ActionResult> InsertTipo(TipoViewModel parameter)
        {
            try
            {
                return this.Json(await this.restClient.RunAsyncPost<TipoViewModel, string>("api/Tipo/InsertAddDetails", parameter));
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }
        public async Task<ActionResult> UpdateTipo(TipoViewModel parameter)
        {
            try
            {
                return this.Json(await this.restClient.RunAsyncPut<TipoViewModel, string>("api/Tipo/UpdateAddDetails", parameter));
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }


        public async Task<ActionResult> DeleteTipo(int id)
        {
            try
            {
                return this.Json(await this.restClient.RunAsyncDelete<int, string>("api/Tipo/DeleteAddData", id));
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }

    }
}