using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class RoleManagement_ManageRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            displayRolesInGrid();
        }
    }

    protected void CreateRoleButton_Click(object sender, EventArgs e)
    {
        String newRoleName = RoleName.Text.Trim();

        if (!Roles.RoleExists(newRoleName))
        {
            Roles.CreateRole(newRoleName);

            displayRolesInGrid();
        }

        RoleName.Text = string.Empty;
    }
 
     protected void grid_roles_list_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        Label l1 = (Label)grid_roles_list.Rows[e.RowIndex].FindControl("RoleNameLabel");

        Roles.DeleteRole(l1.Text, false);

        displayRolesInGrid();
    }

    private void displayRolesInGrid()
    {
        grid_roles_list.DataSource = Roles.GetAllRoles();
        grid_roles_list.DataBind();
    }

}


 