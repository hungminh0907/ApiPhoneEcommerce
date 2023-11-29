namespace ApiPhoneEcommerce.Models.Entity
{
    public class OutProduct
    {
        public string? UrlImage { get; set; }
        public int Position { get; set; } = 1;
        public OutputImage()
        {
            UrlImage = null;
            Position = 1;
        }
    }
}
