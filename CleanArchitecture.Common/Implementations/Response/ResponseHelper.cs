
using CleanArchitecture.Common.Interfaces.Responses;

namespace CleanArchitecture.Common.Implementations.Response;
public static class ResponseHelper<T>
{
    public static IResponse<T> Failed(IError[] errors)
    {
        var response = new Response<T>();
        response.errors = errors;

        return response;
    }
    public static IResponse<T> Failed(IError error)
    {
        var response = new Response<T>();
        response.errors = new IError[] {error};

        return response;
    }
    public static IResponse<T> Failed(IError error,string message)
    {
        var response = new Response<T>();
        response.errors = new IError[] { error };
        response.message = message;

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
