using System;
namespace Carpool.API.Contracts
{
	public class IApiResponse<T>
	{
		public IApiResponse()
		{
		}

        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}

