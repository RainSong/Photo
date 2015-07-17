using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Photo.Model;

namespace Photo.DAL
{
    public class PhotoContext : DbContext
    {
        public PhotoContext() : base("Default") { }

        public virtual DbSet<FileInfo> FileInfos { get; set; }
        public virtual DbSet<PageFile> PageFiles { get; set; }
        public virtual DbSet<PageInfo> PageInfos { get; set; }
        public virtual DbSet<PageTag> PageTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<URL> urls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileInfo>()
                .Property(e => e.md5)
                .IsUnicode(false);

            modelBuilder.Entity<FileInfo>()
                .Property(e => e.extension)
                .IsUnicode(false);

            modelBuilder.Entity<FileInfo>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<FileInfo>()
                .Property(e => e.path)
                .IsUnicode(false);

            modelBuilder.Entity<PageInfo>()
                .Property(e => e.encoding)
                .IsUnicode(false);

            modelBuilder.Entity<PageInfo>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<PageInfo>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<PageInfo>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.tag)
                .IsUnicode(false);

            modelBuilder.Entity<URL>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<URL>()
                .Property(e => e.md5)
                .IsUnicode(false);
        }
    }
}
