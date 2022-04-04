using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Luis_Baltodano_AP1_P3.Entidades;
using Luis_Baltodano_AP1_P3.DAL;
using System.Linq;
using System.Linq.Expressions;



namespace Luis_Baltodano_AP1_P3.BLLContratos
{
    public class ContratosBLL
    {
        private Contexto ___contexto;

        public ContratosBLL(Contexto contexto)
        {
            ___contexto = contexto;
        }

        public bool Existe(int contratoId)
        {

            bool encontrado = false;

            try
            {
                encontrado = ___contexto.Contratos.Any(e => e.ContratoId == contratoId);
            }
            catch (Exception)
            {

                throw;
            }

            return encontrado;
        }
        public bool Existe(string comentarios)
        {

            bool encontrado = false;

            try
            {
                encontrado = ___contexto.Contratos.Any(e => e.Comentarios == comentarios);
            }
            catch (Exception)
            {

                throw;
            }

            return encontrado;

        }
        private bool Insertar(Contratos contratos)
        {

            bool paso = false;

            try
            {
                ___contexto.Contratos.Add(contratos);
                paso = ___contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return paso;

        }
        private bool Modificar(Contratos contratos)
        {

            bool paso = false;
            try
            {
                ___contexto.Database.ExecuteSqlRaw($"Delete FROM ContratosDetalle where ContratoId={contratos.ContratoId}");

                foreach (var anterior in contratos.ContratosDetalle)
                {
                    ___contexto.Entry(anterior).State = EntityState.Added;
                }

                ___contexto.Entry(contratos).State = EntityState.Modified;

                paso = ___contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return paso;


        }

        public bool Guardar(Contratos contratos)
        {
            if (!Existe(contratos.ContratoId))
                return Insertar(contratos);
            else
                return Modificar(contratos);
        }

        public bool Eliminar(int contratoId)
        {


            bool paso = false;
            try
            {
                var contratos = ___contexto.Contratos.Find(contratoId);
                if (contratos != null)
                {
                    ___contexto.Contratos.Remove(contratos);
                    paso = ___contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return paso;

        }

        public Contratos Buscar(int contratoId)
        {

            Contratos? contratos;
            try
            {
                contratos = ___contexto.Contratos.Include(x => x.ContratosDetalle).Where(p => p.ContratoId == contratoId).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return contratos;


        }
        public List<Contratos> GetList(Expression<Func<Contratos, bool>> criterio)
        {

            List<Contratos> lista = new List<Contratos>();
            try
            {
                lista = ___contexto.Contratos
               .Include(x => x.ContratosDetalle)
               .Where(criterio)
               .AsNoTracking()
               .ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;

        }
       
    }
}