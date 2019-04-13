using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

namespace GEDClient.Services
{
    public class ScannerException : ApplicationException
    {
        public ScannerException()
            : base()
        { }

        public ScannerException(string message)
            : base(message)
        { }

        public ScannerException(string message, Exception innerException)
            : base(message, innerException)
        { }

    }

    public class ScannerNotFoundException : ScannerException
    {
        public ScannerNotFoundException()
            : base("Error retrieving a list of scanners. Is your scanner or multi-function printer turned on?")
        {
        }
    }

    public class ScannerService
    {
        public ImageFile Scan()
        {
            ImageFile image;
            
            try
            {
                CommonDialog dialog = new CommonDialog();
                image = dialog.ShowAcquireImage(
                        WiaDeviceType.ScannerDeviceType,
                        WiaImageIntent.ColorIntent,
                        WiaImageBias.MaximizeQuality,
                        WIA.FormatID.wiaFormatJPEG,
                        false,
                        true,
                        false);


                return image;
            }
            catch (COMException ex)
            {
                if (ex.ErrorCode == -2145320939)
                {
                    throw new ScannerNotFoundException();
                }
                else
                {
                    throw new ScannerException("COM Exception", ex);
                }
            }
        }

    }
}
