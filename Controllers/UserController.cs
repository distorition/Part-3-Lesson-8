using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Part_3_Lesson_4.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4.Controllers
{
    [Authorize]
    [ApiController]
    [Route("controller")]
    public class UserController : Controller
    {
        private readonly UserRepositories userRepositories;
        private readonly UserService userService;
        private readonly UserAtribute validations;
        public UserController(UserRepositories user, UserAtribute rules)
        {
            validations = rules;
            userRepositories = user;
        }
        /// <summary>
        /// метод для получения пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res=await userRepositories.GEt();
            return Ok(res);
        }
        /// <summary>
        /// метод для создания пользователя
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User newUser)
        {
            

            var choies = validations.Validate(newUser);
            if (!choies.IsValid)//так мы проверям все ли поля заполнены 
            {
                return BadRequest();
            }
            await userRepositories.Add(newUser);
            return NoContent();
        }
        /// <summary>
        /// метод для его обвноелния
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
           
            await userRepositories.Ubdate(user);
            return NoContent();
        
        }
        /// <summary>
        /// метод для удаления пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete]
        [Route("{userid}")]
        public async Task<IActionResult> Delet([Range(1,int.MaxValue)]int id)//таким образом мы подключили валидацию [тут мы задаем в каком диапазоне может идти поиск только от 1 до макс инта]
        {
            await userRepositories.Delete(id);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("authentication")]
        public IActionResult Authitication([FromQuery] string name , string pas)
        {
            REsponseToken token =userService.Authentication(name, pas);//получаем наш токен 
            if (token is null)
            {
                return BadRequest(new { message = "Name or Pas is incorect" });
            }
            SetTokenCucki(token.Refreshtoken);  //добавляем его в куки 
            return Ok(token);
        }
        /// <summary>
        /// обновляем с определнном промежутке времени
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost("refresh-token")]
        public IActionResult Refresh()
        {
            string oldRefreshToken = Request.Cookies["refresh-token"];
            string newrefreshToken = userService.REfreshToken(oldRefreshToken);
            if (string.IsNullOrWhiteSpace(newrefreshToken))
            {
                return Unauthorized(new { message = "invalid token" });
            }
            SetTokenCucki(newrefreshToken);
            return Ok(newrefreshToken);
        }

        /// <summary>
        /// добавлеям куки
        /// </summary>
        /// <param name="token"></param>
        private void SetTokenCucki(string token)//метод для доавбления в куки 
        {
            var cockeiOption = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cockeiOption);
        }
    }
}
