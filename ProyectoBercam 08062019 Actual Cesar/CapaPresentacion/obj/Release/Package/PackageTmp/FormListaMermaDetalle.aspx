<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaMermaDetalle.aspx.cs" Inherits="CapaPresentacion.FormListaMermaDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css" >
        .auto-style1{
            width:59px
        }
        .auto-style5{
            height:26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2>Lista De Mermas A modificar</h2>
        <table>
            <tr>
               <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1"> Cliente:</td>
               <td>
                   <asp:TextBox ID="TextBuscarMermaCliente" runat="server" Width="300px" OnTextChanged="TextBuscarMerma_TextChanged" CssClass="auto-style1" ></asp:TextBox>
                 </td>
                <td style="text-align:right" class="auto-style1">Ruta</td>
                <td class="auto-style5"><asp:DropDownList ID="CmRuta" runat="server" AutoPostBack="true"></asp:DropDownList></td>
            </tr>
        </table>
       <table>
           <tr>
               <asp:GridView ID="GridListaMerma" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnRowCommand="DtgListaMerma_RowCommand" >
                   <AlternatingRowStyle BackColor="#DCDCDC" />
                   <Columns>
                       <asp:TemplateField HeaderText="Id" InsertVisible="False" SortExpression="Id">
                           <EditItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Abrev" SortExpression="Abrev">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Abrev") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label2" runat="server" Text='<%# Bind("Abrev") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="MermaMaxima" SortExpression="MermaMaxima">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("MermaMaxima") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label3" runat="server" Text='<%# Bind("MermaMaxima") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="MultaPorProducto" SortExpression="MultaPorProducto">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("MultaPorProducto") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label4" runat="server" Text='<%# Bind("MultaPorProducto") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                 <asp:LinkButton ID="LinkEditar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id") %>'
                                    CommandName="Editar" >Editar</asp:LinkButton>
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
           </tr>
       </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString %>" SelectCommand="MostrarListaMerma" SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:ControlParameter ControlID="CmRuta" DefaultValue="0" Name="IdRuta" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
