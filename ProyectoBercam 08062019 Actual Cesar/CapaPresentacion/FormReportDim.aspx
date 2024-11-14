<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormReportDim.aspx.cs" Inherits="CapaPresentacion.FormReportDim" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
        <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportReporteDim.rdlc" ReportPath="ReportReporteDim.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetDimTableAdapters.ProcReporteDetalleDimTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="Id" PropertyName="Text" Type="Int32" />
        </SelectParameters>

    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetDimTableAdapters.ProcReporteDimTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="Id" PropertyName="Text" Type="Int32" />
        </SelectParameters>

    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetDimTableAdapters.ProcSumTotalReportDimTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="Id" PropertyName="Text" Type="Int32" />
        </SelectParameters>

    </asp:ObjectDataSource>
</asp:Content>
