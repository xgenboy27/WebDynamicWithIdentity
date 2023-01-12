using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationWithIdentity.Models;

namespace WebApplicationWithIdentity.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _db;
        


        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }
        //private async Task CreateUserRoles()
        //{
        //    var RoleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var UserManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


        //    IdentityResult roleResult;
        //    //Adding Addmin Role  
        //    var roleCheck = await RoleManager.RoleExistsAsync("Admin");
        //    if (!roleCheck)
        //    {
        //        //create the roles and seed them to the database  
        //        roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
        //    }

        //    roleCheck = await RoleManager.RoleExistsAsync("Manager");
        //    if (!roleCheck)
        //    {
        //        //create the roles and seed them to the database  
        //        roleResult = await RoleManager.CreateAsync(new IdentityRole("Manager"));
        //    }

        //    //Assign Admin role to the main User here we have given our newly loregistered login id for Admin management  
        //    ApplicationUser user = await UserManager.FindByEmailAsync("syedshanumcain@gmail.com");
        //    var User = new ApplicationUser();
        //    await UserManager.AddToRoleAsync(user, "Admin");


        //    user = await UserManager.FindByEmailAsync("Afraz@gmail.com");
        //    await UserManager.AddToRoleAsync(user, "Manager");

        //}
        public async void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

                
            }
            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Manager")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Guest")).GetAwaiter().GetResult();


                //if roles are not created, then we will create admin user as well

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admindemo@gmail.com",
                    Email = "admindemo@gmail.com",
                    Name = "Demo Admin",
                    PhoneNumber = "1112223333",
                    StreetAddress = "test 123 Ave",
                    State = "IL",
                    PostalCode = "23422",
                    City = "Chicago"
                }, "Admin123*").GetAwaiter().GetResult();

                ApplicationUser Admin = _db.ApplicationUser.FirstOrDefault(u => u.Email == "admindemo@gmail.com");

                _userManager.AddToRoleAsync(Admin, "Admin").GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Managerdemo@gmail.com",
                    Email = "Managerdemo@gmail.com",
                    Name = "Demo Manager",
                    PhoneNumber = "1112223333",
                    StreetAddress = "test 123 Ave",
                    State = "IL",
                    PostalCode = "23422",
                    City = "Chicago"
                }, "Manager123*").GetAwaiter().GetResult();

                ApplicationUser Manager = _db.ApplicationUser.FirstOrDefault(u => u.Email == "Managerdemo@gmail.com");

                _userManager.AddToRoleAsync(Manager, "Manager").GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Guestdemo@gmail.com",
                    Email = "Guestdemo@gmail.com",
                    Name = "Demo Guest",
                    PhoneNumber = "1112223333",
                    StreetAddress = "test 123 Ave",
                    State = "IL",
                    PostalCode = "23422",
                    City = "Chicago"
                }, "Guest123*").GetAwaiter().GetResult();

                ApplicationUser Guest = _db.ApplicationUser.FirstOrDefault(u => u.Email == "Guestdemo@gmail.com");

                _userManager.AddToRoleAsync(Guest, "Guest").GetAwaiter().GetResult();



            }


            return;
        }
    }
}
