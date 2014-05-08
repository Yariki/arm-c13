namespace ARM.Data.Models
{
    public class Rate : BaseNamedModel
    {
        public decimal RateMin { get; set; }

        public decimal RateMax { get; set; }

        public decimal Mark { get; set; }

    }
}