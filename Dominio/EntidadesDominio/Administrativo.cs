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
        public const int minimoUsr = 5;
        public const int minimoPwd = 5;

        #region properties
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
        #endregion

        internal Administrativo(string pUsuario, string pPassword, string pNombre)
        {
            this.Usuario = pUsuario.Trim();
            this.Password = pPassword;
            this.Nombre = pNombre;
        }

        internal bool loginCorrecto(string usrName, string pass)
        {
            return this.usuario.Equals(usrName) && this.password.Equals(pass);
        }

        // para registro de admin. Que debe estar dentro de un admin registrado (solo un admin crea admin)

        internal bool validar(string usrName, string pass)
        {
            return usuario.Length >= minimoUsr &&
                password.Length >= minimoPwd;
        }

        //Contraseña coincide
        public bool PswCoincide(string p)
        {
            bool pass_true = false;
            if (p.Equals(this.password)) pass_true = true;
            return pass_true;
        }
 
    }
}
