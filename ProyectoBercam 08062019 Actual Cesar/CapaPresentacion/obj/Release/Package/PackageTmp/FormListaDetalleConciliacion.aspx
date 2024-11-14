<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaDetalleConciliacion.aspx.cs" Inherits="CapaPresentacion.FormListaDetalleConciliacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 59px;
        }
        .auto-style3 {
            width: 239px;
        }
        .auto-style4 {
            width: 240px;
        }
        .auto-style5 {
            width: 239px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2>Listas de camiones</h2>
        <table >
            <tr>
                <td style="text-align:right" class="auto-style5">Buscar Nro Conciliacion:</td>
                <td class="auto-style6"><asp:DropDownList ID="cmConciliacion" runat="server" ></asp:DropDownList></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridViewConciliaciones" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" >
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
          <asp:SqlDataSource ID="SqlDataSource2" runat="server" ></asp:SqlDataSource>
        </div> 
</asp:Content>
