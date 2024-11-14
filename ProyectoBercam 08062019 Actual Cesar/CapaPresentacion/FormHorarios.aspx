<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormHorarios.aspx.cs" Inherits="CapaPresentacion.FormHorarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style{
            width:101px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
           Registro de Horario</h2>
        <table>
            <tr>
                <td style="text-align:right" class="auto-style1">Usuario</td>
                <td><asp:DropDownList ID="ddlUsuario" AutoPostBack="true" runat="server" Width="195px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right">Turno Mañana:</td>
                 </tr>
                <tr>
                <td style="text-align:right"> Entrada</td>
                <td><asp:TextBox ID="TextEntraMaña" runat="server" Width="70px" OnTextChanged="TextEntraMaña_TextChanged"></asp:TextBox></td>
                <td style="text-align:right"> Salida</td>
                <td><asp:TextBox ID="TextSalMaña" runat="server" Width="70px"></asp:TextBox></td>
                <td style="text-align:right">=</td>
                <td><asp:TextBox ID="TextTotMaña" runat="server" Width="70px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Turno Tarde:</td>
            </tr>
            <tr>
                <td style="text-align:right">Entrada</td>
                <td><asp:TextBox ID="TextEntraTarde" runat="server" Width="70px"></asp:TextBox></td>
                <td style="text-align:right">Salida</td>
                <td><asp:TextBox ID="TextSalTarde" runat="server" Width="70px"></asp:TextBox></td>
                <td style="text-align:right">=</td>
                <td><asp:TextBox ID="TextTotTarde" runat="server" Width="70px"></asp:TextBox></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="X-Small" 
                         BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"/> 
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="X-Small" BackColor="Aqua" 
                        Font-Bold="True"/>  
                    <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
