using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivero2023.Datos;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using Vivero2023.Datos.DTOs.Planta;

namespace Vivero2023.Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            //GetAllPlants();
            //GetAllPlantsWithType();
            //DeleteBorrameTipoDeEnvase();
            //BorrarElBorrame();
            //AsignarEnvasesALasPlantas();
            //CambiarPreciosDeHelechos();
            //MostrarPlantasConTodosLosTipos();
            //ListarPlantasEnObjetoAnonimo();
            //ListarPlantasConDTO();
            PlantasAgrupadasPorTipoDePlanta();

            Console.ReadLine();

        }

        private static void PlantasAgrupadasPorTipoDePlanta()
        {
            using (var context = new ViveroDbContext())
            {
                var grupos = context.Plantas.GroupBy(p => p.TipoDePlantaId);
                
                foreach (var grupo in grupos)
                {
                    var tipoDePlanta = context.TiposDePlantas.SingleOrDefault(t => t.TipoDePlantaId == grupo.Key);
                    Console.WriteLine($"{grupo.Key} - {tipoDePlanta.Descripcion} {grupo.Count()}");
                    
                    foreach (var planta in grupo)
                    {
                        Console.WriteLine($"{planta.Descripcion}");
                    }
                    Console.WriteLine("Presione tecla para continuar");
                    Console.WriteLine(); 
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }

        private static void ListarPlantasConDTO()
        {
            using (var context = new ViveroDbContext())
            {
                var lista = context.Plantas
                    .Include(p => p.TipoDePlanta)
                    .Include(p => p.TipoDeEnvase)
                    .Select(p => new PlantaListDto
                    {
                        PlantaId = p.PlantaId,
                        Descripcion = p.Descripcion,
                        TipoPlanta = p.TipoDePlanta.Descripcion,
                        TipoEnvase = p.TipoDeEnvase.Descripcion
                    })
                    .ToList();

                foreach (var item in lista)
                {
                    Console.WriteLine($"{item.Descripcion} - {item.TipoPlanta} - {item.TipoEnvase}");
                }
            }
            Console.ReadLine();
        }

        private static void ListarPlantasEnObjetoAnonimo()
        {
            using (var context = new ViveroDbContext())
            {
                var lista = context.Plantas
                    .Include(p => p.TipoDePlanta)
                    .Include(p => p.TipoDeEnvase)
                    .Select(p => new
                    {
                        Planta = p.Descripcion,
                        Tipo = p.TipoDePlanta.Descripcion,
                        Envase = p.TipoDeEnvase.Descripcion
                    })
                    .ToList();

                foreach (var item in lista)
                {
                    Console.WriteLine($"{item.Planta} - {item.Tipo} - {item.Envase}");
                }
            }
            Console.ReadLine();
        }

        private static void MostrarPlantasConTodosLosTipos()
        {
            using (var context = new ViveroDbContext())
            {
                var lista = context.Plantas
                    .Include(p => p.TipoDePlanta)
                    .Include(p => p.TipoDeEnvase)
                    .ToList();

                foreach (var item in lista)
                {
                    Console.WriteLine($"{item.Descripcion} - {item.TipoDePlanta.Descripcion} - {item.TipoDeEnvase.Descripcion}");
                }
            }
            Console.ReadLine();
        }

        private static void CambiarPreciosDeHelechos()
        {
            using (var context = new ViveroDbContext())
            {
                var listaHelechos = context.Plantas
                    .Where(p => p.Descripcion.Contains("helecho"))
                    .ToList();

                if (listaHelechos.Count > 0) 
                {
                    foreach (var item in listaHelechos)
                    {
                        var precioCosto = item.PrecioCosto * 1.1m;
                        var precioVenta = precioCosto * 1.5m;
                        Console.WriteLine($"{item.Descripcion} - {item.PrecioCosto} - {precioCosto} - {item.PrecioVenta} - {precioVenta}");
                        item.PrecioVenta = precioVenta;
                        item.PrecioCosto = precioCosto;
                    }
                    context.SaveChanges();
                }

            }
            Console.ReadLine();
        }

        private static void AsignarEnvasesALasPlantas()
        {
            var cambiosEfectuados = 0;
            using (var context = new ViveroDbContext())
            {
                var lista = new List<(string planta, string envase)>()
                {
                    ("Helecho", "Maseta Chica"),
                    ("Cactus", "Maseta Mediana"),
                    ("Arbol", "Maseta Grande"),
                    ("Palmera", "Maseta Grande")
                };
                
                foreach (var item in lista)
                {
                    var listaPlantas = context.Plantas
                        .Where(p=>p.Descripcion.Contains(item.planta)).ToList();
                    
                    if (listaPlantas.Count()>0)
                    {
                        var tipoDeEnvaseInDb = context.TiposDeEnvases
                            .SingleOrDefault(t => t.Descripcion == item.envase);

                        if (tipoDeEnvaseInDb!=null)
                        {
                            foreach (var planta in listaPlantas)
                            {
                                planta.TipoDeEnvaseId = tipoDeEnvaseInDb.TipoDeEnvaseId;
                                cambiosEfectuados++;
                            }
                        }
                    }
                }
                context.SaveChanges();
                Console.WriteLine($" {cambiosEfectuados} cambios realizados");
            }
            Console.ReadLine();
        }

        private static void BorrarElBorrame()
        {
            using (var context = new ViveroDbContext())
            {
                var tipoEnvaseInDb = context.TiposDeEnvases
                    .SingleOrDefault(t => t.Descripcion.Contains("Borrame"));
                if (tipoEnvaseInDb == null)
                {
                    Console.WriteLine("Tipo de envase inexistente");
                    return;
                }
                else
                {
                    if (context.Plantas.Any(p => p.TipoDeEnvaseId == tipoEnvaseInDb.TipoDeEnvaseId))
                    {
                        var listaPlantas = context.Plantas
                            .Where(p=>p.TipoDeEnvaseId==tipoEnvaseInDb.TipoDeEnvaseId)
                            .ToList();
                        foreach (var item in listaPlantas)
                        {
                            Console.WriteLine($"Confirma la baja de {item.Descripcion}?");
                            var resp = Console.ReadLine();
                            if (resp.ToUpper()=="S")
                            {
                                context.Plantas.Remove(item);
                            }
                        }
                        context.TiposDeEnvases.Remove(tipoEnvaseInDb);
                        context.SaveChanges();
                        Console.WriteLine("Baja efectuada con éxito");
                    }
                    else
                    {
                        context.TiposDeEnvases.Remove(tipoEnvaseInDb);
                        context.SaveChanges();
                        Console.WriteLine("Baja efectuada");
                    }

                }
            }
            Console.ReadLine();
        }

        private static void DeleteBorrameTipoDeEnvase()
        {
            try
            {
                using (var context = new ViveroDbContext())
                {
                    var tipoDeEnvaseInDb = context.TiposDeEnvases
                        .SingleOrDefault(t => t.Descripcion.Contains("Bolsa"));
                    if (tipoDeEnvaseInDb == null)
                    {
                        Console.WriteLine("Tipo de envase inexistente");
                        return;
                    }
                    else
                    {
                        if (context.Plantas.Any(p => p.TipoDeEnvaseId == tipoDeEnvaseInDb.TipoDeEnvaseId))
                        {
                            Console.WriteLine("Plantas con ese tipo de envase, baja denegada...");
                        }
                        else
                        {
                            context.TiposDeEnvases.Remove(tipoDeEnvaseInDb);
                            context.SaveChanges();
                            Console.WriteLine("Baja efectuada");
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("REFERENCE"))
                {
                    Console.WriteLine("Registros relacionados, baja denegada...");
                }
                else
                {
                    Console.WriteLine("Otro error");
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
