﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace LinqToTwitter
{
    /// <summary>
    /// Geographical coordinates
    /// </summary>
    public class Coordinate
    {
        public const int LatitudePos = 0;
        public const int LongitudePos = 1;

        /// <summary>
        /// Converts XML to a Coordinate
        /// </summary>
        /// <param name="coordinate">XML to convert</param>
        /// <returns>Coordinate holding info from XML</returns>
        public static Coordinate CreateCoordinate(XElement coordinate)
        {
            if (coordinate == null || string.IsNullOrEmpty(coordinate.Value)) return null;

            List<XElement> coords = coordinate.Elements("item").ToList();

            return new Coordinate
            {
                Latitude = double.Parse(coords[LatitudePos].Value, CultureInfo.InvariantCulture),
                Longitude = double.Parse(coords[LongitudePos].Value, CultureInfo.InvariantCulture)
            };
        }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; set; }
    }
}
