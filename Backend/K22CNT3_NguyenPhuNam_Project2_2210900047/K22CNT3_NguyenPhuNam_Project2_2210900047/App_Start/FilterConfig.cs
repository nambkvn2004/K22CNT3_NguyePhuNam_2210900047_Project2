using System.Web;
using System.Web.Mvc;

namespace K22CNT3_NguyenPhuNam_Project2_2210900047
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
