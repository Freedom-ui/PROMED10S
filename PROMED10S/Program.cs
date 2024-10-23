using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gestion_de_Jugadores_de_Futbol
{
    internal class Program
    {
        public class Jugador
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
            public string Pais { get; set; }
            public string Club { get; set; }
            public string Posicion { get; set; }
            public int Partidos { get; set; }
            public int Goles { get; set; }
            public int Asistencias { get; set; }
            public long ValorMercado { get; set; }
        }

        static void Main(string[] args)
        {
            List<Jugador> jugadores = new List<Jugador>();

            MostrarMenu(jugadores);
        }

        //Funcion para la muestra y el control del menu
        static void MostrarMenu(List<Jugador> jugadores)
        {
            int opcion;
            bool opcionValida = false;

            do
            {
                Console.WriteLine("╔═════════════════════════════════════════╗");
                Console.WriteLine("║                PROMED10S                ║");
                Console.WriteLine("╠═════════════════════════════════════════╣");
                Console.WriteLine("║1•Agregar jugador                        ║");
                Console.WriteLine("║2•Modificar jugador                      ║");
                Console.WriteLine("║3•Eliminar jugador                       ║");
                Console.WriteLine("║4•Listar jugadores                       ║");
                Console.WriteLine("║5•Buscar jugador                         ║");
                Console.WriteLine("║6•Rankings                               ║");
                Console.WriteLine("║7•Salir                                  ║");
                Console.WriteLine("╚═════════════════════════════════════════╝");

                Console.Write("•Ingrese una opción: ");
                string entrada = Console.ReadLine();

                //Verifica que la entrada sea un numero valido
                opcionValida = int.TryParse(entrada, out opcion);

                if (!opcionValida || opcion < 1 || opcion > 7 || (jugadores.Count == 0 && opcion != 1))
                {
                    Console.WriteLine();
                    Console.WriteLine("╔═════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║Opción inválida. Por favor, ingrese un número entre 1 y 7║");
                    Console.WriteLine("╚═════════════════════════════════════════════════════════╝");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();

                    switch (opcion)
                    {
                        case 1:
                            AgregarJugador(jugadores);
                            break;
                        case 2:
                            ModificarJugador(jugadores);
                            break;
                        case 3:
                            EliminarJugador(jugadores);
                            break;
                        case 4:
                            ListarJugadores(jugadores);
                            break;
                        case 5:
                            BuscarJugador(jugadores);
                            break;
                        case 6:
                            MostrarRankingMenu(jugadores);
                            break;
                        case 7:
                            Console.WriteLine("╔═══════════════════════╗");
                            Console.WriteLine("║Saliendo del programa..║");
                            Console.WriteLine("╚═══════════════════════╝");
                            Console.WriteLine();
                            break;
                        default:
                            return;
                    }
                }

            } while (opcion != 7);
        }

        //Funcion para agregar un jugador
        static void AgregarJugador(List<Jugador> jugadores)
        {

            Console.WriteLine("══════════ Agregar Jugador ══════════");
            Jugador jugadorNuevo = new Jugador();
            string nombre;

            //Cada vez que el programa pide informacion del jugador, este verifica que sea valida
            do
            {
                Console.Write("║•Nombre completo: ");
                nombre = Console.ReadLine();

                //Esta condicion verifica que el tipo de dato sea un string, ademas de evitar que el usuario ponga el dato en blanco
                if (string.IsNullOrWhiteSpace(nombre) || !nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("╔═══════════════╗");
                    Console.WriteLine("║Opción inválida║");
                    Console.WriteLine("╚═══════════════╝");
                    Console.WriteLine();
                }
            } while (string.IsNullOrWhiteSpace(nombre) || !nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
            jugadorNuevo.Nombre = nombre;

            int edad;
            bool edadValida = false;

            do
            {
                Console.Write("║•Edad: ");
                string entrada = Console.ReadLine();

                //En las condiciones de tipo int, verifica que ponga un dato de tipo int y que el numero sea realista
                edadValida = int.TryParse(entrada, out edad);
                if (!edadValida || edad < 10 || edad > 100)
                {
                    Console.WriteLine("╔═══════════════╗");
                    Console.WriteLine("║Opción inválida║");
                    Console.WriteLine("╚═══════════════╝");
                    Console.WriteLine();
                }
            } while (!edadValida || edad < 10 || edad > 100);
            jugadorNuevo.Edad = edad;

            string pais;

            do
            {
                Console.Write("║•Pais: ");
                pais = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(pais) || !pais.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("╔═══════════════╗");
                    Console.WriteLine("║Opción inválida║");
                    Console.WriteLine("╚═══════════════╝");
                    Console.WriteLine();
                }

            } while (string.IsNullOrWhiteSpace(pais) || !pais.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
            jugadorNuevo.Pais = pais;

            string club;

            do
            {
                Console.Write("║•Club (ENTER si esta retirado): ");
                club = Console.ReadLine();

                //En el dato de club, se agrego la funcionalidad que si el jugador ya esta retirado, el usuario le de a ENTER informandoselo al programa
                if (string.IsNullOrWhiteSpace(club))
                {
                    club = "Retirado";
                    break;
                }

                if (!club.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("╔═══════════════╗");
                    Console.WriteLine("║Opción inválida║");
                    Console.WriteLine("╚═══════════════╝");
                    Console.WriteLine();
                }

            } while (!club.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
            jugadorNuevo.Club = club;

            string posicion;

            do
            {
                Console.Write("║•Posición: ");
                posicion = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(posicion) || !posicion.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("╔═══════════════╗");
                    Console.WriteLine("║Opción inválida║");
                    Console.WriteLine("╚═══════════════╝");
                    Console.WriteLine();
                }

            } while (string.IsNullOrWhiteSpace(posicion) || !posicion.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
            jugadorNuevo.Posicion = posicion;

            int partidos;
            bool partidosValidos = false;

            do
            {
                Console.Write("║•Partidos: ");
                string entrada = Console.ReadLine();

                partidosValidos = int.TryParse(entrada, out partidos);
                if (!partidosValidos || partidos < 0 || partidos > 2000)
                {
                    Console.WriteLine("╔═══════════════╗");
                    Console.WriteLine("║Opción inválida║");
                    Console.WriteLine("╚═══════════════╝");
                    Console.WriteLine();
                }
            } while (!partidosValidos || partidos < 0 || partidos > 2000);
            jugadorNuevo.Partidos = partidos;

            int goles;
            bool golesValidos = false;

            do
            {
                Console.Write("║•Goles: ");
                string entrada = Console.ReadLine();

                golesValidos = int.TryParse(entrada, out goles);
                if (!golesValidos || goles < 0 || goles > 2000)
                {
                    Console.WriteLine("╔═══════════════╗");
                    Console.WriteLine("║Opción inválida║");
                    Console.WriteLine("╚═══════════════╝");
                    Console.WriteLine();
                }
            } while (!golesValidos || goles < 0 || goles > 2000);
            jugadorNuevo.Goles = goles;

            int asistencias;
            bool asistenciasValidas = false;

            do
            {
                Console.Write("║•Asistencias: ");
                string entrada = Console.ReadLine();

                asistenciasValidas = int.TryParse(entrada, out asistencias);
                if (!asistenciasValidas || asistencias < 0 || asistencias > 2000)
                {
                    Console.WriteLine("╔═══════════════╗");
                    Console.WriteLine("║Opción inválida║");
                    Console.WriteLine("╚═══════════════╝");
                    Console.WriteLine();
                }
            } while (!asistenciasValidas || asistencias < 0 || asistencias > 2000);
            jugadorNuevo.Asistencias = asistencias;

            long valorMercado;
            bool valorMercadoValido = false;

            do
            {
                Console.Write("║•Valor de mercado (sin puntos): ");
                string entrada = Console.ReadLine();

                valorMercadoValido = long.TryParse(entrada, out valorMercado);
                if (!valorMercadoValido || valorMercado < 0 || valorMercado > 1000000000)
                {
                    Console.WriteLine("╔═══════════════╗");
                    Console.WriteLine("║Opción inválida║");
                    Console.WriteLine("╚═══════════════╝");
                    Console.WriteLine();
                }
            } while (!valorMercadoValido || valorMercado < 0 || valorMercado > 1000000000);
            jugadorNuevo.ValorMercado = valorMercado;

            jugadores.Add(jugadorNuevo);

            Console.WriteLine("╔══════════════════════════╗");
            Console.WriteLine("║Jugador agregado con exito║");
            Console.WriteLine("╚══════════════════════════╝");
            Console.WriteLine();
        }

        //Funcion para modificar un jugador
        static void ModificarJugador(List<Jugador> jugadores)
        {
            Console.WriteLine("═══════════════ Modificar Jugador ═══════════════");

            Console.Write("║•Jugador a modificar: ");
            string nombreJugador = Console.ReadLine();

            int indice = jugadores.FindIndex(j => j.Nombre.Equals(nombreJugador, StringComparison.OrdinalIgnoreCase));

            //Verifica que exista el jugador ingresado
            if (indice == -1)
            {
                Console.WriteLine();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║Jugador no encontrado.. (El nombre debe coincidir perfectamente)║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
                Console.WriteLine();
            }
            else
            {
                Jugador jugadorElegido = jugadores[indice];
                Console.WriteLine("Jugador encontrado, ingrese los nuevos datos (ENTER si no desea modificar el dato)..");

                Console.Write("║•Nombre actual: {0} ║•Nuevo nombre: ", jugadorElegido.Nombre);
                string nombreNuevo = Console.ReadLine();
                if (!string.IsNullOrEmpty(nombreNuevo))
                {
                    jugadorElegido.Nombre = nombreNuevo;
                }

                Console.Write("║•Edad actual: {0} ║•Nueva edad: ", jugadorElegido.Edad);
                string edadNueva = Console.ReadLine();
                if (!string.IsNullOrEmpty(edadNueva))
                {
                    if (int.TryParse(edadNueva, out int edadValida))
                    {
                        jugadorElegido.Edad = edadValida;
                    }
                    else
                    {
                        Console.WriteLine("Edad inválida, se mantendrá el valor actual..");
                    }
                }

                Console.Write("║•País actual: {0} ║•Nuevo país: ", jugadorElegido.Pais);
                string paisNuevo = Console.ReadLine();
                if (!string.IsNullOrEmpty(paisNuevo))
                {
                    jugadorElegido.Pais = paisNuevo;
                }

                Console.Write("║•Club actual: {0} ║•Nuevo club: ", jugadorElegido.Club);
                string clubNuevo = Console.ReadLine();
                if (!string.IsNullOrEmpty(clubNuevo))
                {
                    jugadorElegido.Club = clubNuevo;
                }

                Console.Write("║•Posición actual: {0} ║•Nueva posición: ", jugadorElegido.Posicion);
                string posicionNueva = Console.ReadLine();
                if (!string.IsNullOrEmpty(posicionNueva))
                {
                    jugadorElegido.Posicion = posicionNueva;
                }

                Console.Write("║•Partidos jugados actuales: {0} ║•Nuevos partidos jugados: ", jugadorElegido.Partidos);
                string partidosNuevos = Console.ReadLine();
                if (!string.IsNullOrEmpty(partidosNuevos))
                {
                    if (int.TryParse(partidosNuevos, out int partidosValidos))
                    {
                        jugadorElegido.Partidos = partidosValidos;
                    }
                    else
                    {
                        Console.WriteLine("Partidos inválidos, se mantendrá el valor actual..");
                    }
                }

                Console.Write("║•Goles actuales: {0} ║•Nuevos goles: ", jugadorElegido.Goles);
                string golesNuevos = Console.ReadLine();
                if (!string.IsNullOrEmpty(golesNuevos))
                {
                    if (int.TryParse(golesNuevos, out int golesValidos))
                    {
                        jugadorElegido.Goles = golesValidos;
                    }
                    else
                    {
                        Console.WriteLine("Goles inválidos, se mantendrá el valor actual..");
                    }
                }

                Console.Write("║•Asistencias actuales: {0} ║•Nuevas asistencias: ", jugadorElegido.Asistencias);
                string asistenciasNuevas = Console.ReadLine();
                if (!string.IsNullOrEmpty(asistenciasNuevas))
                {
                    if (int.TryParse(asistenciasNuevas, out int asistenciasValidas))
                    {
                        jugadorElegido.Asistencias = asistenciasValidas;
                    }
                    else
                    {
                        Console.WriteLine("Asistencias inválidas, se mantendrá el valor actual..");
                    }
                }

                Console.Write("║•Valor de mercado actual: {0} ║•Nuevo valor de mercado (sin puntos): ", jugadorElegido.ValorMercado);
                string valorNuevo = Console.ReadLine();
                if (!string.IsNullOrEmpty(valorNuevo))
                {
                    if (long.TryParse(valorNuevo, out long valorValido) && valorValido >= 0 && valorValido <= 1000000000)
                    {
                        jugadorElegido.ValorMercado = valorValido;
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido, se mantendrá el valor actual..");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Datos del jugador actualizados correctamente..");
            }
        }

        //Funcion para eliminar un jugador
        static void EliminarJugador(List<Jugador> jugadores)
        {
            Console.WriteLine("═══════════════ Eliminar Jugador ═══════════════");

            Console.Write("║•Jugador a eliminar: ");
            string jugadorEliminar = Console.ReadLine();

            Jugador jugadorAEliminar = jugadores.Find(j => j.Nombre.Equals(jugadorEliminar, StringComparison.OrdinalIgnoreCase));

            if (jugadorAEliminar != null)
            {
                jugadores.Remove(jugadorAEliminar);
                Console.WriteLine();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║Jugador eliminado existosamente║");
                Console.WriteLine("╚═══════════════════════════════╝");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║Jugador no encontrado (El nombre debe coincidir perfectamente)  ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
                Console.WriteLine();
            }
        }

        //Funcion para mostrar la tabla de jugadores
        static void ListarJugadores(List<Jugador> jugadores)
        {
            //Define las columnas y sus medidas 
            Console.WriteLine("╔═════════════════════════════════════════════════════ Lista de Jugadores ═════════════════════════════════════════════════════╗");
            Console.WriteLine("║{0,-20} ║{1,-5} ║{2,-15} ║{3,-18} ║{4,-18} ║{5,-8} ║{6,-6} ║{7,-6} ║{8,-14}║",
                "Nombre", "Edad", "Pais", "Club", "Posición", "Partidos", "Goles", "Asist", "Valor");
            Console.WriteLine(new string('═', 128));

            // Recorrer la lista de jugadores
            foreach (var jugador in jugadores)
            {
                Console.WriteLine("║{0,-20} ║{1,-5} ║{2,-15} ║{3,-18} ║{4,-18} ║{5,-8} ║{6,-6} ║{7,-6} ║${8,-13:N0}║",
                    jugador.Nombre,
                    jugador.Edad,
                    jugador.Pais,
                    jugador.Club,
                    jugador.Posicion,
                    jugador.Partidos,
                    jugador.Goles,
                    jugador.Asistencias,
                    jugador.ValorMercado);

                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            }

            Console.WriteLine();
        }

        //Funcion para buscar un jugador especifico
        static void BuscarJugador(List<Jugador> jugadores)
        {
            Console.WriteLine("══════════════ Buscar Jugador ══════════════");
            Console.Write("║•Jugador a buscar: ");
            string buscarJugador = Console.ReadLine();
            Console.WriteLine();

            bool jugadorEncontrado = false;

            foreach (var jugador in jugadores)
            {
                if (!string.IsNullOrEmpty(jugador.Nombre) && jugador.Nombre.Equals(buscarJugador, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine();
                    Console.WriteLine("╔═══════════ Jugador encontrado ═══════════");
                    Console.WriteLine("║•Nombre: {0}", jugador.Nombre);
                    Console.WriteLine("║•Edad: {0}", jugador.Edad);
                    Console.WriteLine("║•País: {0}", jugador.Pais);
                    Console.WriteLine("║•Club: {0}", jugador.Club);
                    Console.WriteLine("║•Posición: {0}", jugador.Posicion);
                    Console.WriteLine("║•Partidos jugados: {0}", jugador.Partidos);
                    Console.WriteLine("║•Goles: {0}", jugador.Goles);
                    Console.WriteLine("║•Asistencias: {0}", jugador.Asistencias);
                    Console.WriteLine("║•valor de mercado: ${0:N0}", jugador.ValorMercado);
                    Console.WriteLine("╚══════════════════════════════════════════");
                    Console.WriteLine();
                    jugadorEncontrado = true;
                    break;
                }
            }

            if (!jugadorEncontrado)
            {
                Console.WriteLine();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║Jugador no encontrado.. (El nombre debe coincidir perfectamente)║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
                Console.WriteLine();
            }
        }

        //Funcion para mostrar un submenu de rankings
        static void MostrarRankingMenu(List<Jugador> jugadores)
        {
            int opcion;
            bool opcionValida;

            do
            {
                Console.WriteLine("╔════════════════════════════╗");
                Console.WriteLine("║          Rankings          ║");
                Console.WriteLine("╠════════════════════════════╣");
                Console.WriteLine("║1•Top goles                 ║");
                Console.WriteLine("║2•Top Asistencias           ║");
                Console.WriteLine("║3•Top goles + asistencias   ║");
                Console.WriteLine("║4•Top valor de mercado      ║");
                Console.WriteLine("║5•Volver al menú            ║");
                Console.WriteLine("╚════════════════════════════╝");

                Console.Write("•Ingrese una opción: ");
                string input = Console.ReadLine();
                opcionValida = int.TryParse(input, out opcion);

                switch (opcion)
                {
                    case 1:
                        TopGoles(jugadores);
                        break;
                    case 2:
                        TopAsistencias(jugadores);
                        break;
                    case 3:
                        TopGolesAsistencias(jugadores);
                        break;
                    case 4:
                        TopValorMercado(jugadores);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción no valida, intente de nuevo..");
                        break;
                }
            } while (opcion != 4);
        }

        //Funcion para calcular los goleadores
        static void TopGoles(List<Jugador> jugadores)
        {
            Console.WriteLine("╔════════════════ Top Goleadores ═══════════════╗");
            var topGoleadores = jugadores.OrderByDescending(j => j.Goles).Take(3).ToList();

            foreach (var jugador in topGoleadores)
            {
                Console.WriteLine("╠{0,-20} ║Goles:{1,4} ║Partidos:{2,4}║", jugador.Nombre, jugador.Goles, jugador.Partidos);
                Console.WriteLine("╚═══════════════════════════════════════════════╝");
            }
        }
        //Funcion para calcular los asistidores
        static void TopAsistencias(List<Jugador> jugadores)
        {
            Console.WriteLine("╔═══════════════════ Top Asistentes ══════════════════╗");
            var topAsistentes = jugadores.OrderByDescending(j => j.Asistencias).Take(3).ToList();

            foreach (var jugador in topAsistentes)
            {
                Console.WriteLine("╠{0,-20} ║Asistencias:{1,4} ║Partidos:{2,4}║", jugador.Nombre, jugador.Asistencias, jugador.Partidos);
                Console.WriteLine("╚═════════════════════════════════════════════════════╝");
            }
        }
        //Funcion para calcular los G+A
        static void TopGolesAsistencias(List<Jugador> jugadores)
        {
            Console.WriteLine("╔═══════════════════════════ Top Goles + Asistencias ══════════════════════════╗");
            var topGolesAsistencias = jugadores.OrderByDescending(j => j.Goles + j.Asistencias).Take(3).ToList();

            foreach (var jugador in topGolesAsistencias)
            {
                Console.WriteLine("╠{0,-20} ║Goles:{1,4} ║Asistencias:{2,4} ║Partidos:{2,4} ║Total: {3,4}║",
                    jugador.Nombre, jugador.Goles, jugador.Asistencias, jugador.Goles + jugador.Asistencias);
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
            }
        }
        static void TopValorMercado(List<Jugador> jugadores)
        {
            Console.WriteLine("╔════════════════ Top Valor de Mercado ════════════════╗");
            var topValorMercado = jugadores.OrderByDescending(j => j.ValorMercado).Take(3).ToList();

            foreach (var jugador in topValorMercado)
            {
                Console.WriteLine("╠{0,-20} ║Valor de Mercado:${1,-14:N0}║", jugador.Nombre, jugador.ValorMercado);
                Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            }
        }
    }
}