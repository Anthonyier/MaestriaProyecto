<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormRutaCorta.aspx.cs" Inherits="CapaPresentacion.FormRutaCorta" %>
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
           
            RUTAS Cortas

        </h2>
        <table>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1">Cliente</td>
                 <td>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                   <asp:TextBox ID="TextCliRutaCorta" runat="server" Width="300px" CssClass="auto-style7" ></asp:TextBox>
                        </asp:Panel>
                    </ContentTemplate>
                    </asp:UpdatePanel>
               </td>
            </tr>
            <tr>
                <td style="text-align:right;font-family:Calibri;" class="auto-style2">Origen</td>
                <td class="auto-style3"><asp:DropDownList ID="cmOrigen" AutoPostBack="true" runat="server" style="font-size: xx-small">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-family:Calibri;" class="auto-style2">Destino</td>
                  <td class="auto-style3"><asp:DropDownList ID="cmDestino" AutoPostBack="true" runat="server" style="font-size: xx-small">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <table>
            <tr>
                 <td>  <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                    BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"/>
                   <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
