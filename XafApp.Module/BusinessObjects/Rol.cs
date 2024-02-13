using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XafApp.Module.BusinessObjects
{
    [NavigationItem()]
    public class Rol : BaseObject
    {
        public Rol()
        {
        }

        public Rol(Session session) : base(session)
        {
        }


        string nombre;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nombre
        {
            get => nombre;
            set => SetPropertyValue(nameof(Nombre), ref nombre, value);
        }

        [Association("Usuario-Roles")]
        
        public XPCollection<Usuario> Usuarios
        {
            get
            {
                return GetCollection<Usuario>(nameof(Usuarios));
            }
        }
    }
}
