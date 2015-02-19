using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDominio
{
    public class Administrativo
    {
        string usuario;
        string password;
        string nombre;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Administrativo(string pUsuario, string pPassword, string pNombre)
        {
            this.Usuario = pUsuario;
            this.Password = pPassword;
            this.Nombre = pNombre;
        }
    }
}
