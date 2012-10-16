// -----------------------------------------------------------------------
// <copyright file="Marker.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using Nltd.Lib.GoogleMap.StaticMap.Modules;
using System;
using System.Web.UI.WebControls;

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    public class CMarker : Marker
    {
        [Browsable(false)]
        [DesignOnly(true)]
        public override List<Location> Locations
        {
            get
            {
                return clocations.ToLocationList();
            }
        }

        private LocationCollection clocations = new LocationCollection();

        /// <summary>
        /// CLocations
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public LocationCollection CLocations
        {
            get
            {
                return clocations;
            }
        }
    }
}
