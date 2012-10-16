// -----------------------------------------------------------------------
// <copyright file="StaticMapStyle.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.UI;
    using Nltd.Lib.GoogleMap.StaticMap.Modules;

    /// <summary>
    /// MapStyleCollection
    /// </summary>
    public class MapStyleCollection : List<MapStyle>
    {
        public List<MapStyle> ToMapStyleList()
        {
            return this.ToList<MapStyle>();
        }
    }
}
