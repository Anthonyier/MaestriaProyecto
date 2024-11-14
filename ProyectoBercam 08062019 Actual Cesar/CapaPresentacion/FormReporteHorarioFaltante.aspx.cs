using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class FormReporteHorarioFaltante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImagenMañana_Click(object sender, ImageClickEventArgs e)
        {

            if (CalendarMañana.Visible)
            {
                CalendarMañana.Visible = false;
            }
            else
            {
                CalendarMañana.Visible = true;
            }

        }
        protected void Calendar_MañanaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarMañana.SelectedDate != null)
            {
                TextMañana.Text = CalendarMañana.SelectedDate.ToString("d");
                CalendarMañana.Visible = false;
            }

        }

        protected void ButtonBus_Click(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.Refresh();
        }
    }
}