# Custom Identity Management
### Custom user, role and initialization for ASP.NET MVC Identity
*Custom Identity Management is an alternative to (but largely derived from) the Identity Sample NuGet package*

## Setup
1. Copy the UsersAdmin and RolesAdmin folder to the Views folder
2. Copy the IdentityManagement folder to the root of the web project
3. Find and replace all instances of CustomIdentityManagement with the name of your web project
4. Open the IdentityInitializer.cs file and update the default admin email and password at the top of the class
5. Add the following to the ConfigureAuth(IAppBuilder app) method of the App_Start/Startup.Auth.cs file below the other app settings.

    app.CreatePerOwinContext&lt;ApplicationRoleManager&gt;(ApplicationRoleManager.Create);

## Initialization
1. Ensure that the DefaultConnection in the web.config file is pointing to the desired database
2. Run the app and call the InitIdentity controller (domain.com/InitIdentity).

## Usage
1. To manage users call the UsersAdmin index view (domain.com/UsersAdmin)
2. To manage roles call the RolesAdmin index view (domain.com/RolesAdmin)

@if (Request.IsAuthenticated && User.IsInRole("Admin"))<br/>
{<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;a href="@Url.Action("Index","UsersAdmin")"&g;Users Admin&lt;/a&gt;<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;a href="@Url.Action("Index","RolesAdmin")"&g;Rules Admin&lt;/a&gt;<br/>
}
