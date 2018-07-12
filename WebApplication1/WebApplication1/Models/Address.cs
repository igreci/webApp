namespace WebApplication1.Models
{
    public class Address : IAddress
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}