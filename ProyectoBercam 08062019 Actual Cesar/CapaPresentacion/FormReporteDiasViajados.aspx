<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteDiasViajados.aspx.cs" Inherits="CapaPresentacion.FormReporteDiasViajados" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
    <div id="abrigo_formulario">
        <h2>Reporte De Dias Viajados</h2>
        <table>
            <tr>
                <td><asp:Button ID="ButtonBus" runat="server" Text="Actualizar" OnClick="ButtonBus_Click" />
                    
                </td>
            </tr>
        </table>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
        <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportCamiones60dias.rdlc" ReportPath="ReportCamiones60dias.rdlc">
              <DataSources>
                   <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
               </DataSources>
          </LocalReport>           
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetCamionesBercamTableAdapters.VistaDiasNoViajadosTableAdapter" ></asp:ObjectDataSource>
</asp:Content>
