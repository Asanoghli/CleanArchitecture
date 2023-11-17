using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Common.Enums
{
    public enum ReturnTypes
    {
        [Description("Email {0} Already Exists")]
        EmailAlreadyExists = 1000,
        [Description("Email {0} Already Exists {1}")]
        EmailAlreadyExists2 = 1001,

    }
}
