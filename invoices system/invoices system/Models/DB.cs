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
            string constring = "Data Source=LAPTOP-5TUKEHTJ\\ELSHAHED;Initial Catalog=\"Invoices System\";Integrated Security=True";
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
        public void approveInvoice(string invoiceID)
        {
            string Q = "  update Invoice set invoiceStatus='approved' where invoiceID='"+ invoiceID + "'   ";
            FuncExecuteNonQuery(Q);
        }
        public void StopInvoice(string invoiceID)
        {
            string Q = "  update Invoice set invoiceStatus='stoped' where invoiceID='" + invoiceID + "'   ";
            FuncExecuteNonQuery(Q);
        }
        public DataTable getSelectedProjects()//PM
        {

            string Q = "   select projectName,p.projectID,projectLocation from Project p ,Project_Location pl where p.projectID=pl.projectID ";
            return FuncExecuteReadr(Q);
        }
        public DataTable getSelectedProjectsData(string PID)//PM
        {

            string Q = "   select projectName,p.projectID,projectLocation from Project p ,Project_Location pl where p.projectID=pl.projectID and p.projectID='"+PID+"' ";
            return FuncExecuteReadr(Q);
        }
        public DataTable getS_Project_current_Invoices(string PID)//PM
        {

            string Q = "  select invoiceID,invoiceType,startDate,invoiceStatus,contractorName,endDate from Invoice where projectID='"+PID+"'                      ";
            return FuncExecuteReadr(Q);
        }
        public string getS_Project_AC(string PID)//PM
        {

            string Q = "  select workerName from Worker w where w.workerID=(select w.workerID from Works_On wo , Worker w where wo.workerID=w.workerID  and w.roleID='AC' and wo.projectID='"+PID+"')                     ";
            return FuncExecuteStringScaler(Q);
		}

        public string getS_Project_PM(string PID)//PM
        {

            string Q = "  select workerName from Worker w where w.workerID=(select w.workerID from Works_On wo , Worker w where wo.workerID=w.workerID  and w.roleID='PM' and wo.projectID='" + PID + "')                     ";
            return FuncExecuteStringScaler(Q);
        }
        public string getS_Project_SE(string PID)//PM
        {

            string Q = "  select workerName from Worker w where w.workerID=(select w.workerID from Works_On wo , Worker w where wo.workerID=w.workerID  and w.roleID='SE' and wo.projectID='" + PID + "')                     ";
            return FuncExecuteStringScaler(Q);
        }
        public DataTable getWorkerInfo(string WorkeruserName)//PM
        {

            string Q = "  select * from Worker where userName='"+ WorkeruserName + "'              ";
            return FuncExecuteReadr(Q);
        }
        public void UpdateWorkerPassword(string Workerpassword,string WorkerUname)
        {
            string Q = "    Update Worker set workerPassword='"+ Workerpassword + "' where userName='"+ WorkerUname + "'       ";
            FuncExecuteNonQuery(Q);
        }
        public DataTable getS_All_Invoices()//PM
        {

            string Q = "  select invoiceID,invoiceType,startDate,invoiceStatus,contractorName,endDate from Invoice                      ";
            return FuncExecuteReadr(Q);
        }
    }
}
