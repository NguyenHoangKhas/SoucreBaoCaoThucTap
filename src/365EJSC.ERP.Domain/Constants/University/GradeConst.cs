using _365EJSC.ERP.Domain.Entities.University;

namespace _365EJSC.ERP.Domain.Constants.University
{
    public class GradeConst
    {
        #region Database defines

        public const string FIELD_GRADE_ID = "grade_id";
        public const string FIELD_STUDENT_ID = "student_id";
        public const string FIELD_SUBJECT_ID = "subject_id";
        public const string FIELD_SEMESTER = "semester";
        public const string FIELD_ACADEMIC_YEAR = "academic_year";
        public const string FIELD_PROCESS_SCORE = "process_score";
        public const string FIELD_MIDTERM_SCORE = "midterm_score";
        public const string FIELD_FINAL_SCORE = "final_score";
        public const string FIELD_TOTAL_SCORE = "total_score";
        public const string FIELD_LETTER_GRADE = "letter_grade";

        #endregion

        #region Max length defines

        public const int SEMESTER_MAX_LENGTH = 32;
        public const int ACADEMIC_YEAR_MAX_LENGTH = 32;
        public const int LETTER_GRADE_MAX_LENGTH = 8;

        #endregion

        #region Message defines

        public const string MSG_GRADE_ID_NOT_FOUND =
            $"{nameof(Grade)} with this grade id was not found";

        public const string MSG_GRADE_ID_EXISTED =
            $"{nameof(Grade)} with this grade id has existed in database";

        public const string MSG_GRADE_RECORD_EXISTED =
            $"{nameof(Grade)} for this student and subject already exists";

        #endregion
    }
}
