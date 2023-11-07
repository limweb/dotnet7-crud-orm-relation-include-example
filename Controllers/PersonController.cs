using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using crudapp.DB;
using crudapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try {         
                var datas = await _context.Persons.
                        Include(p=>p.Addresses)
                        .ToListAsync();
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
                    datas = new List<Person>(),
                    message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try {         
                if (id == 0) { throw new Exception("0 is an invalid ID"); }
                var datas = await  _context.Persons.FindAsync(id);
                if (datas == null) { throw new Exception($"No Person was found with the ID: {id}"); }
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
        public async Task<IActionResult> Create(Person model)
        {
            try {        
                if (model == null){
                    throw new Exception("Please enter valid information");
                }else{
                    await _context.Persons.AddAsync(model);
                    await _context.SaveChangesAsync();
                    return Ok(new  {
                        success = true,
                        status = 1,
                        message = "success",
                        input=model
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
                var data = await _context.Persons.FindAsync(id);
                if (data == null) { throw new Exception($"No Person was found with the ID: {id}"); }
                _context.Persons.Remove(data);
                await _context.SaveChangesAsync();
                return Ok(new  {
                    success = true,
                    status = 1,
                    message = "success",
                    datas = data,
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
        public async Task<IActionResult> Update(int id, Person model)
        {
            if (id == 0)
            {
                return BadRequest("0 is an invalid ID");
            }

            var PersonToUpdate = await _context.Persons.FindAsync(id);

            if (PersonToUpdate != null)
            {
                //------  your code for Update--------------
                //Map the properties from the recieved model
                //to the model that we want to upadte.
                //PersonToUpdate.xxxxx = model.FirstName;

                await _context.SaveChangesAsync();

                return NoContent(); //Return 200 OK Status Code.
            }
            else
            {
                return NotFound($"No Person was found with the ID: {id}"); //Return 404 Status Code
            }
        }

    }
}