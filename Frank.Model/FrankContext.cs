using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Frank.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using Frank.Model;

namespace Frank.Model
{
    public class FrankContext : DbContext
    {
        public FrankContext()
            : base("Name=FrankContext")
        {
            //sử dụng cho việc unit test
            Database.SetInitializer<FrankContext>(null);
            this.Database.CommandTimeout = 60;
        }
        public DbSet<Attribute_Product> Attribute_Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ShopCart> ShopCart { get; set; }
        public DbSet<Order_Address> Order_Address { get; set; }
        public static FrankContext Create()
        {
            return new FrankContext();
        }
        //public override int SaveChanges()
        //{
        //    var modifiedEntries = ChangeTracker.Entries()
        //        .Where(x => x.Entity is IAuditableEntity
        //            && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

        //    foreach (var entry in modifiedEntries)
        //    {
        //        IAuditableEntity entity = entry.Entity as IAuditableEntity;
        //        if (entity != null)
        //        {
        //            string identityName = Thread.CurrentPrincipal.Identity.Name;
        //            var userId = this.Users.Where(x => x.UserName == identityName).Select(x => x.Id).FirstOrDefault();

        //            DateTime now = DateTime.Now;
        //            if (entry.State == System.Data.Entity.EntityState.Added)
        //            {
        //                entity.CreatedBy = identityName;
        //                entity.CreatedDate = now;
        //                entity.CreatedID = userId;
        //            }
        //            else
        //            {
        //                base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
        //                base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        //            }
        //            entity.UpdatedBy = identityName;
        //            entity.UpdatedDate = now;
        //            entity.UpdatedID = userId;
        //        }
        //    }

        //    return base.SaveChanges();
        //}
    }
}
