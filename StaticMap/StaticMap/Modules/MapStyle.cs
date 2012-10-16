// -----------------------------------------------------------------------
// <copyright file="Style.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Lib.GoogleMap.StaticMap.Modules
{
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MapStyle
    {
        /// <summary>
        /// get or set feature type, will be all if do not set
        /// </summary>
        public StyleFeatureType? FeatureType { get; set; }

        /// <summary>
        /// get or set element type, will be all if do not set
        /// </summary>
        public StyleElementType? ElementType { get; set; }

        /// <summary>
        /// get or set hue
        /// </summary>
        public string Hue { get; set; }

        /// <summary>
        /// get or set lightness, value should between -100 and 100
        /// </summary>
        public short? Lightness { get; set; }

        /// <summary>
        /// get or set saturation, value should between -100 and 100
        /// </summary>
        public short? Saturation { get; set; }

        /// <summary>
        /// get or set gamma, value should between 0.01 and 10.0
        /// </summary>
        public float? Gamma { get; set; }

        /// <summary>
        /// get or set inverse lightness
        /// </summary>
        public bool? InverseLightness { get; set; }

        /// <summary>
        /// get or set visibility
        /// </summary>
        public StyleVisibiltyType? Visibility { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (FeatureType != null)
                sb.Append("feature:").Append(FeatureType.ToString().Replace("_",".")).Append("|");

            if (ElementType != null)
                sb.Append("element:").Append(ElementType.ToString()).Append("|");

            if (Hue != null)
                sb.Append("hue:").Append(Hue).Append("|");

            if (Lightness != null)
                sb.Append("lightness:").Append(Lightness.ToString()).Append("|");

            if (Saturation != null)
                sb.Append("saturation:").Append(Saturation.ToString()).Append("|");

            if (Gamma != null)
                sb.Append("gamma:").Append(Gamma.ToString()).Append("|");

            if (InverseLightness != null)
                sb.Append("inverse_lightness:").Append(InverseLightness.ToString().ToLower()).Append("|");

            if (Visibility != null)
                sb.Append("visibility:").Append(Visibility.ToString()).Append("|");

            return sb.ToString().TrimEnd('|');
        }
    }
}
