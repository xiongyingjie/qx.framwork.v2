using System;
using System.DrawingCore;
using System.IO;
using QRCoder;

namespace xyj.core.Utility
{
    public static class QRCoderUtility
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="content">二维码内容</param>
        /// <param name="savePath">保存路径</param>
        /// <returns></returns>
        public static Bitmap CreateQrCode(string content)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
          
            return qrCodeImage;
        }
        public static byte[] BitmapToBytes(this Bitmap Bitmap)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                Bitmap.Save(ms, Bitmap.RawFormat);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }
    }

}