<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FrmImagenes.aspx.cs" Inherits="CapaPresentacion.Imagenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
         <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Registro de Imagenes</h2>
        <table>
            <tr>
                 <td style="text-align: right">C.I.: </td>
                <td>
                    <asp:TextBox ID="TextBoxCi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                 <td style="text-align: right">Persona: </td>
                <td>
                    <asp:TextBox ID="TextBoxPersona" runat="server" Width="320px"></asp:TextBox>
                </td>
            </tr>
            
            <%--<tr>
                    <td style="text-align: right">Imagen Actual CI.: </td>
                    <td>
                        <asp:Image ID="imgCI" runat="server" Height="96px" Width="123px" />
                    </td>
             </tr>--%>
           
             <tr>
                    <td style="text-align: right">Fecha Vencimiento C.I.: </td>
                    <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                            <asp:TextBox ID="txtVencimientoCI" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                                
                            <asp:ImageButton ID="imgVencimientoCI" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgVencimientoCI_Click" />
                            <asp:Label ID="lblVigenciaCI" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
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
                             <asp:Calendar ID="CalendarVencimientoCI" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarVencimientoCI_SelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
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
                     <asp:CheckBox ID="chkSiAplicaCI" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="chkSiAplicaCI_CheckedChanged"  />
                 </td>
                 <td>
                     <asp:CheckBox ID="chkNoAplicaCI" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="chkNoAplicaCI_CheckedChanged" />
                 </td>
               </tr>
           
            <%-- <tr>
                    <td style="text-align: right">Imagen Actual Licencia.: </td>
                    <td>
                        <asp:Image ID="imgLicencia" runat="server" Height="96px" Width="123px" />
                    </td>
             </tr>--%>
                <tr>
                    <td style="text-align: right">Vencimiento Licencia: </td>
                    <%--5<!--<td><asp:TextBox ID="txtLicencia" runat="server" Width="60px" ></asp:TextBox> <asp:Button ID="BtnVerLicencia" runat="server" Text="Imagen Licencia" width="100px" Font-Size="Smaller" OnClick="BtnVerLicencia_Click"/></td> -->--%>       
                     
                      <td>
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                           <ContentTemplate>   
                          <asp:TextBox ID="txtVigenciaLic" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="imgCalendarLic" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgCalendarLic_Click" />
                          <asp:Label ID="lblVigenciaLic" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
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
                             <asp:Calendar ID="CalendarLicencia" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarLicencia_SelectionChanged" NextPrevFormat="FullMonth">
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
                     <asp:CheckBox ID="CheckSiAplicaLic" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaLic_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaLic" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaLic_CheckedChanged" />
                 </td>
                   
                </tr>
                <%--<tr>
                    <td style="text-align: right">Imagen Actual FELCN.: </td>
                    <td>
                        <asp:Image ID="imgFelcn" runat="server" Height="96px" Width="123px" />
                    </td>
                </tr>--%>
                 <tr>
                    <td style="text-align: right">Vencimiento FELCN: </td>
                     <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate> 
                        <asp:TextBox ID="txtVigenciaFelcn" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="imgCalendarFelcn" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgCalendarFelcn_Click" />
                        <asp:Label ID="lblVigenciaFelcn" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                     </td>
                               <%--<td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Especifique una Fecha" ControlToValidate="txtVigenciaFelcn"></asp:RequiredFieldValidator></td>--%>
                    <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarFelcn" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarFelcn_SelectionChanged" NextPrevFormat="FullMonth">
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
                     <asp:CheckBox ID="CheckSiAplicaFelcn" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaFelcn_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaFelcn" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaFelcn_CheckedChanged" />
                 </td>
                </tr>
               <%-- <tr>
                    <td style="text-align: right">Imagen Actual Rejap.: </td>
                    <td>
                        <asp:Image ID="imgRejap" runat="server" Height="96px" Width="123px" />
                    </td>
                </tr>--%>
           
                <tr>
                    <td style="text-align: right">Vencimiento REJAP: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                        <asp:TextBox ID="txtVigenciaRejap" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="imgCalendarRejap" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="imgCalendarRejap_Click" />
                        <asp:Label ID="lblVigenciaRejap" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                    </td>    
                        <%--<td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Especifique una Fecha" ControlToValidate="txtVigenciaRejap"></asp:RequiredFieldValidator></td>--%>
                     </tr>
                <tr>
                     <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarRejap" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" OnSelectionChanged="CalendarRejap_SelectionChanged" NextPrevFormat="FullMonth">
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
                     <asp:CheckBox ID="CheckSiAplicaRejap" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaRejap_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaRejap" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaRejap_CheckedChanged" />
                 </td>
                </tr>
             <%--<tr>
                    <td style="text-align: right">Imagen Actual SegAcc.: </td>
                    <td>
                        <asp:Image ID="imgSegAcc" runat="server" Height="96px" Width="123px" />
                    </td>
                </tr>--%>
                 <tr>
                    <td style="text-align: right">Vencimiento SegAcc: </td>
                     <td>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate> 
                        <asp:TextBox ID="TextBoxSegAcc" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImgCalendarSecAcc" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImgCalendarSecAcc_Click"  />
                        <asp:Label ID="LabelSegAcc" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                     </td>
                               <%--<td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Especifique una Fecha" ControlToValidate="txtVigenciaFelcn"></asp:RequiredFieldValidator></td>--%>
                    <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarSegAcc" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px"  NextPrevFormat="FullMonth" OnSelectionChanged="CalendarSegAcc_SelectionChanged">
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
                     <asp:CheckBox ID="CheckSiAPlicaSegAcc" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAPlicaSegAcc_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaSegAcc" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaSegAcc_CheckedChanged" />
                 </td>
                </tr>
             <%--<tr>
                    <td style="text-align: right">Imagen Actual SegVida.: </td>
                    <td>
                        <asp:Image ID="imgSegVid" runat="server" Height="96px" Width="123px" />
                    </td>
                </tr>--%>
                 <tr>
                    <td style="text-align: right">Vencimiento Seguro Vida: </td>
                     <td>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate> 
                        <asp:TextBox ID="TextBoxSeguroVida" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImgCalenSegVi" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImgCalenSegVi_Click"  />
                        <asp:Label ID="LabelSeguroVida" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                     </td>
                               <%--<td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Especifique una Fecha" ControlToValidate="txtVigenciaFelcn"></asp:RequiredFieldValidator></td>--%>
                    <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarSegVida" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px"  NextPrevFormat="FullMonth" OnSelectionChanged="CalendarSegVida_SelectionChanged">
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
                     <asp:CheckBox ID="CheckSiAplicaSegVida" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaSegVida_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaSegVida" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaSegVida_CheckedChanged" />
                 </td>
                </tr>
         
            <tr>
                <td style="text-align: right"> Certificado de Manejo defensivo</td>
                 <td>
                     <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate> 
                        <asp:TextBox ID="TextManjeDef" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox><asp:ImageButton ID="ImageMaDef" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" Width="22px" OnClick="ImageMaDef_Click" />
                        <asp:Label ID="LabelCertManDef" runat="server" Text="" BackColor="Red" Font-Size="XX-Small"></asp:Label>
                 </td>
                   <td style="text-align: right"> </td>
                    <td>
                        <asp:Calendar ID="CalendarCertManDef" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px"  NextPrevFormat="FullMonth" OnSelectionChanged="CalendarCertManDef_SelectionChanged">
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
                     <asp:CheckBox ID="CheckSiAplicaManDef" Text="Si Aplica" AutoPostBack="true"  runat="server" OnCheckedChanged="CheckSiAplicaManDef_CheckedChanged"   />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckNoAplicaManDef" Text="No Aplica" AutoPostBack="true" runat="server" OnCheckedChanged="CheckNoAplicaManDef_CheckedChanged" />
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=192.168.1.50;Initial Catalog=bercam;User Id=sa;Password=NCapas2525" 
            SelectCommand="SELECT * FROM [Roles]" ProviderName="<%$ ConnectionStrings:bercamConnectionString.ProviderName %>"></asp:SqlDataSource>
        </div>

</asp:Content>
