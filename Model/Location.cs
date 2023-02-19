namespace ApiLocal.Model
{
    public class Location
    {
        public int Id { get; set; } 
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Properties
    {
        public string nom_de_la_commune { get; set; }
        public string libelle_d_acheminement { get; set; }
        public string code_postal { get; set; }
        public List<double> coordonnees_gps { get; set; }
        public string code_commune_insee { get; set; }
        public string ligne_5 { get; set; }
    }

    public class Root
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }
}
