using SixLabors.ImageSharp;
using System;
using System.IO;

namespace Kab.DemirAjans.Business.Helper.ImageHelper;

public static class ImageHelper
{
    public static Guid SaveImage(string base64, ImageEnum imageEnum)
    {
        try
        {
            byte[] imageBytes = Convert.FromBase64String(base64);
            using Image image = Image.Load(imageBytes);
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;

            var guid = Guid.NewGuid();
            if (imageEnum.Equals(ImageEnum.Category))
            {
                var path = Path.Combine(projectPath, "Categories");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                image.Save(Path.Combine(path, guid.ToString() + ".jpg"));
                return guid;
            }
            else if (imageEnum.Equals(ImageEnum.Product))
            {
                var path = Path.Combine(projectPath, "Products");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                image.Save(Path.Combine(path, guid.ToString() + ".jpg"));
                return guid;
            }
            else throw new Exception("asd");
        }
        catch (FormatException ex)
        {
            throw new FormatException("Invalid Base64 string: " + ex.Message);
        }
        catch (UnknownImageFormatException ex)
        {
            throw new UnknownImageFormatException("Unsupported image format: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception("Bilinmeyen bir hata oluştu." + ex.Message);
        }
    }
}