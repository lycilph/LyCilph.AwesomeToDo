using LyCilph.AwesomeToDo.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LyCilph.AwesomeToDo.Infrastructure.Data;

public class ToDoConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.Property(t => t.Title)
               .IsRequired();
    }
}
