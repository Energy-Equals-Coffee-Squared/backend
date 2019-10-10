using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace api.Helpers
{
    public class ErrorResult : ActionResult
    {
        Error _error;

        public ErrorResult(Error error)
        {
            _error = error;
        }

        public Task<HttpResponseMessage> ExecuteAsync()
        {

            List<Error> _errorList = new List<Error>();
            _errorList.Add(_error);

            error err = new error()
            {
                errors = _errorList
            };

            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<error>(err, new JsonMediaTypeFormatter())
            };
            return Task.FromResult(response);
        }
    }

    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class error
    {
        public List<Error> errors { get; set; }
    }
}
