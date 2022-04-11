using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Luis_Baltodano_AP1_P3.Entidades;
using Luis_Baltodano_AP1_P3.DAL;




namespace Luis_Baltodano_AP1_P3.BLLPlanes
{
    public class PlanesBLL
    {
        private Contexto contexto;

        public PlanesBLL(Contexto _contexto)
        {
            contexto = _contexto;
        }

       
        public Planes? Buscar(int planId)
        {

            Planes? planes;
            try
            {
                planes = contexto.Planes.Where(c => c.Id == planId).AsNoTracking().FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return planes;


        }
        public List<Planes> GetList()
        {

            return contexto.Planes.AsNoTracking().ToList();

        }


    }
}