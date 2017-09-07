namespace SaafiMobile.Core.Model
{
    public class SavedRemittance : BaseModel
    {
        public int RemittanceId { get; set; }

        public Remittance Remittance { get; set; }

        public int UserId { get; set; }

        public int BeneficiaryId { get; set; }

    }
}