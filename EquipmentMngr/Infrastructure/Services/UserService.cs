//using EquipmentMngr.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using EquipmentMngr.Infrastructure.Services.Interfaces;

//namespace EquipmentMngr.Infrastructure.Services
//{
//    public class UserService : ICurrentUserService
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly UserManager<IdentityUser> _userManager;
//        public UserService(ApplicationDbContext db, UserManager<IdentityUser> userManager)
//        {
//            _context = db;
//            _userManager = userManager;
//        }

//        public async Task<IdentityResult> AddUserAsync(RegisterUserPageModel user)
//        {
//            var dbUser = new IdentityUser
//            {
//                UserName = user.Email,
//                Email = user.Email,
//                EmailConfirmed = true
//            };
//            var result = await _userManager.CreateAsync(dbUser, user.Password);
//            return result;
//        }

//        public async Task<bool> DeleteUser(string userId)
//        {
//            try
//            {
//                var dbUser = await _context.Users.FirstOrDefaultAsync(d => d.Id.Equals(userId));
//                if (dbUser == null) return false;

//                var userRoles = _context.UserRoles.Where(ur => ur.UserId.Equals(dbUser.Id));

//                _context.UserRoles.RemoveRange(userRoles);
//                _context.Users.Remove(dbUser);

//                var result = await _context.SaveChangesAsync();
//                if (result < 0) return false;
//            }
//            catch
//            {
//                return false;
//            }

//            return true;
//        }


//        public UserPageModel GetUser(string userId)
//        {
//            return (from user in _context.Users
//                    where user.Id.Equals(userId)
//                    select new UserPageModel
//                    {
//                        Id = user.Id,
//                        Email = user.Email,
//                        IsAdmin = _context.UserRoles.Any(ur =>
//                            ur.UserId.Equals(user.Id) &&
//                            ur.RoleId.Equals(1.ToString()))
//                    }).FirstOrDefault();
//        }

//        public IEnumerable<UserPageModel> GetUsers()
//        {
//            return from user in _context.Users
//                   orderby user.Email
//                   select new UserPageModel
//                   {
//                       Id = user.Id,
//                       Email = user.Email,
//                       IsAdmin = _context.UserRoles.Any(ur =>
//                           ur.UserId.Equals(user.Id) &&
//                           ur.RoleId.Equals(1.ToString()))
//                   };
//        }

//        public async Task<bool> UpdateUserAsync(UserPageModel user)
//        {
//            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(user.Id));
//            if (dbUser == null) return false;
//            if (string.IsNullOrEmpty(user.Email)) return false;

//            dbUser.Email = user.Email;

//            var userRole = new IdentityUserRole<string>()
//            {
//                RoleId = "1",
//                UserId = user.Id
//            };

//            var isAdmin = await _context.UserRoles.AnyAsync(ur =>
//                ur.Equals(userRole));

//            if (isAdmin && !user.IsAdmin)
//                _context.UserRoles.Remove(userRole);
//            else if (!isAdmin && user.IsAdmin)
//                await _context.UserRoles.AddAsync(userRole);

//            var result = await _context.SaveChangesAsync();
//            return result >= 0;
//        }
//    }
//}

