<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaSolicitudPagos.aspx.cs" Inherits="CapaPresentacion.FormListaSolicitudPagos" %>
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
        <h2>Lista de Solicitudes De Pago </h2>
        <table>
            <tr>
                <td style="text-align:right" class="auto-style1">Dia</td>
                <td class="auto-style5"><asp:TextBox ID="TextDia" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox></td>
                <td style="text-align:right" class="auto-style1">Mes</td>
                <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                  <td style="text-align:right" class="auto-style1">Año</td>
                <td class="auto-style5"><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
                
            </tr>
            </table> 
          <table>
              <tr>
                  <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id,Conciliacion" DataSourceID="SqlDataSource1" OnRowCommand="DtgListaSolicitudPago_RowCommand">
                      <AlternatingRowStyle BackColor="White" />
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
                                  <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PorPagar") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label5" runat="server" Text='<%# Bind("PorPagar") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Solicitud" SortExpression="Solicitud" Visible="False">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Solicitud") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label6" runat="server" Text='<%# Bind("Solicitud") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="FechaSolicitud" SortExpression="FechaSolicitud">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("FechaSolicitud") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label7" runat="server" Text='<%# Bind("FechaSolicitud") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Conciliacion" SortExpression="Conciliacion">
                              <EditItemTemplate>
                                  <asp:Label ID="Label3" runat="server" Text='<%# Eval("Conciliacion") %>'></asp:Label>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label8" runat="server" Text='<%# Bind("Conciliacion") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Pagar">
                              <ItemTemplate>
                                 <asp:LinkButton ID="LinkRevisar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Conciliacion") %>'
                                    CommandName="Confirmar" OnClientClick="return confirm('Esta seguro de Afirmar Pago de la Conciliacion?');">Pagar</asp:LinkButton>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <%--<asp:TemplateField HeaderText="Pagar Sin Factura">
                              <ItemTemplate>
                                  <asp:LinkButton ID="LinkSinFactura" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Conciliacion") %>'
                                     CommandName="SinFactura" OnClientClick="return confirm('Estas seguro de Afirmar Pago de la Conciliacion Sin Factura?');" >
                                      Pagar Sin Factura
                                  </asp:LinkButton>
                              </ItemTemplate>
                          </asp:TemplateField>--%>
                      </Columns>
                      <EditRowStyle BackColor="#7C6F57" />
                      <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                      <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                      <RowStyle BackColor="#E3EAEB" />
                      <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                      <SortedAscendingCellStyle BackColor="#F8FAFA" />
                      <SortedAscendingHeaderStyle BackColor="#246B61" />
                      <SortedDescendingCellStyle BackColor="#D4DFE1" />
                      <SortedDescendingHeaderStyle BackColor="#15524A" />

                  </asp:GridView>
              </tr>
          </table>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString %>" SelectCommand="ProcSolicitudPagos" SelectCommandType="StoredProcedure" >
              <SelectParameters>
                  <asp:ControlParameter ControlID="TextDia" DefaultValue="1" Name="Dia" PropertyName="Text" Type="Int32" />
                  <asp:ControlParameter ControlID="cmMes" DefaultValue="1" Name="Mes" PropertyName="SelectedValue" Type="Int32" />
                  <asp:ControlParameter ControlID="cmAño" DefaultValue="2000" Name="Año" PropertyName="SelectedValue" Type="string" />
              </SelectParameters>
          </asp:SqlDataSource>
          </div> 

</asp:Content>
