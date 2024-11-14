<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormCamioGuia.aspx.cs" Inherits="CapaPresentacion.FormCamioGuia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 101px;
        }
    </style>
     <script language="javascript" type="text/javascript">
         // Except only numbers and dot (.) for salary textbox
         function onlyDotsAndNumbers(event) {
             var charCode = (event.which) ? event.which : event.keyCode
             if (charCode == 44) {
                 return true;
             }
             if (charCode == 46) {
                 return true;
             }
             if (charCode > 31 && (charCode < 48 || charCode > 57))
                 return false;

             return true;
         }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>Camion Guia</h2>
        <table>
            <tr>
                <td style="text-align:right; font-size:large; font-family:Calibri;"class="auto-style1">Monto</td>
                <td><asp:TextBox ID="TextMonto" runat="server" Width="300px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri;"class="auto-style1">Año</td>
                <td><asp:DropDownList ID="DdlAño" AutoPostBack="true" runat="server" Width="195px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri;"class="auto-style1">Proveedor</td>
                <td><asp:DropDownList ID="DdlProveedor" AutoPostBack="true" runat="server" Width="195px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri;"class="auto-style1">Periodo</td>
                <td><asp:DropDownList ID="DdlPeriodo" AutoPostBack="true" runat="server" Width="195px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri;"class="auto-style1">Region</td>
                <td><asp:DropDownList ID="DdlRegion" AutoPostBack="true" runat="server" Width="195px"></asp:DropDownList></td>
            </tr>
        </table>
        <br/>
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
