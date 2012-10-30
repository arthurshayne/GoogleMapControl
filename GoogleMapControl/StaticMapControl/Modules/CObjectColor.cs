// -----------------------------------------------------------------------
// <copyright file="CObjectColor.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Nltd.Lib.GoogleMap.StaticMap.Modules;
    using System.Web.UI;

    /// <summary>
    /// Object Color for contorl
    /// </summary>
    public class CObjectColor : ObjectColor, IStateManager
    {
        public ColorEnum? ColorEnum
        {
            get
            {
                return colorEnum;
            }
            set
            {
                colorEnum = value;
            }
        }

        public CObjectColor()
            : base(Nltd.Lib.GoogleMap.StaticMap.Modules.ColorEnum.red)
        { 
            
        }

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
                color = data[0] as int?;
                colorEnum = data[1] as ColorEnum?;
            }
        }

        public object SaveViewState()
        {
            object[] data = new object[2];
            data[0] = color;
            data[1] = colorEnum;
            return data;
        }

        public void TrackViewState()
        {
            _isTrackingViewState = true;
        }
    }
}
