namespace IndustrialContoroler.Models.MapsViewModels
{
    public class MapsVM
    {
        public MapsVM(string FaName, string FaLongitude, string FaLatitude, string FaAddress)
        {
            this.FaName = FaName;
            this.FaLongitude = FaLongitude;
            this.FaLatitude = FaLatitude;
            this.FaAddress = FaAddress;
        }

        public string FaName { get; set; }
        public string FaAddress { get; set; }
        public string FaLongitude { get; set; }
        public string FaLatitude { get; set; }
    }
}
