using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public string URL = "http://127.0.0.1:5000/api";

    private IUserRepository _userRepository;


    private void Start()
    {
        SetURL();
    }

    void SetURL()
    {
        _userRepository = new UserRepository(URL);
    }

    public async Task<ResponseBody<ResultUser>> AddUser(RequestAddUser request)
    {
        return await _userRepository.AddUser(request);
    }

    public async Task<ResponseBody<SessionData>> LogInUser(RequestLogIn request)
    {
        return await _userRepository.LogInUser(request);
    }

    public async Task<ResponseBody<SessionData>> LogOutUser(SessionData session)
    {
        return await _userRepository.LogOutUser(session);
    }


    public async Task<ResponseBody<bool>> CheckAccount(RequestCheckAccount request)
    {
        return await _userRepository.CheckAccount(request);
    }
    
    public async Task<ResponseBody<List<ResultUser>>> List(RequestList request)
    {
        return await _userRepository.List(request);
    }


    public async Task<ResponseBody<List<ResultUser>>> SearchUser(RequestSearch request)
    {
        return await _userRepository.SearchUser(request);
    }

    #region Default CRUD Request
    //--------------------------------- Get All Users ---------------------------------
    [ContextMenu("Test Get")]
    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task<User> PostUserData(User user)
    {
        return await _userRepository.PostUserData(user);
    }
    #endregion
}
