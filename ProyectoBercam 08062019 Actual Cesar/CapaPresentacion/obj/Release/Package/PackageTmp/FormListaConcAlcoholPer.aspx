<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaConcAlcoholPer.aspx.cs" Inherits="CapaPresentacion.FormListaConcAlcoholPer" %>
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
    <div id="abrigo_Formulario">
        <h2>Lista De Conciliaciones Alcohol Por Periodo</h2>
        <table>
            <tr>
                <td style="text-align:right" class="auto-style1">Año</td>
                <td class="auto-style5"><asp:DropDownList ID="cmdAño" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                 <td style="text-align:right" class="auto-style1">Mes</td>
                <td class="auto-style5"><asp:DropDownList ID="cmPeriodo" runat="server" AutoPostBack="true"></asp:DropDownList></td>
            </tr>
        </table>
        <table>
            <tr>
                <asp:GridView ID="GridViewConciliacion" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AutoGenerateColumns="False" DataKeyNames="Id_Conciliacion" DataSourceID="SqlDataSource1" OnRowCommand="DtgListaConcAlcoholPeriodoRowCommand">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:TemplateField HeaderText="Id_Conciliacion" SortExpression="Id_Conciliacion">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id_Conciliacion") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id_Conciliacion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id_Cliente" SortExpression="Id_Cliente">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id_Cliente") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Id_Cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nro_Conciliacion" SortExpression="Nro_Conciliacion">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Nro_Conciliacion") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Nro_Conciliacion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Imprimir">
                             <ItemTemplate >
                                 <asp:LinkButton ID="LinkImprimir" runat ="server" CausesValidation="false" CommandArgument='<%#Bind("Id_Conciliacion") %>'
                                   CommandName="Imprimir">Imprimir</asp:LinkButton>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Aprobar">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkAprobar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id_Conciliacion") %>'
                                   CommandName="Aprobar">Aprobar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                </asp:GridView>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString %>" SelectCommand="ProcBuscarConcAlcoholPeriodo" SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:ControlParameter ControlID="cmdAño" Name="Año" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="cmPeriodo" Name="Periodo" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        </div> 
</asp:Content>
