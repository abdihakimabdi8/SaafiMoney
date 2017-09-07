using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaafiMobile.Core.Contracts.Repository;
using SaafiMobile.Core.Model;

namespace SaafiMobile.Core.Repositories
{
    public class RemittanceRepository : BaseRepository, IRemittanceRepository
    {

        private static readonly List<Remittance> AllRemittances = new List<Remittance>()
        {
            new Remittance
            {
                RemittanceId = 1,
                FromCityId = 1,
                ToCityId  = 2,
                DepartureTime = DateTime.Now.AddHours(1),
                ArrivalTime = DateTime.Now.AddHours(2),
                RemittanceDate = DateTime.Now,
                Platform = "12",
                Amount = 50
            },
            new Remittance
            {
                RemittanceId = 2,
                FromCityId = 2,
                ToCityId = 1,
                DepartureTime = DateTime.Now.AddHours(2),
                ArrivalTime = DateTime.Now.AddHours(3),
                RemittanceDate = DateTime.Now,
                Platform = "6",
                Amount = 100
            },
            new Remittance
            {
                RemittanceId = 3,
                FromCityId = 1,
                ToCityId = 2,
                DepartureTime = DateTime.Now.AddHours(4),
                ArrivalTime = DateTime.Now.AddHours(5),
                RemittanceDate = DateTime.Now,
                Platform = "6",
                Amount = 100
            },

            new Remittance
            {
                RemittanceId = 4,
                FromCityId = 1,
                ToCityId = 2,
                DepartureTime = DateTime.Now.AddHours(6),
                ArrivalTime = DateTime.Now.AddHours(7),
                RemittanceDate = DateTime.Now,
                Platform = "6",
                Amount = 100
            }
        };

        public async Task<IEnumerable<Remittance>> SearchRemittance(int fromCity, int toCity, DateTime remittanceDate, DateTime departureTime)
        {
            return await Task.FromResult(AllRemittances.Where(c => c.FromCityId == fromCity && c.ToCityId == toCity)); //For demo purposes, the search doesn't mind the date and hour
        }

        public async Task<Remittance> GetRemittanceDetails(int remittanceId)
        {
            return await Task.FromResult(AllRemittances.FirstOrDefault(j => j.RemittanceId == remittanceId));
        }
    }
}