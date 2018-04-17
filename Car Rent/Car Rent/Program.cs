using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car_Rent
{
    class Program
    {
        //IMPORTANTE
        //Al momento de seleccionar el vehiculo, siempre aparecera el mensaje de que no se pudo agregar la primera
        //vez, hay que seleccionarlo denuevo. Esto es porque use el ciclo dowhile pensando en que solo entra en el do si la condicion del while da true

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int OpcionesLicencia()
            {
                Console.Write("1. A\n" +
                                "2. B\n" +
                                "3. C\n" +
                                "4. D\n" +
                                "5. E\n" +
                                "6. F\n" +
                                "7. G\n");
                return Convert.ToInt32(Console.ReadLine());
            }//Funcion para mostrar y elegir una licencia/tipodevehiculo
            void MostrarVehiculos(Sucursal sucursal)
            {
                int cont = 1;
                foreach (Vehiculo v in sucursal.vehiculos)
                {
                    if (v.estado.Equals(Estados.Disponible))
                    {
                        Console.WriteLine(cont + ". " + v.nombre);
                        
                    }
                    cont += 1;
                }
                
            } //Funcion para mostrar los vehiculos de la sucursal
            bool PermisoMunicipalidad(TipoVehiculo tipoVehiculo, TipoCliente tipoCliente)
            {
                Random rand = new Random();
                if (tipoCliente.Equals(TipoCliente.Empresa))
                {
                    if (tipoVehiculo.Equals(TipoVehiculo.F) || tipoVehiculo.Equals(TipoVehiculo.G))
                    {
                        if (rand.Next(100) < 63)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else
                    {
                        if (rand.Next(100) < 80)
                        {
                            return true;
                        }
                        else return false;
                    }
                }
                if (tipoCliente.Equals(TipoCliente.Organizacion))
                {
                    if (rand.Next(100) < 35)
                    {
                        return true;
                    }
                    else return false;
                }

                if (tipoCliente.Equals(TipoCliente.Insitucion))
                {
                    if (rand.Next(100) < 58)
                    {
                        return true;
                    }
                    else return false;
                }
                return false;
            } //Funcion que ve si la municipalidad da o no el permiso deseado
            
            List <Sucursal>Sucursales = new List<Sucursal>();
            void Arrendar(Sucursal sucursal, Cliente cliente)
            {
                int precioFinal = 0;
                
                Console.WriteLine("Que vehiculo desea arrendar(Ingrese el numero): ");
                MostrarVehiculos(sucursal);
                Vehiculo vehiculo = sucursal.vehiculos[Convert.ToInt32(Console.ReadLine())-1];
                precioFinal += vehiculo.precio;
                if ((cliente.GetTipo().Equals(TipoCliente.Persona) && ((int)cliente.Getlicencia() <= vehiculo.GetTipoN())) || vehiculo.GetTipoN().Equals(TipoVehiculo.E))
                {
                    do
                    {
                        
                        Console.WriteLine("No puede arrendar ese vehiculo. Porfavor elija otro.");
                        MostrarVehiculos(sucursal);
                        vehiculo = sucursal.vehiculos[Convert.ToInt32(Console.ReadLine())-1];
                    } while ((cliente.GetTipo().Equals(TipoCliente.Persona) && ((int)cliente.Getlicencia() <= vehiculo.GetTipoN())) ||vehiculo.GetTipoN().Equals(TipoVehiculo.E)); //Esto hace que no pueda arrendar un bus
                    //Si la letra de la licencia de la persona es mayor o igual a la letra del tipo de vehiculo, entonces la persona puede arrendar el vehiculo
                    goto Accesorio;
                }
                
                
                else if (cliente.GetTipo().Equals(TipoCliente.Organizacion)|| cliente.GetTipo().Equals(TipoCliente.Insitucion) || cliente.GetTipo().Equals(TipoCliente.Empresa))
                {
                    
                    do
                    {
                        
                        Console.WriteLine("No se puede arrendar ese vehiculo. Porfavor elija otro.");
                        MostrarVehiculos(sucursal);
                        vehiculo = sucursal.vehiculos[Convert.ToInt32(Console.ReadLine())-1];
                    } while (!cliente.GetAutorizacion().Contains(vehiculo.GetTipo())); //Mientras la empresa, sucursal o organizacion no tenga la autorizacion se queda aca

                    do
                    {
                        
                        Console.WriteLine("No se puede arrendar ese vehiculo. Porfavor elija otro.");
                        MostrarVehiculos(sucursal);
                        vehiculo = sucursal.vehiculos[Convert.ToInt32(Console.ReadLine())-1];
                    } while ((vehiculo.GetTipo().Equals(TipoVehiculo.F) || vehiculo.GetTipo().Equals(TipoVehiculo.G)) && (cliente.GetTipo().Equals(TipoCliente.Organizacion) || cliente.GetTipo().Equals(TipoCliente.Insitucion)));
                    //Este de arriba hace que las organizaciones e instituciones no puedan arrendar maquinaria pesada


                    if (vehiculo.GetTipo().Equals(TipoVehiculo.F) || vehiculo.GetTipo().Equals(TipoVehiculo.G)) //Ve lo de maquinaria pesada y empresa
                    {
                        if (vehiculo.GetTipo().Equals(TipoVehiculo.F))
                        {
                            if (cliente.GetPermiso().Contains(TipoVehiculo.F))
                            {
                                Console.WriteLine("Tiene el permiso");
                                goto Accesorio;
                            }
                        }
                        else if (vehiculo.GetTipo().Equals(TipoVehiculo.G))
                        {
                            if (cliente.GetPermiso().Contains(TipoVehiculo.G))
                            {
                                Console.WriteLine("Tiene el permiso");
                                goto Accesorio;
                            }
                        }
                        if (PermisoMunicipalidad(vehiculo.GetTipo(), TipoCliente.Empresa))
                        {
                            Console.WriteLine("La municipalidad le dio el permiso");
                        }
                        else
                        {
                            Console.WriteLine("La municipalidad no le dio el permiso, escoja otro vehiculo");
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("No se puede arrendar ese vehiculo. Porfavor elija otro.");
                                MostrarVehiculos(sucursal);
                                vehiculo = sucursal.vehiculos[Convert.ToInt32(Console.ReadLine())-1];
                            } while ((vehiculo.GetTipo().Equals(TipoVehiculo.F)) || vehiculo.GetTipo().Equals(TipoVehiculo.G));
                        }
                    }
                    if (vehiculo.GetTipo().Equals(TipoVehiculo.E))
                    {
                        if (cliente.GetPermiso().Contains(TipoVehiculo.E))
                        {
                            Console.WriteLine("Tiene el permiso");
                            goto Accesorio;
                        }

                        else
                        {
                            if (PermisoMunicipalidad(vehiculo.GetTipo(), cliente.GetTipo()))
                            {
                                Console.WriteLine("La municipalidad le dio el permiso");
                                goto Accesorio;
                            }

                            else
                            {
                                Console.WriteLine("La municipalidad no le dio el permiso, escoja otro vehiculo");
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("No se puede arrendar ese vehiculo. Porfavor elija otro.");
                                    MostrarVehiculos(sucursal);
                                    vehiculo = sucursal.vehiculos[Convert.ToInt32(Console.ReadLine())-1];
                                } while (vehiculo.GetTipo().Equals(TipoVehiculo.E));

                            }
                        }
                    }

                }

                Accesorio:
                Console.WriteLine("¿Desea agregar algun accesorio?(Ingrese el numero) 1. Si\n2. No");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Accesorios accesorio = Accesorios.Ninguno;
                if (opcion == 1)
                {
                    int contador = 1;
                    Console.WriteLine("Que accesorio desea agregar: ");
                    foreach (string acc in Enum.GetNames(typeof(Accesorios)))
                        Console.WriteLine(contador + ". " + acc);
                    accesorio = (Accesorios) Convert.ToInt32(Console.ReadLine());
                    precioFinal += 30000;
                }
                

                Console.Write("Ingrese la fecha de termino del contrato(DD/MM/AAAA): ");
                DateTime fechaTermino = DateTime.Parse(Console.ReadLine());

                Console.Write("Ingrese nombre del arriendo: ");
                sucursal.crearArriendo(new Arriendo(vehiculo, cliente, precioFinal, sucursal, fechaTermino, accesorio));
                Console.WriteLine("Arriendo creado");
            } 
            void MenuSucursal(Sucursal sucursal)
            {
                Inicio:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Usted esta en la sucursal " + sucursal.nombre);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Que desea hacer:\n1. Crear Arriendo\n" +
                                                    "2. Agregar Vehiculo\n" +
                                                    "3. Salir de la sucursal\n");
                int opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion == 1) // Aqui ingreso al cliente para luego ir a la funcion arrendar
                {
                    Console.Write("¿Es persona(1), organizacion(2), Institucion(3) o Empresa(4)?: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion == 1)
                    {
                        Console.Write("Ingrese el nombre de la persona: ");
                        string nombre = Console.ReadLine();
                        TipoVehiculo licencia = TipoVehiculo.A;
                        if (sucursal.GetClientesNombres().Contains(nombre))
                        {
                            foreach (Persona per in sucursal.clientes)
                            {
                                if (nombre == per.Nombre)
                                {
                                    licencia = per.licenciaPersona;
                                }
                            }
                            Arrendar(sucursal, new Persona(nombre, licencia));
                        }
                        else //Si la persona no esta en la sucursal, aqui se crea
                        {
                            Console.Write("Ingrese su licencia: ");
                            licencia = (TipoVehiculo)OpcionesLicencia();
                            sucursal.agregarCliente(new Persona(nombre,licencia));
                            Arrendar(sucursal, new Persona(nombre, licencia));
                        }

                    }
                    else
                    {
                        List<TipoVehiculo> autorizacion = new List<TipoVehiculo>();
                        List<TipoVehiculo> permisos = new List<TipoVehiculo>();

                        Console.Write("Ingrese el nombre: ");
                        string Nombre = Console.ReadLine();
                        Console.Write("Ingrese el tipo (1)Organizacion (2)Empresa (3)Institucion");
                        TipoCliente tipo = (TipoCliente)Convert.ToInt32(Console.ReadLine());

                        if (sucursal.GetClientesNombres().Contains(Nombre))
                        {
                            if (tipo.Equals(TipoCliente.Organizacion))
                            {
                                foreach (Organizacion org in sucursal.clientes) //Aqui se revisa si el cliente existe en la sucursal
                                {
                                    if (Nombre == org.Nombre)
                                    {
                                        autorizacion = org.autorizacion;
                                        permisos = org.permisos;
                                    }
                                }
                                Arrendar(sucursal, new Organizacion(Nombre, autorizacion, permisos));
                            }

                            else if (tipo.Equals(TipoCliente.Empresa))
                            {
                                foreach (Empresa emp in sucursal.clientes)//Aqui se revisa si el cliente existe en la sucursal
                                {
                                    if (Nombre == emp.Nombre)
                                    {
                                        autorizacion = emp.autorizacion;
                                        permisos = emp.permisos;
                                    }
                                }
                                Arrendar(sucursal, new Empresa(Nombre, autorizacion, permisos));
                            }

                            else if (tipo.Equals(TipoCliente.Insitucion))
                            {
                                foreach (Institucion inst in sucursal.clientes)//Aqui se revisa si el cliente existe en la sucursal
                                {
                                    if (Nombre == inst.Nombre)
                                    {
                                        autorizacion = inst.autorizacion;
                                        permisos = inst.permisos;
                                    }
                                }
                                Arrendar(sucursal, new Institucion(Nombre, autorizacion, permisos));
                            }
                        }
                        else //Si el cliente no existe en la sucursal, aqui se crea pidiendo las autorizaciones y permisos correspondientes
                        {
                            int deseo = 1;
                            do
                            {
                                Console.WriteLine("Ingrese autorizacion: ");
                                permisos.Add((TipoVehiculo)OpcionesLicencia());
                                Console.Write("¿Desea agregar otro permiso? (1)Si (2)No");
                                deseo = Convert.ToInt32(Console.ReadLine());
                            } while (deseo == 1);
                            do
                            {
                                Console.WriteLine("Ingrese permiso: ");
                                autorizacion.Add((TipoVehiculo)OpcionesLicencia());
                                Console.Write("¿Desea agregar otro permiso? (1)Si (2)No");
                                deseo = Convert.ToInt32(Console.ReadLine());
                            } while (deseo == 1);

                            if (tipo.Equals(TipoCliente.Organizacion))
                            {
                                sucursal.agregarCliente(new Organizacion(Nombre, autorizacion, permisos));
                                Arrendar(sucursal, new Organizacion(Nombre, autorizacion, permisos));
                            }

                            else if (tipo.Equals(TipoCliente.Empresa))
                            {
                                sucursal.agregarCliente(new Empresa(Nombre, autorizacion, permisos));
                                Arrendar(sucursal, new Empresa(Nombre, autorizacion, permisos));
                            }

                            else if (tipo.Equals(TipoCliente.Insitucion))
                            {
                                sucursal.agregarCliente(new Institucion(Nombre, autorizacion, permisos));
                                Arrendar(sucursal, new Institucion(Nombre, autorizacion, permisos));
                            }
                        }
                    }
                    
                    goto Inicio;
                }

                if (opcion == 2) //Agregar vehiculo
                {
                    Console.WriteLine("Que tipo de vehiculo desea agregar:\n 1.Auto\n" +
                                                                            "2.Moto\n" +
                                                                            "3.Lancha\n" +
                                                                            "4.Camion\n" +
                                                                            "5.Bus\n" +
                                                                            "6.Tractor\n" +
                                                                            "7.Retroexcavadora ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Ingrese la patente: ");
                    string patente = Console.ReadLine();
                    Console.Write("Ingrese el nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el precio: ");
                    int precio = Convert.ToInt32(Console.ReadLine());
                    if (opcion == 1)
                    {
                        sucursal.agregarVehiculo(new Auto(patente, nombre, precio));
                    }

                    else if (opcion == 2)
                    {
                        sucursal.agregarVehiculo(new Moto(patente, nombre, precio));
                    }

                    else if (opcion == 3)
                    {
                        sucursal.agregarVehiculo(new Lancha(patente, nombre, precio));
                    }

                    else if (opcion == 4)
                    {
                        sucursal.agregarVehiculo(new Camion(patente, nombre, precio));
                    }

                    else if (opcion == 5)
                    {
                        sucursal.agregarVehiculo(new Bus(patente, nombre, precio));
                    }

                    else if (opcion == 6)
                    {
                        sucursal.agregarVehiculo(new Tractor(patente, nombre, precio));
                    }

                    else if (opcion == 7)
                    {
                        sucursal.agregarVehiculo(new Retroexcavadora(patente, nombre, precio));
                    }

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Vehiculo Agregado");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Beep();
                    Console.WriteLine("Preione una tecla para continuar");
                    Console.ReadKey();
                    goto Inicio;
                }

                
                
            }
            void Menu()
            {
                InicioPrograma:
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Bienvenido al CarRent");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Que desea hacer:\n1. Crear sucursal\n" +
                                                    "2. Acceder a sucursal\n" +
                                                    "3. Salir");
                Console.Write("Opcion: ");
                int eleccion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (eleccion == 1)
                {
                    Console.Write("Ingrese el nombre de la sucursal: ");
                    Sucursales.Add(new Sucursal(Console.ReadLine()));
                    goto InicioPrograma;
                }

                else if (eleccion == 2)
                {
                    if (Sucursales.Count() == 0)
                    {
                        Console.WriteLine("No hay sucursales, cree una.");
                        goto InicioPrograma;
                    }
                    Console.WriteLine("A que sucursal desea acceder: ");
                        int cont = 1;
                        foreach (Sucursal s in Sucursales)
                        {
                            Console.WriteLine(cont + ". " + s.nombre);
                        }
                    MenuSucursal(Sucursales[Convert.ToInt32(Console.ReadLine())-1]);
                    goto InicioPrograma;
                } 
            }

            
            Menu();
        }
    }
}
