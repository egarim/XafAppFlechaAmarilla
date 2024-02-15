using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.XtraRichEdit.Model;
using XafApp.Module.BusinessObjects;

namespace XafApp.Blazor.Server.Controllers
{
    public class ControllerBlazor:ViewController
    {
        ActionUrl urlAction;
        public ControllerBlazor()
        {

            urlAction = new ActionUrl(this, "ShowUrlAction", "ListView");
            urlAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            urlAction.UrlFieldName = "Nombre";
            urlAction.UrlFormatString = "http://www.google.com/?q={0}";
            urlAction.TextFormatString = "Caption for {0}";
            urlAction.TextFieldName = "Nombre";
            urlAction.TargetObjectType = typeof(Cliente);
            urlAction.TargetViewType = ViewType.ListView;
        }
    }
}
