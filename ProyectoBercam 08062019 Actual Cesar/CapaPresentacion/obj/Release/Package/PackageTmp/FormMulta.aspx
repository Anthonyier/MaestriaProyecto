<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormMulta.aspx.cs" Inherits="CapaPresentacion.FormMulta" %>
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
             if (charCode > 31 && (charCode < 48 || charCode > 57))
                 return false;

             return true;
         }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
            Multas </h2>
        <table>
            <tr>
                <td style="text-align: right" class="auto-style1">Concepto: </td>
                <td><asp:TextBox ID="txtConcep" runat="server" Width="500px" TextMode="MultiLine" CssClass="upper-case"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right" class="auto-style1">Multa: </td>
                <td><asp:TextBox ID="TextMulta" runat="server" Width="100px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
            </tr>
           
            <tr>
                
                <td style="text-align: right" class="auto-style1">IdCliente: </td>
                <td>
                    <asp:DropDownList ID="DdlMulClientes" runat="server" Width="300px" CssClass="upper-case" ></asp:DropDownList>
                    </td>
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
