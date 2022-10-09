using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastructures.DataLayer.Tags
{
    internal class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(50);
        }
    }
}
