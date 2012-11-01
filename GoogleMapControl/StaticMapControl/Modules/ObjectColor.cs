// -----------------------------------------------------------------------
// <copyright file="Color.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Web.UI;
using System.ComponentModel;
using System.Drawing;
namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    public class ObjectColor
    {
        protected Color? color;
        protected ColorEnum? colorEnum;

        /// <summary>
        /// use int to initial, eg. new Color(0xFFFFF)
        /// </summary>
        /// <param name="color"></param>
        public ObjectColor(Color color)
        {
            this.color = color;
        }

        /// <summary>
        /// use enum to initial, eg. new Color(ColorEnum.green)
        /// </summary>
        /// <param name="colorEnum"></param>
        public ObjectColor(ColorEnum colorEnum)
        {
            this.colorEnum = colorEnum;
        }

        public override string ToString()
        {
            if (color != null)
            {
                return string.Format("0x{0:X2}{1:X2}{2:X2}", color.Value.R, color.Value.G, color.Value.B);
            }
            else
            {
                return colorEnum.ToString();
            }
        }
    }
}
