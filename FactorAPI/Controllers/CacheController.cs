using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;

namespace FactorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;
        public CacheController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet]
        [Route("SimpleString")]
        public string SimpleString()
        {
            var cacheKey = "time";
            var existingTime = _distributedCache.GetString(cacheKey);
            if (!string.IsNullOrEmpty(existingTime))
            {
                return "Fetched from cache : " + existingTime;
            }
            else
            {
                existingTime = DateTime.Now.ToString();
                _distributedCache.SetString(cacheKey, existingTime);
                return "Added to cache : " + existingTime;
            }
        }
        [HttpGet]
        [Route("SimpleObject")]
        public IActionResult SimpleObject()
        {
            var cacheKey = "object";
            var obj = new Person { name = "mehdi", familyName = "mahdavi", age = 25 };
            var existingobj = _distributedCache.GetString(cacheKey);
            if (!string.IsNullOrEmpty(existingobj))
            {
                var objFetched = JsonConvert.DeserializeObject<Person>(existingobj);
                return Ok(objFetched);
            }
            else
            {
                existingobj = JsonConvert.SerializeObject(obj);
                _distributedCache.SetString(cacheKey, existingobj);
                return Ok("Fetched Object from cache ");
            }
        }
        private class Person
        {
            public string name { get; set; }
            public string familyName { get; set; }
            public int age { get; set; }



        }
    }
}
