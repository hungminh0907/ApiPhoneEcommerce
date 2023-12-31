﻿namespace DemoApi.Common
{
    public class UploadFiles
    {
        private static string wwwroot = Directory.GetCurrentDirectory() + "\\wwwroot";
        public static string SaveImage(IFormFile img)
        {
            if (img != null && img.Length > 0)
            {
                string urlPath = "";
                string id = Guid.NewGuid().ToString();

                string filePath = Path.Combine(wwwroot, "img", id + "-" + img.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                    urlPath = Path.Combine("\\img", id + "-" + img.FileName);
                }
                return  urlPath;
            }
            return null;
        }

        public static bool RemoveImage(string url)
        {
            string filePath = wwwroot + url;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

        internal static string? SaveImage(string? urlimg)
        {
            throw new NotImplementedException();
        }

        internal static string SaveImage(char img)
        {
            throw new NotImplementedException();
        }
    }
}
