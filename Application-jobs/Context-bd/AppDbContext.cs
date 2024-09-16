using Application_jobs.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
namespace Application_jobs.Context
{
    public class AppDbContext: DbContext // Viene de entity framework y trae metodos para crear la bd con entityframework
    {
        //Configuracion de  clase para contexto de base de datos
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { 
        
        
            
        }

        //set up las entidades para ser agregadas como tablas
        // pasar los nombres de los modelos o entidades a plural, es una convencion para entity framework
        public DbSet<Company> Company { get; set; }
        public DbSet<ApplicationStatus>applicationStatuses { get; set; }
        public DbSet<ApplicationJob> applicationJobs { get; set; }

        //Empezar con modelado de tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //se define la estrutura de la tabla
            modelBuilder.Entity<Company>(table =>
            {
                table.HasKey(col => col.Id);
                table.Property(col => col.Id).UseIdentityColumn().ValueGeneratedOnAdd();
                table.Property(col => col.CompanyName).HasMaxLength(15);
                table.Property(col => col.Code).HasMaxLength(3);
                table.ToTable("Company");

            });

            modelBuilder.Entity<ApplicationStatus>(table =>
            {
                table.HasKey(col => col.Id);
                table.Property(col => col.Id).UseIdentityColumn().ValueGeneratedOnAdd();
                table.Property(col => col.Code).HasMaxLength(3).IsRequired();
                table.Property(col=> col.Description).HasMaxLength(15).IsRequired();
                table.HasData(
                        new ApplicationStatus() { 
                            Id = 1,
                            Description = "APPLIED",
                            Code="C01"
                        },
                        new ApplicationStatus() { 
                            Id=2,
                            Description="IN PROCESS",
                            Code="C02"
                        },
                        new ApplicationStatus() { 
                            Id=3,
                            Description="INTERVIEW",
                            Code="C03"
                        },
                        new ApplicationStatus() { 
                            Id=4,
                            Description="CLOSED",
                            Code="C04"
                        }
                    );
                table.ToTable("ApplicationStatus");

            });

            modelBuilder.Entity<ApplicationJob>(table => {
                table.HasKey(col => col.Id);
                table.Property(col => col.Id).UseIdentityColumn().ValueGeneratedOnAdd();
                table.Property(col => col.CreationDate).IsRequired().HasDefaultValueSql("GETDATE()");
                table.Property(col => col.JobDescription).HasMaxLength(500).IsRequired();
                table.Property(col => col.CompanyId).IsRequired();
                table.Property(col => col.SkillRequest).HasMaxLength(200);
                table.Property(col => col.Interviews);
                table.Property(col => col.TecnicTest);
                table.Property(col => col.Recruter).HasMaxLength(80);

                //clave foraneas
                table.HasOne(col => col.StatusRefence).WithMany(p=> p.ApplicationReference).HasForeignKey(col => col.StatusId);
                table.HasOne(col => col.CompanyRefence).WithMany(p => p.ApplicationReference).HasForeignKey(col => col.CompanyId);

                table.ToTable("ApplicationJob");

            });
               
        }

    }
}

//CREAR MODELADO DE TABLAS
// crear la base de datos
// CREAR CONNECTION STRING EN APPSETTINGS.JSON
//UTILIZAR CONECTION STRING EN PROGRAM.CS (Es la raiz)
// Add-migration para generar la migracion
// Update-Database
//-------------------- para mañana
// En controllers poner el contexto en el constructor
// crear los dtos ya que las entidades no se recomiendan colocar en los controllers ya que estan estan mostrando el estado de la bd


