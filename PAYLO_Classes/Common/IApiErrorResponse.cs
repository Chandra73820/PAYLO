using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Common
{
    public interface IApiErrorResponse
    {
        void SetErrorMessage(string message);
    }
}
