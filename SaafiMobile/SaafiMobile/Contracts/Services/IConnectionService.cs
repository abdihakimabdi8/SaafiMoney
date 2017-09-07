using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaafiMobile.Core.Contracts.Services
{
    public interface IConnectionService
    {
        bool CheckOnline();
    }
}
