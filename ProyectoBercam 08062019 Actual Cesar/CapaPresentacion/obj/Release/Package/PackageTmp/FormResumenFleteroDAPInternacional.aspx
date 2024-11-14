<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormResumenFleteroDAPInternacional.aspx.cs" Inherits="CapaPresentacion.FormResumenFleteroDAPInternacional" %>
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
                <td style="text-align:right" class="auto-style1">Mes</td>
                <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td><asp:Button ID="ButtonBus" runat="server" Text="Buscar" OnClick="ButtonBus_Click"  />
                    
                  </tr>
        </table>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
              <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportResumenFleterosDAPInter.rdlc" ReportPath="ReportResumenFleterosDAPInter.rdlc">
                  <DataSources>
                      <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
              <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
             <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
             <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="DataSet4" />
              <rsweb:ReportDataSource DataSourceId="ObjectDataSource5" Name="DataSet5" />
                  </DataSources>
              </LocalReport>      
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPagarDAPInterTableAdapters.ViResumenDetalleDAPinterPorPagarTableAdapter" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPagarDAPInterTableAdapters.ViResumenTotalPagableDAPinterTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPagarDAPInterTableAdapters.ViTotalTelefoniaDAPinterTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPagarDAPInterTableAdapters.ViTotalRastreoDAPinterTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetResumenConcPagarDAPInterTableAdapters.ViTotalHojaRutaDAPinterTableAdapter"></asp:ObjectDataSource>
</asp:Content>
