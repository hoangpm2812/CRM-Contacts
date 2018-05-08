using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Contacts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Contacts.Controllers
{
    
    public class BaseController : Controller
    {
        protected ObjectResult Ok(object data = null, string message = "Ok")
        {
            return StatusCode(200, GetResultModel(data, message));
        }

        //protected ObjectResult OkPagination(object data, int numberOfPages = 1)
        //{
        //    return Ok(new STResponseModel
        //    {
        //        Data = data,
        //        NumberOfPages = numberOfPages
        //    });
        //}

        protected ObjectResult BadRequest(string message = "Bad Request", object data = null)
        {
            return StatusCode(400, GetResultModel(data, message));
        }

        protected ObjectResult Unauthorized(string message = "Unauthorized", object data = null)
        {
            return StatusCode(401, GetResultModel(data, message));
        }

        protected ObjectResult Forbidden(string message = "Forbidden", object data = null)
        {
            return StatusCode(403, GetResultModel(data, message));
        }

        protected ObjectResult NotFound(string message = "Not Found", object data = null)
        {
            return StatusCode(404, GetResultModel(data, message));
        }

        protected ObjectResult InternalServerError(string message = "Internal Server Error", object data = null)
        {
            return StatusCode(500, GetResultModel(data, message));
        }

        protected ObjectResult NotImplemented(string message = "Not Implemented", object data = null)
        {
            return StatusCode(501, GetResultModel(data, message));
        }

        private ResultModel GetResultModel(object data, string message)
        {
            return new ResultModel
            {
                Message = message,
                Data = data
            };
        }
    }
}