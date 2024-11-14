<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormCreacionDim.aspx.cs" Inherits="CapaPresentacion.FormCreacionDim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <Style>
        .upper-case
        {
            text-transform:uppercase ;
        }
    </Style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="abrigo_formulario">
         <h2 style="text-align:center">Creacion De Dim</h2>
    <asp:Panel ID="Panel1" runat="server">
            <table>
                <tr>
                    <td><asp:Button ID="Button1" runat="server" Text="Crear DIM" OnClick="Button1_Click" /></td>
                    <td></td>
                    <td></td>
                    <td style="text-align:right">Estado:</td>
                    <td><asp:DropDownList ID="DdlEstado" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                </tr>
            </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnRowCommand="DtgGridViewListDim_RowCommand" OnRowDataBound="GridView1_RowDataBound" >
                        <Columns>
                             <asp:TemplateField HeaderText="Id" InsertVisible="False" SortExpression="Id">
                                 <EditItemTemplate>
                                     <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Dim" SortExpression="Dim">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Dim") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("Dim") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Producto" SortExpression="Producto">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Producto") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label3" runat="server" Text='<%# Bind("Producto") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Proveedor" SortExpression="Proveedor">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Proveedor") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label4" runat="server" Text='<%# Bind("Proveedor") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="FechaCreacion" SortExpression="FechaCreacion">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("FechaCreacion") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label5" runat="server" Text='<%# Bind("FechaCreacion") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Activo" SortExpression="Activo" Visible="False">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Activo") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label6" runat="server" Text='<%# Bind("Activo") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="AduanaFrontera" SortExpression="AduanaFrontera">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("AduanaFrontera") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label7" runat="server" Text='<%# Bind("AduanaFrontera") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="EstCerrado" SortExpression="EstCerrado" Visible="False">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("EstCerrado") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label8" runat="server" Text='<%# Bind("EstCerrado") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="VisualizarDim">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkVisualizarDim" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id") %>'
                                       CommandName="VisualizarDim">Visualizar Dim</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cerrar DIM">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkCerrarDim" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id") %>' 
                                       CommandName="CerrarDim" OnClientClick="return confirm('Esta seguro que desea Cerrar el DIM?');" >Cerrar Dim</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ModificarDim">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkModificarDim" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id") %>'
                                        CommandName="ModificarDim" OnClientClick="return confirm('Esta seguro que desea Modificar el DIM?');">Modificar Dim</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EliminarDim">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkELiminarDim" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id") %>'
                                        CommandName="EliminarDim" >Eliminar Dim</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reporte">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkReporteDim" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id") %>'
                                           CommandName="ReporteDim">Reporte</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Excel">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkExcel" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id") %>'
                                        CommandName="Excel">Excel</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString %>" SelectCommand="Proc_isi_DimEstado" SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlEstado" Name="EstadoCerrado" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            </asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="false" >
        <table>
            <tr>
                <td><asp:Button ID="Button2" runat="server" Text="<- Atrás" OnClick="Button2_Click" /></td>
            </tr>
            <tr>
                <td style="text-align:right">Aduana Frontera:</td>
                <td><asp:TextBox ID="TextAduanFront" runat="server" Width="100px" CssClass="upper-case"></asp:TextBox> </td>
                <td><asp:Button ID="ButtonEncotrarDim" Text="CargarDim" runat="server" OnClick="ButtonEncotrarDim_Click" /></td>
                <td style="text-align:right">DIM:</td>
                <td><asp:Label ID="LabelDim" runat="server" Visible="false"></asp:Label></td>
                <td><asp:TextBox ID="TextDim" runat="server" Width="150px" CssClass="upper-case"></asp:TextBox></td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="text-align:right">Producto:</td>
                <td><asp:TextBox ID="TextProducto" runat="server" Width="100px" CssClass="upper-case"></asp:TextBox></td>
                <td></td>
                <td style="text-align:right">Proveedor:</td>
                <td><asp:TextBox ID="TextProveedor" runat="server" Width="100px" CssClass="upper-case"></asp:TextBox></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <%--<asp:GridView id="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" >
                        <AlternatingRowStyle BackColor="White" />
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
                        <Columns>
                            <asp:TemplateField HeaderText="Id_Detalle">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id_Detalle") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FechaCarga">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("FechaCarga") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Placa_Camion">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Placa_Camion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NoCrt">
                                <ItemTemplate>
                                    <asp:Label ID="label4" runat="server" Text='<%# Bind("NoCrt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VolumenCrt">
                                <ItemTemplate>
                                    <asp:label ID="Label5" runat="server" Text='<%# Bind("VolumenCrt") %>'></asp:label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PesoCrt">
                                <ItemTemplate>
                                    <asp:label ID="Label6" runat="server" Text='<%# Bind("PesoCrt") %>'></asp:label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VolumenMic">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("VolumenMic") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PesoMic">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("PesoMic")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="NoMic" SortExpression="NoMic">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("NoMic") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("NoMic") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha P.R.M">
                                <ItemTemplate>
                                    <asp:textbox ID="FechaPRM" runat="server" Width="80px" ></asp:textbox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="P.R.M No">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextPRM" runat="server" Width="150px" ></asp:TextBox> 
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>--%>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td><asp:Button Id="BGuardar" runat="server" Text="Guardar" OnClick="BGuardar_Click"/></td>
            </tr>
        </table>
    </asp:Panel>
  </div>
</asp:Content>
