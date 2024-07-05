namespace IndustrialContoroler.Models.requestsViewModels
{
    public class RequestAttsAttsTypeVM
    {
        public List<Request> request { get; set; } 
        public List<Attachment> attachment { get; set; }
        public List<AttachmentType> attachmentType { get; set; }
    }
}
