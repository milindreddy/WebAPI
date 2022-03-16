using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService2;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Art> GetArts()





        {
            var emp = new List<Art>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\WcfService2\WcfService2\App_Data\Database1.mdf");
            SqlCommand cmd = new SqlCommand("SELECT * from Art", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Art obj = new Art();
                    obj.ArtId = reader.GetInt32(0);
                    obj.Artist = reader.GetString(1);
                    obj.Style = reader.GetString(2);
                    obj.Title = reader.GetString(3);
                    obj.Price = reader.GetInt32(4);
                    obj.Buyer = reader.GetString(5);
                    obj.Location = reader.GetString(6);


                    emp.Add(obj);
                }







            }
            else
            {








            }







            reader.Close();
            return emp;
        }







        public Art GetArtById(string ArtId)
        {
            Art obj1 = new Art();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\WcfService2\WcfService2\App_Data\Database1.mdf");
            SqlCommand comd = new SqlCommand("SELECT ArtId,Artist,Style,Title,Price,Buyer,Location FROM Art " +
                "WHERE ArtId=" +
                Convert.ToInt32(ArtId) +
                ";", conn);







            conn.Open();
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    obj1.ArtId = reader.GetInt32(0);
                    obj1.Artist = reader.GetString(1);
                    obj1.Style = reader.GetString(2);
                    obj1.Title = reader.GetString(3);
                    obj1.Price = reader.GetInt32(4);
                    obj1.Buyer = reader.GetString(5);
                    obj1.Location = reader.GetString(6);
                }
            }
            else
            {
                // No rows found
            }
            reader.Close();
            return obj1;
        }





        public string UpdateArt(string ArtId, string Buyer)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\WcfService2\WcfService2\App_Data\Database1.mdf");
            SqlCommand cmd = con1.CreateCommand();
            cmd.CommandText = "Update Art SET Buyer='" + Buyer
            + "' WHERE ArtId=" + Convert.ToInt32(ArtId);
            con1.Open();
            cmd.ExecuteNonQuery();
            con1.Close();
            return "Updated Successfully";





        }





        public string Add(string ArtId, string Artist, string Style, string Title, string Price, string Buyer, string Location)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\WcfService2\WcfService2\App_Data\Database1.mdf");
            cnn.Open();
            string query = "INSERT into Art(ArtId,Artist,Style,Title,Price,Buyer,Location) values ('" + Convert.ToInt32(ArtId) + "','" + Artist + "','" + Style + "','" + Title + "','" + Convert.ToInt32(Price) + "','" + Buyer + "','" + Location + "')";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            return "Successful";
        }
        public string DeleteArt(string ArtId)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\WcfService2\WcfService2\App_Data\Database1.mdf");
            SqlCommand cmd = con1.CreateCommand();
            cmd.CommandText = "Delete from Art where ArtId=" + Convert.ToInt32(ArtId);
            con1.Open();
            cmd.ExecuteNonQuery();
            con1.Close();
            return "Deleted Successfully";



        }
    }
}
