<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormSeguroCamiones.aspx.cs" Inherits="CapaPresentacion.FormSeguroCamiones" %>
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
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
            Seguro de los camiones </h2>
        <table>
            <tr>
                <td style="text-align:right; font-size: large; font-family:Calibri;" class="auto-style1"> Placa</td>
                <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:TextBox ID="TxtPlacaSeguro" runat="server" Width="100px"></asp:TextBox>
                        </asp:Panel>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
            </tr>
            </table> 
        <br />
        <table>
            <tr>
                 <td>  <asp:Button ID="BtnSeguro" runat="server" Text="Seguro" width="100px" Font-Size="Smaller" 
                    BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnSeguro_Click" />
                   <asp:Button ID="BtnQuitar" runat="server" Text="Quitar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True" OnClick="BtnQuitar_Click"/></td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
            </div> 
</asp:Content>
