using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RemindersDemo.Services
{
    public class UserService : IUserService, IDisposable
    {
        private readonly IApplicationDbContext _db;

        public UserService(IApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetAllUsersExceptCurrent(string currentUserId)
        {
            return (from dbUser in _db.Users where dbUser.Id != currentUserId select new SelectListItem() { Text = dbUser.Email, Value = dbUser.Id });
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}