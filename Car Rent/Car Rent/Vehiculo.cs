using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rent
{
    public enum TipoVehiculo { A, B, C, D, E, F, G }

    abstract class Vehiculo
    {
        public int precio { get ; private set;}
        string patente;
        public string nombre { get; private set; }
        

        public Vehiculo(string patente, string nombre, int precio)
        {
            this.patente = patente;
            this.nombre = nombre;
            this.precio = precio;

        }

        public virtual int GetTipoN()
        {
            return (int)TipoVehiculo.A;
        }

        public virtual TipoVehiculo GetTipo()
        {
            return TipoVehiculo.A;
        }
    }
    class Auto : Vehiculo
    {
        TipoVehiculo Tipo;
        public Auto(string patente, string nombre, int precio) : base(patente, nombre, precio)
        {
            Tipo = TipoVehiculo.A;
        }

        public override int GetTipoN()
        {
            return (int)TipoVehiculo.A;
        }

        public override TipoVehiculo GetTipo()
        {
            return TipoVehiculo.A;
        }
    }
    class Moto : Vehiculo
    {
        TipoVehiculo Tipo;
        public Moto(string patente, string nombre, int precio) : base(patente, nombre, precio)
        {
            Tipo = TipoVehiculo.B;
        }
        public override int GetTipoN()
        {
            return (int)TipoVehiculo.B;
        }

        public override TipoVehiculo GetTipo()
        {
            return TipoVehiculo.B;
        }
    }

    class Lancha : Vehiculo
    {
        TipoVehiculo Tipo;
        public Lancha(string patente, string nombre, int precio) : base(patente, nombre, precio)
        {
            Tipo = TipoVehiculo.C;
        }
        public override int GetTipoN()
        {
            return (int)TipoVehiculo.C;
        }

        public override TipoVehiculo GetTipo()
        {
            return TipoVehiculo.C;
        }
    }

    class Camion : Vehiculo
    {
        TipoVehiculo Tipo;
        public Camion(string patente, string nombre, int precio) : base(patente, nombre, precio)
        {
            Tipo = TipoVehiculo.D;
        }
        public override int GetTipoN()
        {
            return (int)TipoVehiculo.D;
        }

        public override TipoVehiculo GetTipo()
        {
            return TipoVehiculo.D;
        }
    }
    
    
    class Bus : Vehiculo
    {
        TipoVehiculo Tipo;
        public Bus(string patente, string nombre, int precio) : base(patente, nombre, precio)
        {
            Tipo = TipoVehiculo.E;
        }
        public override int GetTipoN()
        {
            return (int)TipoVehiculo.E;
        }

        public override TipoVehiculo GetTipo()
        {
            return TipoVehiculo.E;
        }
    }
    class Tractor : Vehiculo
    {
        TipoVehiculo Tipo;
        public Tractor(string patente, string nombre, int precio) : base(patente, nombre, precio)
        {
            Tipo = TipoVehiculo.F;
        }
        public override int GetTipoN()
        {
            return (int)TipoVehiculo.F;
        }

        public override TipoVehiculo GetTipo()
        {
            return TipoVehiculo.F;
        }
    }
    class Retroexcavadora : Vehiculo
    {
        TipoVehiculo Tipo;
        public Retroexcavadora(string patente, string nombre, int precio) : base(patente, nombre, precio)
        {
            Tipo = TipoVehiculo.G;
        }
        public override int GetTipoN()
        {
            return (int)TipoVehiculo.G;
        }

        public override TipoVehiculo GetTipo()
        {
            return TipoVehiculo.G;
        }
    }


}

