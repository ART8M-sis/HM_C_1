namespace D_ASP_1.Models
{
    public class InsuranceViewModel
    {
        public int EngineCapacity { get; set; }
        public string CityType { get; set; }
        public int DriverExperienceYears { get; set; }
        public bool HasDiscountCategory { get; set; }

        public decimal CalculatedPrice { get; set; }
        public string? ErrorMessage { get; set; }

    }
}
