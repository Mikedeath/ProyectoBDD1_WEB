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
    public partial class Equipos_form : System.Web.UI.Page
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
            SqlDataAdapter show = new SqlDataAdapter("SELECT * FROM Equipos", con);
            show.Fill(dtbl1);

            if (dtbl1.Rows.Count > 0)
            {
                EquiposGV.DataSource = dtbl1;
                EquiposGV.DataBind();
            }
            else
            {
                dtbl1.Rows.Add(dtbl1.NewRow());
                EquiposGV.DataSource = dtbl1;
                EquiposGV.DataBind();
                EquiposGV.Rows[0].Cells.Clear();
                EquiposGV.Rows[0].Cells.Add(new TableCell());
                EquiposGV.Rows[0].Cells[0].Text = "No Data Found..!";
                EquiposGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            }

        }

        //EVENT TRIGGERED WHEN ADD NEW BUTTON IS PRESSED
        protected void EquiposGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {

                SqlCommand insert = new SqlCommand("ADD_EQUIPOS_SP", con);
                insert.Parameters.AddWithValue(" @Codigo_de_Equipo", (EquiposGV.FooterRow.FindControl("txtCodigo_de_EquipoFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Nombre", (EquiposGV.FooterRow.FindControl("txtNombreFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Supervisor", (EquiposGV.FooterRow.FindControl("txtSupervisorFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Rol_clientes", (EquiposGV.FooterRow.FindControl("txtRol_clientesFooter") as TextBox).Text.Trim());
                
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

        protected void EquiposGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EquiposGV.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void EquiposGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            EquiposGV.EditIndex = -1;
            PopulateGridview();
        }

        protected void EquiposGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlCommand update = new SqlCommand("UPDATE_EQUIPOS_SP", con);
            update.Parameters.AddWithValue(" @Codigo_de_Equipo", (EquiposGV.Rows[e.RowIndex].FindControl("txtCodigo_de_Equipo") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Nombre", (EquiposGV.Rows[e.RowIndex].FindControl("txtNombre") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Supervisor", (EquiposGV.Rows[e.RowIndex].FindControl("txtSupervisor") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Rol_clientes", (EquiposGV.Rows[e.RowIndex].FindControl("txtRol_clientes") as TextBox).Text.Trim());
          
            update.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                update.ExecuteNonQuery();
                EquiposGV.EditIndex = -1;
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

        protected void EquiposGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand delete = new SqlCommand("DELETE_EQUIPOS_SP", con);
            //  delete.Parameters.AddWithValue("@Codigo_Cliente", Convert.ToInt32(EquiposGV.DataKeys[e.RowIndex].Value.ToString()));
            delete.Parameters.AddWithValue(" @Codigo_de_Equipo", (EquiposGV.Rows[e.RowIndex].FindControl("txtCodigo_de_Equipo") as TextBox).Text.Trim());
            delete.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                delete.ExecuteNonQuery();
                EquiposGV.EditIndex = -1;
                PopulateGridview();
                lbSuccesMessage.Text = "Selected Row Deled";
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