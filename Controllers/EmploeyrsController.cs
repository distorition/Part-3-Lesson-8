using Microsoft.AspNetCore.Mvc;
using Part_3_Lesson_4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4.Controllers
{
    public class EmploeyrsController : Controller
    {
        private readonly EmploersRepositorties EmploersRepositories;
        public EmploeyrsController(EmploersRepositorties user)
        {
            EmploersRepositories = user;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await EmploersRepositories.GEt();
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employers newUser)
        {
            await EmploersRepositories.Add(newUser);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employers employers)
        {

            await EmploersRepositories.Ubdate(employers);
            return NoContent();

        }

        [HttpDelete]
        [Route("{userid}")]
        public async Task<IActionResult> Delet(int id)
        {
            await EmploersRepositories.Delete(id);
            return NoContent();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
