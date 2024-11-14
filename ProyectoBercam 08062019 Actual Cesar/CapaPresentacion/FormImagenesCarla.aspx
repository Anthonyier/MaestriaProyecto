<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormImagenesCarla.aspx.cs" Inherits="CapaPresentacion.FormImagenesCarla" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Registro De Imagenes
        </h2>
        <table>
            <tr>
                 <td style="text-align: right">ID: </td>
                <td>
                    <asp:TextBox ID="TextBoxID" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td style="text-align: right">Placa: </td>
                <td>
                    <asp:TextBox ID="TextBoxPlaca" runat="server" Width="320px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                    <td style="text-align: right">Fecha Vencimiento tarjeta de operación Tracto: </td>
                    <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                            <asp:TextBox ID="txtVencimientoTarOpTracto" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                                
                            <asp:ImageButton ID="imgVencimientoTarOpTracto" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgVencimientoTarOpTracto_Click"  />
                            <asp:Label ID="lblVigenciaTarOpTracto" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                            <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <br />
                    
                    <td style="text-align: right"> </td>
                    <td>
                         <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>--%>
                            <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>--%>
                             <asp:Calendar ID="CalendarVencimientoTarOpTracto" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarVencimientoTarOpTracto_SelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>
                </tr>
             <tr>
                    <td style="text-align: right">Fecha Vencimiento tarjeta de operación Tanque: </td>
                    <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                            <asp:TextBox ID="TextVencimientoTarOpTanque" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageVencimientoTarOpTanque" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageVencimientoTarOpTanque_Click"  />
                            <asp:Label ID="LabelVigenciaTarOpTanque" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                            <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <br />
                    
                    <td style="text-align: right"> </td>
                    <td>
                             <asp:Calendar ID="CalendarVencimientoTarOpTanque" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarVencimientoTarOpTanque_SelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>
                </tr>
         
              <tr>
                    <td style="text-align: right">Fecha Vencimiento del CNRT: </td>
                    <td>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                            <asp:TextBox ID="TextVencimientoCNRT" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageVencimientoCNRT" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageVencimientoCNRT_Click"  />
                            <asp:Label ID="LabelVigenciaCNRT" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                            <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <br />
                    
                    <td style="text-align: right"> </td>
                    <td>
                             <asp:Calendar ID="CalendarVigenciaCNRT" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarVigenciaCNRT_SelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>
                </tr>
             <tr>
                    <td style="text-align: right">Fecha Vencimiento del DinaTrans: </td>
                    <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                            <asp:TextBox ID="TextVencimientoDinatrans" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageVencimientoDinatrans" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageVencimientoDinatrans_Click"  />
                            <asp:Label ID="LabelVigenciaDinatrans" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                            <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <br />
                    
                    <td style="text-align: right"> </td>
                    <td>
                             <asp:Calendar ID="CalendarVigenciaDinaTrans" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarVigenciaDinaTrans_SelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>
                </tr>
             <tr>
                    <td style="text-align: right">Fecha Vencimiento del Seguro CTI: </td>
                    <td>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                            <asp:TextBox ID="TextVencimientoSegCTI" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageSegCTI" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageSegCTI_Click"  />
                            <asp:Label ID="LabelSegCTI" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                            <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <br />
                    
                    <td style="text-align: right"> </td>
                    <td>
                             <asp:Calendar ID="CalendarVigenciaSegCTI" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarVigenciaSegCTI_SelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>
                </tr>
            <tr>
                 <td style="text-align: right">Fecha Vencimiento del Permiso al Peru: </td>
                    <td>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                            <asp:TextBox ID="TextVencimientoPermPeru" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImagePermPeru" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImagePermPeru_Click"   />
                            <asp:Label ID="LblPermPeru" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                            <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <br />
                    
                    <td style="text-align: right"> </td>
                    <td>
                             <asp:Calendar ID="CalendarPermPeru" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarVigenciaPermPeru_SelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>
            </tr>
            <tr>
                 <td style="text-align: right">Fecha Vencimiento del Permiso al Brasil: </td>
                    <td>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                            <asp:TextBox ID="TextVencimientoPermBrasil" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImagePermBrasil" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImagePermBrasil_Click"   />
                            <asp:Label ID="LblPermBrasil" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                            <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <br />
                    
                    <td style="text-align: right"> </td>
                    <td>
                             <asp:Calendar ID="CalendarPermBrasil" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarVigenciaPermBrasil_SelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>
            </tr>
        </table>
          <table>
                 <tr>
                    <td><asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                           BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"/> 
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                    <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
                 </tr>
        </table>  
    </div>
</asp:Content>
