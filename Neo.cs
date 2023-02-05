using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace lmorgado_nasa
{
    // helper class for the NEO class
     class CloseApproach
    {
        public string close_approach_date { get; set; }
        public string close_approach_date_full { get; set; }
        public double epoch_date_close_approach { get; set; }
        public RelativeVelocity relative_velocity { get; set; }
    public MissDistance miss_distance { get; set; }
        public string orbiting_body { get; set; }
    }
    // helper class for the NEO class
     class EstimatedDiameter
    {
        public Kilometers kilometers { get; set; }
        public Meters meters { get; set; }
        public Miles miles { get; set; }
        public Feet feet { get; set; }
    }
    // helper class for the NEO class
     class OrbitalData
    {
        public string orbit_id { get; set; }
        public string orbit_determination_date { get; set; }
        public string first_observation_date { get; set; }
        public string last_observation_date { get; set; }
        public double data_arc_in_days { get; set; }
        public double observations_used { get; set; }
        public string orbit_uncertainty { get; set; }
        public string minimum_orbit_intersection { get; set; }
        public string jupiter_tisserand_invariant { get; set; }
        public string epoch_osculation { get; set; }
        public string eccentricity { get; set; }
        public string semi_major_axis { get; set; }
        public string inclination { get; set; }
        public string ascending_node_longitude { get; set; }
        public string orbital_period { get; set; }
        public string perihelion_distance { get; set; }
        public string perihelion_argument { get; set; }
        public string aphelion_distance { get; set; }
        public string perihelion_time { get; set; }
        public string mean_anomaly { get; set; }
        public string mean_motion { get; set; }
        public string equinox { get; set; }
        class orbit_class
        {
            public string orbit_class_type { get; set; }
            public string orbit_class_description { get; set; }
            public string orbit_class_range { get; set; }
        }
        public bool is_sentry_object { get; set; }
    }
    // helper class for the NEO class
     class Links
    {
        public string next { get; set; }
        public string previous { get; set; }
        public string self { get; set; }
    }
    // helper class for the NEO class
     class Kilometers
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }
    // helper class for the NEO class
     class Meters
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }
    // helper class for the NEO class
     class Miles
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }
    // helper class for the NEO class
     class Feet
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }
    // helper class for the NEO class
     class RelativeVelocity
    {
        public string kilometers_per_second { get; set; }
        public string kilometers_per_hour { get; set; }
        public string miles_per_hour { get; set; }
    }
    // helper class for the NEO class
     class MissDistance
    {
        public string astronomical { get; set; }
        public string lunar { get; set; }
        public string kilometers { get; set; }
        public string miles { get; set; }
    }
    // a class representing a near earth object from the nasa api neo feed
    class NEO
    {
        public string id { get; set; }
        public string neo_reference_id { get; set; }
        public string name { get; set; }
        public string nasa_jpl_url { get; set; }
        public double absolute_magnitude_h { get; set; }
        public EstimatedDiameter estimated_diameter { get; set; }
        public bool is_potentially_hazardous_asteroid { get; set; }
        public List<CloseApproach> close_approach_data { get; set; }
        public bool is_sentry_object { get; set; }

        // transforms a neo to a display neo
        public NeoDisplay TransformNeo(string unit)
        {
            NeoDisplay display = new NeoDisplay();
            display.id = id;
            display.name = name;
            display.absolute_magnitude_h = absolute_magnitude_h;
            switch (unit)
            {
                case "kilometers":
                    display.estimated_diameter_min = estimated_diameter.kilometers.estimated_diameter_min;
                    display.estimated_diameter_max = estimated_diameter.kilometers.estimated_diameter_max;
                    break;
                case "meters":
                    display.estimated_diameter_min = estimated_diameter.meters.estimated_diameter_min;
                    display.estimated_diameter_max = estimated_diameter.meters.estimated_diameter_max;
                    break;
                case "miles":
                    display.estimated_diameter_min = estimated_diameter.miles.estimated_diameter_min;
                    display.estimated_diameter_max = estimated_diameter.miles.estimated_diameter_max;
                    break;
                case "feet":
                    display.estimated_diameter_min = estimated_diameter.feet.estimated_diameter_min;
                    display.estimated_diameter_max = estimated_diameter.feet.estimated_diameter_max;
                    break;
                default:
                    display.estimated_diameter_min = 0;
                    display.estimated_diameter_max = 0;
                    break;

            }
            CloseApproach data = close_approach_data[0];
            display.close_approach_date = data.close_approach_date;
            display.close_approach_date_full = data.close_approach_date_full;
            display.kilometers_per_second = data.relative_velocity.kilometers_per_second;
            display.kilometers_per_hour = data.relative_velocity.kilometers_per_hour;
            display.miles_per_hour = data.relative_velocity.miles_per_hour;
            display.Distance_astronomical = data.miss_distance.astronomical;
            display.Distance_lunar = data.miss_distance.lunar;
            display.Distance_kilometers = data.miss_distance.kilometers;
            display.Distance_miles = data.miss_distance.miles;
            display.orbiting_body = data.orbiting_body;
            display.is_potentially_hazardous_asteroid = is_potentially_hazardous_asteroid;
            display.is_sentry_object = is_sentry_object;
            return display;
        }
        // transforms a list of neo to a list of display neo
        public List<NeoDisplay> TransformNeoList(string unit, List<NEO> list)
        {
            List<NeoDisplay> displayList = new List<NeoDisplay>();
            foreach (NEO neo in list)
            {
                displayList.Add(neo.TransformNeo(unit));
            }
            return displayList;
        }
    }


    // the class to represent and display a NEO
    class NeoDisplay
    {
        public string id { get; set; }
        public string name { get; set; }
        public double absolute_magnitude_h { get; set; }
        public string Distance_kilometers { get; set; }
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
        public string close_approach_date { get; set; }
        public string close_approach_date_full { get; set; }
        public string orbiting_body { get; set; }
        public bool is_potentially_hazardous_asteroid { get; set; }
        public bool is_sentry_object { get; set; }
        public string kilometers_per_second { get; set; }
        public string kilometers_per_hour { get; set; }
        public string miles_per_hour { get; set; }
        public string Distance_astronomical { get; set; }
        public string Distance_lunar { get; set; }
        public string Distance_miles { get; set; }
    }
    // the Representation of neo feed list from the nasa api
    class NEOFeed
    {
        public int element_count { get; set; }

        public Dictionary<string, List<NEO>> near_earth_objects { get; set; }

        public static NEOFeed GetNeoFeed(NasaApi nasaAPI,DateTime startDate, DateTime endDate )
        {
            string result = "";
            NEOFeed neoFeed = new NEOFeed();
            List<string> paramsList = new List<string>();
            paramsList.Add("start_date=" + startDate.ToString("yyyy-MM-dd"));
            paramsList.Add("end_date=" + endDate.ToString("yyyy-MM-dd"));
            result = nasaAPI.Call("https://api.nasa.gov/neo/rest/v1/feed", paramsList);
            if (result != "")
            {
                // convert json 
                neoFeed = JsonSerializer.Deserialize<NEOFeed>(result);
            }
            return neoFeed;
        }
    }
}
