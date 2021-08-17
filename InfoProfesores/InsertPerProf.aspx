<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertPerProf.aspx.cs" Inherits="InfoProfesores.InsertPerProf" %>

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
         <!--Formularios-->
        <div class="form-group" style="width:700px; margin-left:400px; margin-top:50px;">
             <asp:Label ID="Label1" runat="server" Text="Profesor:"></asp:Label>
            <asp:DropDownList ID="ddlProfe" runat="server" class="form-control"></asp:DropDownList>
            <asp:Label ID="Label2" runat="server" Text="Grado Especialidad:"></asp:Label>
            <asp:DropDownList ID="ddlGrEs" runat="server" class="form-control"></asp:DropDownList>
            <asp:Label ID="Label3" runat="server" Text="Estado:"></asp:Label>
             <asp:TextBox ID="txtEst" runat="server"  class="form-control"></asp:TextBox>
             <asp:Label ID="Label4" runat="server" Text="Fecha de Obtención:"></asp:Label>
             <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
             <asp:Label ID="Label5" runat="server" Text="Evidencia"></asp:Label>
             <asp:TextBox ID="txtEvidencia" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div style="margin-left:400px;">
            <asp:Button ID="btnReg" runat="server" Text="Registrar" class="btn btn-primary" OnClick="btnReg_Click"/>
            <asp:Button ID="btnEdi" runat="server" Text="Editar" class="btn btn-primary" OnClick="btnEdi_Click"/>
        </div>
    </form>
</body>
</html>
