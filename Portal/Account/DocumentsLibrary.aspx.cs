using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;


public partial class Learners_DocumentsLibrary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
            BuildPolicies();
        

    }





     

    protected void BuildPolicies()
    {

        string acc_start = "<div id=\"accordion\" > ";
        string  acc_item_start = "<h3><a href=\"#\">%%%%%</a></h3><div>";
        string  acc_item_end  = "</div>";//End  contents of item
        string  acc_end = "</div>";//end accordion
 

        pnl_panels.Controls.Add(new LiteralControl(acc_start));




        DataSet dsDocCats = DSP.DAL.SQL.GetRecordsBySQL("SELECT DocCat_Id, DocCat_Title FROM DocCategories ORDER BY DocCat_WeightOrder");

        if (dsDocCats != null && dsDocCats.Tables.Count > 0 && dsDocCats.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow r1 in dsDocCats.Tables[0].Rows)
            {
                string[] strArr = new string[2];

                string sTitleCat = r1[1].ToString();
              
                pnl_panels.Controls.Add(new LiteralControl(acc_item_start.Replace("%%%%%", sTitleCat )));

                Table panelTable = new Table();
                panelTable = GetCatFiles(r1[0].ToString());
                pnl_panels.Controls.Add( panelTable );
    
                 pnl_panels.Controls.Add(new LiteralControl(acc_item_end));
    
               
            }
        }

        pnl_panels.Controls.Add(new LiteralControl(acc_end));
    

    }

    protected Table GetCatFiles(string iCatId)
    {

        DataSet dsCatsDocs =  DSP.DAL.SQL.GetRecordsBySQL("SELECT Docs.Docs_ID as 'Id', Docs.Docs_Title as 'File Name', Docs.Docs_File as 'File Path', CONVERT(varchar(10), Docs_FileDate,103) as 'FileDate'  , Docs_Version  ,  Users.Users_Username as 'Uploaded By' FROM Docs Left OUTER JOIN Users ON Users.Users_Id = Docs.Docs_EnteredBy WHERE Docs_Id_DocCategories = " + iCatId);
       
        
        
        Table panelTable = new Table();
           int i =0;

           if (dsCatsDocs != null && dsCatsDocs.Tables.Count > 0 && dsCatsDocs.Tables[0].Rows.Count > 0)
           {  panelTable.Rows.Add(getRowHeader(iCatId, ref i, "Title", "Action", "Date", "Version"));
    
           }


                 
       foreach (DataRow r2 in dsCatsDocs.Tables[0].Rows)
            {
             i++;
            
                 string sFileTitle  = r2[1].ToString();
              string sFilePath = r2[2].ToString();
                string sFileDate = r2[3].ToString();
              string sFileVersion = r2[4].ToString();
             
               panelTable.Rows.Add(getRow(iCatId, ref i, sFileTitle , sFilePath,sFileDate, sFileVersion));
           


             
            }

        return panelTable;
    }

    protected TableRow getRowHeader(string siCat, ref int i, string sFileName, string sFilePath , string sFileDate, string sFileVersion)
    {
        i++;
        TableRow r1 = new TableRow();

        r1.ID = siCat + "-r-" + i.ToString();

        TableCell c1 = new TableCell();
        c1.ID = siCat + "c1-" + i.ToString();
        c1.CssClass = "item_value";
        c1.Text = sFileName;
        c1.Width = Unit.Percentage(80) ;
        r1.Cells.Add(c1);


        TableCell c2 = new TableCell();
        c2.ID = siCat + "c2-" + i.ToString();
        c2.CssClass = "item_value";
        c2.Text = sFileDate;
        r1.Cells.Add(c2);


        TableCell c3 = new TableCell();
        c3.ID = siCat + "c3-" + i.ToString();
        c3.CssClass = "item_value";
        c3.Text = sFileVersion;
        r1.Cells.Add(c3);


        TableCell c4 = new TableCell();
        c4.ID = siCat + "c4-" + i.ToString();
        c4.CssClass = "item_value";
        c4.Text = sFilePath;
        
        r1.Cells.Add(c4);


        return r1;
    }



    protected TableRow getRow(string siCat, ref int i, string sFileName, string sFilePath, string sFileDate, string sFileVersion)
    {
        i++;
        TableRow r1 = new TableRow();

        r1.ID = siCat + "-r-" + i.ToString();

        TableCell c1 = new TableCell();
        c1.ID = siCat + "c1-" + i.ToString();
        c1.CssClass = "item_value";
        c1.Text = sFileName;
        c1.Width = Unit.Percentage(80);
        r1.Cells.Add(c1);


        TableCell c2 = new TableCell();
        c2.ID = siCat + "c2-" + i.ToString();
        c2.CssClass = "item_value";
        c2.Text = sFileDate;
        r1.Cells.Add(c2);


        TableCell c3 = new TableCell();
        c3.ID = siCat + "c3-" + i.ToString();
        c3.CssClass = "item_value";
        c3.Text = sFileVersion;
        r1.Cells.Add(c3);


        TableCell c4 = new TableCell();
        c4.ID = siCat + "c4-" + i.ToString();
        c4.CssClass = "item_value";
        //c4.Text = sFileVersion;
        LinkButton lbtn = new LinkButton();

        lbtn.ID = "opend_file_btn_" + siCat + i.ToString();
        lbtn.Text = "Open";
        lbtn.SkinID = "LinkButton";
        lbtn.CssClass = "LinkButton";
        lbtn.Click += new EventHandler(OpenFile_Click);
        lbtn.CommandName = "opendocument";
        lbtn.CommandArgument = sFilePath;


        c4.Controls.Add(lbtn);
        r1.Cells.Add(c4);


        return r1;
    }


    protected void OpenFile_Click(object sender, EventArgs e)
    {
         LinkButton btn = (LinkButton)sender;
       

        if (btn.CommandName == "opendocument")
        {
            DownloadFile(btn.CommandArgument);

        }
        
    }

    public void DownloadFile(string filePath)
    {

         if (File.Exists(filePath))
        {
            string strFileName = Path.GetFileName(filePath).Replace(" ", "%20");
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName);
            Response.Clear();
            Response.WriteFile(filePath);  
            Response.End();
        }
        else
        {
            show_notif("File is not found.");
       
        }



    }

    protected void show_notif(string str)
    {
        string js = "$('#jgrowlwarn').jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);

    }


    protected string getFileExt(string sFileName)
    {

        string img = "<img src=\"../../App_Resources/images/xxxxx.gif\" border=\"0\" align=\"absmiddle\"> ";
       string sImageIcon = "";

         FileInfo file = new FileInfo(sFileName);
      
        file.Refresh();

        string viewingFileNameExt = file.Extension;
        switch (viewingFileNameExt)
        {
            case ".pdf": sImageIcon = "pdf";
                break;
            case ".txt": sImageIcon = "txt";
                break;
            case ".jpg": sImageIcon = "jpg";
                break;
            case ".gif": sImageIcon = "gif";
                break;
            case ".doc": sImageIcon = "doc";
                break;
            case ".xlsx": sImageIcon = "xls";
                break;
            case ".xls": sImageIcon = "xls";
                break;
            case ".ppt": sImageIcon = "ppt";
                break;
            case ".pps": sImageIcon = "pps";
                break;
            case ".docx": sImageIcon = "doc08";
                break;
            case ".tif": sImageIcon = "tif";
                break;
            case ".tiff": sImageIcon = "tiff";
                break;
        }

        // Checking if file exists
        if (file.Exists)
        {
      
        }


        img = img.Replace("xxxxx", "ico_" + sImageIcon);

        return img;



    }



}
