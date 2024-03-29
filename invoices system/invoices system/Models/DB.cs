﻿using invoices_system.Pages;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

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

            string Q = " select workerPassword  from Worker where userName ='" + W.userName+"' ";

            
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


      

        /// <summary>
        /// this function display some data about the last invoices created by this accountant 
        /// </summary>
        /// <returns></returns>
        public DataTable  displyInvoicedata(string id)
        {

            string Q = "  select invoiceType,invoiceID,invoiceStatus from Invoice I , Works_On wo,Project p,Worker W where W.workerID=wo.workerID and wo.projectID=p.projectID and I.projectID=p.projectID and W.workerID='" + id+"'";
            return FuncExecuteReadr(Q);
        }
        public void AddNewWorker(Worker W)
        {
            string Q = "insert into Worker values('"+W.workerName+"','"+W.workerID+"','"+W.phoneNumber+"','"+W.userName+"','"+W.workerPassword+"','"+W.roleID+"') ";
            FuncExecuteNonQuery(Q);
        }
        public DataTable GetAllWorkers()
        {
            string Q = " select   W.workerName,W.userName,p.projectName from Worker W,Works_On Wo,project p where W.workerID=Wo.workerID and Wo.projectID=p.projectID    ";
            return FuncExecuteReadr(Q);
        }
        public void  EditWorker(string workername ,Worker W)
        {

            string Q = "    update Worker set userName='"+W.userName+"' , workerName='"+W.workerName+"',roleID='"+W.roleID+"' where userName='"+ workername + "'  ";
            FuncExecuteNonQuery(Q);


        }
        public string get_worker_id(string username)
        {
            string Q = "select workerID from Worker W where W.userName='" + username + "'";
            return FuncExecuteStringScaler(Q);
        }

        public DataTable getAccountantAllInvoices(string AcID)
        {

            string Q = "  select invoiceType,startDate,invoiceStatus,contractorName,endDate,invoiceID from Invoice,Worker where workerID='" + AcID + "'";
            return FuncExecuteReadr(Q);
        }

        public void CreateNewTable(Statment S)
        {
            string Q = "insert into Statements (Statements,Unit,currentQuantities,categoryValue) values '" + S.Statements + "'";
        }
        public DataTable getProjectData(string workerid)
        {
            string Q = "select P.projectName,P.projectID,pl.projectLocation,WorkerName from Project P ,Project_Location pl,Worker w where  W.workerID='"+workerid+"' and pl.projectID=p.projectID and  P.projectID in (select W.projectID from Works_On W where W.workerID='" + workerid + "')";
            return FuncExecuteReadr(Q);
        }

        public void insertIntoInvoice(Statment S,Invoice i)
        {
            string QI = "  insert into Invoice (contractorName , startDate ,invoiceType ,  Elta3lya , projectID ,invoiceID )values('\" + i.contractorName + \"','\" + i.startDate + \"','\" + i.invoiceType + \"','\" + i.Elta3lya + \"','\" + i.projectID + \"','\" + i.invoiceID + \"')";
               FuncExecuteNonQuery(QI);

            string Q = " insert into Statements (Statements,Unit,currentQuantities,categoryValue,invoiceID) values ('" + S.Statements + "' '"+S.Unit+ "' '" + S.currentQuantities + "' '"+S.invoiceID+"' )";
             FuncExecuteNonQuery(Q);
        }

        public DataTable selectallDataOfInvoice(string invoiceId )
        {
            string Q = "\r\n select     I.contractorName,\r\n\t\t    I.projectID   ,    \r\n\t\t    I.startDate    ,   \r\n\t\t    I.endDate     ,  \r\n\t\t    I.invoiceType  , \r\n\t\t    I.invoiceID     ,\r\n\t\t    I.TotaL         ,\r\n\t\t    I.Elta3lya      ,\r\n\t\t\tI.invoiceStatus  , \r\n\t\t\ts.Statements,s.Unit,s.previousQuantities,s.currentQuantities,s.totalQuantities,s.categoryValue,s.currentValue,s.totalQuantities\r\n\t\t\t,Wc.Deduction,wc.Loan,wc.SarfElta3lya\r\n\t\t\tfrom invoice I,Statements s,Weekly_Cost Wc\r\n\t\t\twhere I.invoiceID='" + invoiceId + "'";
            return FuncExecuteReadr(Q);
        }
        public void AddNewProject(Project P)
        {
            string Q = "insert into Project values('"+P.projectName+"','"+P.projectID+"','"+P.startDate+"','"+P.endDate+"');";
            FuncExecuteNonQuery(Q);
        }
        public DataTable getAllProjects()
        {
            string Q = "   select * from Project       ";
            return FuncExecuteReadr(Q);
        }
        public DataTable getAllW()
        {
            string Q = "   select * from Worker       ";
            return FuncExecuteReadr(Q);
        }
    }
}
