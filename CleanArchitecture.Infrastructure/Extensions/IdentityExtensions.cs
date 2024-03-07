using CleanArchitecture.Common.Implementations.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Extensions;
public static class IdentityExtensions
{
    public static IEnumerable<Error> GetResponseErrors(this IEnumerable<IdentityError> errors)
    {
        return errors.Select(error => new Error
        {
            errorKey = error.Code,
            errorMessage = error.Description
        });
    }
    public static IEnumerable<Error> GetResponseErrors(this ModelStateDictionary errors)
    {
        return errors.SelectMany(error => error.Value!.Errors.Select(childError=>new Error
        {
            errorKey = error.Key,
            errorMessage = childError.ErrorMessage
        }));
    }
}
