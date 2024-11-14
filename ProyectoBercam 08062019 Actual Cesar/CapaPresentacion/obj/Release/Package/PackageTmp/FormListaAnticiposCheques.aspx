<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaAnticiposCheques.aspx.cs" Inherits="CapaPresentacion.FormListaAnticiposCheques" %>
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
        
            <h2>Lista De Viajes</h2>
            <table>
                <tr>
                    <td style="text-align:right" class="auto-style1"> Dia</td>
                    <td class="auto-style5"><asp:TextBox ID="TextDia" runat="server" Width="70px" Font-Size="Smaller" ></asp:TextBox></td>
                    <td style ="text-align:right" class="auto-style1">Mes</td>
                    <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
                    <td style="text-align:right" class="auto-style1">Año</td>
                    <td class="auto-style5"><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
                </tr>
            </table>
               <table>
                   <tr>
                       <td><asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AutoGenerateColumns="False" DataKeyNames="Id_Detalle" DataSourceID="SqlDataSource1" OnRowCommand="DtgListaAnticipoCheque_RowCommand">
                           <AlternatingRowStyle BackColor="PaleGoldenrod" />
                           <Columns>
                               <asp:TemplateField HeaderText="Id_Detalle" SortExpression="Id_Detalle" Visible="False">
                                   <EditItemTemplate>
                                       <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id_Detalle") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id_Detalle") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Id_Recepcion" SortExpression="Id_Recepcion" Visible="False">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id_Recepcion") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("Id_Recepcion") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Monto_Anticipo" SortExpression="Monto_Anticipo">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Monto_Anticipo") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label3" runat="server" Text='<%# Bind("Monto_Anticipo") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="FechaCarga" SortExpression="FechaCarga" Visible="False">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("FechaCarga") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("FechaCarga") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="FechaRegistro" SortExpression="FechaRegistro" Visible="False">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("FechaRegistro") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label5" runat="server" Text='<%# Bind("FechaRegistro") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Placa" SortExpression="Placa" Visible="False">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Placa") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label6" runat="server" Text='<%# Bind("Placa") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                                   <EditItemTemplate>
                                       <asp:Label ID="Label2" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label7" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="CI" SortExpression="CI" Visible="False">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("CI") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label8" runat="server" Text='<%# Bind("CI") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                             <asp:TemplateField HeaderText="Agregar Documento">
                             <ItemTemplate>
                                <asp:LinkButton ID="LinkAgregar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id_Detalle") %>'
                                    CommandName="AgregarDocumento" >Agregar Documento</asp:LinkButton>
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
                           </asp:GridView></td>
                   </tr>
               </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString %>" SelectCommand="AnticiposPorCheque" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextDia" DefaultValue="1" Name="IdDia" PropertyName="Text" Type="Int32" />
                <asp:ControlParameter ControlID="cmMes" DefaultValue="1" Name="IdMes" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="cmAño" DefaultValue="1" Name="IdAño" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>
    </div>
</asp:Content>
