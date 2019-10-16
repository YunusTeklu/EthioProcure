using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace EthioProcure.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string firstName { get; set; }

        [Required]
        [StringLength(255)]
        public string lastName { get; set; }

        [Required]
        [StringLength(255)]
        public string orgName { get; set; }

        [Required]
        public string role { get; set; }

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
        public DbSet<Organization> org { get; set; }
        public DbSet<Contractor> contr { get; set; }
        public DbSet<Consultant> cons { get; set; }
        public DbSet<PublicBody> pubo { get; set; }
        public DbSet<Supplier> sup { get; set; }
        public DbSet<Employee> emp { get; set; }
        public DbSet<Material> materials { get; set; }
        public DbSet<Tender> tenders { get; set; }
        public DbSet<Bid> bid { get; set; }
        public DbSet<Order> ord { get; set; }
        public DbSet<Project> pro { get; set; }
        public DbSet<AdvancePayement> adv { get; set; }
        public DbSet<Transaction> trans { get; set; }
        public DbSet<EvaluateBid> evaluateBid { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}