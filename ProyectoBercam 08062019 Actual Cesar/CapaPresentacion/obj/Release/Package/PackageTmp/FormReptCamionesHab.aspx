<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReptCamionesHab.aspx.cs" Inherits="CapaPresentacion.FormReptCamionesHab" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div id="abrigo_formulario">
        <h2>Reporte Habilitados</h2>
         
         </div> 
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
         <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportCamionesHabilitados.rdlc" ReportPath="ReportCamionesHabilitados.rdlc" >
             <DataSources>
                   <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
               </DataSources>
         </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetCamionesReporteTableAdapters.ViewCamionesHabilitadosTableAdapter" >

    </asp:ObjectDataSource>
</asp:Content>
