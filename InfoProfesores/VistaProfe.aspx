<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaProfe.aspx.cs" Inherits="InfoProfesores.VistaProfe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!--SweetAlert-->
    <link href="css/sweetalert2.min.css" rel="stylesheet" />
    <script src="js/sweetalert2.all.min.js"></script>
    <script src="js/JavaScript.js"></script>

     <!--Bootstrap-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js""></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gdvProfes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gdvProfes_SelectedIndexChanged" OnRowDeleting="gdvProfes_RowDeleting" OnRowEditing="gdvProfes_RowEditing" OnRowUpdating="gdvProfes_RowUpdating">
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
            <asp:Label ID="Label1" runat="server" Text="Registro Seleccionado"></asp:Label>
            <asp:TextBox ID="txtEli" runat="server" Enabled="False"></asp:TextBox>
        </div>
    </form>
</body>
</html>
