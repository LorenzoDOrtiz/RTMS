//using Microsoft.EntityFrameworkCore;
//using RTMS.CoreBusiness;

//namespace RTMS.Plugins.PostgreEFCore;
//public class UserRepositoryPostgreEFCore
//{
//    public async Task<User> GetOrCreateUserAsync(string provider, string providerKey, string email, string name)
//    {
//        var userLogin = await _context.UserLogins
//            .Include(ul => ul.User)
//            .FirstOrDefaultAsync(ul => ul.Provider == provider && ul.ProviderKey == providerKey);

//        if (userLogin != null)
//        {
//            return userLogin.User;
//        }

//        var user = new User
//        {
//            Name = name,
//            Email = email
//        };

//        _context.Users.Add(user);
//        await _context.SaveChangesAsync();

//        var userLogin = new UserLogin
//        {
//            Provider = provider,
//            ProviderKey = providerKey,
//            UserId = user.Id
//        };

//        _context.UserLogins.Add(userLogin);
//        await _context.SaveChangesAsync();

//        return user;
//    }

//}
