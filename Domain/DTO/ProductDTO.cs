namespace VulcanoTest.DTO
{
    public class ProductDTO
    {
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public decimal price { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
    }
}