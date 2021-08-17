<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActProfe.aspx.cs" Inherits="InfoProfesores.ActProfe" %>

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
            <div class="row">
             <div class="col">
               <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
               <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
             </div>
           <div class="col">
            <asp:Label ID="Label3" runat="server" Text="Apellido Paterno."></asp:Label>
            <asp:TextBox ID="txtApp" runat="server" class="form-control"></asp:TextBox>
           </div>
           <div class="col">
            <asp:Label ID="Label4" runat="server" Text="Apellido Materno:"></asp:Label>
            <asp:TextBox ID="txtApm" runat="server" class="form-control"></asp:TextBox>
           </div>
           </div>
           <div class="row">
           <div class="col">
            <asp:Label ID="Label5" runat="server" Text="Género"></asp:Label>
            <asp:DropDownList ID="ddlGen" runat="server" class="form-control">
                <asp:ListItem>Femenino</asp:ListItem>
                <asp:ListItem>Masculino</asp:ListItem>
            </asp:DropDownList>
           </div>
            <div class="col">
            <asp:Label ID="Label6" runat="server" Text="Categoría:"></asp:Label>
            <asp:TextBox ID="txtCat" runat="server" class="form-control"></asp:TextBox>
            </div>
            </div>
            <div class="row">
            <div class="col">
            <asp:Label ID="Label7" runat="server" Text="Correo:"></asp:Label>
            <asp:TextBox ID="txtCorreo" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col">
            <asp:Label ID="Label8" runat="server" Text="Numero Telefónico (celular):"></asp:Label>
            <asp:TextBox ID="txtCel" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="row">
            <div class="col">
            <asp:Label ID="Label9" runat="server" Text="Estado Civil:"></asp:Label>
            <asp:DropDownList ID="ddlEdoCivil" runat="server" class="form-control"></asp:DropDownList>
            </div>
            <div class="col">
                <asp:Label ID="Label1" runat="server" Text="Registro Empleado"></asp:Label>
                <asp:TextBox ID="txtregEmp" runat="server" class="form-control" Enabled="False"></asp:TextBox>
            </div>
            </div>
        </div>
        </div>
        <br />
        <div style="margin-left:400px;">
        <div class="row">
        <div class="col">
            <asp:Button ID="btnActP" runat="server" Text="Actualizar Profesor" class="btn btn-primary" OnClick="btnActP_Click" />
        </div>
        </div>
        </div>
    </form>
</body>
</html>
