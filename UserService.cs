using System.Collections.Generic;
using System.Threading;

namespace MemcacheExample
{

    public class UserService
    {
        public List<User> FindAll()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Age = 12,
                    Cellphone = "12312541212",
                    Email = "fun@gmail.com",
                    Id = 1,
                    Name = "user1"
                },
                new User()
                {
                    Age = 14,
                    Cellphone = "1412412412",
                    Email = "bbbb@gmail.com",
                    Id = 1,
                    Name = "user2"
                },
                new User()
                {
                    Age = 32,
                    Cellphone = "41241215125",
                    Email = "aaaa@gmail.com",
                    Id = 1,
                    Name = "user3"
                }
            };

            Thread.Sleep(2000);

            return users;
        }
    }
}
