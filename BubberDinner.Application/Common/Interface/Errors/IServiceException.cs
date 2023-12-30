using System.Net;

namespace BubberDinner.Application.Common.Interface.Errors;



public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}