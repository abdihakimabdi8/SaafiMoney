using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaafiMobile.Core.Contracts.Repository;
using SaafiMobile.Core.Contracts.Services;
using SaafiMobile.Core.Model;

namespace SaafiMobile.Core.Services.Data
{
    public class RemittanceDataService : IRemittanceDataService
    {
        private readonly IRemittanceRepository _remittanceRepository;
        private readonly ICityRepository _cityRepository;


        public RemittanceDataService(IRemittanceRepository remittanceRepository,
            ICityRepository cityRepository)
        {
            _remittanceRepository = remittanceRepository;
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<Remittance>> SearchRemittance(int fromCity, int toCity, DateTime remittanceDate, DateTime departureTime)
        {
            var remittances = await _remittanceRepository.SearchRemittance(fromCity, toCity, remittanceDate, departureTime);
            foreach (var remittance in remittances)
            {
                remittance.FromCity = await _cityRepository.GetCityById(remittance.FromCityId);
                remittance.ToCity = await _cityRepository.GetCityById(remittance.ToCityId);
            }
            return remittances;
        }

        public async Task<Remittance> GetRemittanceDetails(int remittanceId)
        {
            return await _remittanceRepository.GetRemittanceDetails(remittanceId);
        }
    }
}