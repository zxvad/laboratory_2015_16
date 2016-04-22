using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerReports.Dal.Entities
{
    public class BaseEntity
    {
        /// <summary>
        ///     Id сущности
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}