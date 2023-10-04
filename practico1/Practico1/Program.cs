using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;

namespace Practico1
{
    class Program
    {
        static void Main(string[] args)
        {
            Parlamento parlamento = new Parlamento();
            string sesion = "0";

            while (sesion != "4")
            {

                Console.WriteLine("       ---Menú---");
                Console.WriteLine("1. Registrar Legisladores");
                Console.WriteLine("2. Continuar");
                Console.WriteLine("3. salir");

                string eleccion = Console.ReadLine();

                if (eleccion == "3")
                {
                    sesion = "4";
                }

                if (sesion != "4")
                {
                    while (eleccion != "2" && eleccion !="3")
                    {
                        if (eleccion == "1")
                        {
                            Console.Write("Tipo de legislador (Senador/Diputado): ");
                            string tipoLegislador = Console.ReadLine();
                            while(inputValidation.IsSenadorOrDioutado(tipoLegislador) != true)
                            {
                                Console.WriteLine("Debe colocar senador o diputado. ");
                                tipoLegislador = Console.ReadLine();
                            }
                            Console.Write("Partido Político: ");
                            string partido = Console.ReadLine();
                            while (inputValidation.IsStringVacio(partido) != true)
                            {
                                Console.WriteLine("Ingrese partido. ");
                                partido = Console.ReadLine();
                            }
                            Console.Write("Departamento que Representa: ");
                            string departamento = Console.ReadLine();
                            while (inputValidation.IsStringVacio(departamento) != true)
                            {
                                Console.WriteLine("Ingrese departamento. ");
                                departamento = Console.ReadLine();
                            }
                            Console.Write("Número de Despacho: ");
                            int numDespacho = inputValidation.IsInt();
                            while (numDespacho == -1)
                            {
                                Console.Write("Coloque un número de Despacho: ");
                                numDespacho = inputValidation.IsInt();
                            }

                            Console.Write("Nombre: ");
                            string nombre = Console.ReadLine();
                            while (inputValidation.IsStringVacio(nombre) != true)
                            {
                                Console.WriteLine("Ingrese nombre. ");
                                nombre = Console.ReadLine();
                            }

                            Console.Write("Apellido: ");
                            string apellido = Console.ReadLine();
                            while (inputValidation.IsStringVacio(apellido) != true)
                            {
                                Console.WriteLine("Ingrese apellido. ");
                                apellido = Console.ReadLine();
                            }
                            Console.Write("Edad: ");
                            int edad = inputValidation.IsInt();
                            while (edad == -1)
                            {
                                Console.Write("Coloque su edad: ");
                                edad = inputValidation.IsInt();
                            }

                            Console.Write("Casado (True/False): ");
                            string prueba = Console.ReadLine();
                            while(inputValidation.IsBool(prueba) != true)
                            {
                                Console.Write("Coloque true o false. ");
                                prueba = Console.ReadLine();

                            }
                            bool casado = bool.Parse(prueba);

                            if (tipoLegislador.ToLower() == "senador")
                            {
                                Console.Write("Número de Asiento en la Cámara Alta: ");
                                int numAsiento = inputValidation.IsInt();
                                while (numAsiento == -1)
                                {
                                    Console.Write("Coloque un número de Asiento. ");
                                    numAsiento = inputValidation.IsInt();
                                }
                                Senador senador = new Senador(numAsiento, partido, departamento, numDespacho, nombre, apellido, edad, casado);
                                parlamento.RegistrarLegislador(senador);
                                Console.WriteLine("Legislador registrado con éxito.");
                            }
                            else if (tipoLegislador.ToLower() == "diputado")
                            {
                                Console.Write("Número de Asiento en la Cámara Baja: ");
                                int numAsiento = inputValidation.IsInt();
                                while (numAsiento == -1)
                                {
                                    Console.Write("Coloque un número de Asiento. ");
                                    numAsiento = inputValidation.IsInt();
                                }
                                Diputado diputado = new Diputado(numAsiento, partido, departamento, numDespacho, nombre, apellido, edad, casado);
                                parlamento.RegistrarLegislador(diputado);
                                Console.WriteLine("Legislador registrado con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Tipo de legislador no válido.");
                            }
                            Console.ReadKey();
                            Console.Clear();
                        }

                        else
                        {
                            Console.WriteLine("Esta opcion no existe.");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        }

                        Console.WriteLine("       ---Menú---");
                        Console.WriteLine("1. Registrar Legisladores");
                        Console.WriteLine("2. Continuar");
                        Console.WriteLine("3. salir");
                        eleccion = Console.ReadLine();
                        Console.Clear();

                        if (eleccion == "3")
                        {
                            sesion = "4";
                        }

                    }

                    if (sesion != "4")
                    {
                        Console.WriteLine("       ---Acciones---");
                        Console.WriteLine("1. Listar Cámaras de Legisladores");
                        Console.WriteLine("2. Dar Cantidad de Legisladores por Tipo");
                        Console.WriteLine("3. Presentar propuesta Legislativa");
                        Console.WriteLine("4. Votar");
                        Console.WriteLine("5. Participar de un debate");
                        Console.WriteLine("6. Volver a menu principal");
                        string accion = Console.ReadLine();
                        Console.Clear();

                        while (accion != "6")
                        {
                            if (accion == "1")
                            {
                                parlamento.ListarCamaras();
                                Console.ReadKey();
                                Console.Clear();

                            }
                            else if (accion == "2")
                            {
                                parlamento.DarCantidadLegisladoresPorTipo();
                                Console.ReadKey();
                                Console.Clear();

                            }
                            else if (accion == "3")
                            {
                                Console.WriteLine("Seleccione un legislador por su número de despacho: ");
                                int numeroDespacho = inputValidation.IsInt();
                                while (numeroDespacho == -1)
                                {
                                    Console.Write("Coloque un número de Despacho. ");
                                    numeroDespacho = inputValidation.IsInt();
                                }

                                Legislador legisladorActual = null;

                                while (legisladorActual == null)
                                {
                                    foreach (var legislador in parlamento.legisladores)
                                    {
                                        if (legislador.getNumDespacho() == numeroDespacho)
                                        {
                                            legisladorActual = legislador;
                                            break;
                                        }
                                    }

                                    if (legisladorActual == null)
                                    {
                                        Console.WriteLine("No se encontró un legislador con ese número de despacho. Coloque el número de despacho nuevamente.");
                                        numeroDespacho = inputValidation.IsInt();
                                        while (numeroDespacho == -1)
                                        {
                                            Console.Write("Coloque un número de Despacho. ");
                                            numeroDespacho = inputValidation.IsInt();
                                        }
                                    }
                                }

                                Console.WriteLine("Escriba su propuesta y envíela presionando enter.");
                                string propuesta = Console.ReadLine();
                                while (inputValidation.IsStringVacio(propuesta) != true)
                                {
                                    Console.WriteLine("Debe colocar una propuesta.");
                                    propuesta = Console.ReadLine();
                                }
                                Console.WriteLine(legisladorActual.presentarPropuestaLegislativa(propuesta));
                                Console.ReadKey();
                                Console.Clear();

                            }
                            else if (accion == "4")
                            {
                                Console.WriteLine("Seleccione un legislador por su número de despacho: ");
                                int numeroDespacho = inputValidation.IsInt();
                                while (numeroDespacho == -1)
                                {
                                    Console.Write("Coloque un número de Despacho. ");
                                    numeroDespacho = inputValidation.IsInt();
                                }

                                Legislador legisladorActual = null;

                                while (legisladorActual == null)
                                {
                                    foreach (var legislador in parlamento.legisladores)
                                    {
                                        if (legislador.getNumDespacho() == numeroDespacho)
                                        {
                                            legisladorActual = legislador;
                                            break;
                                        }
                                    }

                                    if (legisladorActual == null)
                                    {
                                        Console.WriteLine("No se encontró un legislador con ese número de despacho. Coloque el número de despacho nuevamente.");
                                        numeroDespacho = inputValidation.IsInt();
                                        while (numeroDespacho == -1)
                                        {
                                            Console.Write("Coloque un número de Despacho. ");
                                            numeroDespacho = inputValidation.IsInt();
                                        }
                                    }
                                }

                                Console.WriteLine("Emita su voto y envíelo presionando enter.");
                                string voto = Console.ReadLine();
                                while (inputValidation.IsStringVacio(voto) != true)
                                {
                                    Console.WriteLine("Debe colocar el voto que desea emitir.");
                                    voto = Console.ReadLine();
                                }
                                Console.WriteLine(legisladorActual.votar(voto));
                                Console.ReadKey();
                                Console.Clear();

                            }
                            else if (accion == "5")
                            {
                                Console.WriteLine("Seleccione un legislador por su número de despacho: ");
                                int numeroDespacho = inputValidation.IsInt();
                                while (numeroDespacho == -1)
                                {
                                    Console.Write("Coloque un número de Despacho. ");
                                    numeroDespacho = inputValidation.IsInt();
                                }

                                Legislador legisladorActual = null;

                                while (legisladorActual == null)
                                {
                                    foreach (var legislador in parlamento.legisladores)
                                    {
                                        if (legislador.getNumDespacho() == numeroDespacho)
                                        {
                                            legisladorActual = legislador;
                                            break;
                                        }
                                    }

                                    if (legisladorActual == null)
                                    {
                                        Console.WriteLine("No se encontró un legislador con ese número de despacho. Coloque el número de despacho nuevamente.");
                                        numeroDespacho = inputValidation.IsInt();
                                        while (numeroDespacho == -1)
                                        {
                                            Console.Write("Coloque un número de Despacho. ");
                                            numeroDespacho = inputValidation.IsInt();
                                        }
                                    }
                                }

                                Console.WriteLine("Ingrese el debate al que desea participar y presione enter.");
                                string debate = Console.ReadLine();
                                while (inputValidation.IsStringVacio(debate) != true)
                                {
                                    Console.WriteLine("Debe colocar el debate al que desea participar.");
                                    debate = Console.ReadLine();
                                }
                                Console.WriteLine(legisladorActual.participarDebate(debate));
                                Console.ReadKey();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Esta opcion no existe.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Console.WriteLine("       ---Acciones---");
                            Console.WriteLine("1. Listar Cámaras de Legisladores");
                            Console.WriteLine("2. Dar Cantidad de Legisladores por Tipo");
                            Console.WriteLine("3. Presentar propuesta Legislativa");
                            Console.WriteLine("4. Votar");
                            Console.WriteLine("5. Participar de un debate");
                            Console.WriteLine("6. Volver a menu principal");
                            accion = Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
            }
        }
    }

    class Legislador

    {
        private string PartidoPolitico;
        private string DepartamentoQueRepresenta;
        private int NumDespacho;
        private string Nombre;
        private string Apellido;
        private int Edad;
        private bool Casado;


        public Legislador(string PartidoPolitico, string DepartamentoQueRepresenta, int NumDespacho, string Nombre, string Apellido, int Edad, bool Casado)
        {
            this.PartidoPolitico = PartidoPolitico;
            this.DepartamentoQueRepresenta = DepartamentoQueRepresenta;
            this.NumDespacho = NumDespacho;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Edad = Edad;
            this.Casado = Casado;

        }
        public string getPartidoPolitico() => PartidoPolitico;
        public void SetPartidoPolitico(string partido) => this.PartidoPolitico = partido;
        public string getDepartamentoQueRepresenta() => DepartamentoQueRepresenta;
        public void setDepartamentoQueRepresenta(string DepartamentoQueRepresenta) => this.DepartamentoQueRepresenta = DepartamentoQueRepresenta;
        public int getNumDespacho() => NumDespacho;
        public void setNumDespacho(int NumDespacho) => this.NumDespacho = NumDespacho;
        public string getNombre() => Nombre;
        public void setNombre(string Nombre) => this.Nombre = Nombre;
        public string getApellido() => Apellido;
        public void setApellido(string Apellido) => this.Apellido = Apellido;
        public int getEdad() => Edad;
        public void setEdad(int Edad) => this.Edad = Edad;
        public bool getCasado() => Casado;
        public void setCasado(bool Casado) => this.Casado = Casado;


        public virtual string getCamara()
        {
            return "camara de legisladores";
        }

        public virtual string presentarPropuestaLegislativa(string propuesta)
        {
            return $"Propuesta legislativa presentada: {propuesta}";
        }

        public virtual string votar(string voto)
        {
            return $"Voto emitido: {voto}";
        }

        public virtual string participarDebate(string debate)
        {
            return $"Participando en el debate: {debate}";
        }


    }

    class Senador : Legislador
    {
        private int NumAsientoCamaraAlta;

        public Senador(int NumAsientoCamaraAlta, string PartidoPolitico, string DepartamentoQueRepresenta, int NumDespacho, string Nombre, string Apellido, int Edad, bool Casado) : base(PartidoPolitico, DepartamentoQueRepresenta, NumDespacho, Nombre, Apellido, Edad, Casado)
        {
            this.NumAsientoCamaraAlta = NumAsientoCamaraAlta;
        }
        public int getNumAsientoCamaraAlta() => NumAsientoCamaraAlta;
        public void setNumAsientoCamaraAlta(int NumAsientoCamaraAlta) => this.NumAsientoCamaraAlta = NumAsientoCamaraAlta;

        public override string getCamara()
        {
            return "senador";
        }
        public override string presentarPropuestaLegislativa(string propuesta)
        {
            return $"El senador {getNombre()} presenta la propuesta: {propuesta}";
        }

        public override string votar(string voto)
        {
            return $"El senador {getNombre()} emite el voto: {voto}";
        }

        public override string participarDebate(string debate)
        {
            return $"El senador {getNombre()} participa en el debate: {debate}";
        }
    }

    class Diputado : Legislador
    {
        public int NumAsientoCamaraBaja;

        public Diputado(int NumAsientoCamaraBaja, string PartidoPolitico, string DepartamentoQueRepresenta, int NumDespacho, string Nombre, string Apellido, int Edad, bool Casado) : base(PartidoPolitico, DepartamentoQueRepresenta, NumDespacho, Nombre, Apellido, Edad, Casado)
        {
            this.NumAsientoCamaraBaja = NumAsientoCamaraBaja;
        }

        public int getNumAsientoCamaraBaja() => NumAsientoCamaraBaja;
        public void setNumAsientoCamaraBaja(int NumAsientoCamaraBaja) => this.NumAsientoCamaraBaja = NumAsientoCamaraBaja;

        public override string getCamara()
        {
            return "diputado";
        }

        public override string presentarPropuestaLegislativa(string propuesta)
        {
            return $"El diputado {getNombre()} presenta la propuesta: {propuesta}";
        }

        public override string votar(string voto)
        {
            return $"El diputado {getNombre()} emite el voto: {voto}";
        }

        public override string participarDebate(string debate)
        {
            return $"El diputado {getNombre()} participa en el debate: {debate}";
        }
    }

    class Parlamento
    {
        public List<Legislador> legisladores = new List<Legislador>();

        public void RegistrarLegislador(Legislador legislador)
        {
            legisladores.Add(legislador);
        }

        public void ListarCamaras()
        {
            foreach (var legislador in legisladores)
            {
                Console.WriteLine($"Nombre: {legislador.getNombre()} {legislador.getApellido()}, Número de despacho: {legislador.getNumDespacho()}, Cámara: {legislador.getCamara()}");
            }
        }

        public void DarCantidadLegisladoresPorTipo()
        {
            int senadores = 0;
            int diputados = 0;

            foreach (var legislador in legisladores)
            {
                if (legislador is Senador)
                {
                    senadores++;
                }
                else if (legislador is Diputado)
                {
                    diputados++;
                }
            }

            Console.WriteLine($"Cantidad de Senadores: {senadores}");
            Console.WriteLine($"Cantidad de Diputados: {diputados}");
        }

    }
    
    class inputValidation
    {

        public static bool IsSenadorOrDioutado(string legislador)
        {
            if (legislador != "senador" && legislador != "diputado")
            {
                return false;
            }

            return true;
        }

        public static bool IsStringVacio(string parametro)
        {
            if (parametro == "")
            {
                return false;
            }
            return true;
        }

        public static int IsInt()
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                return -1;
            }

            if (int.TryParse(input, out int numeroDespacho))
            {
                return numeroDespacho; 
            }
            else
            {
                return -1; 
            }
        }

        public static bool IsBool(string parametro)
        {
            if(parametro != "false" && parametro != "true")
            {
                return false;
            }
            return true; 
        }
    }
}


