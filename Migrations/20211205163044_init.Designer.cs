﻿// <auto-generated />
using System;
using DataApi1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataApi1.Migrations
{
    [DbContext(typeof(MoneyContext))]
    [Migration("20211205163044_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("DataApi1.Models.Currency", b =>
                {
                    b.Property<int>("crId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BanknoteBuying")
                        .HasColumnType("text");

                    b.Property<string>("BanknoteSelling")
                        .HasColumnType("text");

                    b.Property<string>("CrossOrder")
                        .HasColumnType("text");

                    b.Property<string>("CrossRateOther")
                        .HasColumnType("text");

                    b.Property<string>("CrossRateUSD")
                        .HasColumnType("text");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("text");

                    b.Property<string>("CurrencyName")
                        .HasColumnType("text");

                    b.Property<string>("ForexBuying")
                        .HasColumnType("text");

                    b.Property<string>("ForexSelling")
                        .HasColumnType("text");

                    b.Property<string>("Isim")
                        .HasColumnType("text");

                    b.Property<string>("Kod")
                        .HasColumnType("text");

                    b.Property<int?>("Tarih_DatetrId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasColumnType("text");

                    b.Property<int>("tarihId")
                        .HasColumnType("int");

                    b.HasKey("crId");

                    b.HasIndex("Tarih_DatetrId");

                    b.ToTable("currencies");
                });

            modelBuilder.Entity("DataApi1.Models.Tarih_Date", b =>
                {
                    b.Property<int>("trId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bulten_No")
                        .HasColumnType("text");

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.Property<string>("Tarih")
                        .HasColumnType("text");

                    b.HasKey("trId");

                    b.ToTable("tarih_Dates");
                });

            modelBuilder.Entity("DataApi1.Models.Currency", b =>
                {
                    b.HasOne("DataApi1.Models.Tarih_Date", null)
                        .WithMany("Cur")
                        .HasForeignKey("Tarih_DatetrId");
                });

            modelBuilder.Entity("DataApi1.Models.Tarih_Date", b =>
                {
                    b.Navigation("Cur");
                });
#pragma warning restore 612, 618
        }
    }
}