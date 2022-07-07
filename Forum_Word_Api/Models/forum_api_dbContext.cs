using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace forum_api.Models
{
    public partial class forum_api_dbContext : DbContext
    {
        public forum_api_dbContext()
        {
        }

        public forum_api_dbContext(DbContextOptions<forum_api_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=forum_api_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TopicIdTopic })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("Comment");

                entity.HasIndex(e => e.TopicIdTopic, "fk_Comment_Topic_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TopicIdTopic).HasColumnName("Topic_idTopic");

                entity.Property(e => e.Contenue)
                    .HasMaxLength(256)
                    .HasColumnName("contenue");

                entity.Property(e => e.Createur)
                    .HasMaxLength(50)
                    .HasColumnName("createur");

                entity.Property(e => e.DateCreation).HasColumnName("date_creation");

                entity.Property(e => e.DerniereModification).HasColumnName("derniere_modification");

                entity.HasOne(d => d.TopicIdTopicNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TopicIdTopic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comment_Topic");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Createur)
                    .HasMaxLength(50)
                    .HasColumnName("createur");

                entity.Property(e => e.DateCreation).HasColumnName("date_creation");

                entity.Property(e => e.DateModification).HasColumnName("date_modification");

                entity.Property(e => e.Titre)
                    .HasMaxLength(150)
                    .HasColumnName("titre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
