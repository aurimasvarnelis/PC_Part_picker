using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Part_picker.Models;

namespace PC_Part_picker.Configurations
{
    public class CompatibilityConfiguration : IEntityTypeConfiguration<Compatibility>
    {
        public void Configure(EntityTypeBuilder<Compatibility> builder)
        {
            builder.HasMany(c => c.Parts).WithOne(pc => pc.Compatibility);
        }
    }
}
