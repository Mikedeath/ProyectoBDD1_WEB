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
    public partial class Clientes_form : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-QVVCS8VC;Initial Catalog=Proyect_BDD1;Integrated Security=True"); //AQUI SE CAMBIA LA BASE DE DATOS
        protected void Page_Load(object sender, EventArgs e)
        {
 
            if(!IsPostBack)
            {
                PopulateGridview();

            }
        }
        //LLENAR EL GRIDVIEW
        void PopulateGridview()
        {
            DataTable dtbl1 = new DataTable();
            SqlDataAdapter show = new SqlDataAdapter("SELECT * FROM Clientes", con);
            show.Fill(dtbl1);

            if(dtbl1.Rows.Count > 0)
            {
                ClientesGV.DataSource = dtbl1;
                ClientesGV.DataBind();
            }
            else{
                dtbl1.Rows.Add(dtbl1.NewRow());
                ClientesGV.DataSource = dtbl1;
                ClientesGV.DataBind();
                ClientesGV.Rows[0].Cells.Clear();
                ClientesGV.Rows[0].Cells.Add(new TableCell());
                ClientesGV.Rows[0].Cells[0].Text = "No Data Found..!";
                ClientesGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            }

        }

        //EVENT TRIGGERED WHEN ADD NEW BUTTON IS PRESSED
        protected void ClientesGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
             
                SqlCommand insert = new SqlCommand("ADD_CLIENTES_SP", con);
                insert.Parameters.AddWithValue(" @Codigo_Cliente",(ClientesGV.FooterRow.FindControl("txtCodigo_ClienteFooter")as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Nombre", (ClientesGV.FooterRow.FindControl("txtNombreFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Pais", (ClientesGV.FooterRow.FindControl("txtPaisFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Correo_electronico", (ClientesGV.FooterRow.FindControl("txtCorreo_electronicoFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Pagina_web", (ClientesGV.FooterRow.FindControl("txtPagina_webFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Estado", (ClientesGV.FooterRow.FindControl("txtEstadoFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Ciudad", (ClientesGV.FooterRow.FindControl("txtCiudadFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Avenida", (ClientesGV.FooterRow.FindControl("txtAvenidaFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Codigo_postal", (ClientesGV.FooterRow.FindControl("txtCodigo_postalFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Calle", (ClientesGV.FooterRow.FindControl("txtCalleFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Referencia", (ClientesGV.FooterRow.FindControl("txtReferenciaFooter") as TextBox).Text.Trim());
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

        protected void ClientesGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ClientesGV.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void ClientesGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ClientesGV.EditIndex = -1;
            PopulateGridview();
        }

        protected void ClientesGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlCommand update = new SqlCommand("Update_Clientes_SP", con);
            update.Parameters.AddWithValue(" @Codigo_Cliente",(ClientesGV.Rows[e.RowIndex].FindControl("txtCodigo_Cliente") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Nombre", (ClientesGV.Rows[e.RowIndex].FindControl("txtNombre") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Pais", (ClientesGV.Rows[e.RowIndex].FindControl("txtPais") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Correo_electronico", (ClientesGV.Rows[e.RowIndex].FindControl("txtCorreo_electronico") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Pagina_web", (ClientesGV.Rows[e.RowIndex].FindControl("txtPagina_web") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Estado", (ClientesGV.Rows[e.RowIndex].FindControl("txtEstado") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Ciudad", (ClientesGV.Rows[e.RowIndex].FindControl("txtCiudad") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Avenida", (ClientesGV.Rows[e.RowIndex].FindControl("txtAvenida") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Codigo_postal", (ClientesGV.Rows[e.RowIndex].FindControl("txtCodigo_postal") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Calle", (ClientesGV.Rows[e.RowIndex].FindControl("txtCalle") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Referencia", (ClientesGV.Rows[e.RowIndex].FindControl("txtReferencia") as TextBox).Text.Trim());
            update.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                update.ExecuteNonQuery();
                ClientesGV.EditIndex = -1;
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

        protected void ClientesGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand delete = new SqlCommand("Delete_Clientes_SP", con);
            //  delete.Parameters.AddWithValue("@Codigo_Cliente", Convert.ToInt32(ClientesGV.DataKeys[e.RowIndex].Value.ToString()));
            delete.Parameters.AddWithValue(" @Codigo_Cliente", (ClientesGV.Rows[e.RowIndex].FindControl("txtCodigo_Cliente") as TextBox).Text.Trim());
            delete.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                delete.ExecuteNonQuery();
                ClientesGV.EditIndex = -1;
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