// -----------------------------------------------------------------------
// <copyright file="Marker.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using Nltd.Lib.GoogleMap.StaticMap.Utility;
using System;

namespace Nltd.Lib.GoogleMap.StaticMap.Modules
{
    public class Marker
    {
        /// <summary>
        /// [optional] get or set icon path
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// [optional] get or set marker set
        /// </summary>
        public MarkerSize? MarkerSize { get; set; }

        /// <summary>
        /// [optional] get or set marker color
        /// </summary>
        public ObjectColor Color { get; set; }

        /// <summary>
        /// [optional] get or set marker label
        /// </summary>
        public char? Label { get; set; }

        /// <summary>
        /// [required]get a set of locations
        /// </summary>
        public virtual List<Location> Locations { get; set; }

        public override string ToString()
        {
            StringBuilder marker = new StringBuilder();
            if (!String.IsNullOrEmpty(IconPath))
                marker.Append("icon:").Append(IconPath).Append("|");
            if(MarkerSize != null)
                marker.Append("size:").Append(MarkerSize).Append("|");
            if (Color != null)
                marker.Append("color:").Append(Color).Append("|");
            if (Label != null)
                marker.Append("label:").Append(Label).Append("|");

            foreach (Location l in Locations)
                marker.Append(l).Append("|");

            //trim end |
            if(Locations.Count > 0)
                marker.Replace("|","",marker.Length-1,1);
            return marker.ToString().UrlEncode();
        }
    }

}
