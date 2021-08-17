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
    public partial class VistaPerfilProf : System.Web.UI.Page
    {
        LNeg LN = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LNeg();
                Session["LN"] = LN;

                string ms = "";

                gdvPerfProf.DataSource = LN.tablaPerfilPro(ref ms);
                gdvPerfProf.DataBind();
            }
            else
            {
                LN = (LNeg)Session["LN"];
            }

        }

        protected void gdvPerfProf_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdPerPr.Text = gdvPerfProf.SelectedRow.Cells[3].Text;
        }

        protected void gdvPerfProf_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ms = "";

            LN.EliminarPerProf(Convert.ToInt16(txtIdPerPr.Text), ref ms);


            gdvPerfProf.DataSource = LN.tablaPerfilPro(ref ms);
            gdvPerfProf.DataBind();
        }

        protected void gdvPerfProf_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["IdPP"] = txtIdPerPr.Text;
            Response.Redirect("ActPerProfe.aspx");
        }
    }
}