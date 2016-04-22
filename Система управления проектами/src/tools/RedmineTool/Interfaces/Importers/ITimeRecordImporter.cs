using System.Collections.Generic;
using RedmineTool.Models;

namespace RedmineTool.Interfaces.Importers
{
    public interface ITimeRecordImporter : IImporter<RedmineTimeRecord>
    {
        /// <summary>
        ///     Возвращает все записи о потраченном времени, отфильтрованные по проекту и задаче
        /// </summary>
        /// <param name="projectId">Id проекта</param>
        /// <param name="issueId">Id задачи</param>
        /// <remarks>Значение null убирает фильтр по этому параметру</remarks>
        IEnumerable<RedmineTimeRecord> GetMany(int? projectId = null, int? issueId = null);
    }
}