﻿using EixampleDotnet.Dto;
using EixampleDotnet.Entities;
using System.Threading.Tasks;

namespace EixampleDotnet.Application
{
    public interface IUserService
    {
        Task<ApplicationUser> Authenticate(string username, string password);

        Task<ApplicationUser> Create(CreateUserInput input);
    }
}
