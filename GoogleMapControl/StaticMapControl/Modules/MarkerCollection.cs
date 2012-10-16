// -----------------------------------------------------------------------
// <copyright file="MarkCollection.cs" company="">
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
    /// MarkCollection
    /// </summary>
    public class MarkerCollection : List<CMarker>
    {
        public List<Marker> ToMarkerList()
        {
            return this.ToList<Marker>();
        }
    }
}
