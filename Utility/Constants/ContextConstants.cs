namespace API.Utility.Constants
{
    /// <summary>
    /// Класс для констант
    /// </summary>
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
        #region Enum
        public const string OutsideOfEnum = "Данной должности не существует";
        #endregion
        #region Endpoints
        public const string StartShiftDescription = "Эндпоинт для установки начала смены сотрудника, принимает в себя идентификатор сотрудника, а также дату и время начала смены.";
        public const string StartShiftSummary = "Установка начала смены сотрудника.";
        public const string EndShiftDescription = "Эндпоинт для установки конца смены сотрудника, принимает в себя индентификатор сотрудника и время конца смены.";
        public const string EndShiftSummary = "Установка конца смены сотрудника.";
        public const string AddEmployeeDescription = "Эндпоинт для добавление нового сотрудника, принимает ФИО сотрудника и его должность.";
        public const string AddEmployeeSummary = "Добавление сотрудника.";
        public const string UpdateEmployeeDescription = "Эндпоинт для изменение данных сотрудника, принимает идентификатор, ФИО и должность сотрудника.";
        public const string UpdateEmployeeSummary = "Изменение данных сотрудника.";
        public const string DeleteEmployeeDescription = "Эндпоинт для удаления данных сотрудника, принимает идентификатор сотрудника.";
        public const string DeleteEmployeeSummary = "Удаление данных сотрудника.";
        public const string GetEmployeesDescription = "Эндпоинт для получения данных сотрудников, принимает должность сотрудника (опционально).";
        public const string GetEmployeesSummary = "Получение информации о сотрудниках (вместе с статистикой смен).";
        public const string GetPostsDescription = "Эндпоинт для получение данных должностей";
        public const string GetPostsSummary = "Получение информации о должностях.";
        #endregion
    }
}
