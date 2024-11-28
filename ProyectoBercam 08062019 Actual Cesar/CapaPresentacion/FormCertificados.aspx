<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormCertificados.aspx.cs" Inherits="CapaPresentacion.FormCertificados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
     <div id=" Formulario Certificados">
         <br />
          <table>

              <tr>
                  <td style="text-align :right">Placa:</td>
                  <td><asp:TextBox ID="txtPlaca" runat="server" Width="300px"></asp:TextBox></td>
              </tr>
              <tr>
                  <td style="text-align: right">RUAT: </td>
                    <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="210px"  Font-Size="Smaller"/></td>
                       </ContentTemplate> 
                     </asp:UpdatePanel>
                    </td>
              </tr>
              <tr>
                  <td style="text-align: right">SOAT: </td>
                    <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>
                        <td><asp:TextBox ID="GestionSoat" runat="server" Width="100px"></asp:TextBox></td>
                    <asp:FileUpload ID="FileUpload2" runat="server" Width="210px"  Font-Size="Smaller"/></td>
                       </ContentTemplate> 
                     </asp:UpdatePanel>
                    </td>
              </tr>
              <tr>
                  <td style="text-align: right">Inspeccion tecnica: </td>
                    <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>
                         <td><asp:TextBox ID="GestionInsp" runat="server" Width="100px"></asp:TextBox></td>
                    <asp:FileUpload ID="FileUpload3" runat="server" Width="210px"  Font-Size="Smaller"/></td>
                       </ContentTemplate> 
                     </asp:UpdatePanel>
                    </td>
              </tr>
              <tr>
                  <td style="text-align: right"> Certificado: </td>
                      <td>
                           <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>--%>
                            <asp:DropDownList ID="combo" AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                      </td>
                     </tr>
              <tr>
                         <td style="text-align: right">inicio: </td>
                         <td>
                        <asp:TextBox ID="TextBox2" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton5" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" 
                            Width="22px" />
                         </td>
                      </tr>
              <tr>
                     <td style="text-align: right"> </td>
                     <td>                        
                             <asp:Calendar ID="Calendar1" runat="server" Visible ="False" 
                                 BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                                 Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="100px" ShowGridLines="True"
                                  Width="200px" SelectionMode="DayWeekMonth">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            </asp:Calendar>
                        </td>
                   <tr>
                     <%--<td style="text-align: right"> </td>--%>
                    
                            <td style="text-align: right">Fin: </td>
                            <td>
                           <asp:TextBox ID="TextBox3" runat="server" Width="70px" Font-Size="Smaller"></asp:TextBox>
                           <asp:ImageButton ID="ImageButton2" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" 
                            Width="22px"  />
                            </td>
                         </tr>
              <tr>
                            <td style="text-align: right"></td>
                            <td>
                             <asp:Calendar ID="Calendar2" runat="server" Visible ="False" 
                                 BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                                 Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="100px" ShowGridLines="True"
                                  Width="200px" SelectionMode="DayWeekMonth">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            </asp:Calendar>
                            </td>
                    </tr>
               <tr>
                             <td></td>
                             <td>
                              <asp:GridView id="Gridview1" DataSourceID="SqlDataSource3" runat="server">
                            </asp:Gridview>
                        <%-- </ContentTemplate> 
                        </asp:UpdatePanel>--%>
                          </td>
                         </tr>
          </table>
         <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="Data Source=SERVIDOR;Initial Catalog=Maestria1Modulo;Integrated Security=True" 
           ProviderName="<%$ ConnectionStrings:bercamConnectionString.ProviderName %>"></asp:SqlDataSource>
     </div>
</asp:Content>
