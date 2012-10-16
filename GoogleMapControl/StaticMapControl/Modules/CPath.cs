// -----------------------------------------------------------------------
// <copyright file="Path.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using Nltd.Lib.GoogleMap.StaticMap.Modules;

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    public class CPath : Path
    {
        private LocationCollection clocations = new LocationCollection();

        /// <summary>
        /// [required] get or set a set of locations
        /// </summary>
        [Browsable(false)]
        [DesignOnly(false)]
        public override List<Location> Locations 
        {
            get { return clocations.ToLocationList(); }
        }

        /// <summary>
        /// get or set clocations
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public LocationCollection CLocations
        {
            get { return clocations; }
        }
    }
}
