<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormRepConcRefPagar2023.aspx.cs" Inherits="CapaPresentacion.FormRepConcRefPagar2023" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:TextBox ID="TextBus" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonBus" runat="server"  Text="Buscar" OnClick="ButtonBus_Click" />
        <br />
       <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
            <LocalReport ReportEmbeddedResource="CapaPresentacion.ReportConcPagarRef2023.rdlc" ReportPath="ReportConcPagarRef2023.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="DataSet4" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource5" Name="DataSet5"/>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource6" Name="DataSet6"/>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource7" Name="DataSet7" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource8" Name="DataSet8" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource9" Name="DataSet9" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource10" Name="DataSet10" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource11" Name="DataSet11" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource12" Name="DataSet12" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource13" Name="DataSet13"/>
                </DataSources>
             </LocalReport>
       </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcReportConcilPagarTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
       </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcUnionReportConcNombreTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcSumReportConcTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcReportConciliacionPagarTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcAnticiposAutRepTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcReporteTipoContratoTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcSumRepAntTotalTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcRepDetServiciosTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource9" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcReportTotalServiciosTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource10" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcReporteAdelantosTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
       </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource11" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcSumRepDescuentoTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
       </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource12" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcReporteAdelantoDePagoTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
       </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource13" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CapaPresentacion.DataSetProcReporteTableAdapters.ProcReporteTotalAdelantoDePagosTableAdapter" >
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBus" Name="IdConciliacion" PropertyName="Text" Type="Int32" />
        </SelectParameters>
       </asp:ObjectDataSource>
</asp:Content>
