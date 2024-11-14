<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormRecordatorioCamiones.aspx.cs" Inherits="CapaPresentacion.FormRecordatorioCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css" >
        .auto-style1{
            width:59px
        }
        .auto-style2{
            width: 239px
        }
        .auto-style3{
            width:240px
        }
        .auto-style4{
            width:239px;
            height:26px;
        }
        .auto-style5{
            height:26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="abrigo_formulario" >
         <h2>Recordatorios</h2>
         <table>
             <tr>
 
                 <td>
                     <asp:Button ID="ButtonRecordCamion" runat="server" Text="Recordatorio Camiones" OnClick="ButtonRecordCamion_Click" />
                 </td>
             </tr>
         </table>  

        </div> 
</asp:Content>
