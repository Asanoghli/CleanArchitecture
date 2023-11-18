using CleanArchitecture.Application.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Implementations.Response;

public class Response<T> : IResponse<T>
{
    public bool isSuccess { get; set; } = false;
    public string message { get; set; }
    public T data { get; set; }
    public IEnumerable<IError> errors { get; set; }
}
