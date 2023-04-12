using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivero2023.Datos;
using System.Data.Entity;

namespace Vivero2023.Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            //GetAllPlants();
            //GetAllPlantsWithType();
            DeleteBorrameTipoDeEnvase();
          

            Console.ReadLine();

        }

        private static void DeleteBorrameTipoDeEnvase()
        {
            using (var context = new ViveroDbContext())
            {
                var tipoDeEnvaseInDb = context.TiposDeEnvases
                    .SingleOrDefault(t => t.Descripcion.Contains("Borrame"));
                if (tipoDeEnvaseInDb == null )
                {
                    Console.WriteLine("Tipo de envase inexistente");
                    return;
                }
                var listaPlantas = context.Plantas.Where(p => p.TipoDeEnvaseId == tipoDeEnvaseInDb.TipoDeEnvaseId).ToList();

                foreach (var item in listaPlantas) 
                {
                    Console.WriteLine(item.Descripcion);
                }
                Console.Write("confirma? s/n");
                var respuesta = Console.ReadLine();
                if (respuesta.ToUpper()=="N")
                {
                    Console.WriteLine("Baja cancelada por el usuario");
                    return;
                }
                else
                {
                    context.TiposDeEnvases.Remove(tipoDeEnvaseInDb);
                    context.SaveChanges();
                    Console.WriteLine("Baja efectuada");
                }
            }
            Console.ReadLine(); 
        }

        private static void GetAllPlantsWithType()
        {
            using (var context = new ViveroDbContext())
            {
                context.Database.Log = Console.WriteLine;
                var listaPlantas = context.Plantas.Include(p=>p.TipoDePlanta).ToList();    

                foreach (var item in listaPlantas) 
                {
                    Console.WriteLine($"{item.Descripcion} - {item.TipoDePlanta.Descripcion}");  
                }
            }
        }

        private static void GetAllPlants()
        {
            using (var context = new ViveroDbContext())
            {
                var listaPlantas = context.Plantas.ToList();

                foreach (var planta in listaPlantas)
                {
                    Console.WriteLine(planta.Descripcion);
                }
            }
        }
    }
}
