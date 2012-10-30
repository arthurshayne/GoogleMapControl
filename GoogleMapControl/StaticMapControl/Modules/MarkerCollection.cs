// -----------------------------------------------------------------------
// <copyright file="MarkCollection.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.UI;
    using Nltd.Lib.GoogleMap.StaticMap.Modules;

    /// <summary>
    /// MarkCollection
    /// </summary>
    public class MarkerCollection : List<CMarker>, IStateManager
    {
        private bool _isTrackingViewState;

        public List<Marker> ToMarkerList()
        {
            return this.ToList<Marker>();
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
                CMarker temp;
                foreach (object d in data)
                {
                    temp = new CMarker();
                    temp.LoadViewState(d);
                    this.Add(temp);
                }
            }
        }

        public object SaveViewState()
        {
            int num = this.Count;
            object[] data = new object[num];
            for (int i = 0; i < num; i++)
            {
                data[i] = this[i].SaveViewState();
            }

            return data;
        }

        public void TrackViewState()
        {
            _isTrackingViewState = true;
        }
    }
}
