using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rent
{
    
    class Arriendo
    {
        Vehiculo vehiculo;
        Cliente cliente;
        int precioFinal;
        DateTime fechaInicio;
        DateTime fechaFinal;
        Sucursal sucursal;
        Accesorios accesorio;
        Estados estado;

        public Arriendo(Vehiculo vehiculo, Cliente cliente, int precioFinal,
            Sucursal sucursal, DateTime fechaFinal, Accesorios accesorio)
        {
            this.vehiculo = vehiculo;
            this.cliente = cliente;
            this.precioFinal = precioFinal;
            fechaInicio = DateTime.Now;
            this.fechaFinal = fechaFinal; 
            this.sucursal = sucursal;
            this.accesorio = accesorio;
            estado = Estados.Disponible;
        }
    }
}
