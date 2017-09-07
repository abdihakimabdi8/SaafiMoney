using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaafiMobile.Core.Contracts.Repository;
using SaafiMobile.Core.Model;

namespace SaafiMobile.Core.Repositories
{
    public class SavedRemittanceRepository : BaseRepository, ISavedRemittanceRepository
    {

        private static readonly List<SavedRemittance> AllSavedRemittances = new List<SavedRemittance>
        {
            new SavedRemittance {RemittanceId = 1, BeneficiaryId = 3, UserId = 1},
            new SavedRemittance {RemittanceId = 2, BeneficiaryId = 2, UserId = 1},
            new SavedRemittance {RemittanceId = 3, BeneficiaryId = 3, UserId = 1},
            new SavedRemittance {RemittanceId = 4, BeneficiaryId = 2, UserId = 1},
            new SavedRemittance {RemittanceId = 1, BeneficiaryId = 3, UserId = 2},
            new SavedRemittance {RemittanceId = 2, BeneficiaryId = 3, UserId = 2}
        };

        public async Task<IEnumerable<SavedRemittance>> GetSavedRemittanceForUser(int userId)
        {
            return await Task.FromResult(AllSavedRemittances.Where(j => j.UserId == userId));
        }

        public async Task AddSavedRemittance(int userId, int remittanceId, int beneficiaryId)
        {
            await
                Task.Run(
                    () =>
                        AllSavedRemittances.Add(new SavedRemittance
                        {
                            RemittanceId = remittanceId,
                            BeneficiaryId = beneficiaryId,
                            UserId = userId
                        }));
        }

    }
}