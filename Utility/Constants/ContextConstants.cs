namespace API.Utility.Constants
{
    public static class ContextConstants
    {
        #region General
        public const string ValidationError = "Ошибка валидации";
        #endregion
        #region LastName Messages
        public const string LastNameEmptyMessage = "Фамилия сотрудника не может быть пустой";
        public const string LastNameLengthMessage = "Фамилия сотрудника должна быть от 3 до 120 символов";
        public const string LastNameRegexMessage = "Фамилия сотрудника должна состоять только из букв";
        #endregion
        #region FirstName Messages
        public const string FirstNameEmptyMessage = "Имя сотрудника не может быть пустым";
        public const string FirstNameLengthMessage = "Имя сотрудника должно быть от 3 до 120 символов";
        public const string FirstNameRegexMessage = "Имя сотрудника должно состоять только из букв";
        #endregion
        #region MiddleName Messages
        public const string MiddleNameLengthMessage = "Отчество сотрудника должно быть от 3 до 120 символов";
        public const string MiddleNameRegexMessage = "Отчество сотрудника должно состоять только из букв";
        #endregion
        #region Post Messages
        public const string PostEmptyMessage = "Должность сотрудника не может быть пустой";
        #endregion
        #region Id Messages
        public const string IdEmptyMessage = "Идентификатор не может быть пустым";
        #endregion
        #region External Validation Messages
        public const string NotFound = "Записи не существует";
        public const string EmployeeNotFound = "Данного сотрудника не существует";
        public const string ShiftAlrearyEnded = "Нет начатой смены, начните новую";
        public const string ShiftAlrearyStarted = "Смена уже началась, её необходимо закончить";
        #endregion
        #region Time Messages
        public const string StartGreaterThanEnd = "Начало смены не может быть позже конца смены";
        #endregion
    }
}
