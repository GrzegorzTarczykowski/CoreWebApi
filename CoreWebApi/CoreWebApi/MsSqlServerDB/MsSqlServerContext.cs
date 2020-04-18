using System;
using Microsoft.EntityFrameworkCore;
using CoreWebApi.MsSqlServerDB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CoreWebApi.MsSqlServerDB
{
    public partial class MsSqlServerContext : IdentityDbContext
    {
        public MsSqlServerContext()
        {
        }

        public MsSqlServerContext(DbContextOptions<MsSqlServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderService> OrderService { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderVehiclePart> OrderVehiclePart { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Timetable> Timetable { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserOrder> UserOrder { get; set; }
        public virtual DbSet<UserTimetable> UserTimetable { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleBrand> VehicleBrand { get; set; }
        public virtual DbSet<VehicleColour> VehicleColour { get; set; }
        public virtual DbSet<VehicleEngine> VehicleEngine { get; set; }
        public virtual DbSet<VehicleFuel> VehicleFuel { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }
        public virtual DbSet<VehiclePart> VehiclePart { get; set; }
        public virtual DbSet<VehicleType> VehicleType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderId");

                entity.HasIndex(e => e.UserReceiverId)
                    .HasName("IX_UserReceiverId");

                entity.HasIndex(e => e.UserSenderId)
                    .HasName("IX_UserSenderId");

                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_dbo.Message_dbo.Order_OrderId");

                entity.HasOne(d => d.UserReceiver)
                    .WithMany(p => p.MessageUserReceiver)
                    .HasForeignKey(d => d.UserReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Message_dbo.User_UserReceiverId");

                entity.HasOne(d => d.UserSender)
                    .WithMany(p => p.MessageUserSender)
                    .HasForeignKey(d => d.UserSenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Message_dbo.User_UserSenderId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.OrderStatusId)
                    .HasName("IX_OrderStatusId");

                entity.HasIndex(e => e.VehicleId)
                    .HasName("IX_VehicleId");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDateOfRepair).HasColumnType("datetime");

                entity.Property(e => e.StartDateOfRepair).HasColumnType("datetime");

                entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK_dbo.Order_dbo.OrderStatus_OrderStatusId");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Order_dbo.Vehicle_VehicleId");
            });

            modelBuilder.Entity<OrderService>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ServiceId })
                    .HasName("PK_dbo.OrderService");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderId");

                entity.HasIndex(e => e.ServiceId)
                    .HasName("IX_ServiceId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderService)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_dbo.OrderService_dbo.Order_OrderId");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.OrderService)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_dbo.OrderService_dbo.Service_ServiceId");
            });

            modelBuilder.Entity<OrderVehiclePart>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.VehiclePartId })
                    .HasName("PK_dbo.OrderVehiclePart");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderId");

                entity.HasIndex(e => e.VehiclePartId)
                    .HasName("IX_VehiclePartId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderVehiclePart)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_dbo.OrderVehiclePart_dbo.Order_OrderId");

                entity.HasOne(d => d.VehiclePart)
                    .WithMany(p => p.OrderVehiclePart)
                    .HasForeignKey(d => d.VehiclePartId)
                    .HasConstraintName("FK_dbo.OrderVehiclePart_dbo.VehiclePart_VehiclePartId");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PermissiondId)
                    .HasName("PK_dbo.Permission");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.Property(e => e.RefreshTokenId).HasMaxLength(128);

                entity.Property(e => e.ExpiredTime).HasColumnType("datetime");

                entity.Property(e => e.IssuedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Timetable>(entity =>
            {
                entity.Property(e => e.DateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.PermissionId)
                    .HasName("IX_PermissionId");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.User_dbo.Permission_PermissionId");
            });

            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.OrderId })
                    .HasName("PK_dbo.UserOrder");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UserOrder)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_dbo.UserOrder_dbo.Order_OrderId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOrder)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.UserOrder_dbo.User_UserId");
            });

            modelBuilder.Entity<UserTimetable>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TimetableId })
                    .HasName("PK_dbo.UserTimetable");

                entity.HasIndex(e => e.TimetableId)
                    .HasName("IX_TimetableId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.HasOne(d => d.Timetable)
                    .WithMany(p => p.UserTimetable)
                    .HasForeignKey(d => d.TimetableId)
                    .HasConstraintName("FK_dbo.UserTimetable_dbo.Timetable_TimetableId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTimetable)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.UserTimetable_dbo.User_UserId");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.HasIndex(e => e.VehicleEngineId)
                    .HasName("IX_VehicleEngineId");

                entity.HasIndex(e => e.VehicleFuelId)
                    .HasName("IX_VehicleFuelId");

                entity.HasIndex(e => e.VehicleModelId)
                    .HasName("IX_VehicleModelId");

                entity.HasIndex(e => e.VehicleTypeId)
                    .HasName("IX_VehicleTypeId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Vehicle_dbo.User_UserId");

                entity.HasOne(d => d.VehicleEngine)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleEngineId)
                    .HasConstraintName("FK_dbo.Vehicle_dbo.VehicleEngine_VehicleEngineId");

                entity.HasOne(d => d.VehicleFuel)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleFuelId)
                    .HasConstraintName("FK_dbo.Vehicle_dbo.VehicleFuel_VehicleFuelId");

                entity.HasOne(d => d.VehicleModel)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleModelId)
                    .HasConstraintName("FK_dbo.Vehicle_dbo.VehicleModel_VehicleModelId");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .HasConstraintName("FK_dbo.Vehicle_dbo.VehicleType_VehicleTypeId");
            });

            modelBuilder.Entity<VehicleEngine>(entity =>
            {
                entity.Property(e => e.CapacityCcm)
                    .HasColumnName("CapacityCCM")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PowerKw)
                    .HasColumnName("PowerKW")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.HasIndex(e => e.VehicleBrandId)
                    .HasName("IX_VehicleBrandId");

                entity.HasOne(d => d.VehicleBrand)
                    .WithMany(p => p.VehicleModel)
                    .HasForeignKey(d => d.VehicleBrandId)
                    .HasConstraintName("FK_dbo.VehicleModel_dbo.VehicleBrand_VehicleBrandId");
            });

            modelBuilder.Entity<VehiclePart>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });
        }
    }
}
