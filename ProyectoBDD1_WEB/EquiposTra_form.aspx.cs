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
    public partial class EquiposTra_form : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-QVVCS8VC;Initial Catalog=Proyect_BDD1;Integrated Security=True"); //AQUI SE CAMBIA LA BASE DE DATOS
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PopulateGridview();

            }
        }
        //LLENAR EL GRIDVIEW
        void PopulateGridview()
        {
            DataTable dtbl1 = new DataTable();
            SqlDataAdapter show = new SqlDataAdapter("SELECT * FROM Equipo_trabajo", con);
            show.Fill(dtbl1);

            if (dtbl1.Rows.Count > 0)
            {
                EquiposTraGV.DataSource = dtbl1;
                EquiposTraGV.DataBind();
            }
            else
            {
                dtbl1.Rows.Add(dtbl1.NewRow());
                EquiposTraGV.DataSource = dtbl1;
                EquiposTraGV.DataBind();
                EquiposTraGV.Rows[0].Cells.Clear();
                EquiposTraGV.Rows[0].Cells.Add(new TableCell());
                EquiposTraGV.Rows[0].Cells[0].Text = "No Data Found..!";
                EquiposTraGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            }

        }

        //EVENT TRIGGERED WHEN ADD NEW BUTTON IS PRESSED
        protected void EquiposTraGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {

                SqlCommand insert = new SqlCommand("ADD_EQUIPO_TRABAJO_SP", con);
                insert.Parameters.AddWithValue(" @Codigo_Equipo", (EquiposTraGV.FooterRow.FindControl("txtCodigo_EquipoFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Fecha_Nacimiento", (EquiposTraGV.FooterRow.FindControl("txtFecha_NacimientoFooter") as TextBox).Text.Trim());
               

                insert.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    insert.ExecuteNonQuery();
                    PopulateGridview();
                    lbSuccesMessage.Text = "New Record Added";
                    lblErrorMessage.Text = "";
                }
                catch (Exception ex)
                {
                    lbSuccesMessage.Text = "";
                    lblErrorMessage.Text = ex.Message;
                    throw;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
        }

        protected void EquiposTraGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EquiposTraGV.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void EquiposTraGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            EquiposTraGV.EditIndex = -1;
            PopulateGridview();
        }

        protected void EquiposTraGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlCommand update = new SqlCommand("UPDATE_EQUIPO_TRABAJO_SP", con);
            update.Parameters.AddWithValue("@Codigo_Equipo", (EquiposTraGV.Rows[e.RowIndex].FindControl("txtCodigo_Equipo") as TextBox).Text.Trim());
            update.Parameters.AddWithValue("@Fecha_Nacimiento", (EquiposTraGV.Rows[e.RowIndex].FindControl("txtFecha_Nacimiento") as TextBox).Text.Trim());


            update.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                update.ExecuteNonQuery();
                EquiposTraGV.EditIndex = -1;
                PopulateGridview();
                lbSuccesMessage.Text = "Selected Row Updated";
                lblErrorMessage.Text = "";
            }
            catch (Exception ex)
            {
                lbSuccesMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

     
        }
    }
}