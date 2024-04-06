using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contracts.Auth.Responses
{
    public class AdminAuthLoginResponse
    {
        public string token { get; set; }
        public DateTime validTo { get; set; }
    }
}
