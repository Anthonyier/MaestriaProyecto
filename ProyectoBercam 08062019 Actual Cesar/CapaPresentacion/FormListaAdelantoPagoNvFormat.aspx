<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaAdelantoPagoNvFormat.aspx.cs" Inherits="CapaPresentacion.FormListaAdelantoPagoNvFormat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1{
            width: 59px
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
        <asp:Panel ID="Panel1" runat="server" >
            <h2>Lista De Viajes</h2>
            <table>
                 <tr>
                <td style="text-align:right" class="auto-style1">Dia</td>
                <td class="auto-style5"><asp:TextBox ID="TextDia" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox></td>
                <td style="text-align:right" class="auto-style1">Mes</td>
                <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td style="text-align:right" class="auto-style1">Año</td>
                <td class="auto-style5"><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true"  ></asp:DropDownList></td>
                <td><asp:Button ID="buttonCheck" runat="server" Text="GuardarCheck" OnClick="buttonCheck_Click" /></td>
                <td><asp:Label ID="LblError" runat="server" Visible="false" ForeColor="Red"></asp:Label></td>
            </tr>
            </table>
            <table>
                <tr>
                    <td>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnRowCommand="DtgListaGridViewAdelPmm_RowCommand" >
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="Input" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Id" InsertVisible="False" SortExpression="Id" Visible="False">
                                   <EditItemTemplate>
                                       <asp:Label ID="LabelIdAdelanto" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Monto" SortExpression="Monto">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Monto") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("Monto") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Fecha" SortExpression="Fecha">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Fecha") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label3" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Estado" SortExpression="Estado" Visible="False">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Estado") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                                   <EditItemTemplate>
                                       <asp:Label ID="LabelNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label5" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="NroCuenta" SortExpression="NroCuenta">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("NroCuenta") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label6" runat="server" Text='<%# Bind("NroCuenta") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Telefono" SortExpression="Telefono" Visible="False">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label8" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                                   </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CI" SortExpression="CI">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("CI") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("CI") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Banco" SortExpression="Banco">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Banco") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("Banco") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Id_pmm" SortExpression="Id_pmm">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Id_pmm") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label7" runat="server" Text='<%# Bind("Id_pmm") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                              <asp:TemplateField HeaderText="ModoTexto">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkModoTexto" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id") %>' 
                                       CommandName="ModoTexto" >Modo Texto</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agregar Documento">
                                <ItemTemplate>
                                     <asp:LinkButton ID="LinkAgregar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id") %>'
                                    CommandName="AgregarDocumento" >Agregar Documento</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString %>" SelectCommand="ProcAdelantoDepagoPmm" SelectCommandType="StoredProcedure" >

                <SelectParameters>
                    <asp:ControlParameter ControlID="TextDia" Name="IdDia" PropertyName="Text" Type="Int32" />
                    <asp:ControlParameter ControlID="cmMes" Name="IdMes" PropertyName="SelectedValue" Type="Int32" />
                    <asp:ControlParameter ControlID="cmAño" Name="IdAño" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>

            </asp:SqlDataSource>
        </asp:Panel>
    </div>
</asp:Content>
