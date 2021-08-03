using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.CRMDAL
{
    public static class StringExtensions
    {
        public static string GetStoredProcedureName(this string fullName) =>
            fullName.Substring(0, fullName.LastIndexOf("Async"));
    }
}
