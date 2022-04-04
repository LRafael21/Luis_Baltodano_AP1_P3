using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Luis_Baltodano_AP1_P3.Entidades;
using Luis_Baltodano_AP1_P3.DAL;
using System.Linq;
using System.Linq.Expressions;



namespace Luis_Baltodano_AP1_P3.BLLServicios
{
    public class ServiciosBLL
    {
        private Contexto __contexto;

        public ServiciosBLL(Contexto contexto)
        {
            __contexto = contexto;
        }

        public bool Existe(int servicioId)
        {
       
            bool encontrado = false;

            try
            {
                encontrado = __contexto.Servicios.Any(e => e.ServicioId == servicioId);
            }
            catch (Exception)
            {

                throw;
            }
         
            return encontrado;
        }
        public  bool Existe(string descripcion)
        {
      
            bool encontrado = false;

            try
            {
                encontrado = __contexto.Servicios.Any(e => e.Descripcion == descripcion);
            }
            catch (Exception)
            {

                throw;
            }
          
            return encontrado;

        }
        private  bool Insertar(Servicios servicios)
        {
   
            bool paso = false;

            try
            {
                __contexto.Servicios.Add(servicios);
                paso = __contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
          
            return paso;

        }
        private bool Modificar(Servicios servicios)
        {
         
            bool paso = false;
            try
            {
                __contexto.Entry(servicios).State = EntityState.Modified;
                paso = __contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
    
            return paso;


        }

        public bool Guardar(Servicios servicios)
        {
            if (!Existe(servicios.ServicioId))
                return Insertar(servicios);
                else
                return Modificar(servicios);
        }

        public  bool Eliminar(int servicioId)
        {

        
            bool paso = false;
            try
            {
                var servicios = __contexto.Servicios.Find(servicioId);
                if(servicios != null)
                {
                    __contexto.Servicios.Remove(servicios);
                    paso = __contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
          
            return paso;

        }

        public Servicios Buscar(int servicioId)
        {


 
            Servicios? servicios;
            try
            {
                servicios = __contexto.Servicios.Find(servicioId);
            }
            catch (Exception)
            {

                throw;
            }
            return servicios;




        }
        public List<Servicios> GetList(Expression<Func<Servicios, bool>> criterio)
        {

            List<Servicios> lista = new List<Servicios>();
            try
            {
                lista = __contexto.Servicios.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;

        }


    }
}