namespace LMS.BlazorApp.Dtos
{
    public class ChangesDto
    {
        public int CustomerId { get; set; }
        public int GroupId { get; set; }
        public int LicenseId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int GPChangeQuantity { get; set; }
        public int PPChangeQuantity { get; set; }
    }
}
