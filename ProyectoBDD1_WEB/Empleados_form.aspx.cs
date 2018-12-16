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
    public partial class Empleados_form : System.Web.UI.Page
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
            SqlDataAdapter show = new SqlDataAdapter("SELECT * FROM Empleados", con);
            show.Fill(dtbl1);

            if (dtbl1.Rows.Count > 0)
            {
               EmpleadosGV.DataSource = dtbl1;
               EmpleadosGV.DataBind();
            }
            else
            {
                dtbl1.Rows.Add(dtbl1.NewRow());
               EmpleadosGV.DataSource = dtbl1;
               EmpleadosGV.DataBind();
               EmpleadosGV.Rows[0].Cells.Clear();
               EmpleadosGV.Rows[0].Cells.Add(new TableCell());
               EmpleadosGV.Rows[0].Cells[0].Text = "No Data Found..!";
               EmpleadosGV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            }

        }

        //EVENT TRIGGERED WHEN ADD NEW BUTTON IS PRESSED
        protected void EmpleadosGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {

                SqlCommand insert = new SqlCommand("ADD_EMPLEADOS_SP", con);
                insert.Parameters.AddWithValue(" @Codigo_Empleado", (EmpleadosGV.FooterRow.FindControl("txtCodigo_EmpleadoFooter") as TextBox).Text.Trim());
                
                //Dudas con el Date Convert.ToDateTime()?????
                insert.Parameters.AddWithValue(" @Fecha_Nacimiento", (EmpleadosGV.FooterRow.FindControl("txtFecha_NacimientoFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Fecha_Contratacion", (EmpleadosGV.FooterRow.FindControl("txtFecha_ContratacionFooter") as TextBox).Text.Trim());
                //Dudas con el Date Convert.ToDateTime()?????

                insert.Parameters.AddWithValue(" @Salario", (float)Convert.ToDouble((EmpleadosGV.FooterRow.FindControl("txtSalarioFooter") as TextBox).Text.Trim()));
                insert.Parameters.AddWithValue(" @Primer_Nombre", (EmpleadosGV.FooterRow.FindControl("txtPrimer_NombreFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Segundo_Nombre", (EmpleadosGV.FooterRow.FindControl("txtSegundo_NombreFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Primer_Apellido", (EmpleadosGV.FooterRow.FindControl("txtPrimer_ApellidoFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Segundo_Apellido", (EmpleadosGV.FooterRow.FindControl("txtSegundo_ApellidoFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Depto", (EmpleadosGV.FooterRow.FindControl("txtDeptoFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Avenida", (EmpleadosGV.FooterRow.FindControl("txtAvenidaFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Calle", (EmpleadosGV.FooterRow.FindControl("txtCalleFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Referencia", (EmpleadosGV.FooterRow.FindControl("txtReferenciaFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Num_Casa", Convert.ToInt32((EmpleadosGV.FooterRow.FindControl("txtNum_CasaFooter") as TextBox).Text.Trim()));
                insert.Parameters.AddWithValue(" @Supervisor", (EmpleadosGV.FooterRow.FindControl("txtSupervisorFooter") as TextBox).Text.Trim());
                insert.Parameters.AddWithValue(" @Codigo_Equipo", (EmpleadosGV.FooterRow.FindControl("txtCodigo_EquipoFooter") as TextBox).Text.Trim());

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

        protected void EmpleadosGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
           EmpleadosGV.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void EmpleadosGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
           EmpleadosGV.EditIndex = -1;
            PopulateGridview();
        }

        protected void EmpleadosGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlCommand update = new SqlCommand("UPDATE_EMPLEADOS_SP", con);
            update.Parameters.AddWithValue(" @Codigo_Empleado", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtCodigo_Empleado") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Fecha_Nacimiento", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtFecha_Nacimiento") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Fecha_Contratacion", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtFecha_Contratacion") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Salario", (float)Convert.ToDouble((EmpleadosGV.Rows[e.RowIndex].FindControl("txtSalario") as TextBox).Text.Trim()));
            update.Parameters.AddWithValue(" @Primer_Nombre", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtPrimer_Nombre") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Segundo_Nombre", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtSegundo_Nombre") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Primer_Apellido", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtPrimer_Apellido") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Segundo_Apellido", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtSegundo_Apellido") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Depto", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtDepto") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Calle", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtCalle") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Referencia", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtReferencia") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Num_Casa", Convert.ToInt32((EmpleadosGV.Rows[e.RowIndex].FindControl("txtNum_Casa") as TextBox).Text.Trim()));
            update.Parameters.AddWithValue(" @Supervisor", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtSupervisor") as TextBox).Text.Trim());
            update.Parameters.AddWithValue(" @Codigo_Equipo", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtCodigo_Equipo") as TextBox).Text.Trim());
            update.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                update.ExecuteNonQuery();
               EmpleadosGV.EditIndex = -1;
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

        //protected voidEmpleadosGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    SqlCommand delete = new SqlCommand("Delete_Clientes_SP", con);
        //    //  delete.Parameters.AddWithValue("@Codigo_Cliente", Convert.ToInt32(EmpleadosGV.DataKeys[e.RowIndex].Value.ToString()));
        //    delete.Parameters.AddWithValue(" @Codigo_Cliente", (EmpleadosGV.Rows[e.RowIndex].FindControl("txtCodigo_Cliente") as TextBox).Text.Trim());
        //    delete.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        con.Open();
        //        delete.ExecuteNonQuery();
        //       EmpleadosGV.EditIndex = -1;
        //        PopulateGridview();
        //        lbSuccesMessage.Text = "Selected Row Deled";
        //        lblErrorMessage.Text = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        lbSuccesMessage.Text = "";
        //        lblErrorMessage.Text = ex.Message;
        //        throw;
        //    }
        //    finally
        //    {
        //        if (con.State == ConnectionState.Open)
        //            con.Close();
        //    }
        //}
    }
}