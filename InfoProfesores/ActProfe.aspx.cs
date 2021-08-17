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
    public partial class ActProfe : System.Web.UI.Page
    {
        LogicaNegocios LN = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LogicaNegocios();
                Session["LN"] = LN;
                txtregEmp.Text =(string) Session["regE"];

                List<EstadoCivil> edosCiv = null;
                string msj = "";

                edosCiv = LN.DevuelveEstadoCivil(ref msj);
                if (edosCiv != null)
                {
                    ddlEdoCivil.Items.Clear();
                    foreach (EstadoCivil ec in edosCiv)
                    {
                        ddlEdoCivil.Items.Add(new ListItem(ec.Estado, ec.id_edoCiv.ToString()));
                    }
                }
            }
            else
            {
                LN = (LogicaNegocios)Session["LN"];
            }
        }

        protected void btnActP_Click(object sender, EventArgs e)
        {
            if (txtregEmp.Text != "" && txtNombre.Text != "" && txtCorreo.Text != "" && txtCel.Text != "" && txtCat.Text != "" && txtApp.Text != "" && txtApm.Text != "")
            {
                
                string msj = "";
                LN.EditarProf(txtNombre.Text,txtApp.Text,txtApm.Text,ddlGen.SelectedValue,txtCat.Text,txtCorreo.Text,txtCel.Text,Convert.ToInt16(ddlEdoCivil.SelectedValue),Convert.ToInt16(txtregEmp.Text), ref msj);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg1", "msbox('¡Profesor Registrado!','" + msj + "','success')", true);

                Response.Redirect("VistaProfe.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msbox('¡UPS!','Inserte todos los datos','error')", true);
            }
        }
    }
}