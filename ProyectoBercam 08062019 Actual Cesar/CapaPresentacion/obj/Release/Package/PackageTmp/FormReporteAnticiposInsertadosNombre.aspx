<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteAnticiposInsertadosNombre.aspx.cs" Inherits="CapaPresentacion.FormReporteAnticiposInsertadosNombre" %>
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
                <td style="text-align:right" class="auto-style1">Mes
            </td>
                <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList>
            </td>
             <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:TextBox ID="TextTitularBuscarAnticipoInsertado" runat="server" Width="100px"></asp:TextBox>
                        </asp:Panel>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                <td><asp:Button ID="ButtonBus" runat="server" Text="Buscar" OnClick="ButtonBus_Click" />      
            </td>
            </tr>
            </table> 
         </div> 
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
            <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportAnticipoInsertadoNombre.rdlc" ReportPath="ReportAnticipoInsertadoNombre.rdlc">
            <datasources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                 <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                 <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
                 <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="DataSet4" />
            </datasources>
        </LocalReport>              
    </rsweb:ReportViewer>
     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetAnticiposNombreTableAdapters.VistaDetalleAnticiposInsertadosTableAdapter"  ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetAnticiposNombreTableAdapters.VistaDetalleAnticiposInsertadosAceiteTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetAnticiposNombreTableAdapters.VistaTotalInsertadosTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetAnticiposNombreTableAdapters.VistaTotalInsertadosAceiteTableAdapter"></asp:ObjectDataSource>
</asp:Content>
