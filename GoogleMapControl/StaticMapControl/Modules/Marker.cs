// -----------------------------------------------------------------------
// <copyright file="Marker.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using System;
using System.Web.UI;
using System.ComponentModel;
using Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl.Utility;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Drawing.Design;

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    public class Marker : IStateManager
    {
        public Marker()
        {
            ((IStateManager)this).TrackViewState();
        }

        /// <summary>
        /// [optional] get or set icon path
        /// </summary>
        [Category("Google")]
        public string IconPath
        {
            get
            {
                return ViewState["IconPath"] as string;
            }
            set
            {
                ViewState["IconPath"] = value;
            }
        }

        /// <summary>
        /// [optional] get or set marker set
        /// </summary>
        [Category("Google")]
        public MarkerSize? MarkerSize
        {
            get
            {
                return ViewState["MarkerSize"] as MarkerSize?;
            }
            set
            {
                ViewState["MarkerSize"] = value;
            }
        }

        /// <summary>
        /// [optional] get or set marker color
        /// </summary>
        [Category("Google")]
        public ColorEnum? EnumColor
        {
            get
            {
                return ViewState["EnumColor"] as ColorEnum?;
            }
            set
            {
                ViewState["EnumColor"] = value;
            }
        }

        /// <summary>
        /// [optional] get or set marker color
        /// </summary>
        [Category("Google")]
        [TypeConverter(typeof(WebColorConverter))]
        [Editor("System.Drawing.Design.ColorEditor, System.Drawing.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public Color? CustomColor
        {
            get
            {
                return ViewState["CustomColor"] as Color?;
            }
            set
            {
                ViewState["CustomColor"] = value;
            }
        }

        /// <summary>
        /// get color
        /// </summary>
        internal ObjectColor Color
        {
            get
            {
                if (CustomColor != null)
                {
                    return new ObjectColor(CustomColor.Value);
                }
                else if (EnumColor != null)
                {
                    return new ObjectColor(EnumColor.Value);
                }
                else
                {
                    return new ObjectColor(ColorEnum.red);
                }
            }
        }

        /// <summary>
        /// [optional] get or set marker label
        /// </summary>
        [Category("Google")]
        public char? Label
        {
            get
            {
                return ViewState["Label"] as char?;
            }
            set
            {
                ViewState["Label"] = value;
            }
        }

        private GenericStateManagedCollection<Location> locations;

        /// <summary>
        /// [required]get a set of locations
        /// </summary>
        [Category("Google")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GenericStateManagedCollection<Location> Locations
        {
            get
            {
                if (locations == null)
                {
                    locations = new GenericStateManagedCollection<Location>();
                    if (((IStateManager)this).IsTrackingViewState)
                        ((IStateManager)locations).TrackViewState();
                }
                return locations;
            }
        }

        public override string ToString()
        {
            StringBuilder marker = new StringBuilder();
            if (!String.IsNullOrEmpty(IconPath))
                marker.Append("icon:").Append(IconPath).Append("|");
            if(MarkerSize != null)
                marker.Append("size:").Append(MarkerSize).Append("|");
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

        #region ViewState
        private StateBag _stateBag = new StateBag();
        private bool _isTrackViewState;

        /// <summary>
        /// get viewstate
        /// </summary>
        protected StateBag ViewState
        {
            get
            {
                return _stateBag;
            }
        }

        bool IStateManager.IsTrackingViewState
        {
            get { return _isTrackViewState; }
        }

        void IStateManager.LoadViewState(object state)
        {
            if (state != null)
            {
                object[] data = state as object[];
                (ViewState as IStateManager).LoadViewState(data[0]);
                if (data[1] != null)
                    ((IStateManager)Locations).LoadViewState(data[1]);
            }
        }

        object IStateManager.SaveViewState()
        {
            object[] data = new object[2];
            data[0] = (ViewState as IStateManager).SaveViewState();
            data[1] = locations == null ? null : ((IStateManager)locations).SaveViewState();

            return data;
        }

        void IStateManager.TrackViewState()
        {
            _isTrackViewState = true;
            (ViewState as IStateManager).TrackViewState();
        }
        #endregion
    }

}
