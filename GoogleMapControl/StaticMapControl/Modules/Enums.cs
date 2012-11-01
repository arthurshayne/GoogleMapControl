// -----------------------------------------------------------------------
// <copyright file="Enums.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl
{
    public enum ImageFormat
    {
        png,
        png32,
        gif,
        jpg,
        jpg_baseline
    }

    public enum MapType
    {
        roadmap,
        satellite,
        terrain,
        hybrid
    }

    public enum MarkerSize
    {
        tiny,
        mid,
        small
    }

    public enum ColorEnum
    {
        black,
        brown,
        green,
        purple,
        yellow,
        blue,
        gray,
        orange,
        red,
        white
    }

    public enum StyleFeatureType
    {
        administrative,
        administrative_country,
        administrative_land_parcel,
        administrative_locality,
        administrative_neighborhood,
        administrative_province,
        all,
        landscape,
        landscape_man_made,
        landscape_natural,
        poi,
        poi_attraction,
        poi_business,
        poi_government,
        poi_medical,
        poi_park,
        poi_place_of_worship,
        poi_school,
        poi_sports_complex,
        road,
        road_arterial,
        road_highway,
        road_highway_controlled_access,
        road_local,
        transit,
        transit_line,
        transit_station,
        transit_station_airport,
        transit_station_bus,
        transit_station_rail,
        water
    }

    public enum StyleElementType
    {
        all,
        geometry,
        labels
    }

    public enum StyleVisibiltyType
    { 
        on,
        off,
        simplified
    }
}
