using System;

namespace SaafiMobile.Core.Model
{
    public class Remittance : BaseModel
    {
        public int RemittanceId { get; set; }

        public int FromCityId { get; set; }

        public int ToCityId { get; set; }

        public City FromCity { get; set; }

        public City ToCity { get; set; }

        public DateTime RemittanceDate { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public double Amount { get; set; }

        public string Platform { get; set; }
    }
}