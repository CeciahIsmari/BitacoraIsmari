<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertAsigProMC.aspx.cs" Inherits="InfoProfesores.InsertAsigProMC" %>

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
        <div class="form-group" style="width:700px; margin-left:400px; margin-top:50px;">
            <asp:Label ID="Label1" runat="server" Text="Profesor:"></asp:Label>
            <asp:DropDownList ID="ddlProf" runat="server" class="form-control"></asp:DropDownList>
            <asp:Label ID="Label2" runat="server" Text="Materia:"></asp:Label>
            <asp:DropDownList ID="ddlMate" runat="server" class="form-control"></asp:DropDownList>
            <asp:Label ID="Label3" runat="server" Text="Grupo - Cuatrimestre:"></asp:Label>
            <asp:GridView ID="gdvGruCua" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gdvGruCua_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:Label ID="Label4" runat="server" Text="Extra"></asp:Label>
            <asp:TextBox ID="txtExtra" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div style="margin-left:400px;">
            <asp:Button ID="btnRegis" runat="server" Text="Registrar" class="btn btn-primary" OnClick="btnRegis_Click" />
            <asp:TextBox ID="txtIdGruCua" runat="server" Visible="False"></asp:TextBox>
        </div>
    </form>
</body>
</html>
