using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Web.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace DSP.BAL
{

    public class Basic
    {
        public Basic()
        {
        }

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
        public static string ConvertDateToSQL(string theDate)
        {
            string[] theData = theDate.Split("/".ToCharArray());
            int iDay = int.Parse(theData[0]);
            int iMonth = int.Parse(theData[1]);
            int iYear = int.Parse(theData[2]);
            return iMonth.ToString() + "/" + iDay.ToString() + "/" + iYear.ToString();
        }

        public static string FormatDateForSQL(string theDate)
        {
            string[] theData0 = theDate.Split(" ".ToCharArray());

            string[] theData = theData0[0].Split("/".ToCharArray());

            theDate = theData[1].ToString() + "/" + theData[0].ToString() + "/" + theData[2].ToString();

            return theDate;
        }

        public static string FormatStringForSQL(string str)
        {
            if (str == null)
                str = "";
            str = str.Replace("'", "''");
            return str;
        }

        public static string FormatStringForMySQL(string str)
        {
            if (str == null)
                str = "";
            str = str.Replace("'", "\'");
            return str;
        }


        public MembershipUserCollection getAllASPUsers()
        {
            return Membership.GetAllUsers();
        }



        public static string CalculateFileSize(double FileInBytes)
        {
            string strSize = "00";
            if (FileInBytes < 1024)
                strSize = FileInBytes + " B";//Byte
            else if (FileInBytes > 1024 & FileInBytes < 1048576)
                strSize = Math.Round((FileInBytes / 1024), 2) + " KB";//Kilobyte
            else if (FileInBytes > 1048576 & FileInBytes < 107341824)
                strSize = Math.Round((FileInBytes / 1024) / 1024, 2) + " MB";//Megabyte
            else if (FileInBytes > 107341824 & FileInBytes < 1099511627776)
                strSize = Math.Round(((FileInBytes / 1024) / 1024) / 1024, 2) + " GB";//Gigabyte
            else
                strSize = Math.Round((((FileInBytes / 1024) / 1024) / 1024) / 1024, 2) + " TB";//Terabyte
            return strSize;
        }
        



         

        //setting up  values to controls
        public static void SetControl(object _obj, object sValue)
        {

            string value = sValue.ToString().Trim();
            
            
            switch (_obj.GetType().Name)
            {
                case "Label":
                    //do something
                    Label lbl = (Label)_obj;

                    if (value == "01/01/1900")
                    { lbl.Text = ""; }
                    else
                    {
                        lbl.Text = value;
                    }


                    break;
                
                
                case "TextBox":
                    //do something
                    TextBox webBox = (TextBox)_obj;
                    
                    if (value == "01/01/1900")
                    {   webBox.Text = ""; }
                    else
                    {
                        webBox.Text = value;
                    }


                break;

                case "RadioButtonList":
                    //do something
                    RadioButtonList rbl = (RadioButtonList)_obj;

                    for (int i = 0; i < rbl.Items.Count; i++)
                    {
                        ListItem li = rbl.Items[i];

                        if (li.Value == value)
                        {
                            li.Selected = true;
                        }
                        else
                        {
                            li.Selected = false;
                        }
                    }

                break;

                case "CheckBox":
                    //do something
                    CheckBox chkBox = (CheckBox)_obj;
                   
                    if (value == "0")
                    {
                        chkBox.Checked = false;
                    }
                    else
                    {
                        chkBox.Checked = true;
                    }
                break;


                case "DropDownList":
                //do something
                DropDownList ddlBox = (DropDownList)_obj;
                     
                    ddlBox.Text = value;
                 
                break;

                       
                 
                default:
                Console.WriteLine(_obj.GetType().Name);
                break;
            }


            




        }

        public static void SetControlDate(Label webBox, object fieldData)
        {
            //string value = fieldData.ToString().Trim();

            string strDate;

            if ((fieldData == null) || (fieldData.ToString() == ""))
            {
                webBox.Text = "";
                return;

            }

            strDate = Convert.ToDateTime(fieldData).Day + "/" + Convert.ToDateTime(fieldData).Month + "/" + Convert.ToDateTime(fieldData).Year;
            webBox.Text = strDate.Trim();
        }
        
        public static void FillDropDownList(DropDownList ddl, DataSet ds, string sItemFieldTitle, string sItemFieldValue)
        {

            ddl.DataSource = ds.Tables[0];
            ddl.DataValueField = sItemFieldValue;
            ddl.DataTextField = sItemFieldTitle;

            ddl.DataBind();

        }

        public static void convertAndCheckNullAndSetRadioBox(RadioButtonList _ctl, object sValue)
        {
            string value = sValue.ToString().Trim();

            for (int i = 0; i < _ctl.Items.Count; i++)
            {
                ListItem li = _ctl.Items[i];

                if (li.Value == value)
                {
                    li.Selected = true;
                }
                else
                {
                    li.Selected = false;
                }
            }
        }

        public static void convertAndCheckNullAndSet(TextBox webBox, object fieldData)
        {
            string strItem = fieldData.ToString().Trim();

            if (strItem == "01/01/1900")
            { webBox.Text = ""; }
            else
            {
                webBox.Text = strItem;
            }

        }

        public static void convertAndCheckNullAndSetCheckBox(CheckBox webBox, object fieldData)
        {
            string strItem = fieldData.ToString().Trim();

            if (strItem == "0")
            {
                webBox.Checked = false;
            }
            else
            {
                webBox.Checked = true;
            }
        }

        public static void convertAndCheckNullAndSetDate(TextBox webBox, object fieldData)
        {
            string strDate;

            if ((fieldData == null) || (fieldData.ToString() == ""))
            {
                webBox.Text = "";
            }

            strDate = Convert.ToDateTime(fieldData).Day + "/" + Convert.ToDateTime(fieldData).Month + "/" + Convert.ToDateTime(fieldData).Year;
            webBox.Text = strDate.Trim();
        }

        public static string convertAndCheckNullAndSetDate(object fieldData)
        {
            string strDate = "";

            if (fieldData.ToString().Trim() != "")
            {
                strDate = Convert.ToDateTime(fieldData).Day + "/" + Convert.ToDateTime(fieldData).Month + "/" + Convert.ToDateTime(fieldData).Year;
            }

            return strDate;
        }

        public static void convertAndCheckNullAndSetDopDownBox(DropDownList webBox, object fieldData, bool defaulted = true)
        {
            if (fieldData != null)
            {
                try
                {
                    string strItem = fieldData.ToString().Trim();

                    if (strItem != "")
                    {

                        if (defaulted == false)
                        {
                            webBox.DataBind();
                            ListItem li = new ListItem();
                            li = webBox.Items.FindByValue(strItem);
                            if (!li.IsNull())
                            {
                                webBox.Text = strItem;
                            }
                            else
                            {
                                // webBox.SelectedIndex = 0;
                                //   webBox.Text = "";
                            }
                        }
                        else
                        {
                            webBox.Text = strItem;
                        }
                    }
                        
                }
                catch (Exception ex)
                {
                    //webBox.SelectedIndex = 0;
                    webBox.Text = "";
                }


            }

        }

        public static string validDateCheck(string theDate)
        {
            string[] theData = theDate.Split("/".ToCharArray());
            int iDay = int.Parse(theData[0]);
            int iMonth = int.Parse(theData[1]);
            int iYear = int.Parse(theData[2]);

            if (iYear < 1901)
            {
                iYear = 1901;
            }

            if (iMonth > 12)
            {
                iMonth = 12;
            }

            if (iMonth == 1 | iMonth == 3 | iMonth == 5 | iMonth == 7 | iMonth == 8 | iMonth == 10 | iMonth == 12)
            {
                if (iDay > 31)
                {
                    iDay = 31;
                }
            }
            else
            {
                if (iMonth == 2)
                {
                    if ((iYear % 4) == 0)
                    {
                        if (iDay > 29)
                        {
                            iDay = 29;
                        }
                    }
                    else
                    {
                        if (iDay > 28)
                        {
                            iDay = 28;
                        }
                    }
                }
                else
                {
                    if (iDay > 30)
                    {
                        iDay = 30;
                    }
                }
            }

            theDate = iDay.ToString() + "/" + iMonth.ToString() + "/" + iYear.ToString();

            return theDate;
        }

        internal static bool IsNumeric(string numberString)
        {
            if (numberString.Trim() == "")
            {
                return false;
            }
            else
            {
                char[] ca = numberString.ToCharArray();
                for (int i = 0; i < ca.Length; i++)
                {
                    if (!char.IsNumber(ca[i]))
                        return false;
                }
            }
            return true;
        }

        public static string switchDayAndMonth(string strSomeDate)
        {
            if (strSomeDate != "")
            {
                string[] theDateArray = strSomeDate.Split("/".ToCharArray());

                return theDateArray[1] + "/" + theDateArray[0] + "/" + theDateArray[2];
            }
            else
            {
                return "";
            }
        }
        

        public static string format_short_date(object obtheDate)
        {

            string theDate = obtheDate.ToString();

            if (theDate == "") { return ""; }

            string[] theData0 = theDate.Split(" ".ToCharArray());

            //  string[] theData = theData0[0].Split("/".ToCharArray());


            // theDate = theData[1].ToString() + "/" + theData[0].ToString() + "/" + theData[2].ToString();

            return theData0[0]; //  theDate;
        }


        public string format_short_date_uk(object obtheDate)
        {

            string theDate = obtheDate.ToString();

            if (theDate == "") { return ""; }

            string[] theData0 = theDate.Split(" ".ToCharArray());

            string[] theData = theData0[0].Split("/".ToCharArray());


            theDate = theData[1].ToString() + "/" + theData[0].ToString() + "/" + theData[2].ToString();

            return theDate;
        }


        public static string EncodePassword(string originalPassword)
        {
            // SALT PASSWORD
            originalPassword = "stusPasswordSalt" + originalPassword;

            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }

        // files handling
        public static string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        public string FileUserRefDateStamp(string sRef, string sFileName)
        {
            // today 
            DateTime now = DateTime.Today;

            string sTodayDate = now.Year.ToString() + "-" + now.Month.ToString() + "-" + now.Day.ToString();

            return sTodayDate;


        }

      


        public string cutStringToSize(string theString, int iLen)
        {
            int i = theString.Length;

            if (i > iLen)
            {
                theString = theString.Remove(iLen);
                theString = theString + "...";
            }

            return theString;
        }

        public string FormatDateILMS(string theDate)
        {
            string[] theData0 = theDate.Split(" ".ToCharArray());

            string[] theData = theData0[0].Split("/".ToCharArray());

            theDate = theData[1].ToString() + "/" + theData[0].ToString() + "/" + theData[2].ToString();

            return theDate;
        }

        protected string TrimString(object theOb, int ilen)
        {
            return cutStringToSize(theOb.ToString(), ilen);
        }

        public string ReturnNVQLevel(object iValue)
        {

            string sRet = "";

            string strReturn = iValue.ToString().Trim();
            if (strReturn == "2") { sRet = "2 & 3"; }
            else if (strReturn == "3") { sRet = "3 & 4"; }
            else { sRet = " ? "; }
            return sRet;

        }







        public bool checkRestrictDate(string theDate)
        {
            string[] theData = theDate.Split("/".ToCharArray());
            int iDay = int.Parse(theData[0]);
            int iMonth = int.Parse(theData[1]);
            int iYear = int.Parse(theData[2]);

            int iThisYear = DateTime.Now.Year;

            if (iYear >= iThisYear) return false;

            // back to 15 years
            if ((iThisYear - iYear) <= 15)
            {

                return false;


            }
            return true;

        }

        public string validDateCheck2(string theDate)
        {

            if (theDate == "") return "";
            string[] theData = theDate.Split("/".ToCharArray());
            int iDay = int.Parse(theData[0]);
            int iMonth = int.Parse(theData[1]);
            int iYear = int.Parse(theData[2]);

            if (iYear < 1901)
            {
                iYear = 1901;
            }

            if (iMonth > 12)
            {
                iMonth = 12;
            }

            if (iMonth == 1 | iMonth == 3 | iMonth == 5 | iMonth == 7 | iMonth == 8 | iMonth == 10 | iMonth == 12)
            {
                if (iDay > 31)
                {
                    iDay = 31;
                }
            }
            else
            {
                if (iMonth == 2)
                {
                    if ((iYear % 4) == 0)
                    {
                        if (iDay > 29)
                        {
                            iDay = 29;
                        }
                    }
                    else
                    {
                        if (iDay > 28)
                        {
                            iDay = 28;
                        }
                    }
                }
                else
                {
                    if (iDay > 30)
                    {
                        iDay = 30;
                    }
                }
            }

            theDate = iMonth.ToString() + "/" + iDay.ToString() + "/" + iYear.ToString();

            return theDate;
        }



       

        //static
        public int GetNbMonthsFromDate(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate) return -1;

            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }


        struct structMessage
        {
            public string Message;
            public int Type;
            public System.Drawing.Color FGColour;
            public System.Drawing.Color BGColour;
            //public bool IsBold;
            public string TypeName;


        }


        public void ClearErrorMessage(ref Label lblMessage)
        {
            lblMessage.Visible = false;
            lblMessage.Text = "";

        }

        public string GetErrorMessage(string strMessage, int iType, ref Label lblMessage)
        {
            // iType :  1 = Normal Message / Info
            //          2 = Error Message
            //          3 = Alert Message      
            structMessage MyMessage = new structMessage();
            MyMessage.Message = strMessage;
            MyMessage.Type = iType;


            lblMessage.BorderWidth = 2;
            lblMessage.Width = 400;



            switch (MyMessage.Type)
            {
                case 1:
                    MyMessage.FGColour = System.Drawing.Color.Green;
                    MyMessage.BGColour = System.Drawing.Color.Transparent;
                    MyMessage.TypeName = "Message";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.BackColor = System.Drawing.Color.Transparent;
                    lblMessage.BorderColor = System.Drawing.Color.Green;

                    break;
                case 2:
                    MyMessage.FGColour = System.Drawing.Color.Red;
                    MyMessage.BGColour = System.Drawing.Color.Yellow;
                    MyMessage.TypeName = "Error";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.BackColor = System.Drawing.Color.Yellow;
                    lblMessage.BorderColor = System.Drawing.Color.Red;

                    break;
                case 3:
                    MyMessage.FGColour = System.Drawing.Color.Orange;
                    MyMessage.BGColour = System.Drawing.Color.GhostWhite;
                    MyMessage.TypeName = "Alert";
                    lblMessage.ForeColor = System.Drawing.Color.Orange;
                    lblMessage.BackColor = System.Drawing.Color.GhostWhite;
                    lblMessage.BorderColor = System.Drawing.Color.Orange;

                    break;
                default:
                    MyMessage.Type = 1;
                    MyMessage.FGColour = System.Drawing.Color.Green;
                    MyMessage.BGColour = System.Drawing.Color.Transparent;
                    MyMessage.TypeName = "Message";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.BackColor = System.Drawing.Color.Transparent;
                    lblMessage.BorderColor = System.Drawing.Color.Green;

                    break;

            }


            // System.Drawing.Color bgColor;
            // string bgColor = ""; 

            StringBuilder strBuilder = new StringBuilder("");
            strBuilder.Append("<TABLE style=\"font-size:11;font-family:Verdana\">");

            strBuilder.Append("<TR  BGCOLOR=\"" + MyMessage.BGColour.Name.ToString() + "\" >");
            strBuilder.Append("<TD ><B><span style:color:" + MyMessage.FGColour.Name.ToString() + " >" + MyMessage.TypeName + "</span></B></TD>");
            strBuilder.Append("</TR>");


            strBuilder.Append("<TR>");
            strBuilder.Append("<TD  BGCOLOR=\"" + MyMessage.BGColour.Name.ToString() + "\" ><span style:color:" + MyMessage.FGColour.Name.ToString() + " >" + MyMessage.Message + "</span></TD>");
            strBuilder.Append("</TR>");

            strBuilder.Append("</TABLE>");

            lblMessage.Visible = true;

            lblMessage.Text = strBuilder.ToString();

            return strBuilder.ToString();



        }


        public string GetErrorMessagexxxxxx(string strMessage, int iType, ref Label lblMessage)
        {
            // iType :  1 = Normal Message / Info
            //          2 = Error Message
            //          3 = Alert Message      
            structMessage MyMessage = new structMessage();
            MyMessage.Message = strMessage;
            MyMessage.Type = iType;


            lblMessage.BorderWidth = 2;
            lblMessage.Width = 500;



            switch (MyMessage.Type)
            {
                case 1:
                    MyMessage.FGColour = System.Drawing.Color.Green;
                    MyMessage.BGColour = System.Drawing.Color.Transparent;
                    MyMessage.TypeName = "Message";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.BackColor = System.Drawing.Color.Transparent;
                    lblMessage.BorderColor = System.Drawing.Color.Green;

                    break;
                case 2:
                    MyMessage.FGColour = System.Drawing.Color.Red;
                    MyMessage.BGColour = System.Drawing.Color.Yellow;
                    MyMessage.TypeName = "Error";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.BackColor = System.Drawing.Color.Yellow;
                    lblMessage.BorderColor = System.Drawing.Color.Red;

                    break;
                case 3:
                    MyMessage.FGColour = System.Drawing.Color.Orange;
                    MyMessage.BGColour = System.Drawing.Color.GhostWhite;
                    MyMessage.TypeName = "Alert";
                    lblMessage.ForeColor = System.Drawing.Color.Orange;
                    lblMessage.BackColor = System.Drawing.Color.GhostWhite;
                    lblMessage.BorderColor = System.Drawing.Color.Orange;

                    break;
                default:
                    MyMessage.Type = 1;
                    MyMessage.FGColour = System.Drawing.Color.Green;
                    MyMessage.BGColour = System.Drawing.Color.Transparent;
                    MyMessage.TypeName = "Message";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.BackColor = System.Drawing.Color.Transparent;
                    lblMessage.BorderColor = System.Drawing.Color.Green;

                    break;

            }


          
            StringBuilder strBuilder = new StringBuilder("");
            strBuilder.Append("<TABLE style=\"font-size:11;font-family:Verdana\">");

            strBuilder.Append("<TR  BGCOLOR=\"" + MyMessage.BGColour.Name.ToString() + "\" >");
            strBuilder.Append("<TD ><B><span style:color:" + MyMessage.FGColour.Name.ToString() + " >" + MyMessage.TypeName + "</span></B></TD>");
            strBuilder.Append("</TR>");


            strBuilder.Append("<TR>");
            strBuilder.Append("<TD  BGCOLOR=\"" + MyMessage.BGColour.Name.ToString() + "\" ><span style:color:" + MyMessage.FGColour.Name.ToString() + " >" + MyMessage.Message + "</span></TD>");
            strBuilder.Append("</TR>");

            strBuilder.Append("</TABLE>");

            lblMessage.Visible = true;

            return strBuilder.ToString();



        }


        
        public string ReturnDate(object iValue)
        {

            string sRet = "";

            string strReturn = iValue.ToString().Trim();
            if (strReturn == "" || strReturn == "01/01/1900") { sRet = ""; }
            else { sRet = strReturn; }
            return sRet;

        }




        public string validDateCheck3(string theDate)
        {

            if (theDate == "") return "";

            string[] theData = theDate.Split("/".ToCharArray());
            int iDay = int.Parse(theData[0]);
            int iMonth = int.Parse(theData[1]);
            int iYear = int.Parse(theData[2]);

            if (iYear < 1901)
            {
                iYear = 1901;
            }

            if (iMonth > 12)
            {
                iMonth = 12;
            }

            if (iMonth == 1 | iMonth == 3 | iMonth == 5 | iMonth == 7 | iMonth == 8 | iMonth == 10 | iMonth == 12)
            {
                if (iDay > 31)
                {
                    iDay = 31;
                }
            }
            else
            {
                if (iMonth == 2)
                {
                    if ((iYear % 4) == 0)
                    {
                        if (iDay > 29)
                        {
                            iDay = 29;
                        }
                    }
                    else
                    {
                        if (iDay > 28)
                        {
                            iDay = 28;
                        }
                    }
                }
                else
                {
                    if (iDay > 30)
                    {
                        iDay = 30;
                    }
                }
            }

            theDate = iMonth.ToString() + "/" + iDay.ToString() + "/" + iYear.ToString();

            return theDate;
        }


        public string get_CheckBoxValue(System.Web.UI.WebControls.CheckBox chk)
        {

            if (chk.Checked == true)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }

        public string strip_spaces(string str)
        {
            if (str == "") return "";
            string str2 = str.Replace(" ", "");
            str2 = str2.Replace("(", "");
            str2 = str2.Replace(")", "");
            str2 = str2.Replace("-", "");
            return str2;



        }

        public static string getNow()
        {
            return switchDayAndMonth(DateTime.Now.ToShortDateString());

        }




        public static bool CheckIfItemExists(DataSet ds)
        {

            bool bFound = false;

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                bFound = true;
            }
            else
            {
                bFound = false;
            }

            return bFound;

        }


        /**************************************************************************************************/
        /*
         * ACT INTEGRATION METHODS
        /*
        /**************************************************************************************************/
        /// <summary>
        /// Creates an element and appends it to the parent
        /// </summary>
        /// <param name="name">Name of the element</param>
        /// <param name="value">Value to place</param>
        /// <param name="parent">Node to append to</param>
        /// <param name="document">Document that will create the node</param>
        /// <returns>The node created</returns>
        public static XmlElement AppendElement(string name, string value, XmlNode parent, XmlDocument document)
        {
            XmlElement element = document.CreateElement(name);

            if (value != "")
            {
                XmlText textValue = document.CreateTextNode(value);
                element.AppendChild(textValue);
            }

            parent.AppendChild(element);
            return element;
        }
        /// <summary>
        /// Creates an element and appends it to the parent
        /// </summary>
        /// <param name="name">Name of the element</param>
        /// <param name="parent">Node to append to</param>
        /// <param name="document">Document that will create the node</param>
        /// <returns>The node created</returns>
        public static XmlElement AppendElement(string name, XmlNode parent, XmlDocument document)
        {
            return AppendElement(name, String.Empty, parent, document);
        }

        /// <summary>
        /// Converts a date to XSDDate format
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetXmlDate(DateTime date)
        {
            return date.Year + "-" + date.Month.ToString("00") + "-" + date.Day.ToString("00") + "T" + date.Hour.ToString("00") + ":" + date.Minute.ToString("00") + ":" + date.Second.ToString("00");
        }

        /// <summary>
        /// Removes dodgy characters from the input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CleanXml(string input)
        {
            input = input.Replace("'", "''");
            return input;
        }

        /// <summary>
        /// Writes string data out to file
        /// </summary>
        /// <remarks>Used StreamWriter</remarks>
        /// <param name="filename">File to write to</param>
        /// <param name="data">Data to write to file</param>
        /// <param name="append">Whether to append. False will overwrite data</param>
        public static void StringToFile(string filename, string data, bool append)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename, append))
                {
                    sw.Write(data, 0, data.Length);
                }
            }
            catch (IOException ex)
            {
                string error = ex.Message;
            }
        }
        public static void ResetFormControlValues(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControlValues(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = "";
                            break;
                        case "System.Web.UI.WebControls.CheckBox":
                            ((CheckBox)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;

                        case "System.Web.UI.WebControls.DropDownList":
                            ((DropDownList)c).ClearSelection();
                            break;
                    }
                }
            }
        }
        public static void BindData(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControlValues(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        //case "System.Web.UI.WebControls.TextBox":
                        //    ((TextBox)c).Text = "";
                        //    break;
                        //case "System.Web.UI.WebControls.CheckBox":
                        //    ((CheckBox)c).Checked = false;
                        //    break;
                        //case "System.Web.UI.WebControls.RadioButton":
                        //    ((RadioButton)c).Checked = false;
                        //    break;

                        case "System.Web.UI.WebControls.DropDownList":
                            ((DropDownList)c).Items.Clear();
                            break;
                    }
                }
            }
        }
        public static void CreateTextFile(string filename, string content)
        {
            // Write the string to a file.
          
            
            System.IO.StreamWriter file = new System.IO.StreamWriter( "e:\\" + filename + ".txt");
            file.WriteLine(content);
            file.Close();
        }
        public static void CreateLogFile(string fullpath, string filename, string content)
        {
            // Write the string to a file.
            if (ConfigurationManager.AppSettings["cfg_live"] == "false")
            {
                fullpath = fullpath.Replace("D:", "E:");
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter(fullpath + filename + ".txt");
            file.WriteLine(content);
            file.Close();
        }

        //D:\inetpub\Portal\Portal\Assessors\Uploads\




        public static string GenerateRandomPasswordUsingGUID(int length)
        {
            // Get the GUID
            string guidResult = System.Guid.NewGuid().ToString();

            // Remove the hyphens
            guidResult = guidResult.Replace("-", string.Empty);

            // Make sure length is valid
            /*   if (length <= 0 || length > guidResult.Length)
                   throw new ArgumentException("Length must be between 1 and " + guidResult.Length);
               */
            // Return the first length bytes
            return guidResult.Substring(0, length).ToUpper();
        }




        public static bool EmailValid(string strEmail)
        {

             
        string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        Match match = Regex.Match(strEmail.Trim(), pattern, RegexOptions.IgnoreCase);

        if (match.Success)
            return true;
        else
            return false;

        }


        public static string GetValidEmailFromSelection(string str)
        {
            string sReturn = str;

            if (str.IndexOf("<") > 0)
            {

                string regex = @"\<(.*?)\>";
                //  string text  = "Hi [Stack], Here is my [Tag] which i need to [Find].";

                foreach (Match match in Regex.Matches(str, regex))
                {
                    sReturn = match.Value.ToString().Replace("<","").Replace(">","");
                    //   Console.WriteLine("Found {0}", match.Groups[1].Value);
                    break;
                }


            }
            else 
            
            { return str; }
            return sReturn;

        }



        public static string ReturnExtensionImage(string fileExtension)
        {

            string sImageStart = "<img src=\"../../App_Resources/images/ico_files/%IMAGEICO%.gif\"   alt=\"File Extension\">";
            string sReplaceIco = "ico_other";
            switch (fileExtension)
            {
                case ".htm":
                    sReplaceIco = "ico_html";
                    break;

                case ".html":
                    sReplaceIco = "ico_html";
                    break;

                case ".log":
                    //   return "text/HTML";
                    break;
                case ".txt":
                    //  return "text/plain";
                    break;
                case ".docx":
                    sReplaceIco = "ico_docx";
                    break;
                case ".doc":
                    sReplaceIco = "ico_doc";
                    break;
                case ".tiff":
                    sReplaceIco = "ico_pic";
                    break;
                case ".tif":
                    sReplaceIco = "ico_pic";
                    break;
                case ".asf":

                    break;
                case ".avi":
                    sReplaceIco = "ico_movie";
                    break;

                case ".zip":
                    sReplaceIco = "ico_zip";
                    break;
                case ".xls":
                    break;
                case ".csv":
                    sReplaceIco = "ico_doc";
                    break;
                case ".gif":
                    sReplaceIco = "ico_pic";

                    break;
                case ".jpg":
                    sReplaceIco = "ico_pic";
                    break;
                case "jpeg":
                    sReplaceIco = "ico_pic";

                    break;
                case ".bmp":

                    sReplaceIco = "ico_pic";
                    break;
                case ".wav":
                    sReplaceIco = "ico_music";

                    break;
                case ".mp3":
                    sReplaceIco = "ico_music";
                    break;

                case ".mpg":
                    sReplaceIco = "ico_movie";
                    break;
                case "mpeg":
                    sReplaceIco = "ico_movie";
                    break;

                case ".rtf":
                    sReplaceIco = "ico_doc";
                    break;

                case ".asp":
                    break;

                case ".pdf":
                    sReplaceIco = "ico_pdf";
                    break;
                case ".fdf":

                    break;
                case ".ppt":

                    break;
                case ".dwg":

                    break;
                case ".msg":

                    break;
                case ".xml":
                    break;
                case ".sdxl":
                    break;

                case ".xdp":
                    break;

                default:
                    sReplaceIco = "ico_other";
                    break;

            }
            return sImageStart.Replace("%IMAGEICO%", sReplaceIco);

        }



    }


  

}