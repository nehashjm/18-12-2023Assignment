using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day8AssignmentP2
{
    internal class Program
    {
        static DataTable create()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Pid",typeof(int));  
            dt.Columns.Add("PName",typeof(string));
            dt.Columns.Add("PPrice",typeof(float));
            dt.Columns.Add("MfgDate",typeof(DateTime));
            dt.Columns.Add("ExpDate",typeof (DateTime));
            dt.PrimaryKey = new DataColumn[] { dt.Columns["Pid"] };
            return dt;
        }
        static void Insert(DataTable dt,int id,string name,float price,DateTime mdate,DateTime edate)
        {
            DataRow dr = dt.NewRow();
            dr["Pid"] = id;
            dr["PName"] = name;
            dr["PPrice"] = price;
            dr["MfgDate"]= mdate;
            dr["ExpDate"]= edate;
            dt.Rows.Add(dr);
           // Console.WriteLine("Record inserted");
        }
        static void Search(DataTable dt,int id)
        {
            DataRow foundRow=dt.Rows.Find(id);
            if(foundRow == null) 
            {
                Console.WriteLine("no such id exists");
            }
            else
            {
                Console.WriteLine("record found details as follws");
                Console.WriteLine($"Product id \t {foundRow["Pid"]}");
                Console.WriteLine($"Product Name \t {foundRow["PName"]}");
                Console.WriteLine($"Product Price \t {foundRow["PPrice"]}");
                Console.WriteLine($"Product Name \t {foundRow["MfgDate"]}");
                Console.WriteLine($"Product Name \t {foundRow["ExpDate"]}");
            }
        }
        static void Delete(DataTable dt,int id)
        {
            DataRow delRow = dt.Rows.Find(id);
            if (delRow == null)
            {
                Console.WriteLine("no such id exists");
            }
            else
            {
                dt.Rows.Remove(delRow);
                Console.WriteLine("Record deleted from table");
            }
        }
        static void Update(DataTable dt, int id, string name, float price, DateTime mdate, DateTime edate)
        {
            DataRow updateRow = dt.Rows.Find(id);
            if(updateRow != null)
            {
                updateRow["PName"] = name;
                updateRow["PPrice"] = price;
                updateRow["MfgDate"] = mdate;
                updateRow["ExpDate"] = edate;

            }
            else
            {
                Console.WriteLine("no such id exists");
            }
        }
        static void Display(DataTable dt)
        {
            Console.WriteLine("stored data in table ");
            foreach (DataRow row in dt.Rows)
            {
                Console.Write("Product Id "+ row["PId"]);
                Console.Write("Product Name" + row["PName"]);
                Console.Write("Product Price " + row["PPrice"]);
                Console.Write("manufacture Date" + row["MfgDate"]);
                Console.Write("expiry Date " + row["ExpDate"]);
                Console.WriteLine("\n");
            }
        }
            static void Main(string[] args)
        {
            DataTable dt = create();
            string ch;
            int choice;
            do
            {
                Console.WriteLine("Enter choice 1 insert \t 2 delete \t 3 update \t 4 search ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            //DataTable dt = create();
                            Console.WriteLine("Enter id to insert");
                            int iid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter name of product");
                            string iname = Console.ReadLine();
                            Console.WriteLine("Enter Price of Product");
                            float pprice = float.Parse(Console.ReadLine());
                            Console.WriteLine("ebter manufacture date");
                            DateTime imfg = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("ebter expiry date");
                            DateTime iefg = DateTime.Parse(Console.ReadLine());
                            Insert(dt, iid, iname, pprice, imfg, iefg);
                            Console.WriteLine("record inserted");
                            Display(dt);
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Insert(dt, 101, "monitor", 2000, new DateTime(day: 26, month: 11, year: 2019), new DateTime(day: 27, month: 11, year: 2019));
                            Insert(dt, 102, "tv", 3000, new DateTime(day: 06, month: 12, year: 2018), new DateTime(day: 16, month: 10, year: 2018));
                            Display(dt);
                            Console.WriteLine("enter id to delete ");
                            int deleteid = int.Parse(Console.ReadLine());
                            Delete(dt, deleteid);
                            Display(dt);
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Insert(dt, 101, "monitor", 2000, new DateTime(day: 26, month: 11, year: 2019), new DateTime(day: 26, month: 11, year: 2019));
                            Insert(dt, 102, "tv", 3000, new DateTime(day: 06, month: 12, year: 2018), new DateTime(day: 16, month: 10, year: 2018));
                            Display(dt);
                            Console.WriteLine("Enter id to update ");
                            int iid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter name of product");
                            string iname = Console.ReadLine();
                            Console.WriteLine("Enter Price of Product");
                            float pprice = float.Parse(Console.ReadLine());
                            Console.WriteLine("ebter manufacture date");
                            DateTime imfg = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("ebter expiry date");
                            DateTime iefg = DateTime.Parse(Console.ReadLine());
                            Update(dt, iid, iname, pprice, imfg, iefg);
                            Console.WriteLine("record inserted");
                            Display(dt);
                            break;
                        }
                    case 4:
                        {
                            Display(dt);
                            Console.WriteLine("Enter ID to search the Data Row");
                            int sid = int.Parse(Console.ReadLine());
                            Search(dt, sid);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("program end");

                            break;
                        }
                }
                Console.WriteLine("choose you want to continue");
                ch = Console.ReadLine();
            } while (ch == "y");
        }
    }
}
