// -----------------------------------------------------------------------
// <copyright file="Structs.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    using System.ComponentModel;
    using System;
    using Nltd.Lib.GoogleMap.StaticMap.Modules;
    using System.Web.UI;

    public class CLocation : Location, IStateManager
    {
        private bool _isTrackingViewState;

        /// <summary>
        /// Default
        /// </summary>
        public CLocation() : base ("")
        {
            
        }

        public bool IsTrackingViewState
        {
            get { return _isTrackingViewState; }
        }

        public void LoadViewState(object state)
        {
            if (state != null)
            {
                object[] array = (object[])state;
                Latitude = array[0] as double?;
                Longitude = array[1] as double?;
                Address = array[2] as string;
            }
        }

        public object SaveViewState()
        {
            object[] array = new object[3];
            array[0] = Latitude;
            array[1] = Longitude;
            array[2] = Address;

            return array;
        }

        public void TrackViewState()
        {
            _isTrackingViewState = true;
        }
    }
}