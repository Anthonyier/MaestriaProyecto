<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormTransaccion.aspx.cs" Inherits="CapaPresentacion.FormTransaccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type ="text/css">
        .auto-style1{
            width:101px;
        }
        .auto-style2 {
            width: 101px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
            registro de transaccion
        </h2>
        <table>
            <tr>
                <td style="text-align:right" class="auto-style1"> Monto </td>
                <td> 
                    <asp:TextBox ID="Textmonto" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">Tipo Cambio</td>
              <td><asp:TextBox ID="TextTipoCambio" runat="server" Width="300px"></asp:TextBox></td>  
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">Glosa </td>
                <td><asp:TextBox ID="TextGlosa" runat="server" Width="300px" Height="60px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">IdMoneda</td>
                <td><asp:DropDownList ID="ddlMoneda" AutoPostBack="true" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">IdFormaPago</td>
                <td><asp:DropDownList ID="ddlFormaPago" AutoPostBack="true" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">IdCuenta</td>
                <td><asp:DropDownList ID="ddlCuenta" AutoPostBack="true" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right" class="auto-style1">IdTipoTransaccion</td>
                <td><asp:DropDownList ID="ddlTipoTransaccion" AutoPostBack="true" runat="server"></asp:DropDownList></td>
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
