<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReportCarroGuia.aspx.cs" Inherits="CapaPresentacion.FormReportCarroGuia" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="abrigo_formulario">
        <table>
        <tr>
                <td style="text-align:right">Año</td>
                <td><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
                <td style="text-align:right">Periodo</td>
                <td><asp:DropDownList ID="cmPeriodo" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td style="text-align:right">Region</td>
                <td><asp:DropDownList ID="cmRegion" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td><asp:Button ID="ButtonBus" runat="server" Text="Buscar" OnClick="ButtonBus_Click" /></td>
            </tr>
        </table> 
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
            <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportDetCarroGuia.rdlc" ReportPath="ReportDetCarroGuia.rdlc" >
                 <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                     <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                </DataSources>
            </LocalReport> 
            </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetDetalleCarroGuiaTableAdapters.ViDetalleCarroGuiaTableAdapter" ></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetDetalleCarroGuiaTableAdapters.VistaTotalCarroGuiaTableAdapter" ></asp:ObjectDataSource>
        </div> 
</asp:Content>
