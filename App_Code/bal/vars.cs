using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for vars
/// </summary>
public class vars
{
	public vars()
	{
	 

	}
    public static string STR_EMAIL_TPL_LINK_ALL = "~/Portal/Account/ManageEmailTemplates.aspx";
    public static string STR_EMAIL_TPL_LINK_EDIT = "~/Portal/Account/ManageEmailTemplates.aspx?ed={0}#tabs-2";


    public static string STR_MSG_ENTER_PROPER_TITLE = "Please enter a valid title.";
    public static string STR_MSG_ENTERED_EXIST_TITLE = "Title already exists in the system. Choose another one.";


    public static string STR_MSG_UPDATED_SUCCESSFULLY = "Updated successfully.";

    public static string STR_MSG_SESSION_EXPIRED = "Session expired please login back and try again.";

    public static string STR_MSG_VALID_TITLE = "Please enter a valid title.";

    public static string STR_MSG_CORRECTTIMESPENT = "Please enter the correct time spent on the activity.";
    public static string STR_MSG_ENTERPROPERNOTE = "Please enter a valid note.";



    public static string ERROR_PAGE_SESSIONTIMEDOUT = "Timedout.aspx";
   
    public static bool LIVEMODE = true;
    public static string LANDING_PAGE_DEV = "holdingpage.aspx";
    public static string LANDING_PAGE_LIVE = "Default.aspx";
     
    public static bool LOGGING_ENABLE = true;

    public static string STR_LOG_SECT_EMAIL_TPL = "Email Templates";
    public static string STR_LOG_SEP = " | ";
    public static string STR_LOG_NEW = "NEW";
    public static string STR_LOG_UPDATE = "UPDATE";
    public static string STR_LOG_DELETE = "DELETE";
    public static string STR_LOG_ACCESS = "ACCESS";
}