using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Assignment_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connection = @"Data Source=INLPF3KTP43\MSSQLSERVER1;Initial Catalog=mukesh;trusted_connection=true";
                SqlConnection con = new SqlConnection(connection);
                con.Open();

                Console.WriteLine("Enter The Choice");
                string choice = Console.ReadLine();

                string query = @"select Horror_movies,Kids_movies from Movies ";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    if (i == 5) break;

                    switch (choice)
                    {
                        case "horror":
                            {

                                Console.Write(reader[0]);

                            }
                            break;
                        case "kids":
                            {

                                Console.WriteLine(reader[1]);
                            }
                            break;
                    }
                    i++;
                    Console.WriteLine();
                }
                reader.Close();
                con.Close();
            }
            catch (SqlException exp)
            {
                Console.WriteLine(exp.Message);
                Console.WriteLine("Sql related Problem");
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
                Console.WriteLine("C-Sharp Related problem");
            }
        }
    }
}