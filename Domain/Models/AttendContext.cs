using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Domain.Models
{
    public partial class AttendContext : DbContext
    {
        public AttendContext()
        {
        }

        public AttendContext(DbContextOptions<AttendContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; } 
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
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
                optionsBuilder.UseSqlServer("Server=.;Database=Attend;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Date });

                entity.ToTable("Attendance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_by");

                entity.Property(e => e.End).HasColumnName("end");

                entity.Property(e => e.Start).HasColumnName("start");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Attendance_Employee");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendance_Student");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrackId).HasColumnName("Track_id");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TrackId)
                    .HasConstraintName("FK_Course_Track");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("Created_date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Ssn).HasColumnName("SSN");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Employee_Role");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseBy).HasColumnName("Response_by");

                entity.Property(e => e.ResponseType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Response_type");

                entity.Property(e => e.StudendId).HasColumnName("studend_id");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ResponseByNavigation)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.ResponseBy)
                    .HasConstraintName("FK_Permission_Employee");

                entity.HasOne(d => d.Studend)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.StudendId)
                    .HasConstraintName("FK_Permission_Student");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.ToTable("Program");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("Created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Ssn).HasColumnName("SSN");

                entity.Property(e => e.TrackActionId).HasColumnName("Track_Action_Id");

                entity.HasOne(d => d.TrackAction)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.TrackActionId)
                    .HasConstraintName("FK_Student_Track_Action");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("Track");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramId).HasColumnName("Program_id");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.ProgramId)
                    .HasConstraintName("FK_Track_Program");
            });

            modelBuilder.Entity<TrackAction>(entity =>
            {
                entity.ToTable("Track_Action");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_date");

                entity.Property(e => e.TrackId).HasColumnName("Track_id");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.TrackActions)
                    .HasForeignKey(d => d.TrackId)
                    .HasConstraintName("FK_Track_Action_Track");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
