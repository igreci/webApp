namespace WebApplication1.Models
{
    public interface IAddress
    {
        string City { get; set; }
        string Street { get; set; }
        string Suite { get; set; }
        string ZipCode { get; set; }
    }
}