using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Data.Odbc;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QCSRoleProvider
/// </summary>
public class QCSRoleProvider : System.Web.Security.SqlRoleProvider
{
	public QCSRoleProvider()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public override void AddUsersToRoles(string[] usernames, string[] rolenames)
    {
        foreach (string rolename in rolenames)
        {
            if (rolename == null || rolename == "")
                throw new ProviderException("Role name cannot be empty or null.");
            if (!RoleExists(rolename))
                throw new ProviderException("Role name not found.");
        }

        foreach (string username in usernames)
        {
            if (username == null || username == "")
                throw new ProviderException("User name cannot be empty or null.");
            if (username.Contains(","))
                throw new ArgumentException("User names cannot contain commas.");

            foreach (string rolename in rolenames)
            {
                if (IsUserInRole(username, rolename))
                    throw new ProviderException("User is already in role.");
            }
        }


        try
        {

            foreach (string username in usernames)
            {
                System.Web.Security.MembershipUser user = System.Web.Security.Membership.Providers["QCSMembershipProvider"].GetUser(username, false);
                foreach (string rolename in rolenames)
                {
                    string roleId = DSP.DAL.SQL.GetOneValueBySQLForQCS(String.Format("Select * from aspnet_Roles Where RoleName = '{0}'", rolename), "RoleId");
                    string query = String.Format("INSERT INTO aspnet_UsersInRoles(UserId, RoleId) Values('{0}', '{1}')", user.ProviderUserKey.ToString(), roleId);
                    DSP.DAL.SQL.ExecuteQCSSQL(query);
                }
            }
        }
        catch (OdbcException)
        {
            // Handle exception.
        }
        finally
        {
        }
    }
}