using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Domain.Models
{
    public partial class ITIAttendanceContext : DbContext
    {
        public ITIAttendanceContext()
        {
        }

        public ITIAttendanceContext(DbContextOptions<ITIAttendanceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Employee> Emplyees { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<TrackAction> TrackActions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ITIAttendance;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.Date })
                    .HasName("PK_Attendees_1");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendees_Emplyee");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Attendees)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendees_Student");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RoleId).HasColumnName("Role_id");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Emplyee_Emplyee");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Emplyees)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Emplyee_Role");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Note)
                    .HasColumnName("Note")
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ResponseBy).HasColumnName("Response_by");

                entity.Property(e => e.ResponseDate)
                    .HasColumnType("date")
                    .HasColumnName("Response_Date");

                entity.Property(e => e.ResponseType).HasColumnName("Response_type");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.HasOne(d => d.ResponseByNavigation)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.ResponseBy)
                    .HasConstraintName("FK_Permission_Emplyee");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_Student");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.ToTable("Program");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("SSN");

                entity.Property(e => e.Telephone).HasMaxLength(50);

                entity.Property(e => e.TrackActionId).HasColumnName("Track_Action_ID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Student_Emplyee");

                entity.HasOne(d => d.TrackAction)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.TrackActionId)
                    .HasConstraintName("FK_Student_Track_Action");

                entity.Property(s => s.SerialNumber).HasColumnName(nameof(Student.SerialNumber));
            });
            modelBuilder.Entity<Student>()
                 .HasIndex(st => st.Ssn)
                   .IsUnique();
            modelBuilder.Entity<Student>()
                 .HasIndex(st => st.SerialNumber)
                 .IsUnique();
            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("Track");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProgramId).HasColumnName("Program_id");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Track_Program");
            });

            modelBuilder.Entity<TrackAction>(entity =>
            {
                entity.ToTable("Track_Action");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.End)
                    .HasColumnType("date")
                    .HasColumnName("end");

                entity.Property(e => e.Start).HasColumnType("date");

                entity.Property(e => e.TrackId).HasColumnName("Track_Id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.TrackActions)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Track_Action_Track");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
