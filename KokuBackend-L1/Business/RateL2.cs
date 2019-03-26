using System;
namespace KokuBackend.Business
{
    public class RateL2
    {
        public int Id { get; set; }
        public string Partner { get; set; }
        public int Supply { get; set; }
        public decimal ForexRate { get; set; }
    }
}
