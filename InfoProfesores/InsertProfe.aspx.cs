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
    public partial class InsertProfe : System.Web.UI.Page
    {
        LogicaNegocios LN = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LogicaNegocios();
                Session["LN"] = LN;

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

        protected void btnRegi_Click(object sender, EventArgs e)
        {
            if (txtregEmp.Text != "" && txtNombre.Text != "" && txtCorreo.Text != "" && txtCel.Text != "" && txtCat.Text != "" && txtApp.Text != "" && txtApm.Text != "")
            {
                Profesor newProfee = new Profesor()
                {
                    RegistroEmpleado = Convert.ToInt16(txtregEmp.Text),
                    Nombre = txtNombre.Text,
                    App = txtApp.Text,
                    Apm = txtApm.Text,
                    Genero = ddlGen.SelectedValue,
                    Categria = txtCat.Text,
                    Correo = txtCorreo.Text,
                    Cel = txtCel.Text,
                    fEstadoCivil = Convert.ToByte(ddlEdoCivil.SelectedValue)
                };

                string msj = "";
                LN.InsertarProfe(newProfee, ref msj);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg1", "msbox('¡Profesor Registrado!','" + msj + "','success')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg2", "msbox('¡UPS!','Inserte todos los datos','error')", true);
            }
            
            
        }

        protected void btnEdProf_Click(object sender, EventArgs e)
        {
            Response.Redirect("VistaProfe.aspx");
        }
    }
}