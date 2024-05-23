using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoItems.ModelsDatabase;

public partial class TodoItemsContext : DbContext
{
    public TodoItemsContext()
    {
    }

    public TodoItemsContext(DbContextOptions<TodoItemsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TodoItems;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasIndex(e => e.CategoriaId, "IX_Items_CategoriaId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Categoria).WithMany(p => p.Items).HasForeignKey(d => d.CategoriaId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
