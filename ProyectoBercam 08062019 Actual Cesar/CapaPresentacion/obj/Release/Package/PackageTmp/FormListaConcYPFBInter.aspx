<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListaConcYPFBInter.aspx.cs" Inherits="CapaPresentacion.FormListaConcYPFBInter" %>
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
        <h2>Lista De Conciliaciones</h2>
        <table>
            <tr>
                 <td style="text-align:right"class="auto-style1">Año</td>
                <td class="auto-style5 "><asp:DropDownList ID="cmdAño" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                 <td style="text-align:right" class="auto-style1">Mes</td>
                <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
            </tr>
        </table>
        <table>
            <tr>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" DataKeyNames="Id_Conciliacion" DataSourceID="SqlDataSource1" OnRowCommand="DtgListaConcYpfbInter_RowCommand" >
                    <Columns>
                        <asp:TemplateField HeaderText="Id_Conciliacion" SortExpression="Id_Conciliacion">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id_Conciliacion") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id_Conciliacion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id_Cliente" SortExpression="Id_Cliente">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id_Cliente") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Id_Cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Imprimir">
                             <ItemTemplate >
                                 <asp:LinkButton ID="LinkImprimir" runat ="server" CausesValidation="false" CommandArgument='<%#Bind("Id_Conciliacion") %>'
                                   CommandName="Imprimir">Imprimir</asp:LinkButton>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Aprobar">
                            <ItemTemplate>
                                 <asp:LinkButton ID="LinkAprobar" runat ="server" CausesValidation="false" CommandArgument='<%#Bind("Id_Conciliacion") %>'
                                   CommandName="Aprobar">Aprobar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />

                </asp:GridView>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString %>" SelectCommand="ProcBuscarConcYPFBInternacional" SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:ControlParameter ControlID="cmdAño" Name="IdAño" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="cmMes" Name="IdMes" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>

        </asp:SqlDataSource>
    </div>
</asp:Content>
