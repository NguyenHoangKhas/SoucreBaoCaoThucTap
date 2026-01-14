using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Application.Validators.HRM.Employee;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.DTOs.HRM;
using MediatR;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.Employee
{
    /// <summary>
    /// Handler for <see cref="GetDetailEmployeeRequest"/>
    /// </summary>
    public class GetDetailEmployeeHandler : IRequestHandler<GetDetailEmployeeRequest, Result<EmployeeDetailDTOs>>
    {
        /// <summary>
        /// Repository handle data access of <see cref="Employee"/>
        /// </summary>
        private readonly IEmployeeSqlRepository employeeSqlRepository;

        private readonly IFileService fileService;

        /// <summary>
        /// Constructor of <see cref="GetDetailEmployeeHandler"/>, inject needed dependency
        /// </summary>
        public GetDetailEmployeeHandler(IEmployeeSqlRepository employeeSqlRepository, IFileService fileService)

        {
            this.employeeSqlRepository = employeeSqlRepository;
            this.fileService = fileService;
        }

        /// <summary>
        /// Handle <see cref="GetDetailEmployeeRequest"/>, get <see cref="Employee"/> from database with id provided in <see cref="GetDetailEmployeeRequest"/>.
        /// Throw not found exception when <see cref="Employee"/> with id was not found
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with founded <see cref="Employee"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CustomException"></exception>
        public async Task<Result<EmployeeDetailDTOs>> Handle(GetDetailEmployeeRequest request, CancellationToken cancellationToken)
        {
            // Validate request
            GetDetailEmployeeValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find employee by id
            var result = employeeSqlRepository.FindAll(x => x.Id == request.Id).Select(c => new EmployeeDetailDTOs
            {
                Id = c.Id,
                EmployeeId = c.Id,
                EmpCitizenIdentity = c.EmpCitizenIdentity,
                EmpTaxCode = c.EmpTaxCode,
                EmpCode = c.EmpCode,
                EmpFirstName = c.EmpFirstName,
                EmpLastName = c.EmpLastName,
                EmpGender = c.EmpGender,
                EmpBirthday = c.EmpBirthday,
                EmpImage = fileService.GetFullPathFileServer(c.EmpImage),
                EmpTel = c.EmpTel,
                EmpEmail = c.EmpEmail,
                EmpEducationLevel = c.EmpEducationLevel,
                EmpJoinedDate = c.EmpJoinedDate,
                EmpAccountNumber = c.EmpAccountNumber,
                EmpPlaceOfResidenceAddress = c.EmpPlaceOfResidenceAddress,
                IsActived = c.IsActived,

                EmpPlaceOfResidenceWardId = c.EmpPlaceOfResidenceWardId,
                //Ward = c.EmpPlaceOfResidenceWardIdInfo != null ? new WardDTOs
                //{
                //    LocalWardInfo = c.EmpPlaceOfResidenceWardIdInfo,
                //    LocalDistrictInfo = c.EmpPlaceOfResidenceWardIdInfo.WebLocalDistrict,
                //    LocalProvinceInfo = c.EmpPlaceOfResidenceWardIdInfo.WebLocalDistrict.WebLocalProvince,
                //    WebLocalInfo = c.EmpPlaceOfResidenceWardIdInfo.WebLocalDistrict.WebLocalProvince.WebLocal,
                //} : null,

                BankId = c.BankId,
                BankName = c.BankInfo.BankName,

                EmpPlaceOfBirth = c.EmpPlaceOfBirth,
                //EmpPlaceOfBirthName = c.EmpPlaceOfBirthInfo,

                DegreeId = c.DegreeId,
                DegreeName = c.DegreeInfo.DegreeName,

                MaritalId = c.MaritalId,
                //MaritalStatusName = c.MaritalInfo.MaritalName,

                NationId = c.NationId,
                //NationName = c.NationInfo.NationName,

                ReligionId = c.ReligionId,
                //ReligionName = c.ReligionInfo.ReligionName,

                EmpRoleId = c.EmpRoleId,
                EmpRoleName = c.EmpRoleInfo.EmpRoleName,

                TraMajId = c.TraMajId,
                //TraMajName = c.TraMajInfo.TrainingMajorName,

                CountryId = c.CountryId,
                //CountryName = c.CountryInfo.Localization,

                CompanyId = c.CompanyId,
                //EmployeeCompany = new EmployeeCompanyDTOs
                //{
                //    Email = c.CompanyInfo.Email,
                //    TaxCode = c.CompanyInfo.TaxCode,
                //    Name = c.CompanyInfo.Name,
                //    Address = c.CompanyInfo.Address,
                //    Website = c.CompanyInfo.Website,
                //    WardInfo = new WardDTOs
                //    {
                //        LocalWardInfo = c.CompanyInfo.WardInfo,
                //        LocalDistrictInfo = c.CompanyInfo.WardInfo.WebLocalDistrict,
                //        LocalProvinceInfo = c.CompanyInfo.WardInfo.WebLocalDistrict.WebLocalProvince,
                //        WebLocalInfo = c.CompanyInfo.WardInfo.WebLocalDistrict.WebLocalProvince.WebLocal,
                //    }
                //},

                EmployeeVerifies = c.EmployeeVerifies.Select(s => new Entities.EmployeeVerify
                {
                    Id = s.Id,
                    EmployeeId = s.EmployeeId,
                    VerImage = fileService.GetFullPathFileServer(s.VerImage),
                    UserIdVerify = s.UserIdVerify,
                    VerCreatedDate = s.VerCreatedDate,
                    IsActived = s.IsActived,
                }).AsEnumerable(),

            }).FirstOrDefault();
           
            if (result is null)
                CustomException.ThrowNotFoundException(typeof(Entities.Employee), MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND);

            return Result<EmployeeDetailDTOs>.Ok(result!);
        }
    }
}
