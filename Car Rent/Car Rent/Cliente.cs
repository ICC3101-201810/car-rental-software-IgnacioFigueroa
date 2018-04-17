using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rent
{
    interface IGetLicencia
    {
        TipoVehiculo Getlicencia();
        List<TipoVehiculo> GetAutorizacion();
        List<TipoVehiculo> GetPermiso();
    }

    public enum TipoCliente {Persona, Organizacion, Empresa, Insitucion}
    abstract class Cliente : IGetLicencia
    {
        public string Nombre { get; private set; }

        public Cliente(string nombreCliente)
        {
            Nombre = nombreCliente;
        }

        public virtual TipoCliente GetTipo()
        {
            return TipoCliente.Persona;
        }
        public virtual int GetTipoN()
        {
            return (int)TipoCliente.Persona;
        }

        public TipoVehiculo Getlicencia()
        {
            return TipoVehiculo.A;
        }

        public List<TipoVehiculo> GetAutorizacion()
        {
            return new List<TipoVehiculo>();
        }

        public List<TipoVehiculo> GetPermiso()
        {
            return new List<TipoVehiculo>();
        }

    }


    class Persona : Cliente, IGetLicencia
    {
        public TipoVehiculo licenciaPersona { get; private set; }
        

        public Persona(string miNombre, TipoVehiculo licencia) : base(miNombre)
        {
            licenciaPersona = licencia;
        }
        public override TipoCliente GetTipo()
        {
            return TipoCliente.Persona;
        }

        public override int GetTipoN()
        {
            return (int)TipoCliente.Persona;
        }

        public TipoVehiculo Getlicencia()
        {
            return licenciaPersona;
        }

    }

    class Organizacion : Cliente, IGetLicencia
    {
        public List<TipoVehiculo> autorizacion { get; private set; }
        public List<TipoVehiculo> permisos { get; private set; }

        public Organizacion(string miNombre, List<TipoVehiculo>autorizacion,List<TipoVehiculo> permisos ) : base(miNombre)
        {
            this.autorizacion = autorizacion;
            this.permisos = permisos;
        }
        public override TipoCliente GetTipo()
        {
            return TipoCliente.Organizacion;
        }

        public override int GetTipoN()
        {
            return (int)TipoCliente.Organizacion;
        }

        public List<TipoVehiculo> GetAutorizacion()
        {
            return autorizacion;
        }

        public List<TipoVehiculo> GetPermiso()
        {
            return permisos;
        }
    }

    class Empresa : Cliente,IGetLicencia
    {
        public List<TipoVehiculo> autorizacion { get; private set; }
        public List<TipoVehiculo> permisos { get; private set; }

        public Empresa(string miNombre, List<TipoVehiculo> autorizacion, List<TipoVehiculo> permisos) : base(miNombre)
        {
            this.autorizacion = autorizacion;
            this.permisos = permisos;
        }
        public override TipoCliente GetTipo()
        {
            return TipoCliente.Empresa;
        }

        public override int GetTipoN()
        {
            return (int)TipoCliente.Empresa;
        }

        public List<TipoVehiculo> Getlicencia()
        {
            return autorizacion;
        }

        public List<TipoVehiculo> GetAutorizacion()
        {
            return autorizacion;
        }

        public List<TipoVehiculo> GetPermiso()
        {
            return permisos;
        }
    }

    class Institucion : Cliente,IGetLicencia
    {
        public List<TipoVehiculo> autorizacion { get; private set; }
        public List<TipoVehiculo> permisos { get; private set; }

        public Institucion(string miNombre, List<TipoVehiculo> autorizacion, List<TipoVehiculo> permisos) : base(miNombre)
        {
            this.autorizacion = autorizacion;
            this.permisos = permisos;
        }
        public override TipoCliente GetTipo()
        {
            return TipoCliente.Insitucion;
        }

        public override int GetTipoN()
        {
            return (int)TipoCliente.Insitucion;
        }

        public List<TipoVehiculo> Getlicencia()
        {
            return autorizacion;
        }
        public List<TipoVehiculo> GetAutorizacion()
        {
            return autorizacion;
        }

        public List<TipoVehiculo> GetPermiso()
        {
            return permisos;
        }
    }




}
