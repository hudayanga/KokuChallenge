using System;
namespace KokuBackend_L1.Business
{
    public class RateL3
    {
        public int Id { get; set; }
        public string Partner { get; set; }
        public int Supply { get; set; }
        public decimal Rate { get; set; }
        public decimal EffectiveRate { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal TakenQuantity { get; set; }
    }
}
