<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormModNroConcRefinacion.aspx.cs" Inherits="CapaPresentacion.FormModNroConcRefinacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            Agregar Numero De La Conciliacion
        </h2>
        <table>
            <tr>
                <td style ="text-align: right;font-size:medium;font-family:Calibri;">Numero de la Conciciliacion:</td>
                <td> 
                   <asp:TextBox ID="TextNumeroConciliacion" runat="server" Width="320px"></asp:TextBox>

                </td>
            </tr>
        </table>
    </div>
    <table>
        <tr>
                    <td><asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                         BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"  /> 
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                    <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
                 </tr>
    </table>
</asp:Content>
