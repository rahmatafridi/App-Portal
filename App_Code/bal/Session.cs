using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace DSP.BAL
{
  

/// <summary>
/// Summary description for Session - only function that have interaction with the sessions/cookies- 
/// </summary>
public class Session
{

    public Session()
    {
    }

    public static string GetSession(string sNameSession)
    {
        string sValue = "";
        try
        {
            sValue = HttpContext.Current.Session[sNameSession].ToString();
        }
        catch (Exception ex)
        {

            //  Response.Write(ex.ToString());
            sValue = "0";
        }

        if (sValue == "")
        {
            sValue = "0";
        }
        return sValue;


    }


    public static string GetSessionUserId()
    {

        return GetSession("UserId");

    }



}

}