using Api.Repositories;

namespace WebApiHomeWork.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
        }

        public async Task<User> GetUserById(int id)
        {
            return await Task.Run(() => _users.FirstOrDefault(u => u.Id == id));
        }

        public async Task CreateUser(User user)
        {
            await Task.Run(() => _users.Add(user));
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            return await Task.Run(() =>
            {
                var existingUser = _users.FirstOrDefault(u => u.Id == id);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                }
                return existingUser;
            });
        }

        public async Task<User> UpdateUserPartial(int id, User user)
        {
            return await Task.Run(() =>
            {
                var existingUser = _users.FirstOrDefault(u => u.Id == id);
                if (existingUser != null)
                {
                    if (!string.IsNullOrEmpty(user.Name))
                    {
                        existingUser.Name = user.Name;
                    }
                    if (!string.IsNullOrEmpty(user.Email))
                    {
                        existingUser.Email = user.Email;
                    }
                }
                return existingUser;
            });
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await Task.Run(() =>
            {
                var user = _users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    _users.Remove(user);
                    return true;
                }
                return false;
            });
        }
    }
}