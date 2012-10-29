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
using Nltd.Lib.GoogleMap.StaticMap.Modules;
using Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl.Modules;
using System.Collections;
using System.Reflection;
using System.Linq;

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    [ToolboxData("<{0}:StaticMapBox runat=\"server\"> </{0}:StaticMapBox>")]
    [Designer(typeof(StaticMapDesigner))]
    public class StaticMapBox : Image
    {
        public StaticMapBox()
        {
            BaseUrl = "http://maps.google.com/maps/api/staticmap";
            this.Height = 300;
            this.Width = 300;
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
                return ViewState["BaseUrl"] as string;
            }
            set
            {
                ViewState["BaseUrl"] = value;
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

        /// <summary>
        /// scaling for internal
        /// </summary>
        [Category("Google")]
        [DefaultValue(false)]
        public bool IsHighQality
        {
            get
            {
                return ViewState["IsHighQality"] == null ? false : (bool)ViewState["IsHighQality"];
            }
            set
            {
                ViewState["IsHighQality"] = value;
            }
        }

        private MarkerCollection cmarkers = new MarkerCollection();

        /// <summary>
        /// [optional] get or set markers
        /// </summary>
        [Category("Google")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MarkerCollection CMarkers
        {
            get{ return cmarkers;}
        }

        private PathCollection cpaths = new PathCollection();

        /// <summary>
        /// [optional] get or set paths
        /// </summary>
        [Category("Google")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PathCollection CPaths
        {
            get { return cpaths; }
        }

        public MapStyleCollection cstyles = new MapStyleCollection();

        /// <summary>
        /// [optional] get or set styles
        /// </summary>
        [Category("Google")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MapStyleCollection CStyles
        {
            get { return cstyles; }
        }

        /// <summary>
        /// [optional] get or set some location need to visible
        /// </summary>
        internal Location VisiableLocation 
        {
            get
            {
                if (VisiableAddress != null)
                {
                    return new Location(VisiableAddress);
                }
                else
                {
                    return new Location(VisiableLatitude ?? 0, VisiableLongitude ?? 0);
                }
            }
        
        }

        internal Location Center
        {
            get
            {
                if (CenterAddress != null)
                {
                    return new Location(CenterAddress);
                }
                else
                {
                    return new Location(CenterLatitude??0, CenterLongitude??0);
                }
            }
        }

        /// <summary>
        /// get MapSize
        /// </summary>
        [Browsable(false)]
        internal MapSize Size
        {
            get
            {
                return new MapSize() { Height = (int)this.Height.Value,Width = (int)this.Width.Value};
            }
        }

        internal CMap CMap
        {
            get
            {
                return new CMap()
                {
                    BaseUrl = BaseUrl,
                    Center = Center,
                    ImageFormat = ImageFormat,
                    IsUseSensor = IsUseSensor,
                    Language = Language,
                    MapType = MapType,
                    CMarkers = CMarkers,
                    CPaths = CPaths,
                    Scale = Scale,
                    Size = Size,
                    CStyles = CStyles,
                    Visible = VisiableLocation,
                    Zoom = Zoom
                };
            }
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            this.ImageUrl = CMap.Url;
            base.Render(writer);
        }
    }
}
