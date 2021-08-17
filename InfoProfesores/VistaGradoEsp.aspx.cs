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
    public partial class VistaGradoEsp : System.Web.UI.Page
    {
        LogicaNegocios LN = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LN = new LogicaNegocios();
                Session["LN"] = LN;

                string ms = "";

                gdvGraEsp.DataSource = LN.DtTablaGE(ref ms);
                gdvGraEsp.DataBind();
            }
            else
            {
                LN = (LogicaNegocios)Session["LN"];
            }
        }


        protected void gdvGraEsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGE.Text=gdvGraEsp.SelectedRow.Cells[3].Text;
        }

        protected void gdvGraEsp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ms = "";

            LN.EliminarGradEspf(Convert.ToInt16(txtGE.Text), ref ms);


            gdvGraEsp.DataSource = LN.DtTablaGE(ref ms);
            gdvGraEsp.DataBind();
        }

        protected void gdvGraEsp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["GE"] = txtGE.Text;
            Response.Redirect("ActGradEsp.aspx");
        }
    }
}