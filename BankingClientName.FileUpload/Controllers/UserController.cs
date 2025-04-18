using BankingClientName.FileUpload.BusinessEntities.Interfaces;
using BankingClientName.FileUpload.BusinessEntities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingClientName.FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region constructor
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region GetMethod
        [HttpGet]
        [Route("GetUsers")]
        public async Task<string> GetUsersData()
        {
            return await _userService.InvokeUsersList();
        }
        #endregion

        #region GetById
        [HttpGet]
        [Route("GetUserDetailsById/{id}")]
        public async Task<string> GetUsersDataById(int id)
        {
            return await _userService.InvokeUsersById(id);
        }

        #endregion

        #region Post
        [HttpPost]
        [Route("InsertUserDetails")]
        public async Task<string> InsertUserDetails([FromBody] User userDetail)
        {
            return await _userService.InsertUserData(userDetail);
        }

        #endregion

        #region put
        [HttpPut]
        [Route("UpdateUserDetails/{id}")]
        public async Task<string> UpdateUserDetails([FromBody] User userDetail, [FromRoute] int id)
        {
            return await _userService.UpdateUserData(userDetail, id);
        }

        #endregion

        #region delete
        [HttpDelete]
        [Route("DeleteUserDetailsById/{id}")]
        public async Task<string> DeleteUserDataById(int id)
        {
            return await _userService.DeleteUserData(id);
        }
        #endregion

    }
}
