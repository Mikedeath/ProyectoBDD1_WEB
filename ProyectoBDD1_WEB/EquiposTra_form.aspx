<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquiposTra_form.aspx.cs" Inherits="ProyectoBDD1_WEB.EquiposTra_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="EquiposTraGV" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                ShowHeaderWhenEmpty="true" DataKeyNames="Codigo_Equipo"
                OnRowCommand="EquiposTraGV_RowCommand" OnRowEditing="EquiposTraGV_RowEditing" OnRowCancelingEdit="EquiposTraGV_RowCancelingEdit" OnRowUpdating="EquiposTraGV_RowUpdating"
                
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

                    <asp:TemplateField HeaderText="Codigo de Equipo">

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
