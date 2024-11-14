<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteViajesConfirInter.aspx.cs" Inherits="CapaPresentacion.FormReporteViajesConfirInter" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
    <div id="abrigo_formulario">
        <h2>Seleccione Fecha</h2>
         <table>
        <tr>
            <td style="text-align:right" class="auto-style1">Año</td>
                <td class="auto-style5"><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
                <td style="text-align:right" class="auto-style1">Mes</td>
                <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td><asp:Button ID="ButtonBus" runat="server" Text="Buscar" OnClick="ButtonBus_Click"  />
                    
            </td>
            </tr>
            </table> 
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
          <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportCamionConfirInternacionales.rdlc" ReportPath="ReportCamionConfirInternacionales.rdlc">
         <DataSources>
              <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
         </DataSources>
      </LocalReport> 
    </rsweb:ReportViewer>
<asp:ObjectDataSource id="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetCamionesBercamTableAdapters.Proc_BusquedaViajesInternacionalConfirTableAdapter" >
    <SelectParameters>
        <asp:ControlParameter ControlID="cmMes" Name="mes" PropertyName="SelectedValue" Type="Int32" />
        <asp:ControlParameter ControlID="cmAño" Name="año" PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>
