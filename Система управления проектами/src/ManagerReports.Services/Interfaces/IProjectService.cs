using System;
using System.Collections.Generic;
using ManagerReports.Services.Models;

namespace ManagerReports.Services.Interfaces
{
    public interface IProjectService
    {
        /// <summary>
        ///     Возвращает информацию по проекту с заданным id
        /// </summary>
        /// <param name="id">Id проекта</param>
        Project GetById(Guid id);

        /// <summary>
        ///     Возвращает информацию по всем проектам
        /// </summary>
        IEnumerable<Project> GetAll();

        /// <summary>
        ///     Обновляет информацию о проекте
        /// </summary>
        /// <param name="projectInfo">Новая информация о проекте</param>
        void UpdateProject(Project projectInfo);

        /// <summary>
        ///     Возвращает все версии проекта
        /// </summary>
        IEnumerable<Tuple<int?, string>> GetAllVersions(Guid projectId);
    }
}