using TaksList.Models.Requests;
using TaksList.Models.Responses;

namespace TaksList.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserRequest request);
        void UpdateUser(int id, UpdateUserRequest request);
        void DeleteUser(int id);
        List<TaskResponse> GetTaskByUser(int userId);

    }
}
