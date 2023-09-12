using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
public interface IUserRepository
{
    Task<ResponseBody<ResultUser>> AddUser(RequestAddUser request);

    Task<ResponseBody<SessionData>> LogInUser(RequestLogIn request);

    Task<ResponseBody<SessionData>> LogOutUser(SessionData session);

    Task<ResponseBody<bool>> CheckAccount(RequestCheckAccount request);

    Task<ResponseBody<List<ResultUser>>> List(RequestList request);

    Task<ResponseBody<List<ResultUser>>> SearchUser(RequestSearch request);


    #region Default CRUD Request
    Task<List<User>> GetAllUsers();

    Task<User> PostUserData(User user);
    #endregion
}
