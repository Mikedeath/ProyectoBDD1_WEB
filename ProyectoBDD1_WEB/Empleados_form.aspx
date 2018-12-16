<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados_form.aspx.cs" Inherits="ProyectoBDD1_WEB.Empleados_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 <form id="form1" runat="server">
        <div>
            <asp:GridView ID="EmpleadosGV" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                ShowHeaderWhenEmpty="true" DataKeyNames="Codigo_Empleado"
                OnRowCommand="EmpleadosGV_RowCommand" OnRowEditing="EmpleadosGV_RowEditing" OnRowCancelingEdit="EmpleadosGV_RowCancelingEdit" OnRowUpdating="EmpleadosGV_RowUpdating" OnRowDeleting="EmpleadosGV_RowDeleting"
                
                CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />

                <Columns>

                    <asp:TemplateField HeaderText="Codigo">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Codigo_Empleado")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtCodigo_Empleado" Text='<%# Eval("Codigo_Empleado")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtCodigo_EmpleadoFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha de Nacimiento">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Fecha_Nacimiento")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtFecha_Nacimiento" Text='<%# Eval("Fecha_Nacimiento")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtFecha_NacimientoFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha de Contratacion">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Fecha_Contratacion")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtFecha_Contratacion" Text='<%# Eval("Fecha_Contratacion")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtFecha_ContratacionFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Salario">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Salario")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtSalario" Text='<%# Eval("Salario")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtSalarioFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Primer Nombre">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Primer_Nombre")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrimer_Nombre" Text='<%# Eval("Primer_Nombre")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtPrimer_NombreFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Segundo_Nombre">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Segundo_Nombre")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtSegundo_Nombre" Text='<%# Eval("Segundo_Nombre")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtSegundo_NombreFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Primer Apellido">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Primer_Apellido")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrimer_Apellido" Text='<%# Eval("Primer_Apellido")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtPrimer_ApellidoFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Segundo Apellido">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Segundo_Apellido")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtSegundo_Apellido" Text='<%# Eval("Segundo_Apellido")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtSegundo_ApellidoFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Departamento">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Depto")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtDepto" Text='<%# Eval("Depto")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtDeptoFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Avenida">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Avenida")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtAvenida" Text='<%# Eval("Avenida")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtAvenidaFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Calle">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Calle")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtCalle" Text='<%# Eval("Calle")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtCalleFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Referencia">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Referencia")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtReferencia" Text='<%# Eval("Referencia")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtReferenciaFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Num Casa">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Num_Casa")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtNum_Casa" Text='<%# Eval("Num_Casa")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtNum_CasaFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Supervisor">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Supervisor")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtSupervisor" Text='<%# Eval("Supervisor")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtSupervisorFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Codigo Equipo">

                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Codigo_Equipo")%>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtCodigo_Equipo" Text='<%# Eval("Codigo_Equipo")%>' runat="server" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="txtCodigo_EquipoFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/images/icons/icons8-edit-48.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/images/icons/icons8-trash-48.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/images/icons/icons8-save-48.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/images/icons/icons8-cancel-48.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/images/icons/icons8-plus-48.png" runat="server" CommandName="Add" ToolTip="Add" Width="20px" Height="20px" />
                        </FooterTemplate>


                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

            <br />
            <asp:Label ID="lbSuccesMessage" Text="" runat="server" ForeColor="ForestGreen" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
