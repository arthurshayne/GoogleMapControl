// -----------------------------------------------------------------------
// <copyright file="Common.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl.Utility
{
    using System;
    using System.Text;
    using System.Web;

    /// <summary>
    /// Common
    /// </summary>
    public static class Common
    {
        public static string UrlEncode(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }
    }
}
