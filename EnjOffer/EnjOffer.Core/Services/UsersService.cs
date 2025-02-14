﻿using EnjOffer.Core.Domain.Entities;
using EnjOffer.Core.Domain.IdentityEntities;
using EnjOffer.Core.Domain.RepositoryContracts;
using EnjOffer.Core.DTO;
using EnjOffer.Core.Helpers;
using EnjOffer.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjOffer.Core.Services
{
    public class UsersService : IUsersService
    {
        //private readonly IUsersRepository _usersRepository;
        private readonly IDefaultWordsRepository _defaultWordsRepository;
        private readonly IUsersDefaultWordsRepository _usersDefaultWordsRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersService(/*IUsersRepository usersRepository*/ IDefaultWordsRepository defaultWordsRepository,
            IUsersDefaultWordsRepository usersDefaultWordsRepository, UserManager<ApplicationUser> userManager)
        {
            //_usersRepository = usersRepository;
            _defaultWordsRepository = defaultWordsRepository;
            _usersDefaultWordsRepository = usersDefaultWordsRepository;
            _userManager = userManager;
        }

        /*public UserResponse AddUser(UserAddRequest? userAddRequest)
        {
            if (userAddRequest is null)
            {
                throw new ArgumentNullException(nameof(userAddRequest));
            }

            ValidationHelper.ModelValidation(userAddRequest);
            
            if (userAddRequest.Email is not null && _usersRepository.GetUserByEmail(userAddRequest.Email) is not null)
            {
                throw new ArgumentException("This user already exists", nameof(userAddRequest));
            }

            //Convert userAddRequest to Users type
            Users user = userAddRequest.ToUser();

            //Generate UserId
            user.UserId = Guid.NewGuid();

            //Add user to list
            _usersRepository.AddUser(user);

            //Convert the Users object into UserResponse type
            return user.ToUserResponse();
        }

        public bool DeleteUser(Guid? userId)
        {
            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            Users? user = _usersRepository.GetUserById(userId.Value);

            if (user is null)
            {
                return false;
            }

            _usersRepository.DeleteUser(userId.Value);

            return true;
        }

        public bool DeleteUserByEmail(string email)
        {
            UserResponse? user = _usersRepository.GetAllUsers().FirstOrDefault(user => user.Email == email)?.ToUserResponse();

            if (user is null)
            {
                return false;
            }

            _usersRepository.DeleteUser(user.UserId);
            return true;
        }*/

        /*public List<UserResponse> GetAllUsers()
        {
            return _usersRepository.GetAllUsers().Select(user => user.ToUserResponse()).ToList();
        }*/

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            var identityUsers = await _userManager.Users.ToListAsync();
            return identityUsers.Cast<ApplicationUser>().ToList();
        }

        /*public UserResponse? GetUserById(Guid? userId)
        {
            if (userId is null)
            {
                return null;
            }

            Users? user_response_from_list = _usersRepository.GetUserById(userId.Value);

            if (user_response_from_list is null)
            {
                return null;
            }

            return user_response_from_list?.ToUserResponse() ?? null;
        }*/
    }
}
