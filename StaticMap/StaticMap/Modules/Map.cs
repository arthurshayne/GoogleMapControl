using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Nltd.Lib.GoogleMap.StaticMap.Modules
{
    public class Map
    {
        public Map()
        { 
            BaseUrl = "http://maps.google.com/maps/api/staticmap";
            Scale = 1;
        }

        /// <summary>
        /// get url for request
        /// </summary>
        public string Url
        {
            get
            {
                if (Markers == null)
                {
                    Trace.Assert(Center != null);
                    Trace.Assert(Zoom != null);
                }

                StringBuilder sb = new StringBuilder(BaseUrl);
                sb.Append("?a=1");
                
                if(Center != null)
                    sb.Append("&center=").Append(Center);
                
                if (Zoom != null)
                    sb.Append("&zoom=").Append(Zoom);
                
                //size is required
                sb.Append("&size=").Append(Size);

                if(Scale != null)
                    sb.Append("&scale=").Append(Scale);
                
                if (ImageFormat != null)
                    sb.Append("&format=").Append(ImageFormat);

                if(MapType != null)
                    sb.Append("&maptype=").Append(MapType);

                if (Markers != null)
                {
                    foreach (Marker m in Markers)
                    {
                        sb.Append("&markers=").Append(m);
                    }
                }

                if (Paths != null)
                {
                    foreach (Path p in Paths)
                    {
                        sb.Append("&path=").Append(p);
                    }
                }

                if (Styles != null)
                {
                    foreach (MapStyle s in Styles)
                    {
                        sb.Append("&style=").Append(s);
                    }
                }

                if (Visible != null)
                {
                    sb.Append("&visible=").Append(Visible);
                }

                sb.Append("&sensor=").Append(IsUseSensor.ToString().ToLower());
                return sb.ToString();
            }
        }
        
        /// <summary>
        /// get or set service base url, default is http://maps.google.com/maps/api/staticmap
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// [required when no markers] get or set center
        /// </summary>
        public Location Center { get; set; }

        /// <summary>
        /// [required when no markers] get or set zoom
        /// </summary>
        public int? Zoom { get; set; }

        /// <summary>
        /// [optional] get or set scale
        /// </summary>
        public int? Scale { get; set; }

        /// <summary>
        /// [required] get or set image size
        /// </summary>
        public MapSize Size { get; set; }

        /// <summary>
        /// [optional] get or set image format
        /// </summary>
        public ImageFormat? ImageFormat { get; set; }

        /// <summary>
        /// [optional] get or set map type
        /// </summary>
        public MapType? MapType { get; set; }

        /// <summary>
        /// [optional] get or set language, warning some area may not support this feature.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// [optional] get or set markers
        /// </summary>
        public virtual List<Marker> Markers { get; set; }

        /// <summary>
        /// [optional] get or set paths
        /// </summary>
        public virtual List<Path> Paths { get; set; }

        /// <summary>
        /// [optional] get or set styles
        /// </summary>
        public virtual List<MapStyle> Styles { get; set; }

        /// <summary>
        /// [optional] get or set some location need to visible
        /// </summary>
        public Location Visible { get; set; }

        /// <summary>
        /// [required] get or set wheter use of sensor
        /// </summary>
        public bool IsUseSensor { get; set; }
    }
}
