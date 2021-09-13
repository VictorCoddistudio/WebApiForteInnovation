using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIForteT.Models;


namespace WebAPIForteT.Data
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        {

        }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<TipoPermiso> TipoPermisos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoPermiso>().HasData(
               new TipoPermiso 
               { 
                   TipoPermisoId =1, 
                   Descripcion="Enfermedad" 
               },
               new TipoPermiso 
               { 
                   TipoPermisoId=2, 
                   Descripcion="Diligencias"
               },
               new TipoPermiso 
               { 
                   TipoPermisoId=3, 
                   Descripcion="Matrimonio"
               },
               new TipoPermiso 
               { 
                   TipoPermisoId=4, 
                   Descripcion="Mudanza"
               }
            );

            
            //PermisoM data = new PermisoM();
              //  data.Id = 2;

            modelBuilder.Entity<Permiso>().HasData(
                

               new Permiso
                {
                    Id=1,
                    NombreEmpleado ="Roberto",
                    ApellidosEmpleado ="Sosa Juarez",
                    TipoPermisoId =1 ,
                    FechaPermiso = Convert.ToDateTime("08-20-2021")
                }                
                ,
                new Permiso
                {
                    Id=2,
                    NombreEmpleado="Nataly",
                    ApellidosEmpleado="Pinales Lopez",
                    TipoPermisoId=1,
                    FechaPermiso = Convert.ToDateTime("12-10-2020")
                },
                new Permiso
                {
                    Id=3,
                    NombreEmpleado="Mateo",
                    ApellidosEmpleado="Sandoval Jaramillo",
                    TipoPermisoId = 4,
                    FechaPermiso = Convert.ToDateTime("07-28-2021")
                }
                ,
                new Permiso
                {
                    Id=4,
                    NombreEmpleado="Karla",
                    ApellidosEmpleado="Rodriguez Gracia",
                    TipoPermisoId = 3,
                    FechaPermiso = Convert.ToDateTime("01-07-2021")
                }
                );

        }
        
    }

}
