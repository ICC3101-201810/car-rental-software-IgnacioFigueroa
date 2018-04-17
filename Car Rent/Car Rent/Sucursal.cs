using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rent
{
    public enum Accesorios { RadioBluetooth, GPS, RuedaDeRepuesto,
        CortinasParaVentanas, SillaInfante, Ninguno}
    class Sucursal
    {
        public string nombre { get; private set; }
        public List<Vehiculo> vehiculos { get; private set; }
        public List<Arriendo> arriendos { get; private set; }
        public List<Cliente> clientes { get; private set; }

        public Sucursal(string nombre)
        {
            this.nombre = nombre;
            vehiculos = new List<Vehiculo>();
            arriendos = new List<Arriendo>();
            clientes = new List<Cliente>();
        }
        public void crearArriendo(Arriendo arriendo)
        {
            arriendos.Add(arriendo);
        }

        public void agregarVehiculo(Vehiculo vehiculo)
        {
            vehiculos.Add(vehiculo);
        }

        public void agregarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }
        public List<string> GetClientesNombres()
        {
            
            List<string> nombres = new List<string>();
            foreach (Cliente c in clientes)
            {
                nombres.Add(c.Nombre);
            }
            return nombres;
        }
    }
}
