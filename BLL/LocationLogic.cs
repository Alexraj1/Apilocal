using ApiLocal.Model;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiLocal.BLL
{
    public  class LocationLogic
    {
        private string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        private static LocationLogic instance = null;
        private Root item=null;
        private EntrepriseRoot entreprise = null;
        public static LocationLogic GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new LocationLogic();
                return instance;
            }
        }
        public LocationLogic()
        {
            if (item == null)
            {
                String FilePath = Path.Combine(_filePath, "Data", "laposte.json");
                item = JsonFileReader.Read<Root>(FilePath);
            }
           if(entreprise==null)
            {
                String FilePath = Path.Combine(_filePath, "Data", "entreprise.json");
                entreprise = JsonFileReader.Read<EntrepriseRoot>(FilePath);
            }
        }


        public  IEnumerable<Properties> GetLocationAvailable(string search)
        {
            search = search.ToUpper();
            return item.features.Where(x=>x.properties.code_postal.StartsWith(search) || x.properties.nom_de_la_commune.StartsWith(search)).Select(y=> y.properties);
        }

        public IEnumerable<Societe> GetEntrepriseInfo()
        {
            return GetEntrepriseInfo(null);
        }
        public IEnumerable<Societe> GetEntrepriseInfo(string? insee)
        {
            List<Entreprise> e = entreprise.entreprise;
            if (insee != null)
            {
                 e = e.Where(d => d.disponibilities_insee.Contains(insee)).ToList();
            }
            return e.Select(x => new Societe
            {
                Name = x.Name,
                address = x.address,
                LocationProperties = item.features.Where(y => x.disponibilities_insee.Contains(y.properties.code_commune_insee)).Select(z => z.properties)
            });
        }
    }
}
