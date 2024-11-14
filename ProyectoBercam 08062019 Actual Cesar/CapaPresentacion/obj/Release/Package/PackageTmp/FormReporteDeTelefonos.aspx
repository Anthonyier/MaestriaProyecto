<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteDeTelefonos.aspx.cs" Inherits="CapaPresentacion.FormReporteDeTelefonos" %>
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
        <h2  style="text-align:center">
            <asp:ScriptManager ID="ScriptManager1" runat="server" >

            </asp:ScriptManager>
            Opciones De Reporte Telfonos
        </h2>
        <table>
            <tr>
                <td>
                    <asp:Button ID="ButtonGeneral" runat="server" Text="General" Width="150px" BackColor="Blue" OnClick="ButtonGeneral_Click"/>
                </td>
                <td>
                    <asp:Button ID="ButtonLibre" runat="server" Text="Libre" Width="150px" BackColor="Yellow" OnClick="ButtonLibre_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtonOcupado" runat="server" Text="Ocupado" Width="150px" BackColor="Red" OnClick="ButtonOcupado_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtonCamion" runat="server" Text="Camiones"  Width="150px" BackColor="Green" OnClick="ButtonCamion_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
