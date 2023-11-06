

using ArkanoidProyecto.Modelo.Interfaces;
using ArkanoidProyecto.Modelo.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Patron_repositorio
{
    public class Jugador_repositorio : IRepositorio<Jugador>, Icomprobar_repetido<int>, Ilista_figura<Jugador>
    {
        private readonly ContextArkanoid context;
        private Jugador jugador;
        private string path = Path.Combine(Directory.GetCurrentDirectory(), "arkanoid_registro.txt");
        public List<Jugador> listaObjetos { get; set; }

        public Jugador_repositorio(Jugador jugador,ContextArkanoid context)
        {
            this.jugador = jugador;
            listaObjetos = new List<Jugador>();
            this.context = context;
        }

        public Jugador_repositorio()
        {
            listaObjetos = new List<Jugador>();
        }

        public async Task buscar(Jugador entity)
        {
            string[] lines = File.ReadAllLines(path);
            string jugador =
                lines.First(n => n.Contains(entity.JugadorId.ToString())).ToString();
            //Jugador jugador_encontrado = JsonSerializer.Deserialize<Jugador>(jugador);
           // Console.WriteLine(jugador_encontrado.ToString());
        }

        public async Task eliminar(Jugador entity)
        {
            string[] lines = File.ReadAllLines(path);
            string json = "";
            Jugador player;

            json = lines.ToList().
                Where(n => n.Contains(entity.JugadorId.ToString()))
                .Single().ToString();
            //player = JsonSerializer.Deserialize<Jugador>(json);
           // listaObjetos.Remove(player);

            await registrar(listaObjetos);
        }

        public async Task leer()
        {

            string[] lines = File.ReadAllLines(path);
            List<Jugador> player = new List<Jugador>();
            /*
            Action<string[]> action = (s =>
                s.ToList().ForEach
                (
                    indice =>
                        player.Add(JsonSerializer.Deserialize<Jugador>(indice))
                )
                );
            
            action(lines);
            */
            player.ForEach(n => Console.WriteLine(n.ToString()));
        }

        public async Task registrar(Jugador entity)
        {
            string jsonString = string.Empty;

            if (existe())
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    //jsonString = JsonSerializer.Serialize(entity);
                    sw.WriteLine(jsonString);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                   // jsonString = JsonSerializer.Serialize(entity);
                    sw.WriteLine(jsonString);

                }
            }

        }

        public async Task registrar(List<Jugador> entity)
        {
            string jsonString = string.Empty;

            if (existe())
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    foreach (Jugador jugador in entity)

                        //jsonString = JsonSerializer.Serialize(jugador);
                    sw.WriteLine(jsonString);
                }
            }

            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (Jugador jugador in entity)
                    {
                       // jsonString = JsonSerializer.Serialize(jugador);
                        sw.WriteLine(jsonString);
                    }
                }
            }
        }

        public bool repetido(int entity)
        {
            bool encuentra = false;
            return encuentra = listaObjetos.Any(n => n.JugadorId == entity);
        }

        private bool existe()
        {
            if (File.Exists(path))
            {
                return true;
            }
            else { return false; }
        }
    }
}
