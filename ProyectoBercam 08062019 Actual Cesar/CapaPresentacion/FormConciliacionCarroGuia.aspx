<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormConciliacionCarroGuia.aspx.cs" Inherits="CapaPresentacion.FormConciliacionCarroGuia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type ="text/css">
        .auto-style1{
            width:101px;
        }
        .auto-style2 {
            width: 101px;
            height: 26px;
            font-size: medium;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            font-family: Arial;
            color: #003EFF;
            font-size: x-large;
        }
        .auto-style5 {
            width: 101px;
            font-size: medium;
        }
        .auto-style7 {
            font-size: xx-small;
        }
        .upper-case {
            font-size: xx-small;
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
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server"  ></asp:ScriptManager>
            Conciliacion De Carro Guia
        </h2>
        <table>
            
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;"class="auto-style1">Flete Bruto</td>
                <td><asp:TextBox ID="TextBoxMontoDeposito" runat="server" Width="100px" onkeypress="return onlyDotsAndNumbers(event)" ></asp:TextBox></td>
            </tr>
             <tr>
                <td><asp:TextBox ID="TextBoxDiferenciasCarroGuia" runat="server" Width="100px" onkeypress="return onlyDotsAndNumbers(event)" Visible="false"  ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;"class="auto-style1">Total Pagable</td>
                <td><asp:TextBox ID="TextBoxTotalPagable" runat="server" Width="100px" onkeypress="return onlyDotsAndNumbers(event)" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;"class="auto-style1">Rastreo Satelital</td>
                <td><asp:TextBox ID="TextBoxCalculoRastreo" runat="server" Width="100px" onkeypress="return onlyDotsAndNumbers(event)" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;"class="auto-style1">Telefonia Celular</td>
                <td><asp:TextBox ID="TextBoxCalculoTelefono" runat="server" Width="100px" onkeypress="return onlyDotsAndNumbers(event)" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="TextBoxDiferenciaTotal" runat="server" Width="100px" onkeypress="return onlyDotsAndNumbers(event)" Visible="false" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;"class="auto-style1">Total A Pagar</td>
                <td><asp:TextBox ID="TextBoxPagos" runat="server" Width="100px" onkeypress="return onlyDotsAndNumbers(event)" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;"class="auto-style1">Periodo</td>
                <td><asp:DropDownList ID="DdlPeriodo" runat="server" Width="300px" AutoPostBack="true" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;"class="auto-style1">Año</td>
                <td><asp:DropDownList ID="DdlAño" AutoPostBack="true" runat="server" Width="300px" CssClass="auto-style7" OnSelectedIndexChanged="DdlAño_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;"class="auto-style1">Camion</td>
                <td><asp:DropDownList ID="DDLCamionCarroGuia" AutoPostBack="true" runat="server" Width="300px" CssClass="auto-style7" ></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;" class="auto-style1">Telefono 1</td>
                <td><asp:DropDownList ID="DDLTelefonoCarroGuia" AutoPostBack="true" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;" class="auto-style1">Telefono 2</td>
                <td><asp:DropDownList ID="DDLTelefonoCarroGuia2" AutoPostBack="true" runat="server" Width="300px" CssClass="auto-style7" ></asp:DropDownList></td>
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
