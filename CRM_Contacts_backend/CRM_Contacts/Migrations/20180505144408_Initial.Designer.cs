﻿// <auto-generated />
using CRM_Contacts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CRM_Contacts.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20180505144408_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRM_Contacts.Models.ContactModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateAt");

                    b.Property<int>("CreateBy");

                    b.Property<string>("Email");

                    b.Property<string>("Founder");

                    b.Property<string>("LinkCV");

                    b.Property<string>("Name");

                    b.Property<int?>("OrderId");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Recommender");

                    b.Property<string>("Source");

                    b.Property<string>("Status");

                    b.Property<DateTime>("UpdateAt");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CRM_Contacts.Models.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CRM_Contacts.Models.ContactModel", b =>
                {
                    b.HasOne("CRM_Contacts.Models.OrderModel", "Order")
                        .WithMany("Contacts")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
