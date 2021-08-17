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
    public partial class VistaAPMC : System.Web.UI.Page
    {
        LNeg LN = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LNeg();
                Session["LN"] = LN;

                string ms = "";

                gdvAPMC.DataSource = LN.tablaAsPrMatCua(ref ms);
                gdvAPMC.DataBind();
            }
            else
            {
                LN = (LNeg)Session["LN"];
            }
        }


        protected void gdvAPMC_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdAPMC.Text = gdvAPMC.SelectedRow.Cells[3].Text;
        }
        protected void gdvAPMC_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ms = "";

            LN.ElimAsPrMatCua(Convert.ToInt16(txtIdAPMC.Text), ref ms);


            gdvAPMC.DataSource = LN.tablaAsPrMatCua(ref ms);
            gdvAPMC.DataBind();
        }

        protected void gdvAPMC_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["apmc"] = txtIdAPMC.Text;
            Response.Redirect("ActAPMC.aspx");
        }
    }
}