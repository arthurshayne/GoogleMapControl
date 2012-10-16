// -----------------------------------------------------------------------
// <copyright file="Color.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Lib.GoogleMap.StaticMap.Modules
{
    public class ObjectColor
    {
        int? color;
        ColorEnum? colorEnum;

        /// <summary>
        /// use int to initial, eg. new Color(0xFFFFF)
        /// </summary>
        /// <param name="color"></param>
        public ObjectColor(int color)
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
                return string.Format("0x{0:X6}", color);
            }
            else
            {
                return colorEnum.ToString();
            }
        }
    }
}
