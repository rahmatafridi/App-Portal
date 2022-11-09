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

public partial class RoleManagement_UsersAndRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {           
            // Bind the users and roles
            BindUsersToUserList();
            BindRolesToList();

            // Check the selected user's roles
            CheckRolesForSelectedUser();

            // Display those users belonging to the currently selected role
            DisplayUsersBelongingToRole(); 
        } 
    }

    /* ************************************************* 
    * Show jgrowl notification
    *
    * *************************************************
    */
    protected void show_notif(string str)
    {
        string js = "$.jGrowl('" + str.Replace("'", "\'") + "');";

        Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);

    }
    /* ***********************************************/


    protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckRolesForSelectedUser();
    }

    protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayUsersBelongingToRole();
    }

    private void BindUsersToUserList()
    {   
        // Get all of the user accounts
        MembershipUserCollection users = Membership.GetAllUsers();
        UserList.DataSource = users;
        UserList.DataBind();
    } 
    
    private void BindRolesToList()
    {
        // Get all of the roles
        string[] roles = Roles.GetAllRoles();
        UsersRoleList.DataSource = roles;
        UsersRoleList.DataBind();

        RoleList.DataSource = roles;
        RoleList.DataBind();
    }

    private void DisplayUsersBelongingToRole()
    {
        // Get the selected role
        string selectedRoleName = RoleList.SelectedValue;
        
        // Get the list of usernames that belong to the role
        string[] usersBelongingToRole = Roles.GetUsersInRole(selectedRoleName);
        
        // Bind the list of users to the GridView
        RolesUserList.DataSource = usersBelongingToRole;
        RolesUserList.DataBind();
    }

    private void CheckRolesForSelectedUser() 
    { 
        // Determine what roles the selected user belongs to
        string selectedUserName = UserList.SelectedValue;
        string[] selectedUsersRoles = Roles.GetRolesForUser(selectedUserName);

        // Loop through the Repeater's Items and check or uncheck the checkbox as needed
        foreach(RepeaterItem ri in UsersRoleList.Items)
        { 
            // Programmatically reference the CheckBox
            CheckBox RoleCheckBox = ri.FindControl("RoleCheckBox") as CheckBox;
            // See if RoleCheckBox.Text is in selectedUsersRoles
            int i;

            RoleCheckBox.Checked = false;

            for (i = 0; i < selectedUsersRoles.Length; i++)
            {
                if(RoleCheckBox.Text == selectedUsersRoles.GetValue(i).ToString().Trim())
                {
                    RoleCheckBox.Checked = true;
                }

            }
        }
    }

    protected void RoleCheckBox_CheckChanged(object sender, EventArgs e) 
    {
        // Reference the CheckBox that raised this event
        CheckBox RoleCheckBox = sender as CheckBox;
        
        // Get the currently selected user and role
        string selectedUserName = UserList.SelectedValue;
        string roleName = RoleCheckBox.Text;
        
        // Determine if we need to add or remove the user from this role
        if (RoleCheckBox.Checked)
        {
            // Add the user to the role
            Roles.AddUserToRole(selectedUserName, roleName);
            
            // Display a status message
            ActionStatus.Text = string.Format("User {0} was added to role {1}.", selectedUserName, roleName);
            show_notif(ActionStatus.Text);
        }
        else
        {
            // Remove the user from the role

            try
            {
                Roles.RemoveUserFromRole(selectedUserName, roleName);
            }
            catch (Exception exx)
                {
                
                }
            // Display a status message
            ActionStatus.Text = string.Format("User {0} was removed from role {1}.", selectedUserName, roleName);
            show_notif(ActionStatus.Text);
        }
    }

    protected void RolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the selected role
        string selectedRoleName = RoleList.SelectedValue;
        
        // Reference the UserNameLabel
        Label UserNameLabel = RolesUserList.Rows[e.RowIndex].FindControl("UserNameLabel") as Label;
        
        // Remove the user from the role
        Roles.RemoveUserFromRole(UserNameLabel.Text, selectedRoleName);
        
        // Refresh the GridView
        DisplayUsersBelongingToRole();
        
        // Display a status message
        ActionStatus.Text = string.Format("User {0} was removed from role {1}.", UserNameLabel.Text, selectedRoleName);
        show_notif(ActionStatus.Text);
    }
}
