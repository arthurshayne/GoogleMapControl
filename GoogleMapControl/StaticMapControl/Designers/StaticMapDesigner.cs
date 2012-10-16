using System;
using System.Linq;
using System.Web.UI.Design;

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl.Designers
{
    /// <summary>
    /// 
    /// </summary>
    public class StaticMapDesigner : ControlDesigner
    {
        
        #region Methods /////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetDesignTimeHtml()
        {
            StaticMapBox map = this.Component as StaticMapBox;
            if (map != null)
                return string.Format("<span>Google Static Map points to {0}</span>", map.Center);
            else
                return "<span>Google Map</span>";
        }
        
        #endregion

    }
}
