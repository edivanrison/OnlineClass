using System.Web.Mvc;

namespace EAD.OnlineClass.Areas.Administrador
{
    public class AdministradorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administrador";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administrador_default",
                "Administrador/{controller}/{action}/{id}",
                new { Controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
