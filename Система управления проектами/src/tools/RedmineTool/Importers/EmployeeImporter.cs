using System.Collections.Generic;
using RedmineTool.Models;
using System.Linq;
using RedmineTool.Containers;
using RedmineTool.Infrastructure;
using RedmineTool.Interfaces;
using RedmineTool.Interfaces.Importers;
using Serilog;

namespace RedmineTool.Importers
{
    public class EmployeeImporter : IEmployeeImporter
    {
        private readonly ISerializer _serializer;
        private readonly CommonImporter _commonImporter;

        public EmployeeImporter(string apiFormat)
        {
            _serializer = SerializerFactory.Get(apiFormat);
            _commonImporter = new CommonImporter(RedmineResources.Employees, apiFormat);
        }

        public RedmineEmployee GetById(int id)
        {
            var source = _commonImporter.GetById(id);

            Log.Logger.Information($"resourcce {source}");

            return _serializer.Deserialize<EmployeeContainer>(source).Employee;
        }

        public IEnumerable<RedmineEmployee> GetAll()
        {
            var source = _commonImporter.GetMany();
            return source.SelectMany(i => _serializer.Deserialize<EmployeesContainer>(i).Employees);
        }

        public int GetTotalRecordCount()
        {
            return _commonImporter.GetTotalRecordCount();
        }

        public IEnumerable<RedmineEmployee> GetMany(int? statusId = null)
        {
            var parameters = new List<string>();

            if (statusId.HasValue)
            {
                parameters.Add($"status_id={statusId.Value}");
            }

            var source = _commonImporter.GetMany(parameters);
            return source.SelectMany(i => _serializer.Deserialize<EmployeesContainer>(i).Employees);
        }
    }
}