using System;
using System.Collections.Generic;

namespace SmartElectronicsMVC.Models
{
    public partial class AudioDescription
    {
        public int? ProdId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public string? ConnectorType { get; set; }
        public string? SpecialFeature { get; set; }

        public virtual Product? Prod { get; set; }

        public List<AudioDescription> GetDescription(int id)
        {
            using (var db = new SmartElectronicsContext())
            {
                var res = (from i in db.AudioDescriptions
                           where i.ProdId == id
                           select i).ToList();
                return res;
            }
        }
    }
}
