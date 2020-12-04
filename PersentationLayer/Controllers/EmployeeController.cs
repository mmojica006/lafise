using System;
using System.Web.Mvc;
using PersentationLayer.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace PersentationLayer.Controllers
{
    public class EmployeeController : Controller
    {

        private RestClient restClient = new RestClient();
        // GET: Employee
        public ActionResult EmployeeDetails()
        {
            return this.View();
        }
        public async Task<ActionResult> EmpInfoData()
        {
            try
            {

                return this.Json(await this.restClient.RunAsyncGetAll<Employee, Employee>("api/Employee/EmpDetails"), JsonRequestBehavior.AllowGet);
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

        public async Task<ActionResult> EmployeeInsertData(Employee objEmp)
        {
            try
            {
                return this.Json(await this.restClient.RunAsyncPost<Employee, string>("api/ConfigSetting/InsertConfigSetting", objEmp));
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

        public async Task<ActionResult> InsertEmployeeInfo(Employee objEmp)
        {
            try
            {
                return this.Json(await this.restClient.RunAsyncPost<Employee, string>("api/Employee/InsertEmpDetails", objEmp));
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
        public async Task<ActionResult> UpdateEmployeeInfo(Employee objEmp)
        {
            try
            {
                return this.Json(await this.restClient.RunAsyncPut<Employee, string>("api/Employee/UpdateEmpDetails", objEmp));
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


        public async Task<ActionResult> DeleteEmployeeInfo(int id)
        {
            try
            {
                return this.Json(await this.restClient.RunAsyncDelete<int, string>("api/Employee/DeleteEmpData", id));
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