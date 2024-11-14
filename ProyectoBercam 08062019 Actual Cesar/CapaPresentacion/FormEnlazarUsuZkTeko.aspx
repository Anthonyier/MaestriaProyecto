<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormEnlazarUsuZkTeko.aspx.cs" Inherits="CapaPresentacion.FormEnlazarUsuZkTeko" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2 style="text-align:center">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        Usurios ZkTeko    
        </h2>
        <table>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" > Usuario:</td>
                <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
            
                   <asp:TextBox ID="TextUsuarioZkteko" runat="server" Width="300px"  ></asp:TextBox>
                 
                 </asp:Panel>
                                
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;">Numero ZkTeko</td>
                <td><asp:TextBox ID="TextNumeroZkTeko" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
        </table>
        <table>
            <asp:Button ID="ButtonZkUsuario" runat="server" Text="Registrar" OnClick="ButtonZkUsuario_Click" />
        </table>
    </div>
</asp:Content>
