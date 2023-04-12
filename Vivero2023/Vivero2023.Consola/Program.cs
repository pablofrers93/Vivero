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
            GetAllPlantsWithType();
          
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
