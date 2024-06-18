//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using CleanArchitecture.Domain.Entities;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;

//namespace CleanArchitecture.Infrastructure.Data.Configurations;
//public class DemandsConfiguration : IEntityTypeConfiguration<Demand>
//{
//    public void Configure(EntityTypeBuilder<Demand> builder)
//    {
//        builder.Property(t => t.Unit)
//            .HasMaxLength(200)
//            .IsRequired();
//    }
//}
