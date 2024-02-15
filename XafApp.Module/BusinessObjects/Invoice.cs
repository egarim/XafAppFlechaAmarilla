using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
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
    [Appearance("no editable cuando facturado es verdadero",Enabled =false,TargetItems ="*",Criteria = "Facturado = true")]
    [Appearance("Rojo total negativo",BackColor ="Red", TargetItems = "Total", Criteria = "Total < 0",Priority =1)]
    [Appearance("Verde total mas de 100", BackColor = "Green", TargetItems = "Total", Criteria = "Total > 100", Priority = 2)]
    [Appearance("Ocultar comentario", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.ShowEmptySpace, TargetItems = "Comentarios", Criteria = "Facturado = true")]
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Invoice : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Invoice(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        decimal total;
        string comentarios;
        bool facturado;
        Cliente cliente;
        DateTime fecha;

        //xpo


        public Cliente Cliente
        {
            get => cliente;
            set => SetPropertyValue(nameof(Cliente), ref cliente, value);
        }


        public DateTime Fecha
        {
            get => fecha;
            set => SetPropertyValue(nameof(Fecha), ref fecha, value);
        }

        //A>C  B>C   C

        //xpcl

        //xpb


        public bool Facturado
        {
            get => facturado;
            set => SetPropertyValue(nameof(Facturado), ref facturado, value);
        }


        [Size(SizeAttribute.Unlimited)]
        public string Comentarios
        {
            get => comentarios;
            set => SetPropertyValue(nameof(Comentarios), ref comentarios, value);
        }


        [ImmediatePostData()]
        public decimal Total
        {
            get => total;
            set => SetPropertyValue(nameof(Total), ref total, value);
        }
        //[Association("Invoice-InvoiceDetails")]
        [Association("Invoice-InvoiceDetails"),DevExpress.Xpo.Aggregated()]
        public XPCollection<InvoiceDetail> InvoiceDetails
        {
            get
            {
                return GetCollection<InvoiceDetail>(nameof(InvoiceDetails));
            }
        }
    }
}