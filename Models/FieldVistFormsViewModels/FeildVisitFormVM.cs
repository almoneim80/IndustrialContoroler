namespace IndustrialContoroler.Models.FieldVistFormsViewModels
{
    public class FeildVisitFormVM
    {
        public List<Facility> facilities { get; set; }
        public List<Building> buildings { get; set; }
        public List<Worker> workers { get; set; }

        public List<Machine> machines { get; set; }

        public List<RowMaterial> rowMaterials { get; set; }

        public List<HelpMaterial> helpMaterials { get; set; }

        public List<AgentsPoint> agentsPoints { get; set; }

        public List<ProCapacity> proCapacities { get; set; }

        public List<SafetySecurity> safetySecurities { get; set; }

        public List<CastDatum> castData { get; set; }

        public List<SiteReason> siteReasons { get; set; }

        public List<SecondaryAct> secondaryActs { get; set; }

        public List<RelevantDoc> relevantDocs { get; set; }

        public List<VisitsTraffic> visitsTraffics { get; set; }

        public List<Transportation> transportations { get; set; }
    }
}
