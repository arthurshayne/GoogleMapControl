// -----------------------------------------------------------------------
// <copyright file="LocationCollection.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Nltd.Lib.GoogleMap.StaticMap.Modules;

    /// <summary>
    /// LocationCollection
    /// </summary>
    public class LocationCollection : List<CLocation>
    {
        public List<Location> ToLocationList()
        {
            return this.ToList<Location>();
        }
    }
}
