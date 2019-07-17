//var roleManager = new RoleManager<IdentityRole>(
//    new RoleStore<IdentityRole>(context));

//if (!context.Roles.Any(r => r.Name == "Admin"))
//{
//    roleManager.Create(new IdentityRole { Name = "Admin" });
//}

//  <> = Generic arguments

//userManager.Create(new ApplicationUser()
//{
//    UserName = "guest@myblog.Com",
//    Email = "guest@myblog.com",
//}, "P@ssword");

//Use usermanager to get signed in users id, compare them, if not = prevent action

//Html.Raw(Item.Body)