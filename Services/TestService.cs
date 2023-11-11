using crudapp.DB;
using crudapp.Models;
using Microsoft.EntityFrameworkCore;

namespace crudapp.Services
{
    public class TestService
    {
   protected readonly DataContext _context;

        public TestService(DataContext context)
        {
            _context = context;
        }


        public virtual async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public virtual async Task<Article> GetByIdAsync(int id)
        {
            var item = await _context.Articles.FindAsync(id) ;
            if(item != null){
                return item;
            } else {
                return new Article{};
            }
        }

        public virtual async Task AddAsync(Article model)
        {
            await _context.Articles.AddAsync(model);
        }

        public virtual void Update(Article model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public virtual async Task<Boolean> UpdatebyId(int id,Article model)
        {
            var uitem = await _context.Articles.FindAsync(id);
            
            String[] fields = new String[] {"Title", "BodyText"};
            if(uitem != null ){
                //dynamic code
                foreach( string field in fields) {
                    var propertyInfo = uitem.GetType().GetProperty(field);
                    if (propertyInfo == null) return false;
                    propertyInfo.SetValue(uitem, model.GetType().GetProperty(field));
                }
                // fixed code
                // uitem.xxxx = model.xxxx
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public virtual async Task<Boolean>  Delete(int id)
        {
              var data = await _context.Articles.FindAsync(id);
              if(data != null ){
                _context.Articles.Remove(data);
               await _context.SaveChangesAsync();
               return true;
              }
            return false;
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            return await _context.Articles.AnyAsync(x => x.Id == id);
        }

        
    }
}