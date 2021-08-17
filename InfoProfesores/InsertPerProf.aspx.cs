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
    public partial class InsertPerProf : System.Web.UI.Page
    {
        LNeg LN = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LNeg();
                Session["LN"] = LN;

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
                    ddlGrEs.Items.Clear();
                    foreach (GradoEspecialidad ge in GEsp)
                    {
                        ddlGrEs.Items.Add(new ListItem(ge.Titulo,ge.id_Grado.ToString()));
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
            if (txtEst.Text !="" && txtEvidencia.Text !="")
            {
                PerfilProfe newPerProf = new PerfilProfe()
                {
                    F_Profe = Convert.ToByte(ddlProfe.SelectedValue),
                    F_Grado = Convert.ToByte(ddlGrEs.SelectedValue),
                    Estado = txtEst.Text,
                    FechaObtencion = Calendar1.SelectedDate,
                    Evidencia = txtEvidencia.Text
                };

                string msj = "";
                LN.InsertarPerProfe(newPerProf, ref msj);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg1", "msbox('¡Registrado!','" + msj + "','success')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msbox('¡UPS!','Inserte todos los datos','error')", true);
            }
        }
         protected void btnEdi_Click(object sender, EventArgs e)
        {
            Response.Redirect("VistaPerfilProf.aspx");
        }
    }
}
