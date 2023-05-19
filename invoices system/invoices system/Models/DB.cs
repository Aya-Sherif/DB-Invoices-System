using System.Data;
using System.Data.SqlClient;

namespace invoices_system.Models
{
    public class DB
    {
        public int Scaler { get; set; }
        public string StringScaler { get; set; }
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
                Scaler= (int)cmd.ExecuteScalar();
            }
            catch (Exception ex) { }
            finally { con.Close(); }


            return  Scaler;
        }
        private string FuncExecuteStringScaler(string Q)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                StringScaler = (string)cmd.ExecuteScalar();
            }
            catch (Exception ex) { }
            finally { con.Close(); }


            return StringScaler;
        }
        public string GetWorkerRoleID(Worker W)//to get the role id that determine user page
        {
            string Q = " select roleID from Worker where userName ='"+W.userName+"' ";
            return FuncExecuteStringScaler(Q);

        }

        public bool CheckPassword(Worker W)// this func match username and password
        {

            string Q = " select workerPassword from Worker where userName ='"+W.userName+"' ";
            StringScaler = FuncExecuteStringScaler(Q);
            if (StringScaler == W.workerPassword)
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
