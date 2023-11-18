using CleanArchitecture.Application.Interfaces.Responses;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Infrastructure.Implementations.Response;

public static class ResponseHelper<T>
{
    public static IResponse<T> Failed(IEnumerable<IError> errors)
    {
        var response = new Response<T>();
        response.errors = errors;

        return response;
    }
    public static IResponse<T> Failed(IError[] errors,string message)
    {
        var response = new Response<T>();
        response.errors = errors;
        response.message = message;

        return response;
    }

    public static IResponse<T> Success(T data)
    {
        var response = new Response<T>();
        response.isSuccess = true;
        response.data = data;

        return response;
    }
    public static IResponse<T> Success(T data,string message)
    {
        var response = new Response<T>();
        response.isSuccess = true;
        response.data = data;
        response.message = message;

        return response;
    }
}
