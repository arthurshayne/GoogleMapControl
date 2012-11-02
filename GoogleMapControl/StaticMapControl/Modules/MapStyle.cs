// -----------------------------------------------------------------------
// <copyright file="Style.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    using System.Text;
    using System.Web.UI;

    /// <summary>
    /// MapStyle
    /// </summary>
    public class MapStyle : IStateManager
    {
        public MapStyle()
        {
            ((IStateManager)this).TrackViewState();
        }

        /// <summary>
        /// get or set feature type, will be all if do not set
        /// </summary>
        public StyleFeatureType? FeatureType
        {
            get
            {
                return ViewState["FeatureType"] as StyleFeatureType?;
            }
            set
            {
                ViewState["FeatureType"] = value;
            }
        }

        /// <summary>
        /// get or set element type, will be all if do not set
        /// </summary>
        public StyleElementType? ElementType
        {
            get
            {
                return ViewState["ElementType"] as StyleElementType?;
            }
            set
            {
                ViewState["ElementType"] = value;
            }
        }

        /// <summary>
        /// get or set hue
        /// </summary>
        public string Hue
        {
            get
            {
                return ViewState["Hue"] as string;
            }
            set
            {
                ViewState["Hue"] = value;
            }
        }

        /// <summary>
        /// get or set lightness, value should between -100 and 100
        /// </summary>
        public short? Lightness
        {
            get
            {
                return ViewState["Lightness"] as short?;
            }
            set
            {
                ViewState["Lightness"] = value;
            }
        }

        /// <summary>
        /// get or set saturation, value should between -100 and 100
        /// </summary>
        public short? Saturation
        {
            get
            {
                return ViewState["Saturation"] as short?;
            }
            set
            {
                ViewState["Saturation"] = value;
            }
        }

        /// <summary>
        /// get or set gamma, value should between 0.01 and 10.0
        /// </summary>
        public float? Gamma
        {
            get
            {
                return ViewState["Gamma"] as float?;
            }
            set
            {
                ViewState["Gamma"] = value;
            }
        }

        /// <summary>
        /// get or set inverse lightness
        /// </summary>
        public bool? InverseLightness
        {
            get
            {
                return ViewState["InverseLightness"] as bool?;
            }
            set
            {
                ViewState["InverseLightness"] = value;
            }
        }

        /// <summary>
        /// get or set visibility
        /// </summary>
        public StyleVisibiltyType? Visibility
        {
            get
            {
                return ViewState["Visibility"] as StyleVisibiltyType?;
            }
            set
            {
                ViewState["Visibility"] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (FeatureType != null)
                sb.Append("feature:").Append(FeatureType.ToString().Replace("_",".")).Append("|");

            if (ElementType != null)
                sb.Append("element:").Append(ElementType.ToString()).Append("|");

            if (Hue != null)
                sb.Append("hue:").Append(Hue).Append("|");

            if (Lightness != null)
                sb.Append("lightness:").Append(Lightness.ToString()).Append("|");

            if (Saturation != null)
                sb.Append("saturation:").Append(Saturation.ToString()).Append("|");

            if (Gamma != null)
                sb.Append("gamma:").Append(Gamma.ToString()).Append("|");

            if (InverseLightness != null)
                sb.Append("inverse_lightness:").Append(InverseLightness.ToString().ToLower()).Append("|");

            if (Visibility != null)
                sb.Append("visibility:").Append(Visibility.ToString()).Append("|");

            return sb.ToString().TrimEnd('|');
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
}
