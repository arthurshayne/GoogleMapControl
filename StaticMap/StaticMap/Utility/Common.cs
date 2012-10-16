// -----------------------------------------------------------------------
// <copyright file="Common.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Lib.GoogleMap.StaticMap.Utility
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
