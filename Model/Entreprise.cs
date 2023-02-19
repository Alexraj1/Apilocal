namespace ApiLocal.Model
{
    public class Societe
    {
        public string Name { get; set; }
        public Address address { get; set; }
        public IEnumerable<Properties> LocationProperties { get; set; }
    }
    public class Address
    {
        public string no { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public List<double> coordonnees_gps { get; set; }
    }

    public class Entreprise
    {
        public string Name { get; set; }
        public Address address { get; set; }
        public List<string> disponibilities_insee { get; set; }
    }

    public class EntrepriseRoot
    {
        public List<Entreprise> entreprise { get; set; }
    }
}
