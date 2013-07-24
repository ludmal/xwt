#region License
/*
 **************************************************************
 *  Author: Ludmal de silva
 *          © XWT Solutions, 2010
 *          http://www.infonexsolutions.com/
 * 
 * Created: 12/11/2009
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 **************************************************************  
*/
#endregion

using System;
using System.Web;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;


namespace XWT {
    public class ImageManager {
        private const int MaxFullImageSize = 450;

        private const int FixedMediumImageHeight = 400;
        private const int FixedMediumImageWidth = 320;

        private const int FixedSmallImageHeight = 42;
        private const int FixedSmallImageWidth = 56;

        public static byte[] imageToByteArray(System.Drawing.Image imageIn) {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn) {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static void ResizeImageFile(PhotoSize size, string fromFile, string toFile) {
            using (System.Drawing.Image original = System.Drawing.Image.FromFile(fromFile)) {
                int targetH, targetW;
                if (size == PhotoSize.Small || size == PhotoSize.Medium) {
                    // regardless of orientation,
                    // the *height* is constant for thumbnail images (UI constraint)

                    if (original.Height > original.Width) {
                        if (size == PhotoSize.Small)
                            targetH = FixedSmallImageHeight;
                        else
                            targetH = FixedMediumImageHeight;

                        targetW = (int)(original.Width * ((float)targetH / (float)original.Height));
                    } else {
                        if (size == PhotoSize.Small)
                            targetW = FixedSmallImageWidth;
                        else
                            targetW = FixedMediumImageWidth;

                        targetH = (int)(original.Height * ((float)targetW / (float)original.Width));
                    }
                } else {
                    // for full preview, we scale proportionally according to orienation
                    if (original.Height > original.Width) {
                        targetH = Math.Min(original.Height, MaxFullImageSize);
                        targetW = (int)(original.Width * ((float)targetH / (float)original.Height));
                    } else {
                        targetW = Math.Min(original.Width, MaxFullImageSize);
                        targetH = (int)(original.Height * ((float)targetW / (float)original.Width));
                    }
                }

                using (System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(fromFile)) {
                    // Create a new blank canvas.  The resized image will be drawn on this canvas.
                    using (Bitmap bmPhoto = new Bitmap(targetW, targetH, PixelFormat.Format24bppRgb)) {
                        bmPhoto.SetResolution(72, 72);

                        using (Graphics grPhoto = Graphics.FromImage(bmPhoto)) {
                            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
                            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, targetW, targetH), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel);

                            bmPhoto.Save(toFile, System.Drawing.Imaging.ImageFormat.Gif);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// A quick lookup for getting image encoders
        /// </summary>
        private static Dictionary<string, ImageCodecInfo> encoders = null;

        /// <summary>
        /// A quick lookup for getting image encoders
        /// </summary>
        public static Dictionary<string, ImageCodecInfo> Encoders {
            //get accessor that creates the dictionary on demand
            get {
                //if the quick lookup isn't initialised, initialise it
                if (encoders == null) {
                    encoders = new Dictionary<string, ImageCodecInfo>();
                }

                //if there are no codecs, try loading them
                if (encoders.Count == 0) {
                    //get all the codecs
                    foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders()) {
                        //add each codec to the quick lookup
                        encoders.Add(codec.MimeType.ToLower(), codec);
                    }
                }

                //return the lookup
                return encoders;
            }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static System.Drawing.Bitmap ResizeImage(System.Drawing.Image image, int width, int height) {
            //a holder for the result
            Bitmap result = new Bitmap(width, height);

            //use a graphics object to draw the resized image into the bitmap
            using (Graphics graphics = Graphics.FromImage(result)) {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //draw the image into the target bitmap
                graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            }

            //return the resulting bitmap
            return result;
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path">Path to which the image would be saved.</param> 
        /// <param name="quality">An integer from 0 to 100, with 100 being the 
        /// highest quality</param> 
        /// <exception cref="ArgumentOutOfRangeException">
        /// An invalid value was entered for image quality.
        /// </exception>
        public static void SaveJpeg(string path, Image image, int quality) {
            //ensure the quality is within the correct range
            if ((quality < 0) || (quality > 100)) {
                //create the error message
                string error = string.Format("Jpeg image quality must be between 0 and 100, with 100 being the highest quality.  A value of {0} was specified.", quality);
                //throw a helpful exception
                throw new ArgumentOutOfRangeException(error);
            }

            //create an encoder parameter for the image quality
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            //get the jpeg codec
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            //create a collection of all parameters that we will pass to the encoder
            EncoderParameters encoderParams = new EncoderParameters(1);
            //set the quality parameter for the codec
            encoderParams.Param[0] = qualityParam;
            //save the image using the codec and the parameters
            image.Save(path, jpegCodec, encoderParams);
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        public static ImageCodecInfo GetEncoderInfo(string mimeType) {
            //do a case insensitive search for the mime type
            string lookupKey = mimeType.ToLower();

            //the codec to return, default to null
            ImageCodecInfo foundCodec = null;

            //if we have the encoder, get it to return
            if (Encoders.ContainsKey(lookupKey)) {
                //pull the codec from the lookup
                foundCodec = Encoders[lookupKey];
            }

            return foundCodec;
        }
    }

}
