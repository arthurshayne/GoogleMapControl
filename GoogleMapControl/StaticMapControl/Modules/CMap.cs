// -----------------------------------------------------------------------
// <copyright file="CMap.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Nltd.Lib.GoogleMap.StaticMap.Modules;

    /// <summary>
    /// CMap
    /// </summary>
    public class CMap : Map
    {
        public override List<Marker> Markers
        {
            get
            {
                return CMarkers.ToMarkerList();
            }
            set
            {
                base.Markers = value;
            }
        }

        public override List<Path> Paths
        {
            get
            {
                return CPaths.ToPathList();
            }
            set
            {
                base.Paths = value;
            }
        }

        public override List<MapStyle> Styles
        {
            get
            {
                return CStyles.ToMapStyleList();
            }
            set
            {
                base.Styles = value;
            }
        }

        /// <summary>
        /// get or set CPaths
        /// </summary>
        public PathCollection CPaths { get; set; }

        /// <summary>
        /// get or set CMarkers
        /// </summary>
        public MarkerCollection CMarkers { get; set; }

        /// <summary>
        /// get or set CStyles
        /// </summary>
        public MapStyleCollection CStyles { get; set; }
    }
}
