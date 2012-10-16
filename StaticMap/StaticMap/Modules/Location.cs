// -----------------------------------------------------------------------
// <copyright file="Structs.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using Nltd.Lib.GoogleMap.StaticMap.Utility;
using System;

namespace Nltd.Lib.GoogleMap.StaticMap.Modules
{
    public class Location
    {
        /// <summary>
        /// get or set Latitude
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// get or set Longitude
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// get or set Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// use x,y to initial, eg. new Location(40.714728,-73.998672)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Location(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// use string to initial, eg. new Location("Brooklyn+Bridge,New+York,NY")
        /// </summary>
        /// <param name="address"></param>
        public Location(string address)
        {
            this.Address = address;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(Address))
                return Address.UrlEncode();
            else
                return new Coordinate(Latitude ?? 0, Longitude ?? 0).ToString();
        }
    }

    /// <summary>
    /// coordinate uses in location
    /// </summary>
    public struct Coordinate
    {
        public double Latitude;
        public double Longitude;

        public Coordinate(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public override string  ToString()
        {
            return string.Format("{0},{1}",Latitude,Longitude);
        }
    }
}
