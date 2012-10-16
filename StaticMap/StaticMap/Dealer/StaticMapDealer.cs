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
            Image showImg = Image.FromStream(new MemoryStream(GetMapImageByte(m)));
            int scale = m.Scale ?? 2;

            if (m.IsHighQality)
            {
                int iSourceWidth = showImg.Width;
                int iSourceHeight = showImg.Height;
                float fSourceHorResolution = showImg.HorizontalResolution;
                float fSourceVerResolution = showImg.VerticalResolution;

                //图象dpi
                Bitmap bmpTarget = new Bitmap(iSourceWidth / scale, iSourceHeight / scale);
                bmpTarget.SetResolution(fSourceHorResolution * scale, fSourceVerResolution * scale);

                using (Graphics g = Graphics.FromImage(bmpTarget))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.DrawImage(showImg, 0, 0, iSourceWidth / scale, iSourceHeight / scale);
                }

                return bmpTarget;
            }
            else
            {
                return showImg;
            }
        }
    }
}
