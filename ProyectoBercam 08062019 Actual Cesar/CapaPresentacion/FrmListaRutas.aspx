<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FrmListaRutas.aspx.cs" Inherits="CapaPresentacion.ListaRutas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2> Lista de Rutas</h2>
         <table>
             <td>
                 <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellSpacing="1" GridLines="None" OnRowCommand="DtgListaRuta_RowCommand" >
                     <Columns>
                         <asp:TemplateField HeaderText="Id_Ruta" SortExpression="Id_Ruta">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id_Ruta") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id_Ruta") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Ruta" SortExpression="Ruta">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Ruta") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label2" runat="server" Text='<%# Bind("Ruta") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="MontoAnticipo" SortExpression="MontoAnticipo">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("MontoAnticipo") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label3" runat="server" Text='<%# Bind("MontoAnticipo") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="PrecioTotal" SortExpression="PrecioTotal">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PrecioTotal") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label4" runat="server" Text='<%# Bind("PrecioTotal") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Id_Producto" SortExpression="Id_Producto">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Id_Producto") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label5" runat="server" Text='<%# Bind("Id_Producto") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Id_Cliente" SortExpression="Id_Cliente">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Id_Cliente") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label6" runat="server" Text='<%# Bind("Id_Cliente") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Id_Persona" SortExpression="Id_Persona">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Id_Persona") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label7" runat="server" Text='<%# Bind("Id_Persona") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="CI" SortExpression="CI">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("CI") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label8" runat="server" Text='<%# Bind("CI") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label9" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Apellidos" SortExpression="Apellidos">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Apellidos") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label10" runat="server" Text='<%# Bind("Apellidos") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label11" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="EditarRuta">
                               <ItemTemplate>
                                <asp:LinkButton ID="LinkEditar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id_Ruta") %>'
                                    CommandName="EditarRuta">Editar</asp:LinkButton>
                            </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                     <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                     <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                     <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                     <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                     <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#594B9C" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#33276A" />
                     </asp:GridView>
                     </td>
         </table>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString5 %>" SelectCommand="SELECT * FROM [Vi_ListaRuta]"></asp:SqlDataSource>
    </div>
</asp:Content>
