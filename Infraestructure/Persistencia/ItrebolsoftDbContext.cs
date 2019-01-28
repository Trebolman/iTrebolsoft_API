using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infraestructure.Persistencia
{
    public partial class ItrebolsoftDbContext : DbContext
    {
        public ItrebolsoftDbContext()
        {
        }

        public ItrebolsoftDbContext(DbContextOptions<ItrebolsoftDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TBlog> TBlog { get; set; }
        public virtual DbSet<TImages> TImages { get; set; }
        public virtual DbSet<TProducto> TProducto { get; set; }
        public virtual DbSet<TProyectos> TProyectos { get; set; }
        public virtual DbSet<TUser> TUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source = DANOSHINPC\\SQLEXPRESS; Initial Catalog = Itrebolsoft; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<TBlog>(entity =>
            {
                //entity.HasKey(e => e.PublId)
                //    .HasName("PK_t_blog_1");
                entity.HasKey(e => e.PublId);

                entity.ToTable("t_blog");

                entity.Property(e => e.PublId)
                    .HasColumnName("publ_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkTUserUserId).HasColumnName("fk_t_user_user_id");

                entity.Property(e => e.PublBody)
                    .HasColumnName("publ_body")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PublDate)
                    .HasColumnName("publ_date")
                    .HasColumnType("date");

                entity.Property(e => e.PublDesc)
                    .HasColumnName("publ_desc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PublName)
                    .HasColumnName("publ_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkTUserUser)
                    .WithMany(p => p.TBlog)
                    .HasForeignKey(d => d.FkTUserUserId)
                    .HasConstraintName("FK_t_blog_t_user1");
            });

            modelBuilder.Entity<TImages>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("t_images");

                entity.Property(e => e.ImageId)
                    .HasColumnName("image_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkTBlogPublId).HasColumnName("fk_t_blog_publ_id");

                entity.Property(e => e.FkTProductoProdId).HasColumnName("fk_t_producto_prod_id");

                entity.Property(e => e.FkTProyProyId).HasColumnName("fk_t_proy_proy_id");

                entity.Property(e => e.ImageName)
                    .HasColumnName("image_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkTBlogPubl)
                    .WithMany(p => p.TImages)
                    .HasForeignKey(d => d.FkTBlogPublId)
                    .HasConstraintName("FK_t_images_t_blog");

                entity.HasOne(d => d.FkTProductoProd)
                    .WithMany(p => p.TImages)
                    .HasForeignKey(d => d.FkTProductoProdId)
                    .HasConstraintName("FK_t_images_t_producto");

                entity.HasOne(d => d.FkTProyProy)
                    .WithMany(p => p.TImages)
                    .HasForeignKey(d => d.FkTProyProyId)
                    .HasConstraintName("FK_t_images_t_proyectos");
            });

            modelBuilder.Entity<TProducto>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.ToTable("t_producto");

                entity.Property(e => e.ProdId)
                    .HasColumnName("prod_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkUserUserId).HasColumnName("fk_user_user_id");

                entity.Property(e => e.ProdBrand)
                    .HasColumnName("prod_brand")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdCod)
                    .HasColumnName("prod_cod")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdDesc)
                    .HasColumnName("prod_desc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdName)
                    .HasColumnName("prod_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdPrice)
                    .HasColumnName("prod_price")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdStock)
                    .HasColumnName("prod_stock")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkUserUser)
                    .WithMany(p => p.TProducto)
                    .HasForeignKey(d => d.FkUserUserId)
                    .HasConstraintName("FK_t_producto_t_user");
            });

            modelBuilder.Entity<TProyectos>(entity =>
            {
                entity.HasKey(e => e.ProyId);

                entity.ToTable("t_proyectos");

                entity.Property(e => e.ProyId)
                    .HasColumnName("proy_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkTUserUserId).HasColumnName("fk_t_user_user_id");

                entity.Property(e => e.ProyDate)
                    .HasColumnName("proy_date")
                    .HasColumnType("date");

                entity.Property(e => e.ProyDesc)
                    .HasColumnName("proy_desc")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ProyTitle)
                    .HasColumnName("proy_title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkTUserUser)
                    .WithMany(p => p.TProyectos)
                    .HasForeignKey(d => d.FkTUserUserId)
                    .HasConstraintName("FK_t_proyectos_t_user1");
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("t_user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserAddress)
                    .HasColumnName("user_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasColumnName("user_first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLastname)
                    .IsRequired()
                    .HasColumnName("user_last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserGit)
                    .IsRequired()
                    .HasColumnName("user_git")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasColumnName("user_phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserRole)
                    .HasColumnName("user_role")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserWeb)
                    .HasColumnName("user_web")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
