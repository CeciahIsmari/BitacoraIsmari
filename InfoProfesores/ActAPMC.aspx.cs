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
    public partial class ActAPMC : System.Web.UI.Page
    {
        LNeg LN = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LNeg();
                Session["LN"] = LN;
                Session["apmc"] = txtIdAPMC.Text;

                List<Profesor> profs = null;
                string msj = "";

                profs = LN.DevuelveProfe(ref msj);
                if (profs != null)
                {
                    ddlProf.Items.Clear();
                    foreach (Profesor ec in profs)
                    {
                        ddlProf.Items.Add(new ListItem(ec.Nombre, ec.id_Profe.ToString()));
                    }
                }

                List<Materia> mats = null;

                mats = LN.DevuelveMat(ref msj);
                if (mats != null)
                {
                    ddlProf.Items.Clear();
                    foreach (Materia ec in mats)
                    {
                        ddlProf.Items.Add(new ListItem(ec.NomMat, ec.id_Mat.ToString()));
                    }
                }

                gdvGruCua.DataSource = LN.tablaGruCua(ref msj);
                gdvGruCua.DataBind();

            }
            else
            {
                LN = (LNeg)Session["LN"];
            }

        }

        protected void btnRegis_Click(object sender, EventArgs e)
        {
            if (txtIdAPMC.Text != "" && txtExtra.Text != "")
            {

                string msj = "";
                LN.EditAsPrMatCua(Convert.ToInt16(ddlProf.SelectedValue),Convert.ToInt16(ddlMate.SelectedValue),Convert.ToInt16(txtGC.Text),txtExtra.Text,Convert.ToInt16(txtIdAPMC.Text), ref msj);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg1", "msbox('¡Registrado!','" + msj + "','success')", true);

                Response.Redirect("VistaAPMC.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msbox('¡UPS!','Inserte todos los datos','error')", true);
            }
        }

        protected void gdvGruCua_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGC.Text = gdvGruCua.SelectedRow.Cells[3].Text;

        }
    }
}