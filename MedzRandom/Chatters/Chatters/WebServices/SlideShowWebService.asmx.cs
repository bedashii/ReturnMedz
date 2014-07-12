using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Chatters.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class SlideShowWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public AjaxControlToolkit.Slide[] GetHomeSlides()
        {
            string[] imagenames = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Home"));
            AjaxControlToolkit.Slide[] photos = new AjaxControlToolkit.Slide[imagenames.Length];
            for (int i = 0; i < imagenames.Length; i++)
            {
                string[] file = imagenames[i].Split('\\');
                photos[i] = new AjaxControlToolkit.Slide("Images/Home/" + file[file.Length - 1], file[file.Length - 1],
                                                         "");
            }
            return photos;
        }

        [WebMethod]
        public AjaxControlToolkit.Slide[] GetAboutUsSlides()
        {
            string[] imagenames = System.IO.Directory.GetFiles(Server.MapPath("~/Images/AboutUs"));
            AjaxControlToolkit.Slide[] photos = new AjaxControlToolkit.Slide[imagenames.Length];
            for (int i = 0; i < imagenames.Length; i++)
            {
                string[] file = imagenames[i].Split('\\');
                photos[i] = new AjaxControlToolkit.Slide("Images/AboutUs/" + file[file.Length - 1], file[file.Length - 1],
                                                         "");
            }
            return photos;
        }
    }
}
