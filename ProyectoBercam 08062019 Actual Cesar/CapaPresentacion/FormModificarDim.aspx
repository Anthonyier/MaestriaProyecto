<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormModificarDim.aspx.cs" Inherits="CapaPresentacion.FormModificarDim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2 style="text-align:center">Modicacion De Dim</h2>
        <asp:Panel ID="Panel1" runat="server" >
            <table>
                <tr>
                    <td style="text-align:right">Aduana Frontera:</td>
                    <td><asp:TextBox ID="TextAduanaFront" runat="server" Width="100px" ></asp:TextBox></td>
                    <td style="text-align:right">DIM:</td>
                    <td><asp:TextBox ID="TextDim" runat="server" Width="150px"></asp:TextBox></td>
                    <asp:TextBox Id="TextIdDIm" runat="server" Visible="false" ></asp:TextBox>
                </tr>
                <tr>
                    <td style="text-align:right">Producto:</td>
                    <td><asp:TextBox ID="TextProductoDim" runat="server" Width="100px"></asp:TextBox></td>
                    <td style="text-align:right">Proveedor:</td>
                    <td><asp:TextBox ID="TextProveedor" runat="server" Width="100px"></asp:TextBox></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td><asp:Button ID="btnGuardar" runat="server" text="Guardar" OnClick="btnGuardar_Click" /></td>
                    <td><asp:Button ID="btnVolver" runat="server" Text="<-Atras" BackColor="Red" OnClick="btnVolver_Click" /></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
