using _365EJSC.ERP.Contract.Enumerations;

namespace _365EJSC.ERP.Contract.DTOs
{
    public class UploadFileRequest
    {
        public string Content { get; set; }
        public string RelativePath { get; set; }
        public string FileName { get; set; }
        public EnumOptionPath enumOptionPath { get; set; }
    }
}