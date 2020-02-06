using System.Collections.Generic;
using System.Web.Mvc;

namespace RemindersDemo.Services
{
    public interface IUserService
    {
        IEnumerable<SelectListItem> GetAllUsersExceptCurrent(string currentUserId);
    }
}