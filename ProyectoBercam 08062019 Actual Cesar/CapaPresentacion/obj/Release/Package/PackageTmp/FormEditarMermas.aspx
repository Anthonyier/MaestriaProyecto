<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormEditarMermas.aspx.cs" Inherits="CapaPresentacion.FormEditarMermas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type ="text/css">
        .auto-style1{
            width:101px;
        }
        .auto-style2 {
            width: 101px;
            height: 26px;
            font-size: medium;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            font-family: Arial;
            color: #003EFF;
            font-size: x-large;
        }
        .auto-style5 {
            width: 101px;
            font-size: medium;
        }
        .auto-style7 {
            font-size: xx-small;
        }
        .upper-case {
            font-size: xx-small;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2 style="text-align:center" >
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
            <span class="auto-style4">Modificacion De Mermas</span></h2>
        <table>
            <tr>
                <td style="text-align:right;font-size:medium;font-family:Calibri;" class="auto-style1">PrecioProductoMerma</td>
                <td><asp:TextBox ID="TextPrecioMerma" runat="server" Width="300px" CssClass="auto-style7"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button ID="ButtonModificar"  runat="server" Text="Modificar" width="100px" Font-Size="X-Small" BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="ButtonModificar_Click" style="height: 29px"/>
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="X-Small" BackColor="Aqua" Font-Bold="True"/>
                </td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
        </div> 
</asp:Content>
