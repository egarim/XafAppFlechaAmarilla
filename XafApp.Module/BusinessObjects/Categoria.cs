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
    [DefaultProperty("Codigo")]
    public class Categoria:BaseObject
    {
        public Categoria(Session session):base(session)
        {
        }

        string descripcion;
        string codigo;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Codigo
        {
            get => codigo;
            set => SetPropertyValue(nameof(Codigo), ref codigo, value);
        }
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Descripcion
        {
            get => descripcion;
            set => SetPropertyValue(nameof(Descripcion), ref descripcion, value);
        }
    }
}
