using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaafiMobile.Core.Model;

namespace SaafiMobile.Core.Contracts.Repository
{
    public interface IRemittanceRepository
    {
        Task<IEnumerable<Remittance>> SearchRemittance(int fromCity, int toCity, DateTime remittanceDate, DateTime departureTime);

        Task<Remittance> GetRemittanceDetails(int remittanceId);
        //Task SearchRemittance(int fromCity, int toCity, DateTime remittanceDate, DateTime departureTime);
    }
}
