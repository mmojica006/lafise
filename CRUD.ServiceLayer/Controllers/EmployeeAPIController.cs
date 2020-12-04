using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUD.DataLayer.Entities;
using CRUD.BusinessLayer.Implementation;
using CRUD.BusinessLayer.Interfaces;

namespace CRUD.ServiceLayer.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeAPIController : ApiController
    {

        IEmployee objEmp = new Employee();

        [HttpGet]
        [Route("EmpDetails")]
        public IEnumerable<EmployeeInfo> GetEmployeeData()
        {
          

            IEnumerable<EmployeeInfo> empDetail = new List<EmployeeInfo>();
            try
            {
                empDetail = objEmp.EmployeeGet();
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
        [Route("InsertEmpDetails")]
        public string InserEmployee(EmployeeInfo objEmpDetails)
        {
            string objEmployee;
            try
            {
                objEmployee = this.objEmp.EmployeeInsert(objEmpDetails);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return objEmployee;
        }

        [HttpPut]
        [Route("UpdateEmpDetails")]
        public string UpdateEmployee(EmployeeInfo objEmpDetails)
        {
            string objEmployee;
            try
            {
                objEmployee = this.objEmp.EmployeeUpdate(objEmpDetails);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return objEmployee;
        }
        [HttpDelete]
        [Route("DeleteEmpData/{id}")]
        public string DeleteEmployeeData(int id)
        {
            string objEmpDetails;
            try
            {
                objEmpDetails = this.objEmp.EmployeeDelete(id);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return objEmpDetails;
        }
    }
}
