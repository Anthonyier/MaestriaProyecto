﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteLiquidacionPagada.aspx.cs" Inherits="CapaPresentacion.FormReporteLiquidacionPagada" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div id="abrigo_formulario">
        <h2>Seleccione Fecha</h2>
    <table>
        <tr>
            <td style="text-align:right" class="auto-style1">Año</td>
                <td class="auto-style5"><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
                <td style="text-align:right" class="auto-style1">Mes</td>
                <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td><asp:Button ID="ButtonBus" runat="server" Text="Buscar" OnClick="ButtonBus_Click"/>      
            </td>
            </tr>
            </table> 
         </div> 
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
        <LocalReport ReportEmbeddedResource="CapaPresentacion.ReporteLiquidacionPagada.rdlc" ReportPath="ReporteLiquidacionPagada.rdlc"> 
             <datasources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                 <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                 <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
                 <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="DataSet4" />
                 <rsweb:ReportDataSource DataSourceId="ObjectDataSource5" Name="DataSet5" />
            </datasources>
        </LocalReport>
                    
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetLiquidacionPagadaTableAdapters.LiquidacionPagadaTableAdapter" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetLiquidacionPagadaTableAdapters.LiquidacionPagadaAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetLiquidacionPagadaTableAdapters.VistaTotalLiquidacionPagadadaTableAdapter" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetLiquidacionPagadaTableAdapters.VistaTotalLiquidacionPagadadaAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetLiquidacionPagadaTableAdapters.VistaTotalDeTodasLasLiquidacionesTableAdapter"></asp:ObjectDataSource>
</asp:Content>