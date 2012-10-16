// -----------------------------------------------------------------------
// <copyright file="IMapDealer.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Lib.GoogleMap.StaticMap.Dealer
{
    using System;
    using Nltd.Lib.GoogleMap.StaticMap.Modules;
    using System.Drawing;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IMapDealer
    {
        /// <summary>
        /// get map image byte array
        /// </summary>
        /// <param name="m">Map object</param>
        /// <returns>image byte array</returns>
        byte[] GetMapImageByte(Map m);

        /// <summary>
        /// get map image
        /// </summary>
        /// <param name="m">Map object</param>
        /// <returns>Image object</returns>
        Image GetMapImage(Map m);
    }
}
