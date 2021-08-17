<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActGradEsp.aspx.cs" Inherits="InfoProfesores.ActGradEsp" %>

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
        <div class="form-group" style="width:400px; margin-left:400px; margin-top:50px;">
            <asp:Label ID="Label1" runat="server" Text="Titulo:"></asp:Label>
            <asp:TextBox ID="txtTitu" runat="server" class="form-control"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Instituto:"></asp:Label>
            <asp:TextBox ID="txtInsti" runat="server" class="form-control"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="País:"></asp:Label>
            <asp:TextBox ID="txtPais" runat="server" class="form-control"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Extra:"></asp:Label>
            <asp:TextBox ID="txtExt" runat="server" class="form-control"></asp:TextBox>
        </div>
        <br />
        <div style="margin-left:400px;">
        <div class="row">
        <div class="col">
           <asp:Button ID="btnAct" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="btnAct_Click"/>
            <asp:TextBox ID="txtId" runat="server" Visible="False"></asp:TextBox>
        </div>
        </div>
        </div>
    </form>
</body>
</html>
