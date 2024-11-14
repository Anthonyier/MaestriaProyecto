<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormRepConcPagar.aspx.cs" Inherits="CapaPresentacion.FormRepConcPagar" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:TextBox ID="TextBus" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonBus" runat="server"  Text="Buscar" OnClick="ButtonBus_Click" />
    <asp:Button ID="ButtonAnticip" Visible="false" runat="server" Text="Anticipo" OnClick="ButtonAnticip_Click" />
    <asp:TextBox ID="TextAnticip" Visible="false" runat="server"></asp:TextBox>
      <asp:Button ID="ButtonPagar" Visible="false" runat="server" Text="TotalPagable" OnClick="ButtonPagar_Click" />
    <asp:TextBox ID="TextBoxLiquido" Visible="false"  runat="server"></asp:TextBox>
    <asp:Button ID="ButtonSolicitud" Visible="false"  runat="server" Text="Solicitud" OnClick="ButtonSolicitud_Click" />
    <br />
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
    <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportConciliacionPagar.rdlc" ReportPath="ReportConciliacionPagar.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource7" Name="DataSet1" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource8" Name="DataSet2" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource9" Name="DataSet3" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource10" Name ="DataSet4" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource11" Name="DataSet5" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource12" Name="DataSet6" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource13" Name="DataSet7" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource14" Name="DataSet8" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource15" Name="DataSet9" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource16" Name="DataSet10" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource17" Name="DataSet11" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource18" Name="DataSet12" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource19" Name="DataSet13" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource20" Name="DataSet14" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource21" Name="DataSet15" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource22" Name="DataSet16" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource23" Name="DataSet17" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource24" Name="DataSet18" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource25" Name="DataSet19" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource10" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.VistaDetalleAnticipoTableAdapter"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="ObjectDataSource9" runat="server" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.Vi_TotalConciliacionPorPagarTableAdapter" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.ViConciliacionPagarTableAdapter" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.ViReportConcilPagarTableAdapter" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource11" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.ViListaDetalleGuiaTableAdapter" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource12" runat ="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.ViDetalleServiciosTableAdapter" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource13" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.TotalNumeroAnticiposTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource14" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.ViTotalCamionGuiaTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource15" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.ViTotalServiciosTableAdapter"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="ObjectDataSource16" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.VistaDeAdelantosTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource17" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.TotalNumeroAdelantosTableAdapter" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource18" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.ConciliacionPagAñoPerTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource19" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.MultaConciliacioTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource20" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.VistaDetalleAnticipAutoTableAdapter" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource21" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.VistaDefinAnticiposTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource22" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.VistaDetalleAdelantoDePagosTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource23" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.TotalAdelantoPagosTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource24" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.TotalDefiAdelPagTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource25" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarTableAdapters.VistaTotalAnticiposAutTableAdapter"></asp:ObjectDataSource>
</asp:Content>
