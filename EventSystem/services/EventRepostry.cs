using EventSystem.Data;
using EventSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Humanizer.In;

namespace EventSystem.services
{
    public class EventRepostry : IEventRepostry
    {
        public EventRepostry(ApplicationDbContext context , UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public ApplicationDbContext _context { get; }
        public UserManager<IdentityUser> _userManager { get; }
        public IHttpContextAccessor _httpContextAccessor { get; }

        public async Task<List<AddCategoryViewModel>> GetAllCateogry()
        {
           return  await _context.Categories.Select(x => new AddCategoryViewModel
             {
               CatogryName = x.Name,
                   Id = x.Id,
             }).ToListAsync();
        }

        public async Task<IdentityUser> GetUserLogin()
        {
            HttpContext _httpcontext = _httpContextAccessor.HttpContext;
            return await _userManager.GetUserAsync(_httpcontext.User);
            
        }


        public async Task AddEventDB(EventViewModel model)
        {
            var UserNameLogin = GetUserLogin().Result.UserName;
            var Supervisor = await _context.Users.Where(x => x.UserName == model.SupervisorName).FirstOrDefaultAsync();

            Event newEvent = new Event
            {
                Name = model.Name,
                Details = model.Details,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                CategoryId = model.CategoryId,
                CreatedAt = DateTime.Now,
                CreatedBy = UserNameLogin,
                 Supervisor = Supervisor
                
            };

           await _context.Event.AddAsync(newEvent);
           await _context.SaveChangesAsync();
        }

        public async Task<List<EventViewModel>> GetAllEvents(/*DateTime Date,*/ string name = null, int  CateogryId =0 )
        {
           var result = await _context.Event.Include(x => x.Category).Include(x => x.Supervisor)
                //.Where( x => (Date == null)  ? true : x.StartDate == Date)
                .Where(x => (name == null) ? true : x.Name == name)
                .Where(x => (CateogryId == 0) ? true : x.CategoryId == CateogryId)
                .Select(x => new EventViewModel
                {
                    Name = x.Name,
                    Id = x.Id,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Details = x.Details,
                    CreatedAt = DateTime.Now,
                    CategoryId = x.Category.Id,
                     CategoryName = x.Category.Name,
                      CreatedBy = x.CreatedBy,
                       SupervisorName = x.Supervisor.UserName
                }).ToListAsync();
            return result;
         }

        public async Task<EventViewModel> GetEvent (int id)
        {
              return await _context.Event.Include(x => x.Category).Include(x => x.Supervisor)
                .Where(x => x.Id == id)
                .Select(x => new EventViewModel
                {
                    Name = x.Name,
                    Id = x.Id,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Details = x.Details,
                    CreatedAt = DateTime.Now,
                    CategoryId = x.Category.Id,
                    CategoryName = x.Category.Name,
                    CreatedBy = x.CreatedBy,
                    SupervisorName = x.Supervisor.UserName
                }).FirstOrDefaultAsync();
        }

        public async Task deleteEvent (int Id)
        {
            var EventBeDeilted = await _context.Event.Where(x => x.Id == Id).FirstOrDefaultAsync();
             if (EventBeDeilted is not null) 
             { 
                _context.Event.Remove(EventBeDeilted);
             }
        }

        public async Task UpdateRecord(EventViewModel model)
        {
            var Supervisor = await _context.Users.Where(x => x.UserName == model.SupervisorName).FirstOrDefaultAsync();
            var EventBeDeilted = await _context.Event.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            var UserNameLogin = GetUserLogin().Result.UserName;
            if (EventBeDeilted is not null)
            {
                var NewEvent = new Event
                {
                    Name = model.Name,
                    Details = model.Details,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CategoryId = model.CategoryId,
                    CreatedAt = DateTime.Now,
                    CreatedBy = UserNameLogin,
                     Supervisor = Supervisor,
                };
                _context.Event.Update(NewEvent);
            }
        }
    }

}
