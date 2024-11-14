<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaMultas.aspx.cs" Inherits="CapaPresentacion.FormListaMultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="abrigo_formulario">
        <h2>Listas de Multas</h2>
         <table>
             <tr>
                 <td>

                 </td>
                 <td>
                     <asp:GridView runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" AllowPaging="True" OnRowCommand="DtgListaMulta_RowCommand"  >
                         <AlternatingRowStyle BackColor="#DCDCDC" />
                         <Columns>
                             <asp:TemplateField HeaderText="id" SortExpression="id">
                                 <EditItemTemplate>
                                     <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Concepto" SortExpression="Concepto">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Concepto") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("Concepto") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Multa" SortExpression="Multa">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Multa") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label3" runat="server" Text='<%# Bind("Multa") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Estado") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label4" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" SortExpression="IdCliente" />
                             <asp:TemplateField HeaderText="Cliente" SortExpression="Cliente">
                                 <EditItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%# Eval("Cliente") %>'></asp:Label>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label5" runat="server" Text='<%# Bind("Cliente") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Editar">
                                  <ItemTemplate>
                                <asp:LinkButton ID="LinkEditar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("id") %>'
                                    CommandName=EditarMulta>Editar</asp:LinkButton>
                            </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Deshabilitar">
                                 <ItemTemplate>
                                <asp:LinkButton ID="LinkDeshabilitar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("id") %>'
                                    CommandName="DeshabilitarMulta" OnClientClick="return confirm('Esta seguro que desea ANULAR la Persona?');">Anular</asp:LinkButton>
                            </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                         <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                         <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                         <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                         <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#0000A9" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#000065" />
                     </asp:GridView>
                 </td>
             </tr>
         </table>
         <asp:SqlDataSource Id="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString %>" SelectCommand="SELECT * FROM [ViewMultas] order by id"></asp:SqlDataSource>
         </div> 
</asp:Content>
