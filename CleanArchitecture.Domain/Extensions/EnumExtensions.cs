using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value, params string[] values)
        {
            var description = String.Empty;

            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute?)Attribute.GetCustomAttribute(field!, typeof(DescriptionAttribute));

            description = attribute is not null && !string.IsNullOrWhiteSpace(attribute.Description) ? attribute.Description : String.Empty;

            description = string.Format(description, values);
            return description;
        }
    }
}
