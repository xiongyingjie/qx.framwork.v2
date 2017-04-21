using QRCoder;
using System.Drawing;

namespace Qx.Tools
{
    public class QRCoderUtility
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="content">二维码内容</param>
        /// <param name="savePath">保存路径</param>
        /// <returns></returns>
        public static Bitmap CreateQrCode(string content, string savePath)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save(savePath);
            return qrCodeImage;
        }
    }
}