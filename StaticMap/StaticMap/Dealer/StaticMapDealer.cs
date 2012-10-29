// -----------------------------------------------------------------------
// <copyright file="StaticMapDealer.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Lib.GoogleMap.StaticMap.Dealer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Drawing;
    using System.IO;
    using Nltd.Lib.GoogleMap.StaticMap.Modules;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class StaticMapDealer : IMapDealer
    {

        public byte[] GetMapImageByte(Map m)
        {
            WebClient wb = new WebClient();
            return wb.DownloadData(m.Url);
        }

        public Image GetMapImage(Map m)
        {
            return Image.FromStream(new MemoryStream(GetMapImageByte(m)));
        }
    }
}
