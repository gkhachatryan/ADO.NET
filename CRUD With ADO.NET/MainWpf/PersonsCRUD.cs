using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace MainWpf
{
    class PersonsCRUD
    {
        public List<Person> GetAllPersons()
        {
            string c = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\PC\Documents\Visual Studio 2013\Projects\BetConstruct\MainWpf\MainWpf\PersonsDatabase.mdf; Integrated Security=True";

            List<Person> persons = new List<Person>();

            using (SqlConnection connection = new SqlConnection(c))
            {

                connection.Open();
                // Console.WriteLine(connection.State);

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


        public Person GetByID(int id)
        {
            Person person = null;

            string c = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\PC\Documents\Visual Studio 2013\Projects\BetConstruct\MainWpf\MainWpf\PersonsDatabase.mdf; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(c))
            {
                connection.Open();

                SqlDataReader reader = null;

                SqlCommand command = new SqlCommand("SELECT * FROM Person where Id=@id", connection);

                command.Parameters.AddWithValue("id", id);

                try
                {
                    reader = command.ExecuteReader();
                    reader.Read();
                    person = new Person()
                    {
                        Id = (int)reader[0],
                        FName = reader[1].ToString(),
                        LName = reader[2].ToString(),
                        Phone = (int)reader[3]
                    };
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }

                return person;
            }
        }


        public void Update(Person person)
        {
            string c = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\PC\Documents\Visual Studio 2013\Projects\BetConstruct\MainWpf\MainWpf\PersonsDatabase.mdf; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(c))
            {
                SqlCommand command = new SqlCommand("Update Person Set FName=@FName, LName=@LName, Phone=@Phone where Id=@id", connection);

                command.Parameters.AddWithValue("id", person.Id);

                command.Parameters.AddWithValue("FName", person.FName);

                command.Parameters.AddWithValue("LName", person.LName);

                command.Parameters.AddWithValue("Phone", person.Phone);

                connection.Open();

                command.ExecuteNonQuery();
            }

        }

        public void Delete(int id)
        {
            string c = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\PC\Documents\Visual Studio 2013\Projects\BetConstruct\MainWpf\MainWpf\PersonsDatabase.mdf; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(c))
            {
                SqlCommand command = new SqlCommand("Delete from Person where Id = @id", connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Add(Person person)
        {
            string c = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\PC\Documents\Visual Studio 2013\Projects\BetConstruct\MainWpf\MainWpf\PersonsDatabase.mdf; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(c))
            {
                SqlCommand command = new SqlCommand("Insert into Person (FName, LName, Phone) values (@FName, @LName, @Phone) ", connection);

                command.Parameters.AddWithValue("FName", person.FName);

                command.Parameters.AddWithValue("LName", person.LName);

                command.Parameters.AddWithValue("Phone", person.Phone);

                connection.Open();

                command.ExecuteNonQuery();
            }

        }
    }
}
