<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormDescargarCarroGuia.aspx.cs" Inherits="CapaPresentacion.FormDescargarCarroGuia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="abrigo_formulario" >
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Descargar Imagens Carro Guia</h2>
        <table>
            <tr>
                <td style="text-align:right" >Descargar </td>
                <td><asp:TextBox ID="TextPagado" runat="server" Width="320px"></asp:TextBox></td>
                 <td><asp:Button ID="BtnPagado" runat="server" Text="Descargar" width="100px" OnClick="BtnPagado_Click"/></td>
            </tr>
        </table>
    </div>
     <table>
                 <tr>
                    <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
                 </tr>
        </table>  
</asp:Content>
