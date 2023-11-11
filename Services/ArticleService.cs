using System.Collections;
using crudapp.DB;
using crudapp.Dto;
using crudapp.Dto.Response;
using crudapp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudapp.Services;

   public class ArticleService 
   {
       protected readonly DataContext _context;

       public ArticleService (DataContext context)
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

       public virtual async Task<Boolean> Update(Article model)
       {
           _context.Entry(model).State = EntityState.Modified;
           await _context.SaveChangesAsync();
            return true;
       }

       public virtual async Task<Boolean> UpdatebyId(int id,Article model)
       {
           var uitem = await _context.Articles.FindAsync(id);
            // ---- modify filed waant to update
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
           }
            await _context.SaveChangesAsync();
           return true;
       }

       public virtual async Task<Boolean> Delete(int id)
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

        public async Task<PageResponseDto> vuetable(PageDto page){
            try
            {
                var qry =  _context.Articles;
                int  total = await qry.CountAsync();
                
                // var datas = await _context.Articles.Include(u=>u.Roles)
                var datas = await qry
                .Skip((page.Current_page - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToListAsync();

                return new PageResponseDto { 
                    status = 1,
                    success= true,
                    message = "succexxxxss",
                    datas  = datas,
                    total = total,
                    perpage  = page.PageSize ,
                    currentpage = page.Current_page,

                    };
            }  catch (System.Exception ex)   {
                return new PageResponseDto{
                    status = 0,
                    success= false,
                    message = ex.Message
                };
            }
        }   

       
   }
