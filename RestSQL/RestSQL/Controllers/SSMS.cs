using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SSMS : ControllerBase
    {

        SqlConnection con = new SqlConnection(@"Data Source=192.168.0.35;Initial Catalog=HCSDB; User Id = sa; Password= P@ssword");

        // Post: api/<SSMS>
        [HttpPost(nameof(Fetch))]
        public IActionResult Fetch([FromBody] string query)
        {
            try
            {
                con.Open();
                var result = con.Query(query);
                con.Close();
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        //// GET api/<SSMS>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }
        //    return "value";
        //}

        // POST api/<SSMS>
        [HttpPost]
        public async Task<string> Post([FromBody] string query)
        {
            try
            {
                var result = await Task.FromResult(con.Execute(query));
                return result.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }

        // PUT api/<SSMS>/5
        [HttpPut]       
        public async Task<string> Put([FromBody] string query)
        {
            try
            {
                var result = await Task.FromResult(con.Execute(query));
                return result.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }

        // DELETE api/<SSMS>/5
        [HttpDelete]
        public async Task<string> Delete([FromBody] string query)
        {
            try
            {
                var result = await Task.FromResult(con.Execute(query));
                return result.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }


        //[HttpDelete(nameof(Delete))]  
        //public async Task<int> Delete()  
        //{  
        //    var result = await Task.FromResult(Execute($"Delete [Dummy] Where Id = {Id}", null, commandType: CommandType.Text));  
        //    return result;  
        //}

        //// DELETE api/<SSMS>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }
        //}
    }
}
