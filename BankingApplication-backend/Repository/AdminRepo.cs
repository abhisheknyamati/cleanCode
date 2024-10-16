﻿using BankingApplication_backend.Data;
using BankingApplication_backend.DTOs;
using BankingApplication_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingApplication_backend.Repository
{
    public class AdminRepo : IAdminRepo
    {
        private readonly BankingAppDbContext _context;
        public AdminRepo(BankingAppDbContext context) { _context = context; }
        public async Task<Admin> AddAdmin(AdminDto adminDto)
        {
            var hashedPassword = PasswordHelper.HashPassword(adminDto.AdminPassword);

            var admin = new Admin
            {
                AdminName = adminDto.AdminName,
                AdminEmail = adminDto.AdminEmail,
                AdminPassword = hashedPassword,
            }; 

            var roleId = 1;

            var user = new User { RoleId = roleId };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            admin.UserId = user.UserId;
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
            var creds = new Creds
            {
                Username = admin.AdminEmail,
                Password = admin.AdminPassword,
                UserId = user.UserId
            };
            await _context.Credentials.AddAsync(creds);
            await _context.SaveChangesAsync();
            return admin;
        }
        public async Task<bool> UserExists(string email)
        {
            return await _context.Credentials.AnyAsync(u => u.Username == email);
        }

    }



}
