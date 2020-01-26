using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DotNetSample.Application.DataTypes.Request;
using DotNetSample.Application.DataTypes.Result;
using DotNetSample.Application.Services.Contracts;
using DotNetSample.Domain.Entities;
using DotNetSample.Domain.Interfaces.Service;

namespace DotNetSample.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserAppService(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public OperationResultList<UserResult> GetUsers(bool onlyActives)
        {
            var or = new OperationResultList<UserResult>();

            try
            {
                var users = _userService.GetUsers(onlyActives);
                var usersResult = _mapper.Map<IEnumerable<UserResult>>(users);
                or.Success = true;
                or.Data = usersResult;
            }
            catch (Exception ex)
            {
                or.Success = false;
                or.Data = null;
                or.Message = ex.Message;
                //TODO: LogException();
            }

            return or;
        }

        public OperationResult<UserResult> GetUser(int userId)
        {
            var or = new OperationResult<UserResult>();

            try
            {
                var user = _userService.GetUser(userId);
                var userResult = _mapper.Map<UserResult>(user);

                or.Success = true;
                or.Data = userResult;
            }
            catch (Exception ex)
            {
                or.Success = false;
                or.Data = null;
                or.Message = ex.Message;
                //TODO: LogException();
            }

            return or;
        }

        public OperationResult AddUser(AddUserRequest request)
        {
            var or = new OperationResult();

            try
            {
                var newUser = _mapper.Map<User>(request);
                _userService.AddUser(newUser);
                or.Success = true;
            }
            catch (Exception ex)
            {
                or.Success = false;
                or.Message = ex.Message;
                //TODO: LogException();
            }

            return or;
        }

        public OperationResult UpdateUser(UpdateUserRequest request)
        {
            var or = new OperationResult();

            try
            {
                var newUser = _mapper.Map<User>(request);
                _userService.UpdateUser(newUser);
                or.Success = true;
            }
            catch (Exception ex)
            {
                or.Success = false;
                or.Message = ex.Message;
                //TODO: LogException();
            }

            return or;
        }

        public OperationResult DeleteUser(int userId)
        {
            var or = new OperationResult();

            try
            {
                var user = _userService.GetUser(userId);
                _userService.DeleteUser(user);
                or.Success = true;
            }
            catch (Exception ex)
            {
                or.Success = false;
                or.Message = ex.Message;
                //TODO: LogException();
            }

            return or;
        }
    }
}