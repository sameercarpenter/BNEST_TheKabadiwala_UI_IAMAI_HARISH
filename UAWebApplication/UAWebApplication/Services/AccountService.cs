using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UAWebApplication.Models;
using UAWebApplication.ViewModels;

namespace UAWebApplication.Services
{
    public class AccountService
    {
        private UADataContext _context;

        public AccountService(UADataContext context)
        {
            _context = context;
        }

        public async Task<User> SignUp(SignUpModel model,CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
