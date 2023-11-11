using crudapp.DB;
using crudapp.Dto;
using crudapp.Models;
using crudapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController  : ControllerBase
    {
        private readonly ArticleService _srv;

        public TestController (DataContext context)
        {
           _srv = new ArticleService(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try {         
                var datas = await _srv.GetAllAsync();
                return Ok(new  {
                    success = true,
                    status = 1,
                    message = "success",
                    datas = datas,
                });

            } catch(System.Exception ex)  {
                return BadRequest(new
                {
                    status = 0,
                    success = false,
                    datas = new List<Article>(),
                    message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try {         
                if (id == 0) { throw new Exception("0 is an invalid ID"); }
                var datas = await  _srv.GetByIdAsync(id);
                if (datas == null) { throw new Exception($"No Article was found with the ID: {id}"); }
                return Ok(new  {
                    success = true,
                    status = 1,
                    message = "success",
                    datas = datas,
                });

            } catch(System.Exception ex)  {
                return BadRequest(new
                {
                    status = 0,
                    success = false,
                    datas = new int[0],
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Article model)
        {
            try {        
                if (model == null){
                    throw new Exception("Please enter valid information");
                }else{
                    await _srv.AddAsync(model);
                    return Ok(new  {
                        success = true,
                        status = 1,
                        message = "success",
                        input = model
                    });
                }
            } catch(System.Exception ex)  {
                return BadRequest(new
                {
                    status = 0,
                    success = false,
                    datas = new int[0],
                    message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try {         
                if (id == 0) { throw new Exception("0 is an invalid ID"); }
                await _srv.Delete(id);
                return Ok(new  {
                    success = true,
                    status = 1,
                    message = "success",
                });

            } catch(System.Exception ex)  {
                return BadRequest(new
                {
                    status = 0,
                    success = false,
                    datas = new int[0],
                    message = ex.Message
                });
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Article model)
        {
           try  { 
             if (id == 0)
             {
                 return BadRequest("0 is an invalid ID");
             }
             await _srv.UpdatebyId(id,model);
             return Ok(new  { 
               success = true, 
               status = 1, 
               message = "success", 
             }); 
           }  catch (System.Exception ex) {
             return BadRequest(new
             {
                 status = 0,
                 success = false,
                 datas = new int[0],
                 message = ex.Message
             });
           }
        }

        [HttpPost]
        [Route("vuetable")]
        public async Task<IActionResult> vuetable([FromQuery] PageDto page){
            try
            {
                var rs =  await _srv.vuetable(page);
                return Ok(rs);
            }  catch (System.Exception ex)   {
                return BadRequest( new {
                status = 0,
                success= false,
                message = ex.Message
                });
            }
        }   

    }

}
