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
    public partial class ActPerProfe : System.Web.UI.Page
    {
        LNeg LN = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LNeg();
                Session["LN"] = LN;
                txtIdPP.Text = (string)Session["regE"];
                List<Profesor> prof = null;
                string msj = "";

                prof = LN.DevuelveProfe(ref msj);
                if (prof != null)
                {
                    ddlProfe.Items.Clear();
                    foreach (Profesor ec in prof)
                    {
                        ddlProfe.Items.Add(new ListItem(ec.Nombre + ec.App + ec.Apm, ec.id_Profe.ToString()));
                    }
                }

                List<GradoEspecialidad> GEsp = null;

                GEsp = LN.DevuelveGradEsp(ref msj);
                if (prof != null)
                {
                    ddlProfe.Items.Clear();
                    foreach (GradoEspecialidad ge in GEsp)
                    {
                        ddlProfe.Items.Add(new ListItem(ge.Titulo, ge.id_Grado.ToString()));
                    }
                }
            }
            else
            {
                LN = (LNeg)Session["LN"];
            }
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (txtEst.Text != "" && txtEvidencia.Text != "")
            {
               
                string msj = "";
                LN.EditarPerfProf(Convert.ToInt16(ddlProfe.SelectedValue), Convert.ToInt16(ddlGrEs.SelectedValue), txtEst.Text,Calendar1.SelectedDate,txtEvidencia.Text,Convert.ToInt16(txtIdPP.Text), ref msj);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg1", "msbox('¡Registrado!','" + msj + "','success')", true);
                Response.Redirect("VistaPerfilProf.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msbox('¡UPS!','Inserte todos los datos','error')", true);
            }
        }
    }
}