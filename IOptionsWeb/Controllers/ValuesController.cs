using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOptionsWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace IOptionsWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MyOptions _options;
        private readonly MyOptionsWithDelegateConfig _optionsWithDelegateConfig;
        private readonly MyOptions _snapshotOptions;
        private readonly MyOptions _named_options_1;
        private readonly MyOptions _named_options_2;

        public ValuesController(
            IOptionsMonitor<MyOptions> optionsAccessor,
            IOptionsMonitor<MyOptionsWithDelegateConfig> optionsAccessorWithDelegateConfig,
            IOptionsSnapshot<MyOptions> snapshotOptionsAccessor,
            IOptionsSnapshot<MyOptions> namedOptionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _optionsWithDelegateConfig = optionsAccessorWithDelegateConfig.CurrentValue;
            _snapshotOptions = snapshotOptionsAccessor.Value;
            _named_options_1 = namedOptionsAccessor.Get("named_options_1");
            _named_options_2 = namedOptionsAccessor.Get("named_options_2");
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
