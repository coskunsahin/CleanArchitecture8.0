//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using CleanArchitecture.Domain.Entities;
//namespace CleanArchitecture.Infrastructure.Data.Configurations;
//public class InformationConfiguration : IEntityTypeConfiguration<Information>
//{
//    public void Configure(EntityTypeBuilder<Information> builder)
//    {
//        builder.Property(t => t.Sms)
//            .HasMaxLength(200)
//            .IsRequired();

//        //builder
//        //    .OwnsOne(b => b.Email);
//    }
//}

