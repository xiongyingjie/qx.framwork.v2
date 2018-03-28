
using Microsoft.EntityFrameworkCore;
using erp.invoicing;
using xyj.core.Utility;
namespace erp.invoicing.Entity
{
 public partial class MyContext : DbContext
    {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbUtility.SqlSeverConnString("erp.invoicing"));
        }
        
public virtual DbSet<pay_record> pay_record { get; set; }
public virtual DbSet<in_store_order> in_store_order { get; set; }
public virtual DbSet<product_unit> product_unit { get; set; }
public virtual DbSet<category_attr> category_attr { get; set; }
public virtual DbSet<brand> brand { get; set; }
public virtual DbSet<product_type> product_type { get; set; }
public virtual DbSet<in_store_record> in_store_record { get; set; }
public virtual DbSet<invoicing_order> invoicing_order { get; set; }
public virtual DbSet<category_attr_option> category_attr_option { get; set; }
public virtual DbSet<org_storage_product> org_storage_product { get; set; }
public virtual DbSet<category_attr_type> category_attr_type { get; set; }
public virtual DbSet<category> category { get; set; }
public virtual DbSet<product_extent_attr_value> product_extent_attr_value { get; set; }
public virtual DbSet<in_store_order_item> in_store_order_item { get; set; }
public virtual DbSet<sell_order> sell_order { get; set; }
public virtual DbSet<customer> customer { get; set; }
public virtual DbSet<provider> provider { get; set; }
public virtual DbSet<org_storage> org_storage { get; set; }
public virtual DbSet<product> product { get; set; }
public virtual DbSet<invoicing_order_type> invoicing_order_type { get; set; }
public virtual DbSet<product_combine> product_combine { get; set; }
public virtual DbSet<product_combine_detail> product_combine_detail { get; set; }
public virtual DbSet<invoicing_order_state> invoicing_order_state { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
  }
}
