using System.Collections.Generic;
using System.Threading.Tasks;
using SaafiMobile.Core.Contracts.Repository;
using SaafiMobile.Core.Contracts.Services;
using SaafiMobile.Core.Model;

namespace SaafiMobile.Core.Services.Data
{
    public class SavedRemittanceDataService : ISavedRemittanceDataService
    {
        private readonly ISavedRemittanceRepository _savedRemittanceRepository;
        private readonly IRemittanceDataService _remittanceDataService;
        private readonly ICityDataService _cityDataService;

        public SavedRemittanceDataService(ISavedRemittanceRepository savedRemittanceRepository, IRemittanceDataService remittanceDataService, ICityDataService cityDataService)
        {
            _savedRemittanceRepository = savedRemittanceRepository;
            _remittanceDataService = remittanceDataService;
            _cityDataService = cityDataService;
        }

        public async Task<IEnumerable<SavedRemittance>> GetSavedRemittanceForUser(int userId)
        {

            var list = await _savedRemittanceRepository.GetSavedRemittanceForUser(userId);
            foreach (var savedRemittance in list)
            {
                var remittance = await _remittanceDataService.GetRemittanceDetails(savedRemittance.RemittanceId);
                remittance.FromCity = await _cityDataService.GetCityById(remittance.FromCityId);
                remittance.ToCity = await _cityDataService.GetCityById(remittance.ToCityId);

                savedRemittance.Remittance = remittance;
                savedRemittance.RemittanceId = remittance.RemittanceId;
            }

            return list;
        }

        public async Task AddSavedRemittance(int userId, int remittanceId, int beneficiaryId)
        {
            await _savedRemittanceRepository.AddSavedRemittance(userId, remittanceId, beneficiaryId);
        }
    }
}