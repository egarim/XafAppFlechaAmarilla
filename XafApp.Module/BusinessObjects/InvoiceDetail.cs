using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XafApp.Module.BusinessObjects
{
    //[DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class InvoiceDetail : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public InvoiceDetail(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.Unidades = 1;
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //xpa


        decimal total;
        decimal precioUnitario;
        double unidades;
        Producto producto;
        Invoice invoice;

        [Association("Invoice-InvoiceDetails")]
        public Invoice Invoice
        {
            get => invoice;
            set => SetPropertyValue(nameof(Invoice), ref invoice, value);
        }



        public Producto Producto
        {
            get => producto;
            set => SetPropertyValue(nameof(Producto), ref producto, value);
        }


        public double Unidades
        {
            get => unidades;
            set => SetPropertyValue(nameof(Unidades), ref unidades, value);
        }

        public decimal PrecioUnitario
        {
            get => precioUnitario;
            set => SetPropertyValue(nameof(PrecioUnitario), ref precioUnitario, value);
        }

        
        public decimal Total
        {
            get => total;
            set => SetPropertyValue(nameof(Total), ref total, value);
        }


        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            if(propertyName==nameof(Producto))
            {
                if(newValue==null) 
                {
                    this.PrecioUnitario = 0;
                }
                if (newValue != null)
                {
                    this.PrecioUnitario = this.Producto.PrecioUnitario;
                }
            }
            if (propertyName == nameof(Unidades))
            {
                this.Total = this.PrecioUnitario * (decimal)this.Unidades;
            }
                base.OnChanged(propertyName, oldValue, newValue);
        }
        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}