﻿using NetCore.Domain.Entities;
using NetCore.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Abstractions.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAll();
        Task<IEnumerable<EmployeeDTO>> GeByField(string field, string value);
        void AddEmployee(EmployeeDTO employee);
        void UpdateEmployee(EmployeeDTO employee);
        void RemoveEmployee(EmployeeDTO employee);
    }
}
