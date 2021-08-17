using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLogicaNegocios;
using ClassEntidades;

namespace InfoProfesores
{
    public partial class InsertGradEsp : System.Web.UI.Page
    {
        LogicaNegocios LN = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LogicaNegocios();
                Session["LN"] = LN;
                
            }
            else
            {
                LN = (LogicaNegocios)Session["LN"];
            }
        }

        protected void btnRegi_Click(object sender, EventArgs e)
        {
            if (txtExt.Text != "" && txtInsti.Text  != "" && txtPais.Text != "" && txtTitu.Text != "")
            {
                GradoEspecialidad newGE = new GradoEspecialidad()
                {
                    Titulo = txtTitu.Text,
                    Institucion = txtInsti.Text,
                    Pais = txtPais.Text,
                    Extra = txtExt.Text
                };
                string msj = "";
                LN.InsertarGradEsp(newGE, ref msj);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg1", "msbox('¡Registro Exitoso!','" + msj + "','success')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msbox('¡UPS!','Inserte todos los datos','error')", true);
            }
        }
    }
}