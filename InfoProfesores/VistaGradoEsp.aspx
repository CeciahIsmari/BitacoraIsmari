<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaGradoEsp.aspx.cs" Inherits="InfoProfesores.VistaGradoEsp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gdvGraEsp" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gdvGraEsp_RowDeleting" OnSelectedIndexChanged="gdvGraEsp_SelectedIndexChanged" OnRowEditing="gdvGraEsp_RowEditing">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="Editar" ShowEditButton="True" />
                    <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="True" />
                    <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:TextBox ID="txtGE" runat="server" Enabled="False" Visible="False"></asp:TextBox>
        </div>
    </form>
</body>
</html>
