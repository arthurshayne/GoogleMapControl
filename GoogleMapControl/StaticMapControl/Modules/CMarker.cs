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
using Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl.Modules;

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    public class CMarker : Marker, IStateManager
    {
        private bool _isTrackingViewState;

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

        [Browsable(false)]
        [DesignOnly(true)]
        public override ObjectColor Color
        {
            get
            {
                return CColor;
            }
        }

        /// <summary>
        /// Color for Control
        /// </summary>
        public CObjectColor CColor
        {
            get;
            set;
        }

        public bool IsTrackingViewState
        {
            get { return _isTrackingViewState; }
        }

        public void LoadViewState(object state)
        {
            if (state != null)
            {
                object[] data = state as object[];

                IconPath = data[0] as string;
                MarkerSize = data[1] as MarkerSize?;
                if (data[2] != null)
                {
                    CColor = new CObjectColor();
                    CColor.LoadViewState(data[2]);
                }
                Label = data[3] as char?;
                clocations.LoadViewState(data[4]);
            }
        }

        public object SaveViewState()
        {
            object[] data = new object[5];
            data[0] = IconPath;
            data[1] = MarkerSize;
            data[2] = CColor == null ? null : CColor.SaveViewState();
            data[3] = Label;
            data[4] = CLocations.SaveViewState(); 

            return data;
        }

        public void TrackViewState()
        {
            _isTrackingViewState = true;
        }
    }
}
