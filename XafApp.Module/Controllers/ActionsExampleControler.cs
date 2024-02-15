using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XafApp.Module.BusinessObjects;

namespace XafApp.Module.Controllers
{
    public class ActionsExampleControler : ViewController
    {
        PopupWindowShowAction ListPopup;
        PopupWindowShowAction Popup;
        SingleChoiceAction SeleccionEstado;
        ParametrizedAction AnularFacutra;
        SimpleAction EjemploSimpleAction;
        public ActionsExampleControler()
        {
            //Simple action xas


            EjemploSimpleAction = new SimpleAction(this, "EjemploSimpleAction", "View");
            EjemploSimpleAction.Caption = "Marcar facturado";
            EjemploSimpleAction.Execute += EjemploSimpleAction_Execute;
            EjemploSimpleAction.TargetObjectType = typeof(Invoice);
            EjemploSimpleAction.TargetViewType = ViewType.DetailView;
            EjemploSimpleAction.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Caption;

            //EjemploSimpleAction.TargetViewId = "";



            //Xaf parametrized Action xap


            AnularFacutra = new ParametrizedAction(this, "Anular factura", "View", typeof(string));
            AnularFacutra.Execute += AnularFacutra_Execute;
            AnularFacutra.ImageName = "BO_Skull";

            AnularFacutra.ConfirmationMessage = "Confirme que quiere anular la factura?";


            //Single choice action xasc

            SeleccionEstado = new SingleChoiceAction(this, "SeleccionEstado", "View");
            SeleccionEstado.Caption = "Seleccion de estado";
            SeleccionEstado.ItemType = SingleChoiceActionItemType.ItemIsOperation;
            SeleccionEstado.Execute += SeleccionEstado_Execute;
            // Create some items
            SeleccionEstado.Items.Add(new ChoiceActionItem("MyItem1", "My Item 1", 1));
            var Choice = new ChoiceActionItem("MyItem2", "My Item 2", 2);
            var SubItem = new ChoiceActionItem("SubItem 1", "Sub item 1", 10);
            Choice.Items.Add(SubItem);
            SeleccionEstado.Items.Add(Choice);


            //Xaf popup action window xapw

            Popup = new PopupWindowShowAction(this, "Popup", "View");
            Popup.Execute += Popup_Execute;
            Popup.CustomizePopupWindowParams += Popup_CustomizePopupWindowParams;



            ListPopup = new PopupWindowShowAction(this, "ListPopup", "View");
            ListPopup.Execute += ListPopup_Execute;
            ListPopup.CustomizePopupWindowParams += ListPopup_CustomizePopupWindowParams;
            
        }
        private void ListPopup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var selectedPopupWindowObjects = e.PopupWindowViewSelectedObjects;
            var selectedSourceViewObjects = e.SelectedObjects;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112723/).
        }
        private void ListPopup_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            e.View=this.Application.CreateListView(typeof(Producto), true);

            // Set the e.View parameter to a newly created view (https://docs.devexpress.com/eXpressAppFramework/112723/).
        }
        private void Popup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var selectedPopupWindowObjects = e.PopupWindowViewSelectedObjects;
            var selectedSourceViewObjects = e.SelectedObjects;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112723/).
        }
        private void Popup_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            // Set the e.View parameter to a newly created view (https://docs.devexpress.com/eXpressAppFramework/112723/).

            var os=this.Application.CreateObjectSpace();
            var Cliente=os.CreateObject<Cliente>();
            var ClienteView= this.Application.CreateDetailView(os, Cliente);
            e.View=ClienteView;

        }
        private void SeleccionEstado_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            //
            //this.View.ObjectSpace.GetObjectsQuery<Invoice>().Where(f => f.Facturado); 


            var MyXpObjectSpace=this.View.ObjectSpace as XPObjectSpace;
            //MyXpObjectSpace.Session.ExecuteSproc()


            var itemData = e.SelectedChoiceActionItem.Data;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112738/).
        }
        private void AnularFacutra_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            var parameterValue = (string)e.ParameterCurrentValue;

            var CurrentInvoice = e.CurrentObject as Invoice;

            CurrentInvoice.Comentarios = parameterValue;

            if (this.View.ObjectSpace.IsModified)
            {
                this.View.ObjectSpace.CommitChanges();
            }

            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112724/).
        }
        private void EjemploSimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var CurrentInvoice = e.CurrentObject as Invoice;

            CurrentInvoice.Facturado = true;

            if(this.View.ObjectSpace.IsModified)
            {
                this.View.ObjectSpace.CommitChanges();
            }


        }
    }
}
