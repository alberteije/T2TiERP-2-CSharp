using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using WIA;
using System.IO;
using System.Security.Permissions;

namespace GEDClient.Services
{
    public class ScannerImageConverter
    {
        public string fileName { get; set; }
        public void ConvertScannedImage(ImageFile imageFile)
        {
            fileName = Path.GetTempPath() + "scanner.jpg";

            File.Delete(fileName);
            imageFile.SaveFile(fileName);
        }

        public BitmapSource InMemoryConvertScannedImage(ImageFile imageFile)
        {
            if (imageFile == null)
                return null;

            Vector vector = imageFile.FileData;

            if (vector != null)
            {
                byte[] bytes = vector.get_BinaryData() as byte[];

                if (bytes != null)
                {
                    var ms = new MemoryStream(bytes);
                    return BitmapFrame.Create(ms);
                }
            }

            return null;
        }

    }
}
