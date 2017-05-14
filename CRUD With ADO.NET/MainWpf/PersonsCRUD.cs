using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MainWpf
{
    class PersonsCRUD
    {
        public List<Person> GetAllPersons()
        {
            string c = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\PC\Documents\Visual Studio 2013\Projects\BetConstruct\LocalDB\LocalDB\LocalDB.mdf; Integrated Security=True";
            List<Person> persons = new List<Person>();

            using (SqlConnection connection = new SqlConnection(c))
            {

                connection.Open();
                Console.WriteLine(connection.State);

                SqlDataReader reader = null;

                SqlCommand command = new SqlCommand("SELECT * FROM Person", connection);
                try
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Person per = new Person()
                        {
                            Id = (int)reader[0],
                            FName = reader[1].ToString(),
                            LName = reader[2].ToString(),
                            Phone = (int)reader[3]
                        };
                        persons.Add(per);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    reader.Close();
                }
            }

            return persons;
        }
    }
}
