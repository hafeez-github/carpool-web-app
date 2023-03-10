using System;
using Carpool.Utilities.Interfaces;

namespace Carpool.Utilities
{
	public class ApiResponse<T> : IApiResponse<T>
	{
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(int statusCode, string status, bool isSuccess)
        {
            this.StatusCode = statusCode;
            this.Status = status;
            this.IsSuccess = isSuccess;
        }
    }
}

