﻿using BankingApplication_backend.DTOs;
using BankingApplication_backend.Models;

namespace BankingApplication_backend.Services
{
    public interface IOrgService
    {
        Task<IEnumerable<EmpTransaction>> GetEmployeeTransactionsByOrgIdAsync(EmployeeTransactionFilterDto filter);
        Task<IEnumerable<Outbound>> GetOutboundsByAddedBy(int addedById);
        Task<Organisation> AddOrganisation(Organisation organisation);
        Task<Organisation> GetOrganisationById(int id);
        Task UpdateOrganisation(Organisation organisation);
        int UserIdToOrganisationId(int userId);
        Task AddOutbound(Outbound outbound);
        Task<bool> CanExecuteTransaction(int orgId, decimal transactionAmount);
        Task AddBeneficiaryTransaction(BeneficiaryTransactionRequestDto requestDto);
        Task<List<Organisation>> GetOrganisationsByBankId(int bankId);
    }
}
