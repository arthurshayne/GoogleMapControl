// -----------------------------------------------------------------------
// <copyright file="Path.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Lib.GoogleMap.StaticMap.Modules
{
    using System.Text;
    using System.Collections.Generic;
    using Nltd.Lib.GoogleMap.StaticMap.Utility;

    public class Path
    {
        /// <summary>
        /// [optional] get or set path weight, will be 5px if do not set
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// [optional] get or set path color
        /// </summary>
        public ObjectColor Color { get; set; }

        /// <summary>
        /// [optional] get or set the color of paths surrounded the area
        /// </summary>
        public ObjectColor FillColor { get; set; }

        private List<Location> locations = new List<Location>();

        /// <summary>
        /// [required] get or set a set of locations
        /// </summary>
        public virtual List<Location> Locations
        {
            get { return locations; }
        }

        public override string ToString()
        {
            StringBuilder marker = new StringBuilder();
            if (Weight != null)
                marker.Append("weight:").Append(Weight).Append("|");
            if (Color != null)
                marker.Append("color:").Append(Color).Append("|");
            if (FillColor != null)
                marker.Append("fillcolor:").Append(FillColor).Append("|");

            foreach (Location l in Locations)
                marker.Append(l).Append("|");

            //trim end |
            if(Locations.Count > 0)
                marker.Replace("|", "", marker.Length - 1, 1);
            return marker.ToString().UrlEncode();
        }
    }
}
