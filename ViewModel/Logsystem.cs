using IndustrialContoroler.Models;

namespace IndustrialContoroler.ViewModel
{
    public class Logsystem
    {
        public List<Request>? Requests { get; set; }
        public List<Facility>? Facility { get; set; }

        public List<RequestTraffic>? RequestTraffics { get; set; }
        public List<LogFieldVisitForms>? LogFieldVisitForms { get; set; }

        public Request requests{ get; set; }
        public Facility facility { get; set; }
    }
}
