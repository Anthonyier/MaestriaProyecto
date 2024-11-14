<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormPagadoCorp.aspx.cs" Inherits="CapaPresentacion.FormPagadoCorp" %>
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
        <h2>Lista De Conciliaciones de Corporacion Pagadas</h2>
        <table>
             <tr>
                <td style="text-align:right" class="auto-style1">Mes</td>
                <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td style="text-align:right" class="auto-style1">Año</td>
                <td class="auto-style5"><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
             </tr>
            </table> 
          <table>
              <tr>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="id,Conciliacion" DataSourceID="SqlDataSource1" GridLines="None" OnRowCommand="DtgPagadosCorp_RowCommand" >
                  <Columns>
                      <asp:TemplateField HeaderText="id" SortExpression="id">
                          <EditItemTemplate>
                              <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                          <EditItemTemplate>
                              <asp:Label ID="Label2" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="NroCuenta" SortExpression="NroCuenta">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NroCuenta") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Label3" runat="server" Text='<%# Bind("NroCuenta") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Label4" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="PorPagar" SortExpression="PorPagar">
                          <EditItemTemplate>
                              <asp:Label ID="Label3" runat="server" Text='<%# Eval("PorPagar") %>'></asp:Label>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Label5" runat="server" Text='<%# Bind("PorPagar") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Solicitud" SortExpression="Solicitud" Visible="False">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Solicitud") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Label6" runat="server" Text='<%# Bind("Solicitud") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="IdMes" SortExpression="IdMes" Visible="False">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("IdMes") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Label7" runat="server" Text='<%# Bind("IdMes") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="IdAño" SortExpression="IdAño" Visible="False">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("IdAño") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Label8" runat="server" Text='<%# Bind("IdAño") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Conciliacion" SortExpression="Conciliacion">
                          <EditItemTemplate>
                              <asp:Label ID="Label4" runat="server" Text='<%# Eval("Conciliacion") %>'></asp:Label>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Label9" runat="server" Text='<%# Bind("Conciliacion") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                       <asp:TemplateField HeaderText="Descargar">
                           <ItemTemplate>
                                 <asp:LinkButton ID="LinkRevisar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Conciliacion") %>'
                                    CommandName="Descargar" >Descargar</asp:LinkButton>
                            </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Visualizar">
                          <ItemTemplate>
                                 <asp:LinkButton ID="LinkVisualizar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Conciliacion") %>'
                                    CommandName="Visualizar" >Visualizar</asp:LinkButton>
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
                  </tr>
          </table>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString %>" SelectCommand="ProcPagadoCorp" SelectCommandType="StoredProcedure">
              <SelectParameters>
                  <asp:ControlParameter ControlID="cmMes" Name="IdMes" PropertyName="SelectedValue" Type="Int32" />
                  <asp:ControlParameter ControlID="cmAño" Name="IdAño" PropertyName="SelectedValue" Type="Int32" />
              </SelectParameters>
          </asp:SqlDataSource>
          </div> 

   
</asp:Content>
