using DotNetSample.Application.DataTypes.Request;
using DotNetSample.Application.DataTypes.Result;

namespace DotNetSample.Application.Services.Contracts
{
    public interface IUserAppService
    {
        OperationResult AddUser(AddUserRequest request);
        OperationResultList<UserResult> GetUsers(bool onlyActives);
        OperationResult<UserResult> GetUser(int userId);
        OperationResult UpdateUser(UpdateUserRequest request);
        OperationResult DeleteUser(int userId);
    }
}