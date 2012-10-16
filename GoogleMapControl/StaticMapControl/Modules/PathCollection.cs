// -----------------------------------------------------------------------
// <copyright file="PathCollection.cs" company="">
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

    /// <summary>
    /// PathCollection
    /// </summary>
    public class PathCollection : List<CPath>
    {
        public List<Path> ToPathList()
        {
            return this.ToList<Path>();
        }
    }
}
