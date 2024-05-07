﻿using LyCilph.AwesomeToDo.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LyCilph.AwesomeToDo.Infrastructure.Data;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(p => p.Name)
               .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
               .IsRequired();
    }
}