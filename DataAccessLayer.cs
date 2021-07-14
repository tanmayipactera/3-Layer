using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using System.Data.SqlClient;
using System.Configuration;
using BELayer;



namespace DataAccess
{
    public class DataAccessLayer
    {

        public string conn = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        SqlConnection con = new SqlConnection();





        public int AffectedInsert(BEL beobj)
        {
            con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertAffected", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_code", beobj._emp_code);
            cmd.Parameters.AddWithValue("@Recovery_Duration", beobj._Recovery_Duration);
           
            //if (beobj._Family_Members_Affected)
            //{
           cmd.Parameters.AddWithValue("@Family_Members_Affected", beobj._Family_Members_Affected);
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@Family_Members_Affected", beobj._Family_Members_Affected);
            //}

            cmd.Parameters.AddWithValue("@Family_Members_Relation", beobj._Family_Members_Relation);
            cmd.Parameters.AddWithValue("@Family_Members_Name",beobj._Family_Members_Name);

            int i = cmd.ExecuteNonQuery();

            return i;

            
        }

        public int UpdateAffected(BEL beobj)
        {
            con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateAffected", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_code", beobj._emp_code);
            cmd.Parameters.AddWithValue("@Recovery_Duration", beobj._Recovery_Duration);

            //if (beobj._Family_Members_Affected)
            //{
            cmd.Parameters.AddWithValue("@Family_Members_Affected", beobj._Family_Members_Affected);
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@Family_Members_Affected", beobj._Family_Members_Affected);
            //}

            cmd.Parameters.AddWithValue("@Family_Members_Relation", beobj._Family_Members_Relation);
            cmd.Parameters.AddWithValue("@Family_Members_Name", beobj._Family_Members_Name);

            int i = cmd.ExecuteNonQuery();

            return i;
        }

        public int VaccintedInsert(Vaccinated va)
        {
            con = new SqlConnection(conn);
            con.Open();

            SqlCommand cmd = new SqlCommand("InsertVaccinated", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_code", va.emp_code);
            cmd.Parameters.AddWithValue("@Vaccine_Type", va.Vaccine_Type);
            cmd.Parameters.AddWithValue("@Dose_No", va.Dose_No);
            cmd.Parameters.AddWithValue("@Vaccine_Date", va.Vaccine_Date);
            cmd.Parameters.AddWithValue("@Vaccine_Location", va.Vaccine_Location);
            cmd.Parameters.AddWithValue("@Vaccine_Certificate", va.Vaccine_Certificate);

            int result = cmd.ExecuteNonQuery();

            return result;

        }




        public DataSet Read1( EmployeeData employeeData)
        {
            con = new SqlConnection(conn);
            con.Open();
            
            SqlCommand cmd = new SqlCommand("GetAllEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //SqlDataReader rd = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            //ds.(rd);
            //return dt;
            sda.Fill(ds);
            return ds;

            //DataTable dt = new DataTable();

        }


        public DataSet Load(BEL beobj)
        {
            con = new SqlConnection(conn);
            con.Open();

            SqlCommand cmd = new SqlCommand("GetAllAffected", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //SqlDataReader rd = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            //ds.(rd);
            //return dt;
            sda.Fill(ds);
            return ds;


        }
    }
}
