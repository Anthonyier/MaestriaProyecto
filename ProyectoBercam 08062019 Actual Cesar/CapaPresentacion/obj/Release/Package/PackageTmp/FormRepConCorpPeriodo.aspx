<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormRepConCorpPeriodo.aspx.cs" Inherits="CapaPresentacion.FormRepConCorpPeiodo" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:TextBox ID="TextBus" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonBus" runat="server" Text="Buscar" OnClick="ButtonBus_Click" />
    
    <div id="abrigo_formulario">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
            <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportConciliacionAlcoholPeriodo.rdlc" ReportPath="ReportConciliacionAlcoholPeriodo.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="DataSet4" />
                </DataSources>
            </LocalReport>
    </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetAlcPeriodoTableAdapters.VistaAlcoholPeriodoTableAdapter" ></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetAlcPeriodoTableAdapters.TotalConciliacionTableAdapter" ></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetAlcPeriodoTableAdapters.CantidadCorporacionTableAdapter" ></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetAlcPeriodoTableAdapters.VistaPeriodoAlcohol1TableAdapter"></asp:ObjectDataSource>
    </div>
</asp:Content>
