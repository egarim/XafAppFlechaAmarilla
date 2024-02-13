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
    [VisibleInReports()]
    public class Usuario : BaseObject
    {
        public Usuario()
        {
        }

        public Usuario(Session session) : base(session)
        {
        }

        string nombreDeUsuario;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NombreDeUsuario
        {
            get => nombreDeUsuario;
            set => SetPropertyValue(nameof(NombreDeUsuario), ref nombreDeUsuario, value);
        }


        //xpcl 
        [Association("Usuario-Roles")]
        public XPCollection<Rol> Roles
        {
            get
            {
                return GetCollection<Rol>(nameof(Roles));
            }
        }
    }
}
