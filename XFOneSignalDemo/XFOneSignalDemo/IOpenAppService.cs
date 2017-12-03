using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFOneSignalDemo
{
    public interface IOpenAppService
    {
        Task<bool> Launch(string uri);
    }
}
