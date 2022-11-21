using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PRMusic.Dto;
using PRMusic.Interface;
namespace PRMusic.Repository

{
    public class UserRepository : IUserRepository
    {
        private readonly PRMusicContext _context;
        private readonly UserRepository _repository;

        
        public UserRepository(PRMusicContext context)
        {
            _context = context;
        }

        public UserRepository(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var records = await _context
                .Users
                .Select(user => 
                new UserDto
                {   
                    Id = user.Id, 
                    FirstName = user.FirstName, 
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password
                    

                    
                    
                })
                .ToListAsync();

            return records;
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await _context.Users
                .Where(x => x.Id == id)
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password
                })
                .FirstOrDefaultAsync();

            return user;
               
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            var recordToUpdate = await _context.Users
               .Where(x => x.Id == user.Id)
               .Select(x => x)
               .FirstOrDefaultAsync();

            

            recordToUpdate.FirstName = user.FirstName;
            recordToUpdate.LastName = user.LastName;
            recordToUpdate.Email = user.Email;
            recordToUpdate.Id = user.Id;
            recordToUpdate.Password = user.Password;

            _context.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };

           
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var recordToDelete = await _context
                .Users
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _context.Users.Remove(recordToDelete);
            await _context.SaveChangesAsync();
            
            return true; 

        }

        public async Task<User> CreateUser(UserDto user)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }








    }
}
