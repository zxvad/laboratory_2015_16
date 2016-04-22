using System.Collections.Generic;
using RedmineTool.Models;

namespace RedmineTool.Interfaces.Importers
{
    public interface IIssueImporter : IImporter<RedmineIssue>
    {
        /// <summary>
        ///     Возвращает задачи с фильтром по проекту и статусу
        /// </summary>
        /// <param name="projectId">Id проекта</param>
        /// <param name="statusId">Id статуса задачи</param>
        /// <remarks>Значение null убирает фильтр по этому параметру</remarks>
        IEnumerable<RedmineIssue> GetMany(int? projectId = null, int? statusId = null);
    }
}