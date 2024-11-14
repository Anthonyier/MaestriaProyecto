<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormImagenConcVis.aspx.cs" Inherits="CapaPresentacion.FormImagenConcVis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="abrigo_formulario">
         <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Imagen De Pago</h2>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxLiquidacion" runat="server" Width="320px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                  <asp:Literal ID="ltEmbed" runat="server" ></asp:Literal>
                </td>
                </tr>
          </table> 
        </div> 
</asp:Content>
