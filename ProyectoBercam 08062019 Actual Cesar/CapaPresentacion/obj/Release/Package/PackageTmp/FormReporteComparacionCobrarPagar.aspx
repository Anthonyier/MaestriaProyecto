<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteComparacionCobrarPagar.aspx.cs" Inherits="CapaPresentacion.FormReporteComparacionCobrarPagar" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="abrigo_formulario">
        <h2>Seleccione Fecha</h2>
        <table>
            <tr>
                <td style="text-align:right">Año</td>
                <td><asp:DropDownList ID="DdlAño" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td style="text-align:right">Mes</td>
                <td><asp:DropDownList ID="DdlMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td style="text-align:right">Cliente</td>
                <td><asp:DropDownList ID="DdlCliente" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td><asp:Button ID="ButtonBusqueda" runat="server" Text="Buscar" OnClick="ButtonBusqueda_Click" /></td>
            </tr>
        </table>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
          <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportComparacionPagarCobrar.rdlc" ReportPath="ReportComparacionPagarCobrar.rdlc">
              <DataSources>
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                  <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
              </DataSources>
          </LocalReport>          
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetComparacionTableAdapters.ProcCalculoCompararCobrarTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="DdlMes" DefaultValue="" Name="Mes" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DdlAño" Name="IdAño" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DdlCliente" Name="Cliente" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetComparacionTableAdapters.ProcCalculoCompararPagarTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="DdlMes" Name="Mes" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DdlAño" Name="IdAño" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DdlCliente" Name="Cliente" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
