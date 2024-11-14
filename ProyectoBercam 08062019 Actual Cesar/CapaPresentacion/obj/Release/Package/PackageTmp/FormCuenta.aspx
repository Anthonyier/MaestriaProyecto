<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormCuenta.aspx.cs" Inherits="CapaPresentacion.FormCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <td style="text-align:right" class="auto-style1">Buscar:</td>
            <td><asp:TextBox ID="TxtBuscar" runat="server" Width="300px"></asp:TextBox></td>
            <td><asp:Button ID="BtnBuscar" runat="server" Text="Buscar" Width="100px" Font-Size="Smaller" OnClick="BtnBuscar_Click"/></td>
    <br />
    <div id="abrigo_formulario">
        <asp:TreeView ID="Treeview1" runat="server">
            <%--<Nodes>
                <asp:TreeNode Text="Pasivos">

                </asp:TreeNode>
                <asp:TreeNode Text="Ingresos">

                </asp:TreeNode>
                <asp:TreeNode Text="Egresos">

                </asp:TreeNode>
                <asp:TreeNode Text="Costos">

                </asp:TreeNode>
                <asp:TreeNode Text="Patrimonio">

                </asp:TreeNode>
            </Nodes>--%>
        </asp:TreeView>
    </div>
</asp:Content>
