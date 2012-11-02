// -----------------------------------------------------------------------
// <copyright file="Structs.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Web.UI;
using System.ComponentModel;
using Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl.Utility;

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    public class Location : IStateManager
    {
        public Location()
        {
            ((IStateManager)this).TrackViewState();
        }

        /// <summary>
        /// get or set Latitude
        /// </summary>
        [Category("Google")]
        public double? Latitude
        {
            get
            {
                return ViewState["Latitude"] as double?;
            }
            set
            {
                ViewState["Latitude"] = value;
            }
        }

        /// <summary>
        /// get or set Longitude
        /// </summary>
        [Category("Google")]
        public double? Longitude
        {
            get
            {
                return ViewState["Longitude"] as double?;
            }
            set
            {
                ViewState["Longitude"] = value;
            }
        }

        /// <summary>
        /// get or set Address
        /// </summary>
        [Category("Google")]
        public string Address
        {
            get
            {
                return ViewState["Address"] as string;
            }
            set
            {
                ViewState["Address"] = value;
            }
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(Address))
                return Address.UrlEncode();
            else if (Latitude != null && Longitude != null)
                return new Coordinate(Latitude.Value, Longitude.Value).ToString();
            else
                return "";
        }

        #region ViewState
        private StateBag _stateBage = new StateBag();
        private bool _isTrackViewState;

        /// <summary>
        /// gets viewstate
        /// </summary>
        protected StateBag ViewState
        {
            get
            {
                return _stateBage;
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
                (ViewState as IStateManager).LoadViewState(state);
            }
        }

        object IStateManager.SaveViewState()
        {
            return (ViewState as IStateManager).SaveViewState();
        }

        void IStateManager.TrackViewState()
        {
            _isTrackViewState = true;
            (ViewState as IStateManager).TrackViewState();
        }
        #endregion
    }

    /// <summary>
    /// coordinate uses in location
    /// </summary>
    public struct Coordinate
    {
        public double Latitude;
        public double Longitude;

        public Coordinate(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}",Latitude,Longitude);
        }
    }
}
