using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XafApp.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("Nombre")]
    public class Producto:BaseObject
    {
        /// <summary>
        /// <para>Used to initialize a new instance of a <see cref="Producto"/> descendant, in a particular <see cref="DevExpress.Xpo.Session"/>.</para>
        /// </summary>
        /// <param name="session">A DevExpress.Xpo.Session object which represents a persistent object’s cache where the business object will be instantiated.</param>
        public Producto(Session session) : base(session)
        {

        }

        /// <summary>
        /// <para>Creates a new instance of the <see cref="Producto"/> class.</para>
        /// </summary>
        public Producto()
        {

        }


        string nombre;
        decimal precioUnitario;
        string descripcion;
        string codigo;

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nombre
        {
            get => nombre;
            set => SetPropertyValue(nameof(Nombre), ref nombre, value);
        }
        [ModelDefault("Caption", "Código")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Codigo
        {
            get => codigo;
            set => SetPropertyValue(nameof(Codigo), ref codigo, value);
        }

        [Size(SizeAttribute.Unlimited)]
        public string Descripcion
        {
            get => descripcion;
            set => SetPropertyValue(nameof(Descripcion), ref descripcion, value);
        }

        
        public decimal PrecioUnitario
        {
            get => precioUnitario;
            set => SetPropertyValue(nameof(PrecioUnitario), ref precioUnitario, value);
        }

    }
}
