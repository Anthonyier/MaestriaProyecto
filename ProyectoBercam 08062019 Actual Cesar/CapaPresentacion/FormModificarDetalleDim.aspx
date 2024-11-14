<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormModificarDetalleDim.aspx.cs" Inherits="CapaPresentacion.FormModificarDetalleDim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2 style="text-align:center">Modificar Detalle Dim</h2>
        <asp:Panel ID="Panel1" runat="server" >
            <table>
                <tr>
                     <td><asp:TextBox ID="TextDetalleIdDim" runat="server" Width="100px" Visible="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:right">Fecha P.R.M:</td>
                    <td><asp:TextBox ID="TextFechaPRM" runat="server" Width="100px" TextMode="Date"></asp:TextBox></td>
                    <td style="text-align:right">P.R.M No</td>
                    <td><asp:TextBox ID="TextPRMNo" runat="server" Width="170px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:right">Volume P.R.M</td>
                    <td><asp:TextBox ID="TextVolumenPRM" runat="server" Width="100px"></asp:TextBox></td>
                    <td style="text-align:right">Peso P.R.M</td>
                    <td><asp:TextBox ID="TextPesoPRM" runat="server" Width="100px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:right">Volumen Mic</td>
                    <td><asp:TextBox ID="TextVolumenMic" runat="server" Width="100px"></asp:TextBox></td>
                    <td style="text-align:right">Peso Mic</td>
                    <td><asp:TextBox ID="TextPesoMic" runat="server" Width="100px"></asp:TextBox></td>
                    <td style="text-align:right">Nro Mic</td>
                    <td><asp:TextBox ID="TextNroMic" runat="server" Width="100px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:right"> Volumen Crt</td>
                    <td><asp:TextBox ID="TextVolumenCrt" runat="server" Width="100px"></asp:TextBox></td>
                    <td style="text-align:right">Peso Crt</td>
                    <td><asp:TextBox ID="TextPesoCrt" runat="server" Width="150px"></asp:TextBox></td>
                    <td style="text-align:right">Nro Crt</td>
                    <td><asp:TextBox ID="TextNroCrt" runat="server" Width="150px" ></asp:TextBox></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td><asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" BackColor="Aqua" Font-Bold="true" Font-Italic="false" Font-Size="Small" OnClick="ButtonGuardar_Click"/></td>
                    <td><asp:Button ID="buttonAtras" runat="server" Text="<-Atras" BackColor="Red" Font-Bold="true" Font-Italic="false" Font-Size="Small" /></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
