using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProyectoBDD1_WEB
{
   
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-QVVCS8VC;Initial Catalog=Proyect_BDD1;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
        }
      
        protected void Login_btn_Click(object sender, EventArgs e)
        {
          /////CODIGO PARA PODER METER LOS PARAMETROS A UN PROCESO ALMACENADO
            
            SqlCommand insert = new SqlCommand("ADD_Login_SP", con);
            insert.Parameters.AddWithValue("@email", Email_input.Text);
            insert.Parameters.AddWithValue("@pass", Pass_inupt.Text);
            insert.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                insert.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            /////
            Response.Redirect("Menu_principal.aspx"); 
        }
    }

}
