<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaNroContratoAceite.aspx.cs" Inherits="CapaPresentacion.FormListaNroContratoAceite" %>
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
     <div id="abrigo_formulario">
        <h2> Lista Conciliacion Aceite</h2>
        <table>
            <tr>
                <td style="text-align:right" class="auto-style1">Año</td>
                <td class="auto-style5"><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
                <td style="text-align:right" class="auto-style1">Mes</td>
                <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
            </tr>
        </table>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="GridViewContratoAceite" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="IdConciliacion" DataSourceID="SqlDataSource1" OnRowCommand="DtgListaNumeroConci_RowCommand" >
                         <AlternatingRowStyle BackColor="White" />
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
                             <asp:TemplateField HeaderText="FechaRegisto" SortExpression="FechaRegisto" Visible="False">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FechaRegisto") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label3" runat="server" Text='<%# Bind("FechaRegisto") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="IdMes" SortExpression="IdMes" Visible="False">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("IdMes") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label4" runat="server" Text='<%# Bind("IdMes") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="IdAño" SortExpression="IdAño" Visible="False">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("IdAño") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label5" runat="server" Text='<%# Bind("IdAño") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="NumeroContrato">
                                  <ItemTemplate >
                                 <asp:LinkButton ID="LinkNumeroContrato" runat ="server" CausesValidation="false" CommandArgument='<%#Bind("IdConciliacion") %>'
                                   CommandName="NumeroDeContrato">NumeroDeContrato</asp:LinkButton>
                             </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                         <EditRowStyle BackColor="#2461BF" />
                         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                         <RowStyle BackColor="#EFF3FB" />
                         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                         <SortedAscendingCellStyle BackColor="#F5F7FB" />
                         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                         <SortedDescendingCellStyle BackColor="#E9EBEF" />
                         <SortedDescendingHeaderStyle BackColor="#4870BE" />
                     </asp:GridView>
                 </td>
             </tr>
         </table>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString %>" SelectCommand="ProListaAceiteContrato" SelectCommandType="StoredProcedure" >
             <SelectParameters>
                 <asp:ControlParameter ControlID="cmMes" DefaultValue="1" Name="IdMes" PropertyName="SelectedValue" Type="Int32" />
                 <asp:ControlParameter ControlID="cmAño" DefaultValue="21" Name="IdAño" PropertyName="SelectedValue" Type="Int32" />
             </SelectParameters>
         </asp:SqlDataSource>
         </div> 
    
</asp:Content>
