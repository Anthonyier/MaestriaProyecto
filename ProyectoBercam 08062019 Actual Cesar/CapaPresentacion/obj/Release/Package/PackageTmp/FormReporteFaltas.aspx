<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteFaltas.aspx.cs" Inherits="CapaPresentacion.FormReporteFaltas" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 112px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
 <div id="abrigo_formulario">
     <table>
         <tr>
             <td>
                 <asp:DropDownList ID="DdlMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
             <td class="auto-style1"><asp:DropDownList ID="DdlAño" runat="server" AutoPostBack="true"></asp:DropDownList></td>
             <td>
                 <asp:Button ID="Button1" runat="server"  Text="Buscar" OnClick="Button1_Click" />
             </td>
         </tr>
     </table>
     <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
            <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportHorarioFaltantes.rdlc" ReportPath="ReportHorarioFaltantes.rdlc">
                 <DataSources>
                     <rsweb:ReportDataSource  DataSourceId="ObjectDataSource1" Name="DataSet1"/>
                 </DataSources>
            </LocalReport>
     </rsweb:ReportViewer>
 </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetHorarioPersonaTableAdapters.ViewHorarioFaltantesTableAdapter" ></asp:ObjectDataSource>
</asp:Content>
