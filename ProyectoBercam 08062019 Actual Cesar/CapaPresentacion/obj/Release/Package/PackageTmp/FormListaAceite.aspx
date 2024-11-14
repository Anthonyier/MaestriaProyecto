<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaAceite.aspx.cs" Inherits="CapaPresentacion.FormListaAceite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2>Listas De Programacion De Aceite</h2>
        <table>
            <tr>
                <td style="text-align:right" >Mes</td>
                 <td><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                  <td style="text-align:right">Año</td>
                <td><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" DataKeyNames="IdConciliacion" DataSourceID="SqlDataSource1" OnRowCommand="DtgListaAceite_RowCommand">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:TemplateField HeaderText="IdConciliacion" SortExpression="IdConciliacion">
                                <EditItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("IdConciliacion") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("IdConciliacion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Empresa" SortExpression="Empresa">
                                <EditItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Empresa") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Empresa") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Imprimir">
                                <ItemTemplate >
                                 <asp:LinkButton ID="LinkImprimir" runat ="server" CausesValidation="false" CommandArgument='<%#Bind("IdConciliacion") %>'
                                   CommandName="Imprimir">Imprimir</asp:LinkButton>
                             </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Aprobar">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkAprobar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("IdConciliacion") %>'
                                      CommandName="Aprobar">Aprobar</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString2 %>" SelectCommand="ProcListaAceite" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmMes" DefaultValue="0" Name="IdMes" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="cmAño" DefaultValue="0" Name="IdAño" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
