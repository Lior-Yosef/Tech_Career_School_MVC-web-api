using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tech_Career_School_MVC_web_api.Models;

namespace Tech_Career_School_MVC_web_api.Controllers
{
    public class TeacherController : ApiController
    {
        static string Stringconction = "Data Source=LAPTOP-OT5IVM7S;Initial Catalog=SchoolDB;Integrated Security=True;Pooling=False";

        // GET: api/Teacher
        public IHttpActionResult Get()
        {
            using(SqlConnection conn = new SqlConnection(Stringconction))
            {
                List<Teacher> Teacherlist = new List<Teacher>();
                try
                {

                
                conn.Open();
                string query= @"SELECT * FROM Teacher";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader DataFromDB = cmd.ExecuteReader();

                if (DataFromDB.HasRows)
                {
                    while (DataFromDB.Read())
                    {
                            Teacherlist.Add(new Teacher(DataFromDB.GetInt32(0), DataFromDB.GetString(1), DataFromDB.GetString(2), DataFromDB.GetInt32(3), DataFromDB.GetDateTime(4)));
                    };

                    conn.Close();
                    return Ok(new { Teacherlist });
                }
                else
                {
                    string Answer = "not found";
                    conn.Close();
                    return Ok(new { Answer });
                }
                }
                catch (SqlException ex) { return BadRequest(ex.Message); }

                catch (Exception ex) { return BadRequest(ex.Message); }
            }
            
        }

        // GET: api/Teacher/5
        public IHttpActionResult Get(int id)
        {

            using (SqlConnection conn = new SqlConnection(Stringconction))
            {
                List<Teacher> Teacherlist = new List<Teacher>();
                try
                {
                    conn.Open();
                    string query = @"SELECT * FROM Teacher WHERE Id={id}";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader DataFromDB = cmd.ExecuteReader();

                    if (DataFromDB.HasRows)
                    {
                        while (DataFromDB.Read())
                        {
                            Teacherlist.Add(new Teacher(DataFromDB.GetInt32(0), DataFromDB.GetString(1), DataFromDB.GetString(2), DataFromDB.GetInt32(3), DataFromDB.GetDateTime(4)));
                        };

                        conn.Close();
                        return Ok(new { Teacherlist });
                    }
                    else
                    {
                        string Answer = "not found";
                        conn.Close();
                        return Ok(new { Answer });
                    }
                }
                catch (SqlException ex) { return BadRequest(ex.Message); }

                catch (Exception ex) { return BadRequest(ex.Message); }
            }
        }

        // POST: api/Teacher
        public IHttpActionResult Post([FromBody]Teacher value)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Stringconction))
                {
                    conn.Open();
                    string query = $@"INSERT INTO Teacher (FirstName,LastName,Slary,Born)
                                    VALUES( '{value.FirstName}' ,'{value.LastName}','{value.Slary}','{value.Born}')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int row = cmd.ExecuteNonQuery();
                    return Get();
                }
            }
            catch (SqlException ex) { return BadRequest(ex.Message); }

            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // PUT: api/Teacher/5
        public IHttpActionResult Put(int id, [FromBody] Teacher value)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Stringconction))
                {
                    conn.Open();

                    string Putquery = $@"UPDATE Teacher
                                        SET FirstName='{value.FirstName}',LastName='{value.LastName}',Slary='{value.Slary}',Born='{value.Born}'
                                        WHERE Id={id}";
                    SqlCommand cmd = new SqlCommand(Putquery,conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    return Ok("UPDATE SUCCESSFUL");
                }

            }
            catch (SqlException ex) { return BadRequest(ex.Message); }

            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        // DELETE: api/Teacher/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Stringconction))
                {
                    conn.Open();
                    string Deletequery = $@"DELETE FROM Teacher WHERE Id={id}";

                    SqlCommand cmd = new SqlCommand(Deletequery, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();

                    return Ok(Get());
                }

            }
            catch (SqlException ex) { return BadRequest(ex.Message); }

            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
