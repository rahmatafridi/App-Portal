using System;
using System.Data;
using System.Data.SqlClient ; //for data
using System.Web.Configuration;

using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text ;
using System.Collections;//System.Collections for Hashtable!


namespace DSP.DAL
{

/// <summary>
/// Summary description for Server
/// </summary>
/// 
public static class SQL
{ 

    #region "## Properties - "
     

    #endregion
     

    #region "## Database Functions - Connect() "

        //#############################################################   
        // Connect()  
        //-------------------------------------------------------------   
        //Description:   Connect to the database using web.config string
        //           :   
        //Date       :   03/09/2009,
        //Authors    :   Yasar Qayyum 
        //Inputs     :   None
        //Outputs    :   None
        //#############################################################   
        private static void Connect(ref SqlConnection objConnection)
        {
            string strConnect = "";
            try
            {
                strConnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                objConnection = new SqlConnection(strConnect);
                if (objConnection != null && objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }
            }
            catch (Exception exx)
            {
               
                strConnect = "";
                objConnection = null;
            }
            finally
            {

            }
        }
        private static void QCSConnect(ref SqlConnection objConnection)
        {
            string strConnect = "";
            try
            {
                strConnect = ConfigurationManager.ConnectionStrings["QMS2_3132014Context"].ConnectionString;
                objConnection = new SqlConnection(strConnect);
                if (objConnection != null && objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }
            }
            catch (Exception exx)
            {
                //UtilityFunctions.CreateTextFile("DataAccessFunctions_Connect", "ConnectionString:" + strConnect + "\nException:" + exx.Message);
                // System.Diagnostics.Trace.Write("DataAccessFunctions_Connect", "ConnectionString:" + strConnect + "\nException:" + exx.Message);

                strConnect = "";
                objConnection = null;
            }
            finally
            {

            }
        }
        #endregion


    #region "   DB | Disconnect()"
        //#############################################################   
        // Disconnect()  
        //-------------------------------------------------------------   
        //Description:   Disconnect from the database  
        //           :   
        //Date       :   03/09/2009,
        //Authors    :   Yasar Qayyum,  
        //Inputs     :   None
        //Outputs    :   None
        //#############################################################   
        private static void Disconnect(SqlConnection objConnection)
        {
            if (objConnection != null)
                objConnection.Close();
        }
        #endregion
    
      
    #region "## Database Functions -   "


    public static bool ExecuteSQL(string strSQL)
    {
        SqlConnection objConnection = new SqlConnection();
        try
        {
            Connect(ref objConnection);
            SqlCommand dbComm = new SqlCommand(strSQL, objConnection);
            dbComm.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
           // UtilityFunctions.CreateTextFile("ExecuteSQLException_" + System.DateTime.Now.Millisecond, "Following query was passed which generated an exception:<br/>" + strSQL + "<br/>The following exception occured:<br/>" + ex.Message);
            DSP.BAL.Log.WriteLogTxt(String.Format("ExecuteSQLException_" + System.DateTime.Now.Millisecond, "Following query was passed which generated an exception:<br/>" + strSQL + "<br/>The following exception occured:<br/>" + ex.Message));
        }
        finally
        {
            Disconnect(objConnection);

        }
        return false;
    }

    public static void ExecuteQCSSQL(string strSQL)
    {
        SqlConnection objConnection = new SqlConnection();
        try
        {
            QCSConnect(ref objConnection);
            SqlCommand dbComm = new SqlCommand(strSQL, objConnection);
            dbComm.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // UtilityFunctions.CreateTextFile("ExecuteSQLException_" + System.DateTime.Now.Millisecond, "Following query was passed which generated an exception:<br/>" + strSQL + "<br/>The following exception occured:<br/>" + ex.Message);
        }
        finally
        {
            Disconnect(objConnection);
        }
    }
    public static bool ExecuteSPByHashTable(string spName, Hashtable htHashTable)
        {
            SqlConnection objConnection = new SqlConnection();
            bool bReturn = true;
            if ((spName == ""))
            {
                return false;
            }
            string MySP = spName;
            if (objConnection.State != ConnectionState.Open)
            {
                Connect(ref objConnection);
            }
            SqlCommand cmd = new SqlCommand(MySP, objConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (DictionaryEntry entry in htHashTable)
            {

                switch (entry.Value.GetType().ToString())
                {
                    case "System.String":
                        cmd.Parameters.Add(new SqlParameter(entry.Key.ToString(), entry.Value.ToString()));
                        break;
                    case "System.DateTime":
                        cmd.Parameters.Add(new SqlParameter(entry.Key.ToString(), Convert.ToDateTime(entry.Value.ToString())));
                        break;
                    case "System.Int32":
                        cmd.Parameters.Add(new SqlParameter(entry.Key.ToString(), Int32.Parse(entry.Value.ToString())));
                        break;
                    case "System.Boolean":
                        cmd.Parameters.Add(new SqlParameter(entry.Key.ToString(), Convert.ToBoolean(entry.Value.ToString())));
                        break;
                    case "System.Byte[]":
                        int ilength = entry.Value.ToString().Length;
                       // cmd.Parameters.Add(new SqlParameter(entry.Key.ToString(), SqlDbType.VarBinary, entry.Value));

                        //cmd.Parameters.Add(entry.Key.ToString(), SqlDbType.VarBinary, ilength).Value = entry.Value.ToString();
                        SqlParameter param = cmd.Parameters.Add(entry.Key.ToString(), SqlDbType.VarBinary);
                        param.Value = entry.Value;

                        break;
                    default:
                        cmd.Parameters.Add(new SqlParameter(entry.Key.ToString(), entry.Value.ToString()));
                        break;
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
                //bReturn = true;
            }

            catch (Exception ex)
            {
                 bReturn = false;
            }
            finally
            {
                Disconnect(objConnection);
            }

            return bReturn;


     }


    public  static DataSet GetDsBySP(string spName)
     {
         SqlConnection objConnection = new SqlConnection();
           
         string MySP = spName;
         if (objConnection.State != ConnectionState.Open)
         {
             Connect(ref objConnection);
         }

         SqlCommand cmd = new SqlCommand(MySP, objConnection);
         cmd.CommandType = CommandType.StoredProcedure;

         DataSet ds = new DataSet();

        
         SqlDataAdapter adpt = new SqlDataAdapter(cmd);
         try
         {
             adpt.Fill(ds, "SPs");
         }
         catch (SqlException ex)
         {
            
             ds = null;
         }
         finally
         {
             Disconnect(objConnection);
         }
       
         
         return ds;
     }
    
    public static DataSet GetDsBySP(string spName, string iParamName, int iParamValue)
    {


        SqlConnection objConnection = new SqlConnection();
         
         string MySP = spName;
         if (objConnection.State != ConnectionState.Open)
         {
             Connect(ref objConnection);
         }
         SqlCommand cmd = new SqlCommand(MySP, objConnection);
         cmd.CommandType = CommandType.StoredProcedure;

         DataSet ds = new DataSet();

         if (!string.IsNullOrEmpty(iParamName))
         {
             cmd.Parameters.Add(new SqlParameter(iParamName, iParamValue));
         }
         SqlDataAdapter adpt = new SqlDataAdapter(cmd);
         try
         {
             adpt.Fill(ds, "SPs");
         }
         catch (SqlException ex)
         {
            
             ds = null;
         }
         finally
         {
             Disconnect(objConnection);
         }
         


         return ds;
     }

    public static DataSet GetDsBySP(string spName, string sParamName, string sParamValue)
     {


         SqlConnection objConnection = new SqlConnection();
       
         string MySP = spName;
         if (objConnection.State != ConnectionState.Open)
         {
             Connect(ref objConnection);
         }
         SqlCommand cmd = new SqlCommand(MySP, objConnection);
         cmd.CommandType = CommandType.StoredProcedure;

         DataSet ds = new DataSet();

         if (!string.IsNullOrEmpty(sParamName))
         {
             cmd.Parameters.Add(new SqlParameter(sParamName, sParamValue));
         }
         SqlDataAdapter adpt = new SqlDataAdapter(cmd);
         try
         {
             adpt.Fill(ds, "SPs");
         }
         catch (SqlException ex)
         {
             //Disconnect(objConnection); 
             ds = null;
         }
         finally
         {
             Disconnect(objConnection);
         }


         return ds;
     }
     

    public static int ExecuteScalar(string strSQL)
     {
         SqlConnection objConnection = new SqlConnection();
         Connect(ref objConnection);
         int id = 0;
         try
         {
             SqlCommand dbComm = new SqlCommand(strSQL, objConnection);
             id = Convert.ToInt32(dbComm.ExecuteScalar());
         }
         catch (Exception ex1)
         {
         }
         finally
         {
             Disconnect(objConnection);
         }
         return id;
     }
    
    public static DataSet GetRecordsBySQL(string strSQL)
     {
         DataSet ds = new DataSet();
         SqlConnection objConnection = new SqlConnection();
         if ((string.IsNullOrEmpty(strSQL)))
         {
             return null;
         }
         else
         {
             try
             {
                 if (objConnection.State != ConnectionState.Open)
                 {
                     Connect(ref objConnection);
                 }
                 SqlDataAdapter DBCommand = new SqlDataAdapter(strSQL, objConnection);
                 DBCommand.Fill(ds);
             }
             catch (Exception ex)
             {
                 throw;
               //  UtilityFunctions.CreateTextFile("DataAccessFunctions_GetRecordsBySQL_" + System.DateTime.Now.Millisecond, "SQL:\n" + strSQL + "\nException:" + ex.Message);
             }
             finally
             {
                 Disconnect(objConnection);
             }
               
             return ds;
         }

     }
    public static DataSet GetRecordsByQCSSQL(string strSQL)
    {
        DataSet ds = new DataSet();
        SqlConnection objConnection = new SqlConnection();
        if ((string.IsNullOrEmpty(strSQL)))
        {
            return null;
        }
        else
        {
            try
            {
                if (objConnection.State != ConnectionState.Open)
                {
                    QCSConnect(ref objConnection);
                }
                SqlDataAdapter DBCommand = new SqlDataAdapter(strSQL, objConnection);
                DBCommand.Fill(ds);
            }
            catch (Exception ex)
            {
                //  UtilityFunctions.CreateTextFile("DataAccessFunctions_GetRecordsBySQL_" + System.DateTime.Now.Millisecond, "SQL:\n" + strSQL + "\nException:" + ex.Message);
            }
            finally
            {
                Disconnect(objConnection);
            }

            return ds;
        }

    }
    public static DataSet GetDsBySPArray(string spName, Hashtable htHashTable)
        {

            //Dim ht as new HashTable()ht.Add("Eno",10)ht.Add("Ename","Sadha sivam")ht.Add("EAge",20)
            if ((string.IsNullOrEmpty(spName)))
            {
                return null;
            }

            SqlConnection objConnection = new SqlConnection();
       
            string MySP = spName;
            if (objConnection.State != ConnectionState.Open)
            {
                Connect(ref objConnection);
            }
            SqlCommand cmd = new SqlCommand(MySP, objConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();

            IDictionaryEnumerator _enumerator = htHashTable.GetEnumerator();

        while (_enumerator.MoveNext())
        {
             cmd.Parameters.Add(new SqlParameter(_enumerator.Key.ToString(), _enumerator.Value.ToString()));
     
        }

       

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            try
            {
                adpt.Fill(ds, "SPs");
            }
            catch (SqlException ex)
            {
                 
                ds = null;
            }
            finally
            {
                Disconnect(objConnection);
            }


            return ds;
        }
          
    public static string GetOneValueBySP(string sSP_Name, string sSP_Var, int iSP_Value, string sField)
        {
            DataSet ds = GetDsBySP(sSP_Name, sSP_Var, iSP_Value);

            string sValue = "";
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    sValue = ds.Tables[0].Rows[0][sField].ToString();
                }
                catch (Exception exx)
                {
                    sValue = "";
                }


            }
            else
            {
                sValue = "";
            }
            ds = null;

            return sValue;


        }

        public static string GetOneValueBySP(string sSP_Name, string sSP_Var, string sSP_Value, string sField)
        {
            DataSet ds = GetDsBySP(sSP_Name, sSP_Var, sSP_Value);

            string sValue = "";
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    sValue = ds.Tables[0].Rows[0][sField].ToString();
                }
                catch (Exception exx)
                {
                    sValue = "";
                }


            }
            else
            {
                sValue = "";
            }
            ds = null;

            return sValue;


        }
        public static string GetOneValueBySQL(string sSQL, string sField)
    {
        DataSet ds = GetRecordsBySQL(sSQL);

        string sValue = "";
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            try
            {
                sValue = ds.Tables[0].Rows[0][sField].ToString();
            }
            catch (Exception exx)
            {
                sValue = "";
            }


        }
        else
        {
            sValue = "";
        }
        ds = null;

        return sValue;


    }
    public static string GetOneValueBySQLForQCS(string sSQL, string sField)
    {
        DataSet ds = GetRecordsByQCSSQL(sSQL);

        string sValue = "";
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            try
            {
                sValue = ds.Tables[0].Rows[0][sField].ToString();
            }
            catch (Exception exx)
            {
                sValue = "";
            }


        }
        else
        {
            sValue = "";
        }
        ds = null;

        return sValue;


    }

     
    public static int ExecuteSPByHashTableAndReturnScalar(string spName, Hashtable htHashTable)

    {
        SqlConnection objConnection = new SqlConnection();
        Connect(ref objConnection);
        string MySP = spName;
        if (objConnection.State != ConnectionState.Open)
        {
            Connect(ref objConnection);
        }

        SqlCommand cmd = new SqlCommand(MySP, objConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        foreach (DictionaryEntry entry in htHashTable)
        {
            switch (entry.Value.GetType().ToString())
            {
                case "System.DateTime":
                    cmd.Parameters.Add(new SqlParameter(entry.Key.ToString(), Convert.ToDateTime(entry.Value.ToString())));
                    break;
                case "System.Int32":
                    cmd.Parameters.Add(new SqlParameter(entry.Key.ToString(), Int32.Parse(entry.Value.ToString())));
                    break;
                case "System.Boolean":
                    cmd.Parameters.Add(new SqlParameter(entry.Key.ToString(), Convert.ToBoolean(entry.Value.ToString())));
                    break;
                default:
                    cmd.Parameters.Add(new SqlParameter(entry.Key.ToString(), entry.Value.ToString()));
                    break;
            }
        }
        try
        {
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        catch (Exception)
        {
            return -2;
        }
        finally
        {
            Disconnect(objConnection);
        }
    }

    
    #endregion

      

}

}
