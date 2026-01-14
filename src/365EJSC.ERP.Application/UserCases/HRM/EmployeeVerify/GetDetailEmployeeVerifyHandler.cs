using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
using _365EJSC.ERP.Application.Validators.HRM.EmployeeVerify;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.DTOs.HRM;
using MediatR;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.EmployeeVerify
{
    public class GetDetailEmployeeVerifyHandler : IRequestHandler<GetDetailEmployeeVerifyRequest, Result<EmployeeVerifyDTOs>>
    {
        private readonly IEmployeeVerifySqlRepository employeeVerifySqlRepository;
        private readonly IFileService fileService;

        public GetDetailEmployeeVerifyHandler(IEmployeeVerifySqlRepository employeeVerifySqlRepository, IFileService fileService)
        {
            this.employeeVerifySqlRepository = employeeVerifySqlRepository;
            this.fileService = fileService;
        }
        public async Task<Result<EmployeeVerifyDTOs>> Handle(GetDetailEmployeeVerifyRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            GetDetailEmployeeVerifyValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find employee by id
            var result = employeeVerifySqlRepository.FindAll(x => x.Id.Equals(request.Id)).Select(s => new EmployeeVerifyDTOs
            {
                Id = s.Id,
                EmployeeVerifyId = s.Id,
                EmployeeId = s.EmployeeId,
                VerImage = fileService.GetFullPathFileServer(s.VerImage),
                UserIdVerify = s.UserIdVerify,
                VerCreatedDate = s.VerCreatedDate,
                IsActived = s.IsActived,
                Employee = new EmployeeDetailDTOs
                {
                    Id = s.Employee.Id,
                    EmployeeId = s.Employee.Id,
                    EmpCitizenIdentity = s.Employee.EmpCitizenIdentity,
                    EmpTaxCode = s.Employee.EmpTaxCode,
                    EmpCode = s.Employee.EmpCode,
                    EmpFirstName = s.Employee.EmpFirstName,
                    EmpLastName = s.Employee.EmpLastName,
                    EmpGender = s.Employee.EmpGender,
                    EmpBirthday = s.Employee.EmpBirthday,
                    EmpImage = fileService.GetFullPathFileServer(s.Employee.EmpImage),
                    EmpTel = s.Employee.EmpTel,
                    EmpEmail = s.Employee.EmpEmail,
                    EmpEducationLevel = s.Employee.EmpEducationLevel,
                    EmpJoinedDate = s.Employee.EmpJoinedDate,
                    EmpAccountNumber = s.Employee.EmpAccountNumber,
                    EmpPlaceOfResidenceAddress = s.Employee.EmpPlaceOfResidenceAddress,
                    IsActived = s.Employee.IsActived,

                    //Ward = new WardDTOs
                    //{
                    //    LocalWardInfo = s.Employee.EmpPlaceOfResidenceWardIdInfo,
                    //    LocalDistrictInfo = s.Employee.EmpPlaceOfResidenceWardIdInfo.WebLocalDistrict,
                    //    LocalProvinceInfo = s.Employee.EmpPlaceOfResidenceWardIdInfo.WebLocalDistrict.WebLocalProvince,
                    //    WebLocalInfo = s.Employee.EmpPlaceOfResidenceWardIdInfo.WebLocalDistrict.WebLocalProvince.WebLocal,
                    //},

                    BankId = s.Employee.BankId,
                    BankName = s.Employee.BankInfo.BankName,

                    EmpPlaceOfBirth = s.Employee.EmpPlaceOfBirth,
                    //EmpPlaceOfBirthName = s.Employee.EmpPlaceOfBirthInfo,

                    DegreeId = s.Employee.DegreeId,
                    DegreeName = s.Employee.DegreeInfo.DegreeName,

                    MaritalId = s.Employee.MaritalId,
                    //MaritalStatusName = s.Employee.MaritalInfo.MaritalName,

                    NationId = s.Employee.NationId,
                    //NationName = s.Employee.NationInfo.NationName,

                    ReligionId = s.Employee.ReligionId,
                    //ReligionName = s.Employee.ReligionInfo.ReligionName,

                    EmpRoleId = s.Employee.EmpRoleId,
                    EmpRoleName = s.Employee.EmpRoleInfo.EmpRoleName,

                    TraMajId = s.Employee.TraMajId,
                    //TraMajName = s.Employee.TraMajInfo.TrainingMajorName,

                    CountryId = s.Employee.CountryId,
                    //CountryName = s.Employee.CountryInfo.Localization,
                },
            }).FirstOrDefault();

            // Fetch the employee verify again but now we need to add EmpImage
            if (result is null) CustomException.ThrowNotFoundException(typeof(Entities.EmployeeVerify), MsgCode.ERR_EMPLOYEE_VERIFY_ID_NOT_FOUND);

            return Result<EmployeeVerifyDTOs>.Ok(result!);
        }
    }
}
