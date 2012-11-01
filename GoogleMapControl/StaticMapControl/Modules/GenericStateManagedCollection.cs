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
    using System.Web.UI;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using System.Collections;

    /// <summary>
    /// LocationCollection
    /// </summary>
    public class GenericStateManagedCollection<T> : List<T>, IStateManager where T : IStateManager, new()
    {
        # region IStateManager
        private bool _isTrackingViewState;

        public bool IsTrackingViewState
        {
            get { return _isTrackingViewState; }
        }

        public void LoadViewState(object state)
        {
            if (state != null)
            {
                object[] data = state as object[];
                T temp;
                foreach (var d in data)
                {
                    temp = new T();
                    temp.LoadViewState(d);
                    this.Add(temp);
                }
            }
        }

        public object SaveViewState()
        {
            int count = this.Count;
            object[] data = new object[count];
            for (int i = 0; i < count; i++)
            {
                data[i] = this[i].SaveViewState();
            }

            return data;
        }

        public void TrackViewState()
        {
            _isTrackingViewState = true;
        }
        #endregion
    }
}