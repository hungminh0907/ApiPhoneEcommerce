namespace ApiPhoneEcommerce.Models.Curd
{
    public class OutputImage
    {
        public string Urlimg { get; set; } = null;
        public int Position { get; set; } = 1;
    }

    public class ListOutputImage
    {
        public List<OutputImage> Images { get; set; } = new List<OutputImage>();
        public ListOutputImage() 
        {
            Images = new List<OutputImage>();
        }
    }
}
