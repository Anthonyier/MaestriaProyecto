<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormCambioRutaViaje.aspx.cs" Inherits="CapaPresentacion.FormCambioRutaViaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <style type="text/css">
        .auto-style1 {
            width: 119px;
        }
        .auto-style3 {
            width: 239px;
        }
        .auto-style4 {
            width: 240px;
        }
        .auto-style5 {
            width: 239px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_Formulario">
      <h2 style="text-align:center" >
          <asp:ScriptManager ID="ScriptManager1" runat="server" >

          </asp:ScriptManager>
          <span class="auto-style4">CAMBIO DE RUTA </span>
      </h2>
        <table>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1">Cliente:</td>
                <td>
                    <asp:TextBox ID="txtCliente" runat="server" Width="350px"></asp:TextBox>
                    <asp:TextBox ID="txtIdCliente" runat="server" Width="100px" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1">Ruta Actual :</td>
                <td>
                    <asp:TextBox ID="TextRutaActual" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; font-size:medium; font-family:Calibri;" class="auto-style1">Nueva Ruta</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="NuevaRuta" runat="server" AutoPostBack="true" OnSelectedIndexChanged="NuevaRuta_SelectedIndexChanged" style="font-size:xx-small" ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; font-size:medium; font-family:Calibri;" class="auto-style1">Origen</td>
                <td><asp:DropDownList ID="DdlOrigen" runat="server" Width="300px" ></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right; font-size:medium; font-family:Calibri;" class="auto-style1">Destino</td>
                  <td><asp:DropDownList ID="DdlDestino" runat="server" Width="300px" ></asp:DropDownList></td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                 <td>  <asp:Button ID="BtnModificar" runat="server" Text="Modificar" width="100px" Font-Size="Smaller" 
                    BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnModificar_Click"/>
                   <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
