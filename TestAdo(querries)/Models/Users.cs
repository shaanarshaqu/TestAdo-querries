using System.Data.SqlClient;
using System.Xml.Linq;
using TestAdo_querries_.Interfaces;

namespace TestAdo_querries_.Models
{
    public class Users:IUsers
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public Users(IConfiguration configuration) 
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        }


        public List<UserDTO> DisplayUsers()
        {
            List<UserDTO> userslist = new List<UserDTO>();
            using(SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();
                using(SqlCommand command = new SqlCommand("select * from UserDetails", connect))
                {
                    SqlDataReader Read = command.ExecuteReader();
                    while (Read.Read())
                    {
                        userslist.Add(new UserDTO()
                        {
                            Id = Convert.ToInt32(Read["Id"].ToString()),
                            Name = Read["Name"].ToString(),
                            Qual_Id = Convert.ToInt32(Read["Qual_Id"].ToString())
                        });
                    }
                }
            }

            using(SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();
                using(SqlCommand command = new SqlCommand("select * from UserDetails", connect))
                {
                    SqlDataReader Read = command.ExecuteReader();
                    while (Read.Read())
                    {
                        userslist.Add(new UserDTO()
                        {
                            Id = Convert.ToInt32(Read["Id"].ToString()),
                            Name = Read["Name"].ToString(),
                            Qual_Id = Convert.ToInt32(Read["Qual_Id"].ToString())
                        });
                    }
                }
            }

            return userslist;
        }



        public string AddUser(UserDTO user)
        {
            using(SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("insert into UserDetails values (@name,@quId)",connect);
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@quId", user.Qual_Id);
                int result = cmd.ExecuteNonQuery();
                return $"{result} effect";
            }
        }

    }
}
