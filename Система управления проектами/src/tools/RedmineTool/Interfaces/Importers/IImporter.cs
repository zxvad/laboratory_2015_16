using System.Collections.Generic;

namespace RedmineTool.Interfaces.Importers
{
    public interface IImporter<out T>
    {
        /// <summary>
        ///     Возвращает запись по заданному id
        /// </summary>
        /// <param name="id">Id записи</param>
        T GetById(int id);

        /// <summary>
        ///     Возвращает все записи
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        ///     Возвращает количество записей
        /// </summary>
        int GetTotalRecordCount();
    }
}