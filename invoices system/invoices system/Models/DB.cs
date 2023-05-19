﻿using System.Data;
using System.Data.SqlClient;

namespace invoices_system.Models
{
    public class DB
    {
        public int int_Scaler { get; set; }
        public string String_Scaler { get; set; }
        SqlConnection con = new SqlConnection();
        public DB()
        {
            string constring = "Data Source=DESKTOP-VF3J892\\MSSQLSERVER01;Initial Catalog=Invoices_System;Integrated Security=True";
            con = new SqlConnection(constring);
        }
        private DataTable FuncExecuteReadr(string Q)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex) { }
            finally { con.Close(); }


            return dt;
        }

        private void FuncExecuteNonQuery(string Q)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex) { }
            finally { con.Close(); }

        }

        private int  FuncExecuteScaler(string Q)
        {
            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                int_Scaler= (int)cmd.ExecuteScalar();
            }
            catch (Exception ex) { }
            finally { con.Close(); }


            return  int_Scaler;
        }
        private string FuncExecuteStringScaler(string Q)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                String_Scaler = (string)cmd.ExecuteScalar();
            }
            catch (Exception ex) { }
            finally { con.Close(); }


            return String_Scaler;
        }
        public string GetWorkerRoleID(Worker W)//to get the role id that determine user page
        {
            string Q = " select roleID from Worker where userName ='"+W.userName+"' ";
            String_Scaler= FuncExecuteStringScaler(Q);
            return String_Scaler;

        }

        public bool CheckPassword(Worker W)// this func match username and password
        {

            string Q = " select workerPassword from Worker where userName ='"+W.userName+"' ";

            
            String_Scaler = FuncExecuteStringScaler(Q);
            if (String_Scaler == W.workerPassword)
            {
                return true;
            }

            else
            {
                return false;
            }

        }




    }
}