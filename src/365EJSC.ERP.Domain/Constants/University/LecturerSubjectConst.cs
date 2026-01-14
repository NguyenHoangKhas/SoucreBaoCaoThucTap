using _365EJSC.ERP.Domain.Entities.University;

namespace _365EJSC.ERP.Domain.Constants.University
{
    public class LecturerSubjectConst
    {
        #region Database defines

        public const string FIELD_LECTURER_SUBJECT_ID = "lecturer_subject_id";
        public const string FIELD_LECTURER_ID = "lecturer_id";
        public const string FIELD_SUBJECT_ID = "subject_id";
        public const string FIELD_SEMESTER = "semester";
        public const string FIELD_ACADEMIC_YEAR = "academic_year";

        #endregion

        #region Max length defines

        public const int SEMESTER_MAX_LENGTH = 32;
        public const int ACADEMIC_YEAR_MAX_LENGTH = 32;

        #endregion

        #region Message defines

        public const string MSG_LECTURER_SUBJECT_ID_NOT_FOUND =
            $"{nameof(LecturerSubject)} with this id was not found";

        public const string MSG_LECTURER_SUBJECT_EXISTED =
            $"{nameof(LecturerSubject)} already exists for this lecturer and subject";

        public const string MSG_LECTURER_ID_NOT_FOUND =
            $"{nameof(Lecturer)} with this lecturer id was not found";

        public const string MSG_SUBJECT_ID_NOT_FOUND =
            $"{nameof(Subject)} with this subject id was not found";

        #endregion
    }
}
