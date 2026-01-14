using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Filters;
using _365EJSC.ERP.Contract.Helpers;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.DTOs.HRM;
using MediatR;
using EntitiesHRM = _365EJSC.ERP.Domain.Entities.HRM;


namespace _365EJSC.ERP.Application.UserCases.HRM.Employee
{
    /// <summary>
    /// Handler for <see cref="GetAllEmployeeRequest"/>
    /// </summary>
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeRequest, Result<object>>
    {
        /// <summary>
        /// Repository handle data access of <see cref="Employee"/>
        /// </summary>
        private readonly IEmployeeSqlRepository employeeSqlRepository;
        private readonly IFileService fileService;

        /// <summary>
        /// Constructor of <see cref="GetAllEmployeeHandler"/>, inject needed dependency
        /// </summary>
        public GetAllEmployeeHandler(IEmployeeSqlRepository employeeSqlRepository, IFileService fileService)
        {
            this.employeeSqlRepository = employeeSqlRepository;
            this.fileService = fileService;
        }

        /// <summary>
        /// Handle <see cref="GetAllEmployeeRequest"/>, get all train major in database, can skip a number of records and limit record taken
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with list of <see cref="Employee"/></returns>
        /// <exception cref="Exception"></exception>
        public Task<Result<object>> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
        {
            var expression = new FilterBuilder<Domain.Entities.HRM.Employee>()
                .AddContainFilter(x => x.EmpCode, request.EmpCode)
                .AddContainFilter(x => x.EmpFirstName + " " + x.EmpLastName, request.EmpName)
                .AddEqualFilter(x => x.DegreeId, request.DegreeId)
                .AddEqualFilter(x => x.TraMajId, request.TraMajId)
                .AddEqualFilter(x => x.BankId, request.BankId)
                .AddEqualFilter(x => x.NationId, request.NationId)
                .AddEqualFilter(x => x.ReligionId, request.ReligionId)
                .AddEqualFilter(x => x.MaritalId, request.MaritalId)
                .AddEqualFilter(x => x.EmpRoleId, request.EmpRoleId)
                .AddEqualFilter(x => x.CountryId, request.CountryId)
                .AddEqualFilter(x => x.EmpPlaceOfResidenceWardId, request.EmpPlaceOfResidenceWardId)
                .AddEqualFilter(x => x.EmpPlaceOfBirth, request.EmpPlaceOfBirth)
                .AddEqualFilter(x => x.IsActived, request.IsActived)
                .AddEqualFilter(x => x.CompanyId, request.CompanyId)
                .Build();

            var result = employeeSqlRepository.FindAll(expression).Select(c => new EmployeeDetailDTOs
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

                EmployeeVerifies = c.EmployeeVerifies.Select(s => new EntitiesHRM.EmployeeVerify
                {
                    Id = s.Id,
                    EmployeeId = s.EmployeeId,
                    VerImage = fileService.GetFullPathFileServer(s.VerImage),
                    UserIdVerify = s.UserIdVerify,
                    VerCreatedDate = s.VerCreatedDate,
                    IsActived = s.IsActived,
                }).AsEnumerable()
            }).OrderByDescending(x => x.Id);
            
            if (request.IsDescending != null)
                result = (bool)request.IsDescending
                    ? result.OrderByDescending(x => x.EmpFirstName).ThenByDescending(x => x.EmpLastName).ThenByDescending(x => x.EmpCode)
                    : result.OrderBy(x => x.EmpFirstName).ThenBy(x => x.EmpLastName).ThenBy(x => x.EmpCode);

            return Task.FromResult<Result<object>>(PaginationHelper.ApplyPaginationSkipTake(result, request));
        }
    }
}