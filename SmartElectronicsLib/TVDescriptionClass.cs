using SmartElectronicsLib.Models;

namespace SmartElectronicsLib
{
    public class TVDescriptionClass
    {
        public List<Tvdescription> GetDescription(int id)
        {
            using (var db = new SmartElectronicsContext())
            {
                var res = (from i in db.Tvdescriptions
                           where i.ProdId == id select i).ToList();
                return res;
            }
        }

    }
}