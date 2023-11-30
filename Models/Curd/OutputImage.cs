namespace ApiPhoneEcommerce.Models.Curd
{
    public class OutputImage
    {
        public string? Urlimg { get; set; }
        public int Position { get; set; } = 1;
        public OutputImage()
        {
            Urlimg = null;
            Position = 1;
        }
    }
}
