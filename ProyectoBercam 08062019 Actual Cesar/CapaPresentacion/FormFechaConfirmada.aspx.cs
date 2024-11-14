using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class FormFechaConfirmada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Calendar_CargaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarCarga.SelectedDate != null)
            {
                TextCarga.Text = CalendarCarga.SelectedDate.ToString("d");
                CalendarCarga.Visible = false;
            }

        }

        protected void imgCalendarCarga_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarCarga.Visible)
            {
                CalendarCarga.Visible = false;
            }
            else
            {
                CalendarCarga.Visible = true;
            }
        }
    }
}