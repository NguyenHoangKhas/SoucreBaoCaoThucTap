namespace _365EJSC.ERP.Domain.Constants
{
    public class StoreProcConst
    {
        #region Report Beauty Booking
        
        public const string RPT_BOOKING_MONTHLY_SUMMARY = "dbo.sp_rpt_BookingMonthlySummary";
        public const string RPT_BOOKING_DAILY_SUMMARY = "dbo.sp_rpt_BookingDailySummary";
        public const string RPT_BOOKING_DAILY_SUMMARY_BYRANGE = "dbo.sp_rpt_BookingDailySummaryByRange";
        public const string RPT_EMPLOYEE_BOOKING_MONTHLY_SUMMARY = "dbo.sp_rpt_EmployeeBookingMonthlySummary";
        public const string RPT_EMPLOYEE_BOOKING_DETAIL_MONTHLY_SUMMARY = "dbo.sp_rpt_EmployeeBookingDetailMonthlySummary";

        #endregion

        #region Report Beauty Service Catalog

        public const string RPT_SERVICE_CATALOG_MONTHLY_SUMMARY = "dbo.sp_rpt_ServiceCatalogMonthlySummary";
        public const string RPT_SERVICE_CATALOG_SUMMARY = "dbo.sp_rpt_ServiceCatalogSummary";

        #endregion

        #region BeautyBookingInvoice

        public const string INVOICE_BEAUTYBOOKING = "dbo.sp_GetInvoiceBookingById";
        public const string INVOICE_BEAUTYBOOKING_DETAIL = "dbo.sp_GetInvoiceBookingDetailByBookingId";

        #endregion

        #region Beauty Booking Detail

        public const string BOOKING_DETAIL_UPDATE_PRICE_AND_TAX = "dbo.sp_UpdateBookingDetailPriceAndTax";

        #endregion

        #region Beauty Service Pricinbg Deatail

        /// <summary>
        /// Param: Id list (string), ex: "1, 2, 3"
        /// </summary>
        public const string SERVICE_PRICING_DETAIL_UPDATE_UNIT_PRICE = "dbo.sp_UpdateSPDetailUnitPrice";

        #endregion
    }
}
