﻿// <auto-generated />
using System;
using Broker.ApplicationDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Broker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220530075835_init1")]
    partial class init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Broker.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Broker.Models.FeedBack", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SentBy")
                        .HasColumnType("int");

                    b.Property<int?>("SentTo")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("FeedbackId");

                    b.HasIndex("SentBy");

                    b.HasIndex("SentTo");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("Broker.Models.Invite", b =>
                {
                    b.Property<int>("InviteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("SentBy")
                        .HasColumnType("int");

                    b.Property<int?>("SentTo")
                        .HasColumnType("int");

                    b.HasKey("InviteId");

                    b.HasIndex("PostId");

                    b.HasIndex("SentBy");

                    b.HasIndex("SentTo");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("Broker.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("PaymentFinished")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("SentBy")
                        .HasColumnType("int");

                    b.Property<int?>("SentTo")
                        .HasColumnType("int");

                    b.Property<double>("Tip")
                        .HasColumnType("float");

                    b.HasKey("PaymentId");

                    b.HasIndex("SentBy");

                    b.HasIndex("SentTo");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Broker.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PostUserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int?>("TakenBy")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("PostUserId");

                    b.HasIndex("TakenBy");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Broker.Models.PostCategory", b =>
                {
                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("Broker.Models.PostImage", b =>
                {
                    b.Property<int>("PostImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("PostImageId");

                    b.HasIndex("PostId");

                    b.ToTable("PostImages");
                });

            modelBuilder.Entity("Broker.Models.Tags", b =>
                {
                    b.Property<int>("TagsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ForPost")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("TagsId");

                    b.HasIndex("ForPost");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Broker.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("type").HasValue("User");
                });

            modelBuilder.Entity("Broker.Models.Agent", b =>
                {
                    b.HasBaseType("Broker.Models.User");

                    b.Property<long>("AccountNr")
                        .HasColumnType("bigint");

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<double>("Income")
                        .HasColumnType("float");

                    b.Property<double>("Outcome")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Agent");
                });

            modelBuilder.Entity("Broker.Models.SimpleUser", b =>
                {
                    b.HasBaseType("Broker.Models.User");

                    b.HasDiscriminator().HasValue("SimpleUser");
                });

            modelBuilder.Entity("Broker.Models.FeedBack", b =>
                {
                    b.HasOne("Broker.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("SentBy");

                    b.HasOne("Broker.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("SentTo");
                });

            modelBuilder.Entity("Broker.Models.Invite", b =>
                {
                    b.HasOne("Broker.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("Broker.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("SentBy");

                    b.HasOne("Broker.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("SentTo");
                });

            modelBuilder.Entity("Broker.Models.Payment", b =>
                {
                    b.HasOne("Broker.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("SentBy");

                    b.HasOne("Broker.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("SentTo");
                });

            modelBuilder.Entity("Broker.Models.Post", b =>
                {
                    b.HasOne("Broker.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("PostUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Broker.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("TakenBy");
                });

            modelBuilder.Entity("Broker.Models.PostCategory", b =>
                {
                    b.HasOne("Broker.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Broker.Models.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Broker.Models.PostImage", b =>
                {
                    b.HasOne("Broker.Models.Post", "Post")
                        .WithMany("Images")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("Broker.Models.Tags", b =>
                {
                    b.HasOne("Broker.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("ForPost");
                });
#pragma warning restore 612, 618
        }
    }
}
