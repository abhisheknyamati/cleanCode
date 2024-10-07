﻿using BankingApplication_backend.Models;

namespace BankingApplication_backend.Services
{
    public interface IEmpTransactionService
    {
        Task<List<TransactionStatusCount>> GetEmployeeTransactionStatusCountsAsync();

        Task<IEnumerable<EmpTransaction>> GetEmployeeSalaryDisbursements(int organizationId, string status);
       
    }
}
