using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8AssignmentP1
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string constr = "server=DESKTOP-0GDER0O;database=Day8AssignmentDb;trusted_connection=true";
        static void Main(string[] args)
        {
            try 
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = "select * from Products order by PId desc"
                };
                con.Open();
                reader = cmd.ExecuteReader();
                Console.WriteLine("ID \t Name \t Price \t Manufacturing Date \t Expirydate");
                while (reader.Read())
                {
                    Console.Write(reader[0] + "\t");
                    Console.Write(reader[1] + "\t");
                    Console.Write(reader[2] + "\t");
                    Console.Write(reader[3]);
                    Console.Write("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error"+ex.Message);
            }
            finally 
            {
                con.Close();
            }
        }
    }
}
