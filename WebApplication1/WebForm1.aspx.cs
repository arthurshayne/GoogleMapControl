using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StaticMapBox1.CenterAddress = "China";
                StaticMapBox1.MapType = Nltd.Lib.GoogleMap.StaticMap.Modules.MapType.satellite;
            }
        }
    }
}