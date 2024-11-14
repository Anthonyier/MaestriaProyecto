<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReporteAplicacion.aspx.cs" Inherits="CapaPresentacion.FormReporteAplicacion" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager1" runat="server" ></asp:ScriptManager>
    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" ></asp:TextBox>
    <asp:Button Id="Button1" runat="server" Text="Buscar" OnClick="Button1_Click"/>
    
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
        <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportAplicacionDim.rdlc" ReportPath="ReportAplicacionDim.rdlc" >
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetAplicacionDimTableAdapters.ProcBuscarAplicacionDimReporteTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="Id" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
