using _365EJSC.ERP.Domain.Entities.University;

namespace _365EJSC.ERP.Domain.Constants.University
{
    public class CourseRegistrationConst
    {
        #region Database defines

        public const string FIELD_COURSE_REGISTRATION_ID = "course_registration_id";
        public const string FIELD_STUDENT_ID = "student_id";
        public const string FIELD_SUBJECT_ID = "subject_id";
        public const string FIELD_SEMESTER = "semester";
        public const string FIELD_ACADEMIC_YEAR = "academic_year";
        public const string FIELD_STATUS = "status";
        public const string FIELD_REGISTRATION_DATE = "registration_date";

        #endregion

        #region Max length defines

        public const int SEMESTER_MAX_LENGTH = 32;
        public const int ACADEMIC_YEAR_MAX_LENGTH = 32;
        public const int STATUS_MAX_LENGTH = 32;

        #endregion

        #region Message defines

        public const string MSG_COURSE_REGISTRATION_ID_NOT_FOUND =
            $"{nameof(CourseRegistration)} with this id was not found";

        public const string MSG_COURSE_REGISTRATION_ID_EXISTED =
            $"{nameof(CourseRegistration)} with this id has existed in database";

        public const string MSG_COURSE_ALREADY_REGISTERED =
            $"{nameof(CourseRegistration)} for this student and subject already exists";

        public const string MSG_REGISTRATION_NOT_ALLOWED =
            $"Registration is not allowed for this course";

        #endregion
    }
}
