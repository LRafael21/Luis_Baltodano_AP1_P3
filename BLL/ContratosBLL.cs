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


                foreach (var detalle in contratos.ContratosDetalle)
                {
                    ___contexto.Entry(detalle).State = EntityState.Added;
                    ___contexto.Entry(detalle.servicios).State = EntityState.Modified;
                    detalle.servicios.MontoFacturado += detalle.Cantidad * detalle.servicios.Precio;

                }
                ___contexto.Contratos.Add(contratos);
                paso = ___contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }

            return paso;

        }
        private bool Modificar(Contratos contratoModificado)
        {

            bool paso = false;
            try
            {
                var contratoAnterior = ___contexto.Contratos
                .Where(c => c.ContratoId == contratoModificado.ContratoId)
                .Include(c => c.ContratosDetalle)
                .ThenInclude(c => c.servicios)
                .AsNoTracking()
                .SingleOrDefault();
                if (contratoAnterior != null)   //Buscamos el contrato anterior
                {
                    foreach (var detalleAnterior in contratoAnterior.ContratosDetalle) //Por cada detalle se deshace el calculo de montoFacturado
                    {
                        detalleAnterior.servicios.MontoFacturado -= detalleAnterior.Cantidad * detalleAnterior.servicios.Precio;
                    }
                    ___contexto.Database.ExecuteSqlRaw($"DELETE from ContratosDetalle where ContratoId = {contratoAnterior.ContratoId}"); //y se borra el anterior

                    foreach (var detalle in contratoModificado.ContratosDetalle) //ahora se va a crear un nuevo detalle
                    {
                        ___contexto.Entry(detalle).State = EntityState.Added;
                        ___contexto.Entry(detalle.servicios).State = EntityState.Modified;
                        detalle.servicios.MontoFacturado += detalle.Cantidad * detalle.servicios.Precio;
                    }

                    ___contexto.Entry(contratoModificado).State = EntityState.Modified;

                    paso = ___contexto.SaveChanges() > 0;
                }


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

                    foreach (var detalle in contratos.ContratosDetalle)
                    {
                        ___contexto.Entry(detalle.servicios.Plan).State =  EntityState.Modified;
                        ___contexto.Entry(detalle.servicios).State = EntityState.Modified;
                        detalle.servicios.MontoFacturado -= detalle.Cantidad * detalle.servicios.Precio;
                    }
                  
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
                contratos = ___contexto.Contratos.Include(x => x.ContratosDetalle).ThenInclude(x => x.servicios).ThenInclude(x => x.Plan)
                .Where(p => p.ContratoId == contratoId).AsNoTracking().SingleOrDefault();
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
               .ThenInclude(x => x.servicios)
               .ThenInclude(x => x.Plan)
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

        public List<Contratos> GetLista(Expression<Func<Contratos, bool>> criterio)
        {

            List<Contratos> lista = new List<Contratos>();
            try
            {
                lista = ___contexto.Contratos.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;

        }

    }
}