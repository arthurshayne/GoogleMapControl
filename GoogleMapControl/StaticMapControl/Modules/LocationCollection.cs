// -----------------------------------------------------------------------
// <copyright file="LocationCollection.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Nltd.Lib.GoogleMap.StaticMap.Modules;
    using System.Web.UI;

    /// <summary>
    /// LocationCollection
    /// </summary>
    public class LocationCollection : List<CLocation>, IStateManager
    {
        private bool _isTrackingViewState;

        public List<Location> ToLocationList()
        {
            return this.ToList<Location>();
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
                CLocation temp;
                foreach (object d in data)
                {
                    temp = new CLocation();
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
