using System;
using System.Collections;
using System.Configuration;
using System.Data;
 
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public   partial class wuc_MessageBox : System.Web.UI.UserControl
{
    #region "Timer"
 
   protected System.Timers.Timer _timer;

   private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        // Do whatever you want to do on each tick of the timer  Timer1_Tick
        _timer.Stop();  
         this.Visible = false;

        MessageBox.Visible = false;
       // MessageBox.Attributes.Add("style.display", "none");
        //  Page.DataBind(); 

      //  MessageBox.Attributes.Add("onclick", "document.getElementById('" + MessageBox.ClientID + "').style.display = 'none'");
   
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        // initialize the time control
        _timer = new System.Timers.Timer(4000);

        // subscribe to the Elapsed event
        _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
    }
     

    #endregion

   
    #region Properties
    public   bool ShowCloseButton  { get; set; }
    
    #endregion

    #region Load
    protected void Page_Load(object sender, EventArgs e)
    {
        // _timer.Start(); 

        if (!Page.IsPostBack)
        {
            CloseButton.Visible = false;
        }

        if (ShowCloseButton)
            CloseButton.Attributes.Add("onclick", "document.getElementById('" + MessageBox.ClientID + "').style.display = 'none'");
    }
    #endregion

    #region Wrapper methods
    public void ShowError(string message)
    {
        Show(MessageType.Error, message);
    }

    public void ShowInfo(string message)
    {
        Show(MessageType.Info, message);
    }

    public void ShowSuccess(string message)
    {
        Show(MessageType.Success, message);
    }

    public void ShowWarning(string message)
    {
        Show(MessageType.Warning, message);
    } 
    #endregion

    #region Show control
    public void Show(MessageType messageType, string message)
    {
        _timer.Start();

        if (ShowCloseButton)
            CloseButton.Attributes.Add("onclick", "document.getElementById('" + MessageBox.ClientID + "').style.display = 'none'");

        CloseButton.Visible = ShowCloseButton;
        litMessage.Text = message  ;

        MessageBox.CssClass = messageType.ToString().ToLower();
        this.Visible = true;
    } 
    #endregion

    #region Enum
    public enum MessageType
    {
        Error = 1,
        Info = 2,
        Success = 3,
        Warning = 4
    } 
    #endregion
}

