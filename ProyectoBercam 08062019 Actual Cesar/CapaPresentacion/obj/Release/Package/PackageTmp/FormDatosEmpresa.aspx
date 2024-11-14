<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormDatosEmpresa.aspx.cs" Inherits="CapaPresentacion.FormDatosEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 101px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            Registro de la empresa</h2>
        <br />
        <table>
            <tr>
                <td style="text-align:right" class="auto-style1">Nombre</td>
                <td><asp:TextBox ID="txtNombre" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">RazonSocial</td>
                <td><asp:TextBox ID="txtRazonSocial" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">Nit</td>
                <td><asp:TextBox ID="txtNit" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">Rubro</td>
                <td><asp:TextBox ID="txtRubro" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
            <td style="text-align:right" class="auto-style1">Telefono</td>
                <td><asp:TextBox ID="txtTelefono" runat="server" Width="300px"></asp:TextBox></td>
                </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">Direcccion</td>
                <td><asp:TextBox ID="txtDireccion" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">NombreContacto</td>
                <td><asp:TextBox ID="txtNombreContacto" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">Email</td>
                <td><asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">EmaliEnvio</td>
                <td><asp:TextBox ID="txtEmailEnvio" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">PaginaWeb</td>
                <td><asp:TextBox ID="txtPaginaWeb" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
            <td style="text-align:right" class="auto-style1">Facebook</td>
                <td><asp:TextBox ID="txtFacebook" runat="server" Width="300px"></asp:TextBox></td>
                </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">Whatsapp</td>
                <td><asp:TextBox ID="txtWhatsapp" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
        </table>
         <br />
        <table>
            <tr>
              <td>  <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                     BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"/>
                   <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
        </div>
</asp:Content>
