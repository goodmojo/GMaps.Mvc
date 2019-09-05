namespace GMaps.Mvc.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class BasicController
    {
        public ActionResult Language(string mapLanguage)
        {
            return this.View((object)(mapLanguage ?? "ru"));
        }
    }
}