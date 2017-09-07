using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaafiMobile.Core.Model;

namespace SaafiMobile.Core.Contracts.Repository
{
    public interface ISavedRemittanceRepository
    {
        Task<IEnumerable<SavedRemittance>> GetSavedRemittanceForUser(int userId);

        Task AddSavedRemittance(int userId, int remittanceId, int beneficiaryId);
    }
}
