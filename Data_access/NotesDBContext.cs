using Data_access.Entities;
using Data_access.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access
{
    public class NotesDBContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"workstation id=NotesDataB.mssql.somee.com;packet size=4096;user id=Oleksandrowicz_SQLLogin_1;pwd=raz9464klt;data source=NotesDataB.mssql.somee.com;persist security info=False;initial catalog=NotesDataB");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Note>().Property(n => n.MessageNote).HasMaxLength(200).IsRequired();
            modelBuilder.SeedNotes();
            //MessageBox.Show("Hello");
            
        }
    }
}
