using System.Collections.Generic;
using System.Threading.Tasks;


#nullable enable
public class UserRepository : IUserRepository
{
    private readonly WebAPIClient _webAPIClient;

    public string URL = string.Empty;

    public UserRepository(string url)
    {
        _webAPIClient = new WebAPIClient(new JsonSerializationOption());

        URL = url + "/User";
    }

    public async Task<ResponseBody<ResultUser>> AddUser(RequestAddUser request)
    {
        var result = await _webAPIClient.PostAsync<ResponseBody<ResultUser>, RequestAddUser>(URL + "/AddUser", request);
        return result;
    }

    public async Task<ResponseBody<SessionData>> LogInUser(RequestLogIn request)
    {
        var result = await _webAPIClient.PostAsync<ResponseBody<SessionData>, RequestLogIn>(URL + "/LogIn", request);
        return result;
    }

    public async Task<ResponseBody<SessionData>> LogOutUser(SessionData session)
    {
        var result = await _webAPIClient.PostAsync<ResponseBody<SessionData>, SessionData>(URL + "/LogOut", session);
        return result;
    }

    public async Task<ResponseBody<bool>> CheckAccount(RequestCheckAccount request)
    {
        var result = await _webAPIClient.PostAsync<ResponseBody<bool>, RequestCheckAccount>(URL + "/Check", request);
        return result;
    }

    public async Task<ResponseBody<List<ResultUser>>> List(RequestList request)
    {
        var result = await _webAPIClient.PostAsync<ResponseBody<List<ResultUser>>, RequestList>(URL + "/List", request);
        return result;
    }

    public async Task<ResponseBody<List<ResultUser>>> SearchUser(RequestSearch request)
    {
        var result = await _webAPIClient.PostAsync<ResponseBody<List<ResultUser>>, RequestSearch>(URL + "/Search", request);
        return result;
    }


    #region Default CRUD Request
    #region Get Mothods
    //--------------------------------- Get All Users ---------------------------------
    public async Task<List<User>> GetAllUsers()
    {
        var users = await _webAPIClient.GetAsync<List<User>>(URL);
        return users;
    }

    #endregion
    #region Post Methods
    // --------------------------------- Post User Data -------------------------------------------  
    public async Task<User> PostUserData(User user)
    {
        var postUser = await _webAPIClient.PostAsync<User, User>(URL, user);

        return postUser;
    }

    #endregion
    #region Put Methods
    // --------------------------------- Put User Data -------------------------------------------  
    public async Task<User> PutUserData(User user)
    {
        var postUser = await _webAPIClient.PutAsync<User, User>(URL + $"/{user.Id}", user);

        return postUser;
    }

    #endregion
    #region Delete Methos
    // --------------------------------- Delete User Data -------------------------------------------  
    public async Task<User> DeleteUserData(int index)
    {
        var deleteUser = await _webAPIClient.DeleteAsync<User>(URL, index);
        return deleteUser;
    }

    #endregion

    #endregion
}