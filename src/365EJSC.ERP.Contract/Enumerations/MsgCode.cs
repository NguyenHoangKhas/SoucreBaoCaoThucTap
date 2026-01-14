using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Contract.Enumerations
{
    /// <summary>
    /// Enum to define error code, use for decompile into message for end user
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MsgCode
    {
        #region FileSERVER msg codes

        /// <summary>
        /// File size exceed limit
        /// </summary>
        ERR_FILE_TOO_LARGE,

        /// <summary>
        /// File extension is not permitted
        /// </summary>
        ERR_INVALID_FILE,
        #endregion

        ERR_UNSUPPORTED_MEDIA_TYPE,

        ERR_BAD_REQUEST,

        ERR_UNAUTHORIZED,

        ERR_USER_LOGIN_FAIL,

        ERR_DEFINE_WEB_LOCAL_WARDS_V2_INVALID,

        ERR_DEFINE_WEB_LOCAL_WARDS_V2_ID_NOT_FOUND,

        #region Beauty booking invoice CQT Msg Codes

        /// <summary>
        /// Beauty booking invoice request is invalid
        /// </summary>
        ERR_BEAUTY_BOOKING_INVOICE_CQT_INVALID,

        /// <summary>
        /// Beauty booking invoice with the id provided was not found
        /// </summary>
        ERR_BEAUTY_BOOKING_INVOICE_CQT_ID_NOT_FOUND,

        #endregion

        #region Beauty booking invoice Msg Codes

        /// <summary>
        /// Beauty booking invoice request is invalid
        /// </summary>
        ERR_BEAUTY_BOOKING_INVOICE_INVALID,

        /// <summary>
        /// Beauty booking invoice with the id provided was not found
        /// </summary>
        ERR_BEAUTY_BOOKING_INVOICE_ID_NOT_FOUND,

        /// <summary>
        /// Beauty booking invoice with the BOOKID provided was use
        /// </summary>
        ERR_BEAUTY_BOOKING_INVOICE_BOOKID_ALREADY_EXISTS,

        #endregion

        #region Purchase Detail Msg Codes

        /// <summary>
        /// Purchase Detail request is invalid
        /// </summary>
        ERR_PURCHASE_DETAIL_INVALID,

        /// <summary>
        /// Purchase Detail with the id provided was not found
        /// </summary>
        ERR_PURCHASE_DETAIL_ID_NOT_FOUND,

        #endregion
        #region Helpdesk Catalog msg codes

        /// <summary>
        /// Helpdesk catalog with the id provided was not found
        /// </summary>
        ERR_DEFINE_HELPDESK_CATALOG_ID_NOT_FOUND,

        /// <summary>
        /// Helpdesk catalog request is invalid
        /// </summary>
        ERR_DEFINE_HELPDESK_CATALOG_INVALID,

        #endregion

        #region Helpdesk Content msg codes

        /// <summary>
        /// Helpdesk content with the id provided was not found
        /// </summary>
        ERR_DEFINE_HELPDESK_CONTENT_ID_NOT_FOUND,

        /// <summary>
        /// Helpdesk content request is invalid
        /// </summary>
        ERR_DEFINE_HELPDESK_CONTENT_INVALID,

        #endregion

        #region Helpdesk Table name constants

        /// <summary>
        /// Helpdesk catalog table name
        /// </summary>
        TABLE_HELPDESK_CATALOG,

        #endregion

        #region Purchase Order Msg Codes

        /// <summary>
        /// Purchase Order request is invalid
        /// </summary>
        ERR_PURCHASE_ORDER_INVALID,

        /// <summary>
        /// Purchase Order with the id provided was not found
        /// </summary>
        ERR_PURCHASE_ORDER_ID_NOT_FOUND,

        #endregion

        #region Payment Method Msg Codes

        /// <summary>
        /// Payment Method request is invalid
        /// </summary>
        ERR_PAYMENT_METHOD_INVALID,

        /// <summary>
        /// Payment Method with the id provided was not found
        /// </summary>
        ERR_PAYMENT_METHOD_ID_NOT_FOUND,

        #endregion

        #region Product Catalog Msg Codes

        /// <summary>
        /// Product Catalog request is invalid
        /// </summary>
        ERR_PRODUCT_CATALOG_INVALID,

        /// <summary>
        /// Product Catalog with the id provided was not found
        /// </summary>
        ERR_PRODUCT_CATALOG_ID_NOT_FOUND,

        #endregion

        #region Manufacturer Catalog Msg Codes

        /// <summary>
        /// Manufacturer Catalog request is invalid
        /// </summary>
        ERR_MANUFACTURER_CATALOG_INVALID,

        /// <summary>
        /// Manufacturer Catalog with the id provided was not found
        /// </summary>
        ERR_MANUFACTURER_CATALOG_ID_NOT_FOUND,

        #endregion

        #region Brand Catalog Msg Codes

        /// <summary>
        /// Brand Catalog request is invalid
        /// </summary>
        ERR_BRAND_CATALOG_INVALID,

        /// <summary>
        /// Brand Catalog with the id provided was not found
        /// </summary>
        ERR_BRAND_CATALOG_ID_NOT_FOUND,

        #endregion

        #region Beauty Booking Detail Msg Codes
        /// <summary>
        /// Beauty Booking Detail request is invalid
        /// </summary>
        ERR_BEAUTY_BOOKING_DETAIL_INVALID,

        /// <summary>
        /// Beauty Booking Detail with the id provided was not found
        /// </summary>
        ERR_BEAUTY_BOOKING_DETAIL_ID_NOT_FOUND,

        /// <summary>
        /// Beauty Booking Detail can't update
        /// </summary>
        ERR_BEAUTY_BOOKING_DETAIL_CAN_NOT_UPDATE,

        /// <summary>
        /// Beauty Booking Detail can't delete
        /// </summary>
        ERR_BEAUTY_BOOKING_DETAIL_CAN_NOT_DELETE,
        #endregion

        #region Beauty Booking Msg Codes
        /// <summary>
        /// Beauty Booking request is invalid
        /// </summary>
        ERR_BEAUTY_BOOKING_INVALID,

        /// <summary>
        /// Beauty Booking with the id provided was not found
        /// </summary>
        ERR_BEAUTY_BOOKING_ID_NOT_FOUND,

        /// <summary>
        /// New Beauty Booking with the companyId provided was not found
        /// </summary>
        ERR_BEAUTY_BOOKING_CUSTOMER_BOOK_NOT_FOUND,
        #endregion

        #region Beauty Service Pricing Msg Codes
        /// <summary>
        /// Beauty Service Pricing request is invalid
        /// </summary>
        ERR_BEAUTY_SERVICE_PRICING_INVALID,

        /// <summary>
        /// Beauty Service Pricing with the id provided was not found
        /// </summary>
        ERR_BEAUTY_SERVICE_PRICING_ID_NOT_FOUND,
        #endregion

        #region Beauty Service Pricing Detail Msg Codes
        /// <summary>
        /// Beauty Service Pricing Detail request is invalid
        /// </summary>
        ERR_BEAUTY_SERVICE_PRICING_DETAIL_INVALID,

        /// <summary>
        /// Beauty Service Pricing Detail with the id provided was not found
        /// </summary>
        ERR_BEAUTY_SERVICE_PRICING_DETAIL_ID_NOT_FOUND,

        /// <summary>
        /// Beauty Service Pricing Detail can't update
        /// </summary>
        ERR_BEAUTY_SERVICE_PRICING_DETAIL_CAN_NOT_UPDATE,

        /// <summary>
        /// Beauty Service Pricing Detail can't delete
        /// </summary>
        ERR_BEAUTY_SERVICE_PRICING_DETAIL_CAN_NOT_DELETE,
        #endregion

        #region Beauty Web Show Msg Codes
        /// <summary>
        /// Beauty Web Show request is invalid
        /// </summary>
        ERR_BEAUTY_WEB_SHOW_INVALID,

        /// <summary>
        /// Beauty Web Show with the id provided was not found
        /// </summary>
        ERR_BEAUTY_WEB_SHOW_ID_NOT_FOUND,
        #endregion

        #region Employee Company msg codes

        /// <summary>
        /// Employee Company request is invalid
        /// </summary>
        ERR_EMPLOYEE_COMPANY_INVALID,

        /// <summary>
        /// Employee Company with id provided was not found
        /// </summary>
        ERR_EMPLOYEE_COMPANY_ID_NOT_FOUND,

        #endregion

        #region Employee Access msg codes

        /// <summary>
        /// Employee Access request is invalid
        /// </summary>
        ERR_EMPLOYEE_ACCESS_INVALID,

        /// <summary>
        /// Employee Access with id provided was not found
        /// </summary>
        ERR_EMPLOYEE_ACCESS_ID_NOT_FOUND,

        #endregion

        #region AIAnalyzer msg codes

        /// <summary>
        /// Beauty define request is invalid
        /// </summary>
        ERR_AI_ANALYZER_INVALID,

        /// <summary>
        /// Beauty define with id provided was not found
        /// </summary>
        ERR_AI_ANALYZER_ID_NOT_FOUND,

        #endregion

        #region Beauty AI Face msg codes

        /// <summary>
        /// AI face with id provided was not found
        /// </summary>
        ERR_AI_FACE_ID_NOT_FOUND,

        /// <summary>
        /// AI face request is invalid
        /// </summary>
        ERR_AI_FACE_INVALID,

        #endregion

        #region Beauty Pricing msg codes

        /// <summary>
        /// Beauty Pricing with id provided was not found
        /// </summary>
        ERR_BEAUTY_PRICING_ID_NOT_FOUND,

        /// <summary>
        /// Beauty Pricing request is invalid
        /// </summary>
        ERR_BEAUTY_PRICING_INVALID,

        #endregion

        #region Beauty Service msg codes

        /// <summary>
        /// Beauty Service with id provided was not found
        /// </summary>
        ERR_BEAUTY_SERVICE_ID_NOT_FOUND,

        /// <summary>
        /// Beauty Service request is invalid
        /// </summary>
        ERR_BEAUTY_SERVICE_INVALID,

        #endregion

        #region CheckCompany msg codes

        /// <summary>
        /// Check company with id provided was not found
        /// </summary>
        ERR_KEY_CHECK_COMPANY_NOT_FOUND,

        /// <summary>
        /// Check company request is invalid
        /// </summary>
        ERR_CHECK_COMPANY_INVALID,

        #endregion

        #region BeautyDefine msg codes

        /// <summary>
        /// Beauty define request is invalid
        /// </summary>
        ERR_BEAUTY_DEFINE_INVALID,

        /// <summary>
        /// Beauty define with id provided was not found
        /// </summary>
        ERR_BEAUTY_DEFINE_ID_NOT_FOUND,

        #endregion

        #region ConfigIcon msg codes

        /// <summary>
        /// ConfigIcon with id provided was not found
        /// </summary>
        ERR_KEY_CONFIG_ICON_NOT_FOUND,

        /// <summary>
        /// ConfigIcon with id has exist in database
        /// </summary>
        ERR_KEY_CONFIG_ICON_EXISTED,

        /// <summary>
        /// ConfigIcon request is invalid
        /// </summary>
        ERR_CONFIG_ICON_INVALID,

        #endregion

        #region Local msg codes

        /// <summary>
        /// Local with id provided was not found
        /// </summary>
        ERR_KEY_LOCAL_NOT_FOUND,

        /// <summary>
		/// Local with id has exist in database
		/// </summary>
		ERR_KEY_LOCAL_EXISTED,

        /// <summary>
        /// Local request is invalid
        /// </summary>
        ERR_LOCAL_INVALID,

        #endregion

        #region Province msg codes

        /// <summary>
        /// Province with KeyLocalization was not found
        /// </summary>
        ERR_PROVINCE_ID_NOT_FOUND,

        /// <summary>
        /// Province request is invalid
        /// </summary>
        ERR_PROVINCE_INVALID,

        /// <summary>
        /// Cannot delete Province because it still contains Districts
        /// </summary>
        ERR_PROVINCE_HAS_DISTRICTS,

        #endregion

        #region District msg codes

        /// <summary>
        /// District with id provided was not found
        /// </summary>
        ERR_DISTRICT_ID_NOT_FOUND,

        /// <summary>
        /// District request is invalid
        /// </summary>
        ERR_DISTRICT_INVALID,

        /// <summary>
        /// Cannot delete District because it still contains Wards
        /// </summary>
        ERR_DISTRICT_HAS_WARDS,

        #endregion

        #region Ward msg codes

        /// <summary>
        /// Company with id provided was not found
        /// </summary>
        ERR_WARD_ID_NOT_FOUND,

        /// <summary>
        /// Company request is invalid
        /// </summary>
        ERR_WARD_INVALID,

        ERR_WARD_IN_USE,
        #endregion

        #region Company msg codes

        /// <summary>
        /// Company with id provided was not found
        /// </summary>
        ERR_COMPANY_ID_NOT_FOUND,

        /// <summary>
        /// Company request is invalid
        /// </summary>
        ERR_COMPANY_INVALID,

        /// <summary>
        /// Company tax code is existed
        /// </summary>
        ERR_COMPANY_TAX_CODE_EXISTED,

        /// <summary>
        /// Company password is incorrect
        /// </summary>
        ERR_COMPANY_PASSWORD_INCORRECT,

        /// <summary>
        /// Company password is incorrect
        /// </summary>
        ERR_COMPANY_NEW_PASSWORD_NOT_MATCH,

        #endregion

        #region CompanyDepartment msg codes

        /// <summary>
        /// CompanyDepartment with id provided was not found
        /// </summary>
        ERR_COMPANY_DEPARTMENT_ID_NOT_FOUND,

        /// <summary>
        /// CompanyDepartment request is invalid
        /// </summary>
        ERR_COMPANY_DEPARTMENT_INVALID,

        #endregion

        #region CompanyPosition msg codes

        /// <summary>
        /// CompanyPosition with id provided was not found
        /// </summary>
        ERR_COMPANY_POSITION_ID_NOT_FOUND,

        /// <summary>
        /// CompanyPosition request is invalid
        /// </summary>
        ERR_COMPANY_POSITION_INVALID,

        /// <summary>
        /// Position request is duplicate id
        /// </summary>
        ERR_POSITION_DUPLICATE_ID,

        /// <summary>
        /// Position request is duplicate in database
        /// </summary>
        ERR_POSITION_DUPLICATE_IN_DATABASE,

        #endregion

        #region Department msg codes

        /// <summary>
        /// Department with id provided was not found
        /// </summary>
        ERR_DEPARTMENT_ID_NOT_FOUND,

        /// <summary>
        /// Department request is invalid
        /// </summary>
        ERR_DEPARTMENT_INVALID,

        /// <summary>
        /// Department request is duplicate id
        /// </summary>
        ERR_DEPARTMENT_DUPLICATE_ID,

        /// <summary>
        /// Department request is duplicate in database
        /// </summary>
        ERR_DEPARTMENT_DUPLICATE_IN_DATABASE,

        #endregion

        #region Position msg codes

        /// <summary>
        /// Position with id was not found
        /// </summary>
        ERR_POSITION_ID_NOT_FOUND,

        /// <summary>
        /// Position request is invalid
        /// </summary>
        ERR_POSITION_INVALID,

        #endregion

        #region Salary Structure msg codes

        /// <summary>
        /// SalaryStructure with id was not found
        /// </summary>
        ERR_SALARY_STRUCTURE_ID_NOT_FOUND,

        /// <summary>
        /// SalaryStructure request is invalid
        /// </summary>
        ERR_SALARY_STRUCTURE_INVALID,

        #endregion

        #region ContractType msg codes

        /// <summary>
        /// ContractType with id was not found
        /// </summary>
        ERR_CONTRACT_TYPE_ID_NOT_FOUND,

        /// <summary>
        /// ContractType request is invalid
        /// </summary>
        ERR_CONTRACT_TYPE_INVALID,

        #endregion

        #region EmployeeRole msg codes

        /// <summary>
        /// EMPLOYEE with id provided was not found
        /// </summary>
        ERR_EMPLOYEE_ROLE_ID_NOT_FOUND,

        /// <summary>
        /// EMPLOYEE request is invalid
        /// </summary>
        ERR_EMPLOYEE_ROLE_INVALID,

        #endregion

        #region Marital msg codes

        ERR_MARITAL_ID_NOT_FOUND,

        ERR_MARITAL_INVALID,

        #endregion

        #region Training Major msg codes

        /// <summary>
        /// Training Major with id provided was not found
        /// </summary>
        ERR_TRAININGMAJOR_ID_NOT_FOUND,

        /// <summary>
        /// Training Major request is invalid
        /// </summary>
        ERR_TRAININGMAJOR_INVALID,

        #endregion

        #region Degree msg codes

        /// <summary>
        /// Degree with id provided was not found
        /// </summary>
        ERR_DEGREE_ID_NOT_FOUND,

        /// <summary>
        /// Degree with id has exist in database
        /// </summary>
        ERR_DEGREE_EXISTED,

        /// <summary>
        /// Degree request is invalid
        /// </summary>
        ERR_DEGREE_INVALID,

        #endregion

        #region Wh Catalog msg codes

        /// <summary>
        /// Wh Catalog with id provided was not found
        /// </summary>
        ERR_WH_CATALOG_ID_NOT_FOUND,

        /// <summary>
        /// Wh Catalog request is invalid
        /// </summary>
        ERR_WH_CATALOG_INVALID,

        #endregion

        #region Wh Company msg codes

        /// <summary>
        /// Wh Company with id provided was not found
        /// </summary>
        ERR_WH_COMPANY_ID_NOT_FOUND,

        /// <summary>
        /// Wh Company request is invalid
        /// </summary>
        ERR_WH_COMPANY_INVALID,
        ERR_WH_COMPANY_EXISTED_IN_DATABASE,
        ERR_COMPANY_DUPLICATED_ID,

        #endregion

        #region Bank msg codes
        /// <summary>
        /// Bank with id provided was not found
        /// </summary>
        ERR_BANK_ID_NOT_FOUND,
        /// <summary>
        /// Bank request is invalid
        /// </summary>
        ERR_BANK_INVALID,

        ERR_BANK_IN_USE,
        #endregion

        #region Langs msg codes
        /// <summary>
        /// Bank with id provided was not found
        /// </summary>
        ERR_KEY_LANGS_ID_NOT_FOUND,
        /// <summary>
        /// Bank request is invalid
        /// </summary>
        ERR_LANGS_INVALID,
        /// <summary>
        /// Local with id has exist in database
        /// </summary>
        ERR_KEY_LANGS_EXISTED,
        #endregion

        #region Nation msg codes

        /// <summary>
        /// Nation with id was not found
        /// </summary>
        ERR_NATION_ID_NOT_FOUND,

        /// <summary>
        /// Nation request is invalid
        /// </summary>
        ERR_NATION_INVALID,

        #endregion

        #region ProductGroup msg codes

        /// <summary>
        /// ProductGroup with id was not found
        /// </summary>
        ERR_PRODUCT_GROUP_ID_NOT_FOUND,

        /// <summary>
        /// ProductGroup request is invalid
        /// </summary>
        ERR_PRODUCT_GROUP_INVALID,

        ERR_NO_MATCHING_PRODUCT_GROUP_FOUND,

        #endregion

        #region ProductType msg codes
        /// <summary>
        /// Bank with id provided was not found
        /// </summary>
        ERR_PRODUCT_TYPE_ID_NOT_FOUND,
        /// <summary>
        /// Bank request is invalid
        /// </summary>
        ERR_PRODUCT_TYPE_INVALID,
        #endregion

        #region WhType msg codes

        /// <summary>
        /// WhType with id provided was not found
        /// </summary>
        ERR_WHTYPE_ID_NOT_FOUND,

        /// <summary>
        /// WHTYPE request is invalid
        /// </summary>
        ERR_WHTYPE_INVALID,

        #endregion

        #region WhUnit msg codes

        /// <summary>
        /// WhUnit with id provided was not found
        /// </summary>
        ERR_WHUNIT_ID_NOT_FOUND,

        /// <summary>
        /// WhUnit request is invalid
        /// </summary>
        ERR_WHUNIT_INVALID,

        #endregion

        #region Religion msg codes

        /// <summary>
        /// Religion with id provided was not found
        /// </summary>
        ERR_RELIGION_ID_NOT_FOUND,

        /// <summary>
        /// Religion request is invalid
        /// </summary>
        ERR_RELIGION_INVALID,

        #endregion

        #region Customer Type msg codes

        /// <summary>
        /// Customer Type with id provided was not found
        /// </summary>
        ERR_CUSTOMER_TYPE_ID_NOT_FOUND,

        /// <summary>
        /// Customer Type request is invalid
        /// </summary>
        ERR_CUSTOMER_TYPE_INVALID,

        #endregion

        #region Tax msg codes

        /// <summary>
        /// Degree with id provided was not found
        /// </summary>
        ERR_TAX_ID_NOT_FOUND,

        /// <summary>
        /// Degree with id has exist in database
        /// </summary>
        ERR_TAX_EXISTED,

        /// <summary>
        /// Degree request is invalid
        /// </summary>
        ERR_TAX_INVALID,

        #endregion

        #region SupplierCatalog msg codes

        /// <summary>
        /// SupplierCatalog with id was not found
        /// </summary>
        ERR_SUPPLIER_CATALOG_ID_NOT_FOUND,

        /// <summary>
        /// SupplierCatalog request is invalid
        /// </summary>
        ERR_SUPPLIER_CATALOG_INVALID,

        #endregion

        #region SupplierVerify msg codes

        /// <summary>
        /// SupplierVerify with id was not found
        /// </summary>
        ERR_SUPPLIER_VERIFY_ID_NOT_FOUND,

        /// <summary>
        /// SupplierVerify request is invalid
        /// </summary>
        ERR_SUPPLIER_VERIFY_INVALID,

        #endregion

        #region Employee msg codes

        /// <summary>
        /// Employee with id Employeed was not found
        /// </summary>
        ERR_EMPLOYEE_ID_NOT_FOUND,

        /// <summary>
        /// Employee request is invalid
        /// </summary>
        ERR_EMPLOYEE_INVALID,

        /// <summary>
        /// Employee password is incorrect
        /// </summary>
        ERR_EMPLOYEE_PASSWORD_INCORRECT,

        /// <summary>
        /// Employee newPassword and comfirmPassword is not match
        /// </summary>
        ERR_EMPLOYEE_NEW_PASSWORD_NOT_MATCH,

        /// <summary>
        /// Employee code is existed
        /// </summary>
        ERR_EMPLOYEE_CODE_EXISTED,
        #endregion

        #region Attendance msg codes

        /// <summary>
        /// Attendance with id provided was not found
        /// </summary>
        ERR_ATTENDANCE_ID_NOT_FOUND,

        /// <summary>
        /// Attendance record already exists for this employee and date
        /// </summary>
        ERR_ATTENDANCE_ALREADY_EXISTS,

        /// <summary>
        /// Attendance request is invalid
        /// </summary>
        ERR_ATTENDANCE_INVALID,

        #endregion

        #region Employee Verify msg codes

        /// <summary>
        /// Employee verify with id Employeed was not found
        /// </summary>
        ERR_EMPLOYEE_VERIFY_ID_NOT_FOUND,

        /// <summary>
        /// Employee verify request is invalid
        /// </summary>
        ERR_EMPLOYEE_VERIFY_INVALID,

        #endregion

        #region HourPerDay msg codes

        /// <summary>
        /// HourPerDay with id was not found
        /// </summary>
        ERR_HOUR_PER_DAY_ID_NOT_FOUND,

        /// <summary>
        /// HourPerDay request is invalid
        /// </summary>
        ERR_HOUR_PER_DAY_INVALID,

        #endregion

        #region HourPerWeek msg codes

        /// <summary>
        /// HourPerWeek with id was not found
        /// </summary>
        ERR_HOUR_PER_WEEK_ID_NOT_FOUND,

        /// <summary>
        /// HourPerWeek request is invalid
        /// </summary>
        ERR_HOUR_PER_WEEK_INVALID,

        #endregion

        #region Management Group msg codes

        /// <summary>
        /// Management group with id Employeed was not found
        /// </summary>
        ERR_MANAGEMENT_GROUP_ID_NOT_FOUND,

        /// <summary>
        /// Management group request is invalid
        /// </summary>
        ERR_MANAGEMENT_GROUP_INVALID,

        #endregion

        #region Customer Catalog msg codes
        /// <summary>
        /// Bank with id provided was not found
        /// </summary>
        ERR_CUSTOMER_CATALOG_ID_NOT_FOUND,
        /// <summary>
        /// Bank request is invalid
        /// </summary>
        ERR_CUSTOMER_CATALOG_INVALID,
        #endregion

        #region Management Level msg codes

        /// <summary>
        /// Degree with id provided was not found
        /// </summary>
        ERR_MANAGEMENT_LEVEL_ID_NOT_FOUND,

        /// <summary>
        /// Degree with id has exist in database
        /// </summary>
        ERR_MANAGEMENT_LEVE_EXISTED,

        /// <summary>
        /// Degree request is invalid
        /// </summary>
        ERR_MANAGEMENT_LEVE_INVALID,
        #endregion

        #region CustomerGroup msg codes
        /// <summary>
        /// CustomerGroup with id provided was not found
        /// </summary>
        ERR_CUSTOMER_GROUP_ID_NOT_FOUND,
        /// <summary>
        /// CustomerGroup request is invalid
        /// </summary>
        ERR_CUSTOMER_GROUP_INVALID,
        #endregion

        #region Customer Source msg codes

        /// <summary>
        /// Customer source with id provided was not found
        /// </summary>
        ERR_CUSTOMER_SOURCE_ID_NOT_FOUND,

        /// <summary>
        /// Customer source request is invalid
        /// </summary>
        ERR_CUSTOMER_SOURCE_INVALID,
        #endregion

        #region Group Catalog msg codes

        /// <summary>
        /// Group Catalog with id provided was not found
        /// </summary>
        ERR_GROUP_CATALOG_ID_NOT_FOUND,

        /// <summary>
        /// Group Catalog request is invalid
        /// </summary>
        ERR_GROUP_CATALOG_INVALID,

        ERR_MENU_CATALOG_DUPLICATED_ID,

        #endregion

        #region Menu Catalog msg codes

        /// <summary>
        /// Menu Catalog with id provided was not found
        /// </summary>
        ERR_MENU_CATALOG_ID_NOT_FOUND,

        /// <summary>
        /// Menu Catalog request is invalid
        /// </summary>
        ERR_MENU_CATALOG_INVALID,
        #endregion

        #region CustomerField msg codes
        /// <summary>
        /// Bank with id provided was not found
        /// </summary>
        ERR_CUSTOMER_FIELD_ID_NOT_FOUND,
        /// <summary>
        /// Bank request is invalid
        /// </summary>
        ERR_CUSTOMER_FIELD_INVALID,

        ERR_CUSTOMER_FIELD_IN_USE,
        #endregion

        #region Customer Status msg codes

        /// <summary>
        /// Customer Type with id provided was not found
        /// </summary>
        ERR_CUSTOMER_STATUS_ID_NOT_FOUND,

        /// <summary>
        /// Customer Type request is invalid
        /// </summary>
        ERR_CUSTOMER_STATUS_INVALID,

        #endregion

        #region Customer Scale msg codes

        /// <summary>
        /// Customer Scale with id provided was not found
        /// </summary>
        ERR_CUSTOMER_SCALE_ID_NOT_FOUND,

        /// <summary>
        /// Customer Scale request is invalid
        /// </summary>
        ERR_CUSTOMER_SCALE_INVALID,
        #endregion

        #region Base msg codes

        /// <summary>
        /// Define error code for invalid email format
        /// </summary>
        /// <remarks>
        /// Correct example: abc@gmail.com
        /// </remarks>
        ERR_INVALID_EMAIL,

        /// <summary>
        /// Define error code for invalid phone format
        /// </summary>
        /// <remarks>
        /// Correct example: +84 123 123 1234
        /// </remarks>
        ERR_INVALID_PHONE,

        /// <summary>
        /// Define error for invalid key format
        /// </summary>
        /// <remarks>
        /// Correct example: ABC_123
        /// </remarks>
        ERR_INVALID_KEY,

        /// <summary>
        /// Define error code for internal server error
        /// </summary>
        ERR_INTERNAL_SERVER,

        /// <summary>
        /// Define error code for not found resources
        /// </summary>
        ERR_NOT_FOUND,

        /// <summary>
        /// Define error code for conflict between resources
        /// </summary>
        ERR_CONFLICT,

        /// <summary>
        /// Define error code for unexpected validation exception
        /// </summary>
        ERR_INVALID,

        /// <summary>
        /// Define error code for not found resources find by key
        /// </summary>
        ERR_NF_FIND_KEY,

        /// <summary>
        /// Define code for created message
        /// </summary>
        INF_CREATED,

        /// <summary>
        /// Define code for updated message
        /// </summary>
        INF_UPDATED,

        /// <summary>
        /// Define code for deleted message
        /// </summary>
        INF_DELETED,

        /// <summary>
        /// Define code for found resource
        /// </summary>
        INF_FOUND,
        #endregion

        #region Report booking msg codes
        /// <summary>
        /// report booking MonthlySummary for year
        /// </summary>
        ERR_RPTBEAUTYBOOKING_YEAR_INVALID,

        /// <summary>
        /// report booking DailySummary for month
        /// </summary>
        ERR_RPTBEAUTYBOOKING_MONTH_INVALID,

        /// <summary>
        /// report booking DailySummary from date start to date end
        /// </summary>
        ERR_RPTBEAUTYBOOKING_DATEBETWEEN_INVALID,
        #endregion

        #region Beauty Booking Service Catalog Report Msg Codes

        /// <summary>
        /// report Service MonthlySummary for year
        /// </summary>
        ERR_RPTBEAUTYSERVICE_YEAR_INVALID,

        /// <summary>
        /// report Service DailySummary for month
        /// </summary>
        ERR_RPTBEAUTYSERVICE_MONTH_INVALID,

        /// <summary>
        /// report Service DailySummary from date start to date end
        /// </summary>
        ERR_RPTBEAUTYSERVICE_DATEBETWEEN_INVALID,

        #endregion

        #region Base msg codes
        ERR_BEAUTY_INVOICE_LANG_NOT_FOUND,
        ERR_BEAUTY_INVOICE_LOGIN_FAIL,
        ERR_BEAUTY_INVOICE_REFERENCE_FAIL,
        ERR_BEAUTY_INVOICE_REFERENCE_KHHDON_NOT_FOUND,
        ERR_BEAUTY_INVOICE_CERTIFICATE_FAIL,
        ERR_BEAUTY_INVOICE_CERTIFICATE_NOT_FOUND,
        ERR_BEAUTY_INVOICE_CREATE_FAIL,
        ERR_BEAUTY_INVOICE_DOWNLOAD_PDF_FAIL,
        ERR_BEAUTY_BOOKING_INVOICE_PDF_INVALID,
        ERR_BEAUTY_BOOKING_INVOICE_LOGIN_INVALID,

        ERR_RPTSERVICECATALOG_YEAR_INVALID,
        #endregion
		
		#region Status Catalog Msg Codes

        /// <summary>
        /// Status Catalog request is invalid
        /// </summary>
        ERR_STATUS_CATALOG_INVALID,

        /// <summary>
        /// Status Catalog with the id provided was not found
        /// </summary>
        ERR_STATUS_CATALOG_ID_NOT_FOUND,

        /// <summary>
        /// Status Catalog can't delete
        /// </summary>
        ERR_STATUS_CATALOG_CAN_NOT_DELETE,

        #endregion


        #region PartnerCatalog msg codes

        /// <summary>
        /// PartnerCatalog request is invalid
        /// </summary>
        ERR_CRM_PARTNER_CATALOG_INVALID,

        /// <summary>
        /// PartnerCatalog with the id provided was not found
        /// </summary>
        ERR_CRM_PARTNER_CATALOG_ID_NOT_FOUND,

        #endregion
    }
}
