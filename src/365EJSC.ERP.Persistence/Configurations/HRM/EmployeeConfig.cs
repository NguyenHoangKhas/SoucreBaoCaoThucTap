using _365EJSC.ERP.Domain.Constants;
using _365EJSC.ERP.Domain.Constants.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365EJSC.ERP.Persistence.Configurations.HRM
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(EmployeeConst.FIELD_ID);

            builder.Property(x => x.EmpCitizenIdentity).HasColumnName(EmployeeConst.FIELD_CITIZEN_IDENTITY).HasMaxLength(EmployeeConst.CITIZEN_IDENTITY_MAX_LENGTH);
            builder.Property(x => x.EmpTaxCode).HasColumnName(EmployeeConst.FIELD_TAX_CODE).HasMaxLength(EmployeeConst.TAX_CODE_MAX_LENGTH);
            builder.Property(x => x.EmpCode).HasColumnName(EmployeeConst.FIELD_CODE).HasMaxLength(EmployeeConst.CODE_MAX_LENGTH);
            builder.Property(x => x.EmpFirstName).HasColumnName(EmployeeConst.FIELD_FIRST_NAME).HasMaxLength(EmployeeConst.FIRST_NAME_MAX_LENGTH);
            builder.Property(x => x.EmpLastName).HasColumnName(EmployeeConst.FIELD_LAST_NAME).HasMaxLength(EmployeeConst.LAST_NAME_MAX_LENGTH);
            builder.Property(x => x.EmpGender).HasColumnName(EmployeeConst.FIELD_GENDER);
            builder.Property(x => x.EmpBirthday).HasColumnName(EmployeeConst.FIELD_BIRTHDAY);
            builder.Property(x => x.EmpPlaceOfBirth).HasColumnName(EmployeeConst.FIELD_PLACE_OF_BIRTH);
            builder.Property(x => x.EmpImage).HasColumnName(EmployeeConst.FIELD_IMAGE).HasMaxLength(EmployeeConst.IMAGE_MAX_LENGTH);
            builder.Property(x => x.EmpTel).HasColumnName(EmployeeConst.FIELD_TEL).HasMaxLength(EmployeeConst.TEL_MAX_LENGTH);
            builder.Property(x => x.EmpEmail) .HasColumnName(EmployeeConst.FIELD_EMAIL).HasMaxLength(EmployeeConst.EMAIL_MAX_LENGTH);
            builder.Property(x => x.EmpEducationLevel).HasColumnName(EmployeeConst.FIELD_EDUCATION_LEVEL).HasMaxLength(EmployeeConst.EDUCATION_LEVEL_MAX_LENGTH);
            builder.Property(x => x.Password).HasColumnName(EmployeeConst.FIELD_PASSWORD).HasMaxLength(EmployeeConst.PASSWORD_MAX_LENGTH);
            builder.Property(x => x.CompanyId).HasColumnName(EmployeeConst.FIELD_COMPANY_ID);
            builder.Property(x => x.EmpJoinedDate).HasColumnName(EmployeeConst.FIELD_JOINED_DATE);
            builder.Property(x => x.DegreeId).HasColumnName(EmployeeConst.FIELD_DEGREE_ID);
            builder.Property(x => x.TraMajId).HasColumnName(EmployeeConst.FIELD_TRA_MAJ_ID);
            builder.Property(x => x.EmpAccountNumber).HasColumnName(EmployeeConst.FIELD_ACCOUNT_NUMBER).HasMaxLength(EmployeeConst.ACCOUNT_NUMBER_MAX_LENGTH);
            builder.Property(x => x.BankId).HasColumnName(EmployeeConst.FIELD_BANK_ID);
            builder.Property(x => x.NationId).HasColumnName(EmployeeConst.FIELD_NATION_ID);
            builder.Property(x => x.ReligionId).HasColumnName(EmployeeConst.FIELD_RELIGION_ID);
            builder.Property(x => x.MaritalId).HasColumnName(EmployeeConst.FIELD_MARITAL_ID);
            builder.Property(x => x.EmpRoleId).HasColumnName(EmployeeConst.FIELD_ROLE_ID);
            builder.Property(x => x.CountryId).HasColumnName(EmployeeConst.FIELD_COUNTRY_ID);
            builder.Property(x => x.EmpPlaceOfResidenceAddress).HasColumnName(EmployeeConst.FIELD_PLACE_OF_RESIDENCE_ADDRESS).HasMaxLength(EmployeeConst.RESIDENCE_ADDRESS_MAX_LENGTH);
            builder.Property(x => x.EmpPlaceOfResidenceWardId).HasColumnName(EmployeeConst.FIELD_PLACE_OF_RESIDENCE_WARD_ID);
            builder.Property(x => x.IsActived).HasColumnName(EmployeeConst.FIELD_IS_ACTIVED);

            //builder.HasOne(x => x.CompanyInfo).WithMany().HasForeignKey(x => x.CompanyId).IsRequired(false);
            builder.HasOne(x => x.DegreeInfo).WithMany().HasForeignKey(x => x.DegreeId).IsRequired(false);
            //builder.HasOne(x => x.TraMajInfo).WithMany().HasForeignKey(x => x.TraMajId).IsRequired(false);
            //builder.HasOne(x => x.EmpAccountNumberInfo).WithMany().HasForeignKey(x => x.EmpAccountNumber);
            builder.HasOne(x => x.BankInfo).WithMany().HasForeignKey(x => x.BankId).IsRequired(false);
            //builder.HasOne(x => x.NationInfo).WithMany().HasForeignKey(x => x.NationId).IsRequired(false);
            //builder.HasOne(x => x.ReligionInfo).WithMany().HasForeignKey(x => x.ReligionId).IsRequired(false);
            //builder.HasOne(x => x.MaritalInfo).WithMany().HasForeignKey(x => x.MaritalId).IsRequired(false);
            builder.HasOne(x => x.EmpRoleInfo).WithMany().HasForeignKey(x => x.EmpRoleId).IsRequired(false);
            //builder.HasOne(x => x.EmpPlaceOfBirthInfo).WithMany().HasForeignKey(x => x.EmpPlaceOfBirth).IsRequired(false);
            //builder.HasOne(x => x.CountryInfo).WithMany().HasForeignKey(x => x.CountryId).IsRequired(false);
            //builder.HasOne(x => x.EmpPlaceOfResidenceWardIdInfo).WithMany().HasForeignKey(x => x.EmpPlaceOfResidenceWardId).IsRequired(false);

            builder.HasMany(x => x.EmployeeVerifies).WithOne(ei => ei.Employee).HasForeignKey(x => x.EmployeeId).IsRequired(false);

            builder.ToTable(TableConst.TABLE_HRM_EMPLOYEE);
        }
    }
}
