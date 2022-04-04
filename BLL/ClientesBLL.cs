using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Luis_Baltodano_AP1_P3.Entidades;
using Luis_Baltodano_AP1_P3.DAL;
using System.Linq;
using System.Linq.Expressions;



namespace Luis_Baltodano_AP1_P3.BLL
{
    public class ClientesBLL
    {
        private Contexto _contexto;

        public ClientesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int clienteId)
        {
       
            bool encontrado = false;

            try
            {
                encontrado = _contexto.Clientes.Any(e => e.ClienteId == clienteId);
            }
            catch (Exception)
            {

                throw;
            }
         
            return encontrado;
        }
        public  bool Existe(string nombre)
        {
      
            bool encontrado = false;

            try
            {
                encontrado = _contexto.Clientes.Any(e => e.Nombre == nombre);
            }
            catch (Exception)
            {

                throw;
            }
          
            return encontrado;

        }
        private  bool Insertar(Clientes clientes)
        {
   
            bool paso = false;

            try
            {
                _contexto.Clientes.Add(clientes);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
          
            return paso;

        }
        private bool Modificar(Clientes clientes)
        {
         
            bool paso = false;
            try
            {
                _contexto.Entry(clientes).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
    
            return paso;


        }

        public bool Guardar(Clientes clientes)
        {
            if (!Existe(clientes.ClienteId))
                return Insertar(clientes);
                else
                return Modificar(clientes);
        }

        public  bool Eliminar(int clienteId)
        {

        
            bool paso = false;
            try
            {
                var clientes = _contexto.Clientes.Find(clienteId);
                if(clientes != null)
                {
                    _contexto.Clientes.Remove(clientes);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
          
            return paso;

        }

        public Clientes Buscar(int clienteId)
        {


 
            Clientes? clientes;
            try
            {
                clientes = _contexto.Clientes.Find(clienteId);
            }
            catch (Exception)
            {

                throw;
            }
            return clientes;




        }
        public List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {

            List<Clientes> lista = new List<Clientes>();
            try
            {
                lista = _contexto.Clientes.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;

        }


    }
}