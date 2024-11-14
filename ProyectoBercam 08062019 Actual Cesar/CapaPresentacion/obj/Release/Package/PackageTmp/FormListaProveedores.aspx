<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaProveedores.aspx.cs" Inherits="CapaPresentacion.FormListaProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="abrigo_formulario">
        <h2>Listas de Proveedores</h2>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="GridProveedor" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AutoGenerateColumns="False" DataKeyNames="Id_Proveedores" DataSourceID="SqlDataSource1"  >
                         <AlternatingRowStyle BackColor="PaleGoldenrod" />
                         <Columns>
                             <asp:TemplateField HeaderText="Id_Proveedores" InsertVisible="False" SortExpression="Id_Proveedores">
                                 <EditItemTemplate>
                                     <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id_Proveedores") %>'></asp:Label>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id_Proveedores") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="CI" SortExpression="CI">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CI") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("CI") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                                 <EditItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label3" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Direccion" SortExpression="Direccion">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label4" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Telefono" SortExpression="Telefono">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label5" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="TelfReferencia" SortExpression="TelfReferencia">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("TelfReferencia") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label6" runat="server" Text='<%# Bind("TelfReferencia") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label7" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Emision" SortExpression="Emision">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Emision") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label8" runat="server" Text='<%# Bind("Emision") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Estado" SortExpression="Estado" Visible="False">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Estado") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label9" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Fecha_Registro" SortExpression="Fecha_Registro" Visible="False">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Fecha_Registro") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label10" runat="server" Text='<%# Bind("Fecha_Registro") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Cod_Ente" SortExpression="Cod_Ente" Visible="False">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Cod_Ente") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label11" runat="server" Text='<%# Bind("Cod_Ente") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Editar">
                                  <ItemTemplate>
                                <asp:LinkButton ID="LinkEditar" runat="server">Editar</asp:LinkButton>
                            </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Deshabilitar">
                                 <ItemTemplate>
                                <asp:LinkButton ID="LinkDeshabilitar" runat="server" 
                                    OnClientClick="return confirm('Esta seguro que desea ANULAR la Persona?');">Anular</asp:LinkButton>
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
                 </td>
             </tr>
             </table> 
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString %>" SelectCommand="SELECT * FROM [vi_ListaProveedores]" ></asp:SqlDataSource>
          </div>
</asp:Content>
