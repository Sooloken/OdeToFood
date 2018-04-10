
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
       [Route("company/[controller]/[action]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {

        return "0723458496";

        }
        [Route("address")]
        public string Address()
        {
            return "USA";
        }
    }
}
