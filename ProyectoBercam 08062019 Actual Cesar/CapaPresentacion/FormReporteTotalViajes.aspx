<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteTotalViajes.aspx.cs" Inherits="CapaPresentacion.FormReporteTotalViajes" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" >
    </asp:ScriptManager>
        <div id="abrigo_formulario">
            <h2>
                Seleccion Fecha
            </h2>
            <table>
                <tr>
                    <td style="text-align:right">Año</td>
                    <td><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                    <td style="text-align:right">Mes</td>
                    <td><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                    <td><asp:Button ID="ButtonBus" runat="server" Text="Buscar" OnClick="ButtonBus_Click" />
                        
                    </td>
                </tr>
            </table>
        </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
              <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportNumeroViajes.rdlc" ReportPath="ReportNumeroViajes.rdlc">
                  <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                  </DataSources>
              </LocalReport>          
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetViNominaTableAdapters.ProcObtenerListaViajesTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="cmMes" Name="IdMes" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="cmAño" Name="IdAño" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>

    </asp:ObjectDataSource>
</asp:Content>
