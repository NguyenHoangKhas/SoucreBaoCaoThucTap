using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.DTOs.HRM;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.HRM.EmployeeVerify
{
    public class GetAllEmployeeVerifyHandler : IRequestHandler<GetAllEmployeeVerifyRequest, Result<IQueryable<EmployeeVerifyDTOs>>>
    {
        private readonly IEmployeeVerifySqlRepository employeeVerifySqlRepository;
        private readonly IFileService fileService;

        public GetAllEmployeeVerifyHandler(IEmployeeVerifySqlRepository employeeVerifySqlRepository, IFileService fileService)
        {
            this.employeeVerifySqlRepository = employeeVerifySqlRepository;
            this.fileService = fileService;
        }

        public async Task<Result<IQueryable<EmployeeVerifyDTOs>>> Handle(GetAllEmployeeVerifyRequest request, CancellationToken cancellationToken)
        {
            var result = employeeVerifySqlRepository.FindAll().Select(s => new EmployeeVerifyDTOs
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

                    EmpPlaceOfResidenceWardId = s.Employee.EmpPlaceOfResidenceWardId,
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
            }).AsQueryable();

            if (request.EmployeeId.HasValue)
            {
                result = result.Where(x => x.EmployeeId == request.EmployeeId.Value).AsQueryable();
            }

            if (request.IsActived.HasValue)
            {
                result = result.Where(x => x.IsActived == request.IsActived.Value).AsQueryable();
            }

            // Return the result as a successful response
            return Result<IQueryable<EmployeeVerifyDTOs>>.Ok(result);
        }
    }
}
