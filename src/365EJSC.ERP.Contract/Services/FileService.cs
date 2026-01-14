using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Constants;
using _365EJSC.ERP.Contract.DTOs;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace _365EJSC.ERP.Contract.Services
{
    public class FileService : IFileService
    {
        private readonly string fileDirectoryPath;
        private readonly DomainHostsDTOs domainSetting;
        private readonly UploadedSettingsDTOs uploadedSettings;

        private const long MAX_FILE_SIZE = 2 * 1024 * 1024;

        // use data from db
        private readonly List<string> permittedExtensions = [".png", ".jpg", ".jpeg", ".pdf", ".webp"];

        private static readonly List<FileSignature> FileSignatures =
        [
            new FileSignature(".jpeg", [0xFF, 0xD8]), // JPEG
            new FileSignature(".png", [0x89, 0x50, 0x4E, 0x47]), // PNG
            new FileSignature(".pdf", [0x25, 0x50, 0x44, 0x46]), // PDF
            new FileSignature(".gif", [0x47, 0x49, 0x46, 0x38]), // GIF
            new FileSignature(".webp", [
                0x52, 0x49, 0x46, 0x46, // RIFF
                null, null, null, null, // xx xx xx xx (bỏ qua)
                0x57, 0x45, 0x42, 0x50 // WEBP
            ])
        ];

        public FileService(IWebHostEnvironment env,
                           IOptions<DomainHostsDTOs> domainSetting,
                           IOptions<UploadedSettingsDTOs> uploadedSettings)
        {
            fileDirectoryPath = Path.Combine(env.WebRootPath);
            this.domainSetting = domainSetting.Value;
            this.uploadedSettings = uploadedSettings.Value;
        }

        private string GetFileExtensionFromBase64(string base64Content)
        {
            // Convert base64 into byte array
            byte[] fileBytes = Convert.FromBase64String(base64Content);

            // Compare a length first bytes of fileBytes with signature key to get file extension
            return FileSignatures.FirstOrDefault(signature =>

                       // File length must be longer than signature length
                       fileBytes.Length >= signature.Signature.Length &&

                       // Take a length bytes of signature key from fileBytes and compare sequence equal with signature keys
                       MatchesSignature(fileBytes, signature.Signature))?.Extension

                   // If there is no matching signature, throw exception
                   ?? throw new InvalidOperationException("Unknown file format.");
        }

        private string GetFilePath(string relativePath, string fileName)
        {
            // Combine directory with relative path
            string fullRelativePath = Path.Combine(fileDirectoryPath, relativePath);

            // If directory after combine isn't exist, create new   
            if (!Directory.Exists(fullRelativePath)) Directory.CreateDirectory(fullRelativePath);

            // Combine with file name to get full file path
            return Path.Combine(fullRelativePath, fileName).Replace("\\", "/");
        }

        private string GetRelativeFilePath(string relativePath, string fileName) => Path.Combine(relativePath, fileName).Replace("\\", "/");

        private async Task SaveFile(IFormFile file, string filePath)
        {
            // Write file to directory
            await using FileStream stream = new(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
        }

        private IFormFile ConvertBase64ToFormFile(string base64Content, string fileName)
        {
            byte[]? fileBytes = Convert.FromBase64String(base64Content);
            if (fileBytes == null || fileBytes.Length == 0) CustomException.ThrowValidationException(MsgCode.ERR_INVALID_FILE);
            if (fileBytes.Length > MAX_FILE_SIZE)
                CustomException.ThrowValidationException(MsgCode.ERR_FILE_TOO_LARGE);
            MemoryStream stream = new(fileBytes);
            return new FormFile(stream, 0, fileBytes.Length, "file", fileName);
        }

        private bool IsExtensionPermitted(string extension) => permittedExtensions.Contains(extension);

        private static bool MatchesSignature(byte[] fileBytes, byte?[] signature)
        {
            for (int i = 0; i < signature.Length; i++)
            {
                // Skip null
                if (signature[i] == null)
                    continue;
                if (fileBytes[i] != signature[i])
                    return false;
            }

            return true;
        }

        public async Task<string> UploadFileAsync(UploadFileRequest uploadFileRequest)
        {
            string pathResult = string.Empty;
            try
            {
                uploadFileRequest.RelativePath = GetPathDir(uploadFileRequest.enumOptionPath, uploadedSettings);

                //UploadFileRequest uploadFileRequest = context.Message;
                string extension = GetFileExtensionFromBase64(uploadFileRequest.Content);
                string fileName = Path.GetFileNameWithoutExtension(uploadFileRequest.FileName) + extension;

                // Check extension is permitted
                if (!IsExtensionPermitted(extension))
                    CustomException.ThrowValidationException(MsgCode.ERR_INVALID_FILE, MsgConst.EXT_NOT_PERMITTED);

                IFormFile file = ConvertBase64ToFormFile(uploadFileRequest.Content, fileName);

                string filePath = GetFilePath(uploadFileRequest.RelativePath, fileName);

                // Write file to directory
                await SaveFile(file, filePath);

                pathResult = GetRelativeFilePath(uploadFileRequest.RelativePath, fileName);
            }
            catch (Exception)
            {
                pathResult = "";
            }

            return pathResult;
        }

        private string GetPathDir(EnumOptionPath optionPathEnum, UploadedSettingsDTOs settings)
        {
            string res = Const.OUTPUTFILE_UPLOADED;

            switch (optionPathEnum)
            {
                case EnumOptionPath.Company:
                    res = checkNullorEmpty(settings.Company, res);
                    break;

                case EnumOptionPath.Employee:
                    res = checkNullorEmpty(settings.Employee, res);
                    break;

                case EnumOptionPath.EmployeeVerify:
                    res = checkNullorEmpty(settings.EmployeeVerify, res);
                    break;

                case EnumOptionPath.ProSupplierCatalog:
                    res = checkNullorEmpty(settings.ProSupplierCatalog, res);
                    break;

                case EnumOptionPath.ProSupplierVerify:
                    res = checkNullorEmpty(settings.ProSupplierVerify, res);
                    break;

                case EnumOptionPath.ProBrandCatalog:
                    res = checkNullorEmpty(settings.ProBrandCatalog, res);
                    break;

                case EnumOptionPath.ProManufacturerCatalog:
                    res = checkNullorEmpty(settings.ProManufacturerCatalog, res);
                    break;

                case EnumOptionPath.CustomerCatalog:
                    res = checkNullorEmpty(settings.CustomerCatalog, res);
                    break;

                case EnumOptionPath.ConfigIcon:
                    res = checkNullorEmpty(settings.ConfigIcon, res);
                    break;

                case EnumOptionPath.BeautyDefine:
                    res = checkNullorEmpty(settings.BeautyDefine, res);
                    break;

                case EnumOptionPath.BeautyPricing:
                    res = checkNullorEmpty(settings.BeautyPricing, res);
                    break;

                case EnumOptionPath.BeautyService:
                    res = checkNullorEmpty(settings.BeautyService, res);
                    break;

                case EnumOptionPath.BeautyAIFace:
                    res = checkNullorEmpty(settings.BeautyAIFace, res);
                    break;
                
                case EnumOptionPath.BeautyAIAnalyzer:
                    res = checkNullorEmpty(settings.BeautyAIAnalyzer, res);
                    break;
                case EnumOptionPath.BeautyWebShow:
                    res = checkNullorEmpty(settings.BeautyWebShow, res);
                    break;

                default:
                    break;
            }

            return res;
        }

        private string checkNullorEmpty(string values, string _default = "")
        {
            if (!string.IsNullOrEmpty(values)) return values;
            return _default;
        }

        public string GetFullPathFileServer(string? filePath)
        {
            return !string.IsNullOrWhiteSpace(filePath) ? string.Format("{0}{1}", domainSetting.Url, filePath) : null;
        }
    }
}