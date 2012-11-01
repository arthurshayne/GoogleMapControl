// -----------------------------------------------------------------------
// <copyright file="Size.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    public struct MapSize
    {
        public int Width;
        public int Height;

        public MapSize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            return string.Format("{0}x{1}", Width, Height);
        }
    }
}
