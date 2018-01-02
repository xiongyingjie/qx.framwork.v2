

namespace Qx.Contents.Interfaces
{
    public interface IWebSiteService
    {
        MvcHtmlString GetColumnTemplete(string key);
        MvcHtmlString GetTemplete(string id);
        JsonResult GetSigleColumnDesign(string id);
        JsonResult GetMultipleColumnDesign(string id);

        /// <summary>
        /// ��ȡCSS/JS�ļ�
        /// </summary>
        /// <returns></returns>
        JsonResult GetLibrarys();
    }
}