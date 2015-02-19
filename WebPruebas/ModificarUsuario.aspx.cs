using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebPruebas
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["modo"] == "0")
            {
                editTitle.Visible = true;
                inputTitle.Visible = false;
            }
            else
            {
                editTitle.Visible = false;
                inputTitle.Visible = true;
            }
        }
    }
}