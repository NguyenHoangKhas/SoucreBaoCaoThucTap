using _365EJSC.ERP.Domain.Entities.University;

namespace _365EJSC.ERP.Domain.Constants.University
{
    public class SubjectConst
    {
        #region Database defines

        public const string FIELD_SUBJECT_ID = "subject_id";
        public const string FIELD_SUBJECT_CODE = "subject_code";
        public const string FIELD_SUBJECT_NAME = "subject_name";
        public const string FIELD_CREDITS = "credits";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_PREREQUISITE_ID = "prerequisite_id";

        #endregion

        #region Max length defines

        public const int SUBJECT_CODE_MAX_LENGTH = 64;
        public const int SUBJECT_NAME_MAX_LENGTH = 256;
        public const int DESCRIPTION_MAX_LENGTH = 512;

        #endregion

        #region Message defines

        public const string MSG_SUBJECT_ID_NOT_FOUND =
            $"{nameof(Subject)} with this id was not found";

        public const string MSG_SUBJECT_ID_EXISTED =
            $"{nameof(Subject)} with this id has existed in database";

        public const string MSG_SUBJECT_CODE_EXISTED =
            $"{nameof(Subject)} with this subject code has existed in database";

        public const string MSG_PREREQUISITE_SUBJECT_NOT_FOUND =
            $"Prerequisite {nameof(Subject)} with this id was not found";

        #endregion
    }
}
