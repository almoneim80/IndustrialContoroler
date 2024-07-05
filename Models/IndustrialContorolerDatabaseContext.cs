using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IndustrialContoroler.Models
{
    public partial class IndustrialContorolerDatabaseContext : IdentityDbContext<AppUsers>
    {
        public IndustrialContorolerDatabaseContext()
        {
        }

        public IndustrialContorolerDatabaseContext(DbContextOptions<IndustrialContorolerDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgentsPoint> AgentsPoints { get; set; } = null!;
        public virtual DbSet<Attachment> Attachments { get; set; } = null!;
        public virtual DbSet<AttachmentType> AttachmentTypes { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<CastDatum> CastData { get; set; } = null!;
        public virtual DbSet<Facility> Facilities { get; set; } = null!;
        public virtual DbSet<HelpMaterial> HelpMaterials { get; set; } = null!;
        public virtual DbSet<Machine> Machines { get; set; } = null!;
        
        public virtual DbSet<ProCapacity> ProCapacities { get; set; } = null!;
        public virtual DbSet<RelevantDoc> RelevantDocs { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<RequestTraffic> RequestTraffics { get; set; } = null!;
        public virtual DbSet<RowMaterial> RowMaterials { get; set; } = null!;
        public virtual DbSet<SafetySecurity> SafetySecurities { get; set; } = null!;
        public virtual DbSet<SecondaryAct> SecondaryActs { get; set; } = null!;
        public virtual DbSet<SiteReason> SiteReasons { get; set; } = null!;
        public virtual DbSet<Temporary> Temporaries { get; set; } = null!;
        public virtual DbSet<Transportation> Transportations { get; set; } = null!;
        public virtual DbSet<VisitsTraffic> VisitsTraffics { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;


        public virtual DbSet<VwUser> VwUsers { get; set; } = null!;
        //add example category//************
       

        //add example Logcategory

        public virtual DbSet<Noti> Notis { get; set; } = null!;
        public virtual DbSet<LogFieldVisitForms> LogFieldVisitForms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MSI\\SQL;Database=IndustrialContorolerDatabase;Trusted_Connection = yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AgentsPoint>(entity =>
            {
                entity.HasKey(e => e.ApId)
                    .HasName("PK__agentsPo__C40F0A854A571820");

                entity.Property(e => e.ApNotes).HasDefaultValueSql("('لاتوجد ملاحظات')");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.AgentsPoints)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityAgentsPoints");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasKey(e => e.AtId)
                    .HasName("PK__Attachme__61F955B0B84DF688");

                entity.HasOne(d => d.Att)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.AttId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttachmentTypeAttachments");

                entity.HasOne(d => d.Re)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.ReId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestsAttachments");
            });

            modelBuilder.Entity<AttachmentType>(entity =>
            {
                entity.HasKey(e => e.AttId)
                    .HasName("PK__attachme__4831C98D604648A8");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.BuId)
                    .HasName("PK__Building__A53BF20F1FDEA98B");

                entity.Property(e => e.BuNotes).HasDefaultValueSql("('لاتوجد ملاحظات')");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityBuildings");
            });

            modelBuilder.Entity<CastDatum>(entity =>
            {
                entity.HasKey(e => e.CdId)
                    .HasName("PK__castData__D552B11E20D67763");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.CastData)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityCastData");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.HasKey(e => e.FaId)
                    .HasName("PK__Facility__BD0780CCBCC58253");

                entity.HasOne(d => d.ReFormNoNavigation)
                    .WithOne(p => p.Facility)
                    .HasPrincipalKey<Request>(p => p.ReFormNo)
                    .HasForeignKey<Facility>(d => d.ReFormNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityRequests");
            });

            modelBuilder.Entity<HelpMaterial>(entity =>
            {
                entity.HasKey(e => e.HmId)
                    .HasName("PK__helpMate__842BCD5BBE7C0D47");

                entity.Property(e => e.HmNotes).HasDefaultValueSql("('لاتوجد ملاحظات')");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.HelpMaterials)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityHelpMaterials");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.HasKey(e => e.MaId)
                    .HasName("PK__Machine__0FE6627F9DD47CE6");

                entity.Property(e => e.MaNotes).HasDefaultValueSql("('لاتوجد ملاحظات')");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityMachines");
            });

            //modelBuilder.Entity<Notification>(entity =>
            //{
            //    entity.HasKey(e => e.NoId)
            //        .HasName("PK__Notifica__E2D318E83F3B1F73");

            //    entity.HasOne(d => d.RequestTraffic)
            //        .WithMany(p => p.Notifications)
            //        .HasForeignKey(d => d.RequestTrafficId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_requestTrafficNotifications");
            //});

            modelBuilder.Entity<ProCapacity>(entity =>
            {
                entity.HasKey(e => e.PcProductId)
                    .HasName("PK__proCapac__A38A36234161F13B");

                entity.Property(e => e.PcNotes).HasDefaultValueSql("('لاتوجد ملاحظات')");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.ProCapacities)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityProductionCapacity");
            });

            modelBuilder.Entity<RelevantDoc>(entity =>
            {
                entity.HasKey(e => e.RdId)
                    .HasName("PK__relevant__D3D102FA6D3F5895");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.RelevantDocs)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityRelevantDocuments");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.ReId)
                    .HasName("PK__Request__1A4B5594E26764D9");
            });

            modelBuilder.Entity<RequestTraffic>(entity =>
            {
                entity.HasKey(e => e.RtId)
                    .HasName("PK__requestT__EF871B05A6AC9F69");

                entity.HasOne(d => d.Re)
                    .WithMany(p => p.RequestTraffics)
                    .HasForeignKey(d => d.ReId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestsRequestTraffic");
            });

            modelBuilder.Entity<RowMaterial>(entity =>
            {
                entity.HasKey(e => e.RmId)
                    .HasName("PK__rowMater__62C24217C2AA7444");

                entity.Property(e => e.RmNotes).HasDefaultValueSql("('لاتوجد ملاحظات')");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.RowMaterials)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityRowMaterials");
            });

            modelBuilder.Entity<SafetySecurity>(entity =>
            {
                entity.HasKey(e => e.SsId)
                    .HasName("PK__SafetySe__A444DACAACCB338D");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.SafetySecurities)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilitySafetySecurity");
            });

            modelBuilder.Entity<SecondaryAct>(entity =>
            {
                entity.HasKey(e => e.SaId)
                    .HasName("PK__secondar__FE003E7225435974");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.SecondaryActs)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilitySecondaryAct");
            });

            modelBuilder.Entity<SiteReason>(entity =>
            {
                entity.HasKey(e => e.SrId)
                    .HasName("PK__siteReas__5C9F948102D1C6EC");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.SiteReasons)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilitySiteReasons");
            });

            modelBuilder.Entity<Transportation>(entity =>
            {
                entity.HasKey(e => e.TrId)
                    .HasName("PK__Transpor__ABD6A7503771012A");

                entity.Property(e => e.TrNotes).HasDefaultValueSql("('لاتوجد ملاحظات')");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.Transportations)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityTransportation");
            });

            modelBuilder.Entity<VisitsTraffic>(entity =>
            {
                entity.HasKey(e => e.VtId)
                    .HasName("PK__visitsTr__9458D67B52050576");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.VisitsTraffics)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityVisitsTraffic");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.WoId)
                    .HasName("PK__Worker__DD93F5F884D36C53");

                entity.Property(e => e.WoNotes).HasDefaultValueSql("('لاتوجد ملاحظات')");

                entity.HasOne(d => d.Fa)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.FaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityWorkers");
            });

            modelBuilder.Entity<VwUser>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VwUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
