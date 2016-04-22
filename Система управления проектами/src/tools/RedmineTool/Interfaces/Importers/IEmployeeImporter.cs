using System.Collections.Generic;
using RedmineTool.Models;

namespace RedmineTool.Interfaces.Importers
{
    public interface IEmployeeImporter : IImporter<RedmineEmployee>
    {
        /// <summary>
        ///     Возвращает пользователей с фильтром по статусу
        /// </summary>
        /// <param name="statusId">Id статуса</param>
        /// <remarks>Если значение фильтра null, то вернет всех пользователей</remarks>
        IEnumerable<RedmineEmployee> GetMany(int? statusId = null);
    }
}