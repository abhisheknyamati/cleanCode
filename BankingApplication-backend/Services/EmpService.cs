﻿using BankingApplication_backend.Data;
using BankingApplication_backend.Models;
using BankingApplication_backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace BankingApplication_backend.Services
{
    public class EmpService : IEmpService
    {

        private readonly IEmpRepo _empRepo;
        public EmpService(IEmpRepo empRepo)
        {
            _empRepo = empRepo;
        }
        public async Task<IEnumerable<Employee>> GetEmployeesByOrgId(int orgId, string searchTerm, int pageNumber, int pageSize)
        {
            var employees = await _empRepo.GetEmployeesByOrgId(orgId, searchTerm, pageNumber, pageSize);
            return employees;
        }

        public async Task<bool> SoftDeleteEmployeeAsync(int id)
        {
            var employee = await _empRepo.GetEmployeeByIdAsync(id);
            if (employee == null) return false;

            employee.IsActive = false;
            await _empRepo.UpdateEmployeeAsync(employee);
            return true;
        }
    }
}
