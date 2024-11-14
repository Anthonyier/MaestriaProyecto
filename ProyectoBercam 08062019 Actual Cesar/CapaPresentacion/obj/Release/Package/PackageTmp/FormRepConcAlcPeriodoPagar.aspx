<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormRepConcAlcPeriodoPagar.aspx.cs" Inherits="CapaPresentacion.FormRepConcAlcPeriodoPagar" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:TextBox ID="TextBus" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonBus" runat="server" Text="Buscar" OnClick="ButtonBus_Click"  />
    <asp:Button ID="ButtonAnticip" runat="server" Text="Anticipo" Visible="false" OnClick="ButtonAnticip_Click"/>
    <asp:TextBox ID="TextAnticip" runat="server" Visible="false" ></asp:TextBox>
      <asp:Button ID="ButtonPagar" runat="server" Text="TotalPagable" Visible="false"  OnClick="ButtonPagar_Click" />
    <asp:TextBox ID="TextBoxLiquido" runat="server" Visible="false"></asp:TextBox>
    <asp:Button ID="ButtonSolicitud" runat="server" Text="Solicitud" Visible="false" OnClick="ButtonSolicitud_Click" />
      <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
          <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportConciliacionPagarAlcoholPeriodo.rdlc" ReportPath="ReportConciliacionPagarAlcoholPeriodo.rdlc">
              <DataSources>
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="DataSet4" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource5" Name="DataSet5" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource6" Name="DataSet6" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource7" Name="DataSet7" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource8" Name="DataSet8" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource9" Name="DataSet9" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource10" Name="DataSet10" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource11" Name="DataSet12" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource12" Name="DataSet11" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource13" Name="DataSet13" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource14" Name="DataSet14" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource15" Name="DataSet15" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource16" Name="DataSet16" />
                   <rsweb:ReportDataSource DataSourceId="ObjectDataSource17" Name="DataSet17" />
              </DataSources>
          </LocalReport>
      </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConcPagarCorpAlcoholTableAdapters.TotalNumeroAnticiposTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.VistaDetalleAnticipoTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.ViTotalServiciosTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.ViDetalleServiciosTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.ViConciliacionPagarTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.Vi_TotalConciliacionPorPagarTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.ViReportConcCorPagarAlcperiodoTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.VistaDeAdelantosTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource9" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.TotalNumeroAdelantosTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource10" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.MultaConciliacioTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource11" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.ConciliacionPagAñoPerTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource12" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.VistaDetalleAnticipAutoTableAdapter"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource13" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.VistaDefinAnticiposTableAdapter"></asp:ObjectDataSource> 
      <asp:ObjectDataSource ID="ObjectDataSource14" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.VistaDetalleAdelantoDePagosTableAdapter" ></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource15" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.TotalAdelantoPagosTableAdapter" ></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ObjectDataSource16" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.TotalDefiAdelPagTableAdapter"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="ObjectDataSource17" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciPagarAlcoPeriTableAdapters.VistaTotalAnticiposAutTableAdapter" ></asp:ObjectDataSource>
    <br />
</asp:Content>
