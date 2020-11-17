using Enyim.Caching;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemcacheExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly CacheService<User> _cache;
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, IMemcachedClient memCache)
        {
            _logger = logger;
            _userService = new UserService();
            _cache = new CacheService<User>(memCache);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var cached = await _cache.GetList("users");
            if (cached != null)
            {
                return cached;
            }

            var users = _userService.FindAll();
            await _cache.Save("users", users);
            return users;
        }
    }
}
