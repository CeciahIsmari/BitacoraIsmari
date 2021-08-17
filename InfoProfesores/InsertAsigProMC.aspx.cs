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
    public partial class InsertAsigProMC : System.Web.UI.Page
    {
        LNeg LN = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LNeg();
                Session["LN"] = LN;

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
                    ddlMate.Items.Clear();
                    foreach (Materia ec in mats)
                    {
                        ddlMate.Items.Add(new ListItem(ec.NomMat, ec.id_Mat.ToString()));
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

        protected void gdvGruCua_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdGruCua.Text = gdvGruCua.SelectedRow.Cells[1].Text;
        }

        protected void btnRegis_Click(object sender, EventArgs e)
        {
            if (txtExtra.Text !="" && txtIdGruCua.Text !="")
            {
                AsiProMatCua newApmce = new AsiProMatCua()
                {
                    F_Profe = Convert.ToInt16(ddlProf.SelectedValue),
                    F_Materia = Convert.ToInt16(ddlMate.SelectedValue),
                    F_GrupCua = Convert.ToInt16(txtIdGruCua.Text),
                    Extra=txtExtra.Text
                };

                string msj = "";
                LN.InsAsPrMatCua(newApmce, ref msj);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg1", "msbox('¡Registrado!','" + msj + "','success')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msbox('¡UPS!','Inserte todos los datos','error')", true);
            }
        }
    }
}
