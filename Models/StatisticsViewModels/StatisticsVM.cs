using IndustrialContoroler.Models;

namespace IndustrialContoroler.Models
{
    public class VewStatistics
    {
        public List<Facility> facility { get; set; }
        public List<SiteReason> SiteReason { get; set; }
        public List<ProCapacity> ProCapacity { get; set; }
        public int statistic_num { get; set; }
    }
}