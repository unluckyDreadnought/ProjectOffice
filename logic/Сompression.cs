using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using ProjectOffice;

namespace ProjectOffice.logic
{
    public static class Сompressor
    {
        public static string HumanReadableSizeLite(long size)
        {
            string[] prefix = new string[] { "", "K", "M", "G", "T", "P" };
            double mutableSize = size;
            int indx = 0;
            while (mutableSize > 1000)
            {
                mutableSize /= 1024;
                indx++;
            }

            return $"{mutableSize} {prefix[indx]}B";
        }

        public static byte[] CompressBytes(byte[] input)
        {
            MemoryStream output = new MemoryStream();
            using (var compressStream = new DeflateStream(output, CompressionMode.Compress))
            {
                compressStream.Write(input, 0, input.Length);
            }
            return output.ToArray();
        }

        public static byte[] DecompressBytes(byte[] compressedInput)
        {
            MemoryStream input = new MemoryStream(compressedInput);
            MemoryStream output = new MemoryStream();
            using (var decompressStream = new DeflateStream(input, CompressionMode.Decompress))
            {
                decompressStream.CopyTo(output);
            }
            return output.ToArray();
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.SmoothingMode = SmoothingMode.HighSpeed;
                graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        public static byte[] GetThumbnail(string srcPath, int quality)
        {
            var FileName = Path.GetFileName(srcPath);
            using (Bitmap bmp1 = new Bitmap(srcPath))
            {
                // check extension
                ImageCodecInfo jpgEncoder = GetEncoder(GetImageFormat(Path.GetExtension(srcPath)));  // ImageFormat.Jpeg
                System.Drawing.Imaging.Encoder QualityEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(QualityEncoder, quality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                using (var ms = new MemoryStream())
                {
                    bmp1.Save(ms, jpgEncoder, myEncoderParameters);
                    return ms.ToArray();
                }
            }
        }

        public static byte[] GetThumbnail(Bitmap virtualImage, int quality)
        {
            using (Bitmap bmp1 = virtualImage)
            {
                // check extension
                ImageCodecInfo jpgEncoder = GetEncoder(GetImageFormat("mb"));  // ImageFormat.Jpeg
                System.Drawing.Imaging.Encoder QualityEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(QualityEncoder, quality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                using (var ms = new MemoryStream())
                {
                    bmp1.Save(ms, jpgEncoder, myEncoderParameters);
                    return ms.ToArray();
                }
            }
        }

        private static ImageFormat GetImageFormat(string extension)
        {
            ImageFormat format = null;
            switch (extension.ToLower())
            {
                case ".jpg":
                case ".jpeg": format = ImageFormat.Jpeg; break;
                case ".png": format = ImageFormat.Png; break;
                case "mb":
                case ".bmp": format = ImageFormat.Bmp; break;
                case ".tiff": format = ImageFormat.Tiff; break;
                case ".gif": format = ImageFormat.Gif; break;
                case ".ico": format = ImageFormat.Icon; break;
            }
            return format;
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        /// <summary>
        /// Пережимает входное изображение по пути <see cref="srcPath"/> <br></br>
        /// и возвращает сжатое изображение до 65 КБ в виде массива байт
        /// </summary>
        /// <param name="srcPath">Путь к входному изображению</param>
        /// <returns>Массив байт до 65 КБ выходного изображения</returns>
        public static byte[] CompressImageToBytes(string srcPath)
        {
            MemoryStream imageMemoryStream = new MemoryStream();
            using (var file = File.Open(srcPath, FileMode.Open))
            {
                file.CopyTo(imageMemoryStream);
            }
            byte[] thumb = Сompressor.GetThumbnail(srcPath, Convert.ToInt32(Math.Abs(Math.Sin(Math.Cos((double)imageMemoryStream.Length / 65535))) * 100));
            byte[] final = Сompressor.CompressBytes(thumb);
            MemoryStream tmp = null;
            int n = 0;
            while (final.Length > 65535)
            {
                n++;
                tmp = new MemoryStream(thumb);
                Bitmap bmp = new Bitmap(tmp);
                bmp = Сompressor.ResizeImage(bmp, bmp.Width / n, bmp.Height / n);
                thumb = Сompressor.GetThumbnail(bmp, 0);
                final = Сompressor.CompressBytes(thumb);
                tmp.Close();
            }
            imageMemoryStream = new MemoryStream(Сompressor.DecompressBytes(final));
            byte[] bytes = imageMemoryStream.ToArray();
            imageMemoryStream.Close();
            return bytes;
        }
        
    }
}
