﻿namespace ApiPhoneEcommerce.Models.Curd
{
    public class OutputImage
    {
        public string Urlimg { get; set; } = null;
        public int Position { get; set; } = 1;
    }

    public class ListOutputImage
    {
        public List<OutputImage> Urlimg { get; set; } = new List<OutputImage>();
        public ListOutputImage() 
        {
            Urlimg = new List<OutputImage>();
        }
    }
}
