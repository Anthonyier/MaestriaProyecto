<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteDescuentos.aspx.cs" Inherits="CapaPresentacion.FormReporteDescuentos" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <div id="abrigo_formulario">
      
        <table>
            
        <tr>
                <td style="text-align:right" class="auto-style1">Año</td>
                <td class="auto-style5"><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmAño_SelectedIndexChanged" ></asp:DropDownList></td>
                <td style="text-align:right" class="auto-style1">Monto</td>
                <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmMes_SelectedIndexChanged"></asp:DropDownList></td>
               <td style="text-align:right; font-size:large; font-family:Calibri;" class="auto-style1">Titular</td>
                <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:TextBox ID="TextoPlacasDescuenReportes" runat="server" Width="300px" OnTextChanged="TextoPlacasDescuenReportes_TextChanged" ></asp:TextBox>
                        </asp:Panel>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
            <td>
                <asp:HiddenField id="TextHid" runat="server" OnValueChanged="TextHid_ValueChanged"></asp:HiddenField>
            </td>
             <td><asp:Button ID="ButtonFecha" runat="server" Text="BuscarFecha" OnClick="ButtonFecha_Click"></asp:Button></td>
             <td><asp:Button ID="ButtonBus" Width="150px" runat="server" Text="Buscar Reporte" OnClick="ButtonBus_Click" />
                 
            </tr>
        </table>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
        <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportDescuento.rdlc" ReportPath="ReportDescuento.rdlc">
         <DataSources>
              <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
              <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
              <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
         </DataSources>
      </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetDescuentosTableAdapters.ViewListaDescuentosTableAdapter" ></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetDescuentosTableAdapters.ViewConcilicionDescuentoTotalTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetDescuentosTableAdapters.ViewConciliacionDescuentoTotalMejoradoTableAdapter"></asp:ObjectDataSource>
</asp:Content>
