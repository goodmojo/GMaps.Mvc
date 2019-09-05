namespace GMaps.Mvc.Examples
{
    using System.Web.Mvc;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AutoPopulateSourceCodeAttribute());
        }
    }
}
