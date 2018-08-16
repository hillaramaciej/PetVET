﻿using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;


namespace System.Web.Http.ApiMessage
{
    public class ErrorResult : IHttpActionResult
    {
        Error _error;
        HttpRequestMessage _request;

        public ErrorResult(Error error, HttpRequestMessage request)
        {
            _error = error;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new ObjectContent<Error>(_error, new JsonMediaTypeFormatter()),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
}

public class Error
{
    public string Code { get; set; }
    public string Message { get; set; }
}