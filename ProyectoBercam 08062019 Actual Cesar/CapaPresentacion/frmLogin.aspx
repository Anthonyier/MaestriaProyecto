<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="LogisticaBercam.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="abrigo_general" align="center">
    
        <div id:"content_login">
            <table>

                <tr>
                    <td>
                         <asp:Image ID="imgLogin" runat="server" ImageUrl="~/Dibey/Login3.jpg" Width="100px" Height="80px"/>
                    </td>
                    <td align="left" style="font-weight: bold">
                        Inicio de Sesión
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left" style="font-weight: bold"> Nombre de Usuario: </td>
                </tr>

                 <tr>
                    <td colspan="2" align="left"><asp:TextBox ID="txtUsuario" runat="server" Width="170px"></asp:TextBox></td>
                </tr>

                <tr>
                    <td colspan="2" align="left" style="font-weight: bold"> Contraseña: </td>
                </tr>

                 <tr>
                    <td colspan="2" align="left"><asp:TextBox ID="txtContraseña" runat="server" Width="170px" TextMode="Password"></asp:TextBox></td>
                </tr>

                <tr>
                    <td colspan="2" align="center"> <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label> </td>
                </tr>

                 <tr>
                    <td colspan="2" align="center"><asp:Button ID="BtnAceptar" runat="server" Text="Ingresar" Width="150px" OnClick="BtnAceptar_Click" /></td>
                </tr>

                <tr>
                    <td colspan="2" align="center"> <asp:Label ID="lblNombreUser" runat="server" Text="" ForeColor="Blue" Visible="false"></asp:Label> </td>
                </tr>

                <tr>
                     <td colspan="2" align="center">
                         <asp:Image ID="imgLogoBer" runat="server" ImageUrl="~/Dibey/LOGOdibey-2.jpg" Width="100px" Height="80px"/>
                    </td>
                </tr>

            </table>

        </div>

    </div>
    </form>
</body>
</html>
