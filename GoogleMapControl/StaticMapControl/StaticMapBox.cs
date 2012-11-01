using System.ComponentModel;
using System.Drawing.Design;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl.Designers;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.ComponentModel.Design;
using System;
using System.Collections;
using System.Reflection;
using System.Linq;

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    [ToolboxData("<{0}:StaticMapBox runat=\"server\"> </{0}:StaticMapBox>")]
    [Designer(typeof(StaticMapDesigner))]
    public class StaticMapBox : Image
    {

        /// <summary>
        /// get url for request
        /// </summary>
        public override string ImageUrl
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

                if (Center != null)
                    sb.Append("&center=").Append(Center);

                if (Zoom != null)
                    sb.Append("&zoom=").Append(Zoom);

                //size is required
                sb.Append("&size=").Append(Size);

                if (Scale != null)
                    sb.Append("&scale=").Append(Scale);

                if (ImageFormat != null)
                    sb.Append("&format=").Append(ImageFormat);

                if (MapType != null)
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

                if (VisiableLocation != null)
                {
                    sb.Append("&visible=").Append(VisiableLocation);
                }

                sb.Append("&sensor=").Append(IsUseSensor.ToString().ToLower());
                return sb.ToString();
            }
        }

        /// <summary>
        /// get or set service base url, default is http://maps.google.com/maps/api/staticmap
        /// </summary>
        [Category("Google")]
        [DefaultValue(typeof(string),"http://maps.google.com/maps/api/staticmap")]
        public string BaseUrl 
        {
            get
            {
                return ViewState["BaseUrl"] as string ?? "http://maps.google.com/maps/api/staticmap";
            }
            set
            {
                ViewState["BaseUrl"] = value;
            }
        }

        /// <summary>
        /// get or set Height
        /// </summary>
        [Category("Google")]
        public override Unit Height
        {
            get
            {
                if (base.Height.Value == 0)
                    base.Height = new Unit(300);
                return base.Height;
            }
            set
            {
                base.Height = value;
            }
        }

        /// <summary>
        /// get or set Width
        /// </summary>
        [Category("Google")]
        public override Unit Width
        {
            get
            {
                if (base.Width.Value == 0)
                    base.Width = new Unit(300);
                return base.Width;
            }
            set
            {
                base.Width = value;
            }
        }


        /// <summary>
        /// get MapSize
        /// </summary>
        internal MapSize Size
        {
            get
            {
                return new MapSize() { Height = (int)this.Height.Value, Width = (int)this.Width.Value };
            }
        }

        /// <summary>
        /// [required when no markers] get or set center address
        /// </summary>
        [Category("Google")]
        public string CenterAddress
        {
            get
            {
                return ViewState["CenterAddress"] as string;
            }
            set
            {
                ViewState["CenterAddress"] = value;
            }
        }

        /// <summary>
        /// [required when no markers] get or set center Latitude
        /// </summary>
        [Category("Google")]
        public double? CenterLatitude
        {
            get
            {
                return ViewState["CenterLatitude"] as double?;
            }
            set
            {
                ViewState["CenterLatitude"] = value;
            }
        }

        /// <summary>
        /// [required when no markers] get or set center Longitude
        /// </summary>
        [Category("Google")]
        public double? CenterLongitude
        {
            get
            {
                return ViewState["CenterLongitude"] as double?;
            }
            set
            {
                ViewState["CenterLongitude"] = value;
            }
        }

        /// <summary>
        /// get center
        /// </summary>
        internal Location Center
        {
            get
            {
                if (CenterAddress != null)
                {
                    return new Location() { Address = CenterAddress };
                }
                else if (CenterLatitude != null && CenterLongitude != null)
                {
                    return new Location() { Latitude = CenterLatitude.Value, Longitude = CenterLongitude.Value }; ;
                }
                else
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// [required when no markers] get or set center
        /// </summary>
        [Category("Google")]
        public string VisiableAddress
        {
            get
            {
                return ViewState["VisiableAddress"] as string;
            }
            set
            {
                ViewState["VisiableAddress"] = value;
            }
        }

        /// <summary>
        /// get or set Latitude
        /// </summary>
        [Category("Google")]
        public double? VisiableLatitude
        {
            get
            {
                return ViewState["VisiableLatitude"] as double?;
            }
            set
            {
                ViewState["VisiableLatitude"] = value;
            }
        }

        /// <summary>
        /// get or set Longitude
        /// </summary>
        [Category("Google")]
        public double? VisiableLongitude
        {
            get
            {
                return ViewState["VisiableLongitude"] as double?;
            }
            set
            {
                ViewState["VisiableLongitude"] = value;
            }
        }

        /// <summary>
        /// get some location need to visible
        /// </summary>
        internal Location VisiableLocation
        {
            get
            {
                if (VisiableAddress != null)
                {
                    return new Location() { Address = VisiableAddress };
                }
                else if (VisiableLatitude != null && VisiableLongitude != null)
                {
                    return new Location() { Latitude = VisiableLatitude.Value, Longitude = VisiableLongitude.Value };
                }
                else
                {
                    return null;
                }
            }

        }

        /// <summary>
        /// [required when no markers] get or set zoom
        /// </summary>
        [Category("Google")]
        public int? Zoom
        {
            get
            {
                return ViewState["Zoom"] as int?;
            }
            set
            {
                ViewState["Zoom"] = value;
            }
        }

        /// <summary>
        /// [optional] get or set scale
        /// </summary>
        [Category("Google")]
        public int? Scale
        {
            get
            {
                return ViewState["Scale"] as int?;
            }
            set
            {
                ViewState["Scale"] = value;
            }
        }

        /// <summary>
        /// [optional] get or set image format
        /// </summary>
        [Category("Google")]
        public ImageFormat? ImageFormat
        {
            get
            {
                return ViewState["ImageFormat"] as ImageFormat?;
            }
            set
            {
                ViewState["ImageFormat"] = value;
            }
        }

        /// <summary>
        /// [optional] get or set map type
        /// </summary>
        [Category("Google")]
        public MapType? MapType
        {
            get
            {
                return ViewState["MapType"] as MapType?;
            }
            set
            {
                ViewState["MapType"] = value;
            }
        }

        /// <summary>
        /// [optional] get or set language, warning some area may not support this feature.
        /// </summary>
        [Category("Google")]
        public string Language
        {
            get
            {
                return ViewState["Language"] as string;
            }
            set
            {
                ViewState["Language"] = value;
            }
        }

        /// <summary>
        /// [required] get or set wheter use of sensor
        /// </summary>
        [Category("Google")]
        [DefaultValue(false)]
        public bool IsUseSensor
        {
            get
            {
                return ViewState["IsUseSensor"] == null ? false : (bool)ViewState["IsUseSensor"];
            }
            set
            {
                ViewState["IsUseSensor"] = value;
            }
        }

        private GenericStateManagedCollection<Marker> markers;

        /// <summary>
        /// [optional] get or set markers
        /// </summary>
        [Category("Google")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public GenericStateManagedCollection<Marker> Markers
        {
            get
            {
                if (markers == null)
                {
                    markers = new GenericStateManagedCollection<Marker>();
                }
                return markers;
            }
        }

        private GenericStateManagedCollection<Path> paths;

        /// <summary>
        /// [optional] get or set paths
        /// </summary>
        [Category("Google")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GenericStateManagedCollection<Path> Paths
        {
            get
            {
                if (paths == null)
                {
                    paths = new GenericStateManagedCollection<Path>();
                }
                return paths;
            }
        }

        private GenericStateManagedCollection<MapStyle> styles;

        /// <summary>
        /// [optional] get or set styles
        /// </summary>
        [Category("Google")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GenericStateManagedCollection<MapStyle> Styles
        {
            get 
            {
                if (styles == null)
                {
                    styles = new GenericStateManagedCollection<MapStyle>();
                }
                return styles; 
            }
        }

        protected override void LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                object[] data = savedState as object[];
                base.LoadViewState(data[0]);

                if (data[1] != null)
                    Markers.LoadViewState(data[1]);

                if (data[2] != null)
                    Paths.LoadViewState(data[2]);

                if (data[3] != null)
                    Styles.LoadViewState(data[3]);
            }
        }

        protected override object SaveViewState()
        {
            object[] savedata = new object[4];
            savedata[0] = base.SaveViewState();
            savedata[1] = markers == null ? null : markers.SaveViewState();
            savedata[2] = paths == null ? null : paths.SaveViewState();
            savedata[3] = styles == null ? null : styles.SaveViewState();

            return savedata;
        }
    }
}
