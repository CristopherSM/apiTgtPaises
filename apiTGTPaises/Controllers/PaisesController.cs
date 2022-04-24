using apiTGTPaises.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace apiTGTPaises.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisL>>> GetPaises() 
        {
            var url = "https://restcountries.com/v2/all";
            using (var http = new HttpClient()) 
            {
                var res = await http.GetStringAsync(url);
                var paises = JsonConvert.DeserializeObject<List<Pais>>(res);
                var paisesFil = new List<PaisL>();
                foreach (var pa in paises)
                {
                    var p = new PaisL();
                    p.Name = pa.name;
                    p.Population = pa.population;
                    p.Capital = pa.capital;
                    paisesFil.Add(p);
                }
                return paisesFil;
            }
        }

    }
}
