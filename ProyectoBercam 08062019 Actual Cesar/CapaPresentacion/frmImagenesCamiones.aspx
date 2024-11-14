<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="frmImagenesCamiones.aspx.cs" Inherits="CapaPresentacion.frmImagenesCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
         <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Registro de Documentos</h2>
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
           
           <%-- <tr>
                    <td style="text-align: right">Imagen Actual RUAT: </td>
                    <td>
                        <asp:Image ID="imgRUAT" runat="server" Height="96px" Width="123px" />
                    </td>
             </tr>--%>
             
             <tr>
                    <td style="text-align: right">Fecha Vencimiento RUAT: </td>
                    <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                            <asp:TextBox ID="txtVencimientoRUAT" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                                
                            <asp:ImageButton ID="imgVencimientoRUAT" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgVencimientoRUAT_Click" />
                            <asp:Label ID="lblVigenciaRUAT" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
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
                             <asp:Calendar ID="CalendarVencimientoRUAT" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarVencimientoRUAT_SelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
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
            
            <%-- <tr>
                    <td style="text-align: right">Imagen Actual SOAT: </td>
                    <td>
                        <asp:Image ID="imgSOAT" runat="server" Height="96px" Width="123px" />
                    </td>
             </tr>--%>
          
                <tr>
                    <td style="text-align: right">Vencimiento SOAT: </td>
                    <%--5<!--<td><asp:TextBox ID="txtLicencia" runat="server" Width="60px" ></asp:TextBox> <asp:Button ID="BtnVerLicencia" runat="server" Text="Imagen Licencia" width="100px" Font-Size="Smaller" OnClick="BtnVerLicencia_Click"/></td> -->--%>       
                     
                      <td>
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                           <ContentTemplate>   
                          <asp:TextBox ID="txtVigenciaSOAT" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="imgCalendarSOAT" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgCalendarSOAT_Click" />
                          <asp:Label ID="lblVigenciaSOAT" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                               <%--</ContentTemplate> 
                            </asp:UpdatePanel>--%>
                      </td>
                      
                      <td>
                            
                      </td>
                       <%--<td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Especifique una fecha" ControlToValidate="txtVigenciaLic"></asp:RequiredFieldValidator></td>--%>
                <%--</tr>
                <tr>--%>
                     <td style="text-align: right"> </td>
                    <td>
                        
                           <%--<asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" >
                         <ContentTemplate> --%>
                             <asp:Calendar ID="CalendarSOAT" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarSOAT_SelectionChanged" NextPrevFormat="FullMonth">
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
                
               <%-- <tr>
                    <td style="text-align: right">Imagen Actual Inspeccion Tecnica: </td>
                    <td>
                        <asp:Image ID="imgINSTEC" runat="server" Height="96px" Width="123px" />
                    </td>
                </tr>--%>
            
                 <tr>
                    <td style="text-align: right">Vencimiento INSTEC: </td>
                     <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate> 
                        <asp:TextBox ID="txtVigenciaINSTEC" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="imgCalendarINSTEC" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgCalendarINSTEC_Click" />
                        <asp:Label ID="lblVigenciaINSTEC" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                     </td>
                               <%--<td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Especifique una Fecha" ControlToValidate="txtVigenciaFelcn"></asp:RequiredFieldValidator></td>--%>
                    <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarINSTEC" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarINSTEC_SelectionChanged" NextPrevFormat="FullMonth">
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
                
               <%-- <tr>
                    <td style="text-align: right">Imagen Actual Mantenimiento: </td>
                    <td>
                        <asp:Image ID="imgMant" runat="server" Height="96px" Width="123px" />
                    </td>
                </tr>--%>
           
                <tr>
                    <td style="text-align: right">Vencimiento Mantenimiento: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtVigenciaMant" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="imgCalendarRejap" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgCalendarMant_Click" />
                        <asp:Label ID="lblVigenciaMant" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                        <%--<td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Especifique una Fecha" ControlToValidate="txtVigenciaRejap"></asp:RequiredFieldValidator></td>--%>
                     </tr>
                <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarMant" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarMant_SelectionChanged" NextPrevFormat="FullMonth">
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
                     <td>
                     <asp:CheckBox ID="chkSiAplicaMantenimiento" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="chkSiAplicaMantenimiento_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="chkNoAplicaMantenimiento" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="chkNoAplicaMantenimiento_CheckedChanged"  />
                 </td>
                </tr>
         
            <%--<tr>
                    <td style="text-align: right">Imagen Actual Tornamesa: </td>
                    <td>
                        <asp:Image ID="ImageINTT" runat="server" Height="96px" Width="123px" />
                    </td>
                </tr>--%>
             
                <tr>
                    <td style="text-align: right">Vencimiento Tornamesa: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtVigenciaINTT" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImageButton1" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgCalendarINTT_Click" />
                        <asp:Label ID="LabelINTT" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                </tr>
                     
                 <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarINTT" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarINTT_SelectionChanged" NextPrevFormat="FullMonth">
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
                     <td>
                     <asp:CheckBox ID="CheckSiAplicaTornamesa" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaTornamesa_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaTornamesa" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaTornamesa_CheckedChanged"  />
                 </td>
                </tr>
           
            <%--<tr>
                    <td style="text-align: right">Imagen Actual Cisterna: </td>
                    <td>
                        <asp:Image ID="ImageVAC" runat="server" Height="96px" Width="123px" />
                    </td>
                </tr>--%>
            
                <tr>
                    <td style="text-align: right">Certificado de Verificación: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtVigenciaCisterna" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImageButton2" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgCalendarCIS_Click" />
                        <asp:Label ID="LabelCisterna" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                </tr>
                     
                 <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarCisterna" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarCIS_SelectionChanged" NextPrevFormat="FullMonth">
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
                     <td>
                     <asp:CheckBox ID="CheckSiAplicaCisterna" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaCisterna_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaCisterna" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaCisterna_CheckedChanged"  />
                 </td>
                </tr>
             
            <%--<tr>
                    <td style="text-align: right">Imagen Actual ESTANQUEIDAD: </td>
                    <td>
                        <asp:Image ID="ImageEST" runat="server" Height="96px" Width="123px" />
                    </td>
                </tr>--%>
            
                <tr>
                    <td style="text-align: right">Vencimiento ESTANQUEIDAD: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtVencimientoEst" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImageButton3" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgCalendarEST_Click" />
                        <asp:Label ID="LabelEst" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                </tr>
                     
                 <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarEst" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarEST_SelectionChanged" NextPrevFormat="FullMonth">
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
                     <td>
                     <asp:CheckBox ID="CheckSiAplicaEstan" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaEstan_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaEstan" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaEstan_CheckedChanged"  />
                 </td>
                </tr>
         
           <%-- <tr>
                    <td style="text-align: right">Imagen Actual SegRespCivprod: </td>
                    <td>
                        <asp:Image ID="ImgCivProd" runat="server" Height="96px" Width="123px" />
                    </td>
                </tr>--%>
            
                <tr>
                    <td style="text-align: right">Vencimiento RespCivProd: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel16" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtRespCivProd" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImageRespCivProd" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageRespCivProd_Click" />
                        <asp:Label ID="lblRespCivProd" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                </tr>
                     
                 <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarRespCivProd" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px"  NextPrevFormat="FullMonth" OnSelectionChanged="CalendarRespCivProd_SelectionChanged">
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
                     <td>
                     <asp:CheckBox ID="CheckSiAplicaResCivProd" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaResCivProd_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaResCivProv" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaResCivProv_CheckedChanged"  />
                 </td>
                </tr>
             
            <%--<tr>
                    <td style="text-align: right">Imagen Actual RespCivTra: </td>
                    <td>
                        <asp:Image ID="ImgRespCivTra" runat="server" Height="96px" Width="123px" />
                    </td>
                </tr>--%>
            
                <tr>
                    <td style="text-align: right">Vencimiento RespCivTra: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel18" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtRespCivTra" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImageRespCivTra" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageRespCivTra_Click"  />
                        <asp:Label ID="lblRespCivTra" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                </tr>
                     
                 <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarRespCivTra" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" NextPrevFormat="FullMonth" OnSelectionChanged="CalendarRespCivTra_SelectionChanged" >
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
                     <td>
                     <asp:CheckBox ID="CheckSiAplicaRespCivTra" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaRespCivTra_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaRespCivTra" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaRespCivTra_CheckedChanged"  />
                 </td>
                </tr>
            <%--<tr>
               <td style="text-align: right">Imagen Actual Contrato: </td>
                    <td>
                        <asp:Image ID="ImageContrato" runat="server" Height="96px" Width="123px" />
                    </td>
            </tr>--%>
             <tr>
                    <td style="text-align: right">Vencimiento Contrato: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel20" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtContrato" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImageContra" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageContra_Click" />
                        <asp:Label ID="lblContrato" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                </tr>
                     
                 <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarContrato" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" NextPrevFormat="FullMonth" OnSelectionChanged="CalendarContrato_SelectionChanged" >
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
                  <td>
                     <asp:CheckBox ID="CheckSiAplicaContrato" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaContrato_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaContrato" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaContrato_CheckedChanged"  />
                 </td>
                </tr>
            <tr>
                <td style="text-align:right">Venc.Poliza Automotor:</td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel21" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtPoliza" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImagePoliza" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImagePoliza_Click"  />
                        <asp:Label ID="LblPolizaAuto" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                </tr>
                 <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarPolizaAuto" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" NextPrevFormat="FullMonth" OnSelectionChanged="CalendarPoliza_SelectionChanged" >
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
                 <td>
                     <asp:CheckBox ID="CheckSiAplicaPoliza" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaPoliza_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaPoliza" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaPoliza_CheckedChanged"  />
                 </td>
            </tr>
            <tr>
                <td style="text-align:right">Venc.Resp Civil Combustible:</td>
                  <td>
                        <asp:UpdatePanel ID="UpdatePanel22" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtResCivilCombustible" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImageRespCivCombustible" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageRespCivCombustible_Click" />
                        <asp:Label ID="LblResCivilCombustible" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                </tr>
                 <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarRespCivilCombustible" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" NextPrevFormat="FullMonth" OnSelectionChanged="CalendarRespCivilCombustible_SelectionChanged">
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
                 <td>
                     <asp:CheckBox ID="CheckSiAplicaRespCivilCombustible" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaRespCivilCombustible_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaRespCivilCombustible" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaRespCivilCombustible_CheckedChanged"  />
                 </td>
            </tr>
            <tr>
                <td style="text-align:right ">Calibracion(Campana)</td>
                 <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtCalibracion" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImgCalibracion" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImgCalibracion_Click"  />
                        <asp:Label ID="LblCalibracion" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                </tr>
                 <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarCalibracion" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" NextPrevFormat="FullMonth" OnSelectionChanged="CalendarCalibracion_SelectionChanged">
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
                 <td>
                     <asp:CheckBox ID="CheckSiAplicaCalibracion" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaCalibracion_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaCalibracion" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaCalibracion_CheckedChanged"  />
                 </td>
            </tr>
           
            <tr>
                 <td style="text-align:right ">Inspeccion Tecnica Tanque</td>
                 <td>
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtInspecTecTanque" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImgTectanque" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImgTectanque_Click"  />
                        <asp:Label ID="LblInspecTecTanque" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                </tr>
                 <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarInspecTecTanque" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" NextPrevFormat="FullMonth" OnSelectionChanged="CalendarInspecTanque_SelectionChanged">
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
                 <td>
                     <asp:CheckBox ID="CheckSiAplicaInspec" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaInspec_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaInspec" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaInspec_CheckedChanged"  />
                 </td>
            </tr>
        </table>
         <br />
        <table>
                 <tr>
                    <td><asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                        OnClick="BtnGuardar_Click" BackColor="Aqua" Font-Bold="True" Font-Italic="False"/> 
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                    <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
                 </tr>
        </table>  
        </div>

</asp:Content>
