using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

 
public class Activity
{    
    public string TypeContact;
    public string TypeActivity;
    public int iTypeContact;
    public int iTypeActivity;
}


/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]


public class WebService : System.Web.Services.WebService {

    public WebService () {


    }



 
    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    
}



