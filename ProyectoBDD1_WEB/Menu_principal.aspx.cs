using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBDD1_WEB
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Ordenes_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ordenes_form.aspx");
        }

        protected void Clientes_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes_form.aspx");
        }

        protected void Equipos_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Equipos_form.aspx");
        }

        protected void Empleados_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados_form.aspx");
        }

        protected void Equipos_de_trabajo_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("EquiposTra_form.aspx");
        }

        protected void Herramientas_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Herramientas_form.aspx");
        }

        protected void Proyectos_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proyectos_form.aspx");
        }

        protected void Actividades_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Actividades_form.aspx");
        }
    }
}