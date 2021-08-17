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
    public partial class VistaProfe : System.Web.UI.Page
    {
        LogicaNegocios LN = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LogicaNegocios();
                Session["LN"] = LN;

                string ms = "";

                gdvProfes.DataSource = LN.DtTablas(ref ms);
                gdvProfes.DataBind();
            }
            else
            {
                LN = (LogicaNegocios)Session["LN"];
            }

        }
        protected void gdvProfes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEli.Text = gdvProfes.SelectedRow.Cells[3].Text;
        }

        protected void gdvProfes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ms = "";
            
            LN.EliminarProf(Convert.ToInt16(txtEli.Text), ref ms);
            

            gdvProfes.DataSource = LN.DtTablas(ref ms);
            gdvProfes.DataBind();
        }

        protected void gdvProfes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        }

        protected void gdvProfes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["regE"] = txtEli.Text;
            Response.Redirect("ActProfe.aspx");

        }
    }
}