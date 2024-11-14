<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormDescuentosPorNombre.aspx.cs" Inherits="CapaPresentacion.FormDescuentosPorNombre" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" >

    </asp:ScriptManager>
    <div id="abrigo_formulario">
        <table>
            <tr>
                <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:TextBox ID="TextBoxNombrePersonaDescuento" runat="server" width="300px"></asp:TextBox>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                    </td>
                <td><asp:Button ID="ButtonEncontrar" runat="server" Text="Buscar" OnClick="ButtonEncontrar_Click"></asp:Button></td>
            </tr>
        </table>
    </div>
      <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
                 <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportDescuentoPorNombre.rdlc" ReportPath="ReportDescuentoPorNombre.rdlc">
                     <DataSources>
                         <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                     </DataSources>
                 </LocalReport>   
      </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetDescuentosTableAdapters.ViewListaDescuentosTableAdapter"></asp:ObjectDataSource>
</asp:Content>
