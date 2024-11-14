<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteSeguros.aspx.cs" Inherits="CapaPresentacion.FormReporteSeguros" %>
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
                <td style="text-align:right">Cliente</td>
                <td style="text-align:right"><asp:DropDownList ID="DdlCliente" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td><asp:Button ID="ButtonBus" runat="server" Text="Buscar" OnClick="ButtonBus_Click"  />
            </td>
            </tr>
            </table> 
         </div> 
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
         <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportSeguroFletero.rdlc" ReportPath="ReportSeguroFletero.rdlc">
         <DataSources>
              <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet2" />
             <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet1" />
             <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
         </DataSources>
      </LocalReport> 
    </rsweb:ReportViewer>
    <asp:ObjectDataSource id="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetSegurosFleterosTableAdapters.ProcPrimaSeguroTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="cmMes" DefaultValue="1" Name="Mes" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="cmAño" DefaultValue="1" Name="Año" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DdlCliente" DefaultValue="1" Name="IdTipoContrato" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetSegurosFleterosTableAdapters.ViPrimaSeguroTableAdapter" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetSegurosFleterosTableAdapters.TotalProcPrimaSeguroTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmMes" DefaultValue="1" Name="IdMes" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="cmAño" DefaultValue="1" Name="IdAño" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DdlCliente" DefaultValue="" Name="IdTipoContrato" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
</asp:Content>
