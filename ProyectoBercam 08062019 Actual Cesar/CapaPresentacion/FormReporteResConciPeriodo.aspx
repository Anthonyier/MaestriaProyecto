<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteResConciPeriodo.aspx.cs" Inherits="CapaPresentacion.FormReporteResConciPeriodo" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="abrigo_formulario">
        <h2>Seleccione Fecha</h2>
         <table>
        <tr>
                <td style="text-align:right" class="auto-style1">Año</td>
                <td class="auto-style5"><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
                <td style="text-align:right" class="auto-style1">Periodo</td>
                <td class="auto-style5"><asp:DropDownList ID="cmPeriodo" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td><asp:Button ID="ButtonBus" runat="server" Text="Buscar" OnClick="ButtonBus_Click" /></td>
            </tr>
        </table> 
        </div> 
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
        <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportResumenConcPeriodo.rdlc" ReportPath="ReportResumenConcPeriodo.rdlc">
            <DataSources>
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="DataSet4" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource5" Name="DataSet5" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource6" Name="DataSet6" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource7" Name="DataSet7" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource8" Name="DataSet8" /> 
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPeriodoTableAdapters.VistatotalDetalleCorporacionPeriodoTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPeriodoTableAdapters.VistatotalPagableCorporacionPeriodoTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPeriodoTableAdapters.TotalTelefoniaPeriodoTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPeriodoTableAdapters.TotalRastreoSatelitalPeriodoTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPeriodoTableAdapters.ViTotalTelefoniaRefinacionTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPeriodoTableAdapters.ViTotalRastreoRefTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPeriodoTableAdapters.ViResumenDetalleRefTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPeriodoTableAdapters.ViResumenTotalPagableRefinacionTableAdapter"></asp:ObjectDataSource>
</asp:Content>
