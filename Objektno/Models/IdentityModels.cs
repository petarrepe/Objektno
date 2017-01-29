using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Objektno.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<KonobApp.Model.Models.CaffeModel> CaffeModels { get; set; }

        public System.Data.Entity.DbSet<KonobApp.Model.Models.UserModel> UserModels { get; set; }

        public System.Data.Entity.DbSet<KonobApp.Model.Models.WaiterModel> WaiterModels { get; set; }

        public System.Data.Entity.DbSet<KonobApp.Model.Models.TableModel> TableModels { get; set; }

        public System.Data.Entity.DbSet<KonobApp.Model.Models.ArticleModel> ArticleModels { get; set; }

        public System.Data.Entity.DbSet<KonobApp.Model.Models.CategoryModel> CategoryModels { get; set; }

        public System.Data.Entity.DbSet<KonobApp.Model.Models.ArticleInCaffeModel> ArticleInCaffeModels { get; set; }

        public System.Data.Entity.DbSet<KonobApp.Model.Models.ArticleReceiptModel> ArticleReceiptModels { get; set; }

        public System.Data.Entity.DbSet<KonobApp.Model.Models.ReceiptModel> ReceiptModels { get; set; }

        public System.Data.Entity.DbSet<KonobApp.Model.Models.PaymentMethodModel> PaymentMethodModels { get; set; }
    }
}