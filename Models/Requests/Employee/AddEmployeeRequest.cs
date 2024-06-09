﻿using API.Models.Entity;

namespace API.Models.Requests.Employee
{
    /// <summary>
    /// Модель-запрос на добавление сотрудника
    /// </summary>
    /// <param name="LastName">Фамилия сотрудника</param>
    /// <param name="FirstName">Имя сотрудника</param>
    /// <param name="MiddleName">Отчество сотрудника</param>
    /// <param name="Post">Должность сотрудника</param>
    public record AddEmployeeRequest(
        string LastName,
        string FirstName,
        string? MiddleName,
        PostEnum? Post = null)
    { }
}
