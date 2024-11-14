<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteAceiteAPagar.aspx.cs" Inherits="CapaPresentacion.FormReporteAceiteAPagar" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:TextBox ID="TextBus" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonBus" runat="server" Text="Buscar" OnClick="ButtonBus_Click"  />
    <asp:Button ID="ButtonAnticip" Visible="false" runat="server" Text="Anticipo" OnClick="ButtonAnticip_Click"/>
    <asp:TextBox ID="TextAnticip" Visible="false" runat="server"></asp:TextBox>
      <asp:Button ID="ButtonPagar" Visible="false" runat="server" Text="TotalPagable" OnClick="ButtonPagar_Click"  />
    <asp:TextBox ID="TextBoxLiquido" Visible="false" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonSolicitud" Visible="false"  runat="server" Text="Solicitud" OnClick="ButtonSolicitud_Click"  />
    <div id="abrigo_formulario">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
            <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportConciliacionPagarAceite.rdlc" ReportPath="ReportConciliacionPagarAceite.rdlc">
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
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource11" Name ="DataSet11" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource12" Name="DataSet12" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource13" Name="DataSet13" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource14" Name="DataSet14" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource15" Name="DataSet15" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource16" Name="DataSet16" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource17" Name="DataSet17" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource18" Name="DataSet18" />
                </DataSources>
            </LocalReport> 
        </rsweb:ReportViewer>
        </div> 
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.ViDetalleConcPagarAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.DetalleServiciosAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.ViAnticipoConciliacionPagarAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.TotalSumaConcAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.VistaConciliacionTotalAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.TotalServicioAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.SumaTotalAnticiposAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.VistaNombreTitularAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource9" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.NombreEmpresaConcAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource10" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.VistaDetalleAnticipoAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource11" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.TotalNumeroAnticiposAceiteTableAdapter" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource12" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.ViSumaAceiteAnticiposAutoTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource13" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.ViTotalAceiteAnticiposTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource14" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.VistaDeAdelantosAceiteMejorTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource15" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.VistaDescuentosAceiteTotalTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource16" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.AdelantoAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource17" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.ViTotalAdelantosAceiteTableAdapter"></asp:ObjectDataSource> 
    <asp:ObjectDataSource ID="ObjectDataSource18" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetConciliacionPagarAceiteTableAdapters.VistaDescuenAdelantAceiteTableAdapter"></asp:ObjectDataSource>
    <br />
</asp:Content>
