using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using crudapp.DB;
using crudapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly DataContext _context;

        public AddressController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try {         
                var datas = await _context.Addresses
                            .Include(a=>a.Person)
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
                    datas = new List<Address>(),
                    message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try {         
                if (id == 0) { throw new Exception("0 is an invalid ID"); }
                var datas = await  _context.Addresses.FindAsync(id);
                if (datas == null) { throw new Exception($"No Address was found with the ID: {id}"); }
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
        public async Task<IActionResult> Create(Address model)
        {
            try {        
                if (model == null){
                    throw new Exception("Please enter valid information");
                }else{
                    await _context.Addresses.AddAsync(model);
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
        public async Task<IActionResult> Delete(long id)
        {
            try {         
                if (id == 0) { throw new Exception("0 is an invalid ID"); }
                var data = await _context.Addresses.FindAsync(id);
                if (data == null) { throw new Exception($"No Address was found with the ID: {id}"); }
                _context.Addresses.Remove(data);
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
        public async Task<IActionResult> Update(int id, Address model)
        {
            if (id == 0)
            {
                return BadRequest("0 is an invalid ID");
            }

            var AddressToUpdate = await _context.Addresses.FindAsync(id);

            if (AddressToUpdate != null)
            {
                //Map the properties from the recieved model
                //to the model that we want to upadte.
                // AddressToUpdate.FirstName = model.FirstName;
                // AddressToUpdate.LastName = model.LastName;
                // AddressToUpdate.Email = model.Email;
                // AddressToUpdate.Salary = model.Salary;

                await _context.SaveChangesAsync();

                return NoContent(); //Return 200 OK Status Code.
            }
            else
            {
                return NotFound($"No Address was found with the ID: {id}"); //Return 404 Status Code
            }
        }

    }
}