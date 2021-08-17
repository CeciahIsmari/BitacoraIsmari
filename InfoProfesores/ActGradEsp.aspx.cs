using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassEntidades;
using ClassLogicaNegocios;

namespace InfoProfesores
{
    public partial class ActGradEsp : System.Web.UI.Page
    {
        LogicaNegocios LN = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LogicaNegocios();
                Session["LN"] = LN;
                txtId.Text = (string)Session["GE"];

                
            }
            else
            {
                LN = (LogicaNegocios)Session["LN"];
            }

        }

        protected void btnAct_Click(object sender, EventArgs e)
        {
            if (txtTitu.Text != "" && txtInsti.Text != "" && txtPais.Text != "" && txtExt.Text != "" )
            {

                string msj = "";
                LN.EditarGradEsp(txtTitu.Text,txtInsti.Text,txtPais.Text,txtExt.Text, Convert.ToInt16(txtId.Text), ref msj);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg1", "msbox('¡Atualizado!','" + msj + "','success')", true);

                Response.Redirect("VistaGradoEsp.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msbox('¡UPS!','Inserte todos los datos','error')", true);
            }
        }
    }
}