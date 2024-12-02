using Kab.DemirAjans.Entities.Categories;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
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
            string projectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            if (!Directory.Exists(projectPath))
                Directory.CreateDirectory(projectPath);

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
            else throw new Exception("Enumaration Not Found!");
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

    public static CategoryGetImageBase64Dto GetImage(Guid imageName, ImageEnum imageEnum)
    {
        try
        {
            string projectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

            if (imageEnum.Equals(ImageEnum.Category))
            {
                var path = Path.Combine(projectPath, "Categories");

                using var image = Image.Load(Path.Combine(path, imageName + ".jpg"));
                using var memoryStream = new MemoryStream();

                image.Save(memoryStream, new JpegEncoder());
                memoryStream.Seek(0, SeekOrigin.Begin);

                var base64String = Convert.ToBase64String(memoryStream.ToArray());
                return new CategoryGetImageBase64Dto { ImageName = imageName, Base64 = base64String };
            }
            //else if (imageEnum.Equals(ImageEnum.Product))
            //{
            //    var path = Path.Combine(projectPath, "Products");

            //    using var image = Image.Load(Path.Combine(path, imageName + ".jpg"));
            //    using var memoryStream = new MemoryStream();

            //    image.Save(memoryStream, new JpegEncoder());
            //    memoryStream.Seek(0, SeekOrigin.Begin);

            //    var base64String = Convert.ToBase64String(memoryStream.ToArray());
            //    return base64String;
            //}

            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static void DeleteImage(Guid guid, ImageEnum imageEnum)
    {
        try
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;

            if (imageEnum.Equals(ImageEnum.Category))
            {
                var path = Path.Combine(projectPath, "Categories", guid.ToString() + ".jpg");

                File.Delete(path);
            }
            else if (imageEnum.Equals(ImageEnum.Product))
            {
                var path = Path.Combine(projectPath, "Products", guid.ToString() + ".jpg");

                File.Delete(path);
            }
            else throw new Exception("Enumaration Not Found!");
        }
        catch (Exception ex)
        {
            throw new Exception("Bilinmeyen bir hata oluştu." + ex.Message);
        }
    }
}