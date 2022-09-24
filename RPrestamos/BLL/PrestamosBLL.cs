using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RPrestamos.DAL;
using RPrestamos.Entidades;

namespace RPrestamos.BLL
{

    public class PrestamosBLL
    {

        private Contexto contextos;

          public PrestamosBLL(Contexto contexto)
          {
               contextos = contexto;
          }

           public bool Existe2(int PrestamosId)
        {
            return contextos.Prestamos.Any(o => o.PrestamosId == PrestamosId);
        }

        private bool Insertar2(Prestamos prestamos)
        {
            contextos.Prestamos.Add(prestamos);
            return contextos.SaveChanges() > 0;
        }

        private bool Modificar2(Prestamos prestamos)
        {
            contextos.Entry(prestamos).State = EntityState.Modified;
            return contextos.SaveChanges() > 0;
        }

        public bool Guardar2(Prestamos prestamos)
        {
            if (!Existe2(prestamos.PrestamosId))
                return this.Insertar2(prestamos);
            else
                return this.Modificar2(prestamos);
        }

        public bool Eliminar2(Prestamos prestamos)
        {
            contextos.Entry(prestamos).State = EntityState.Deleted;
            return contextos.SaveChanges() > 0;
        }

        public Prestamos? Buscar2(int prestamosId)
          {
               return contextos.Prestamos 
                       .Where(o => o.PrestamosId == prestamosId)
                       .AsNoTracking()
                       .SingleOrDefault();

          }


        public bool Editar(Prestamos prestamos)
        {
            if (!Existe2(prestamos.PrestamosId))
                return this.Insertar2(prestamos);
            else
                return this.Modificar2(prestamos);
        }


        public List<Prestamos> GetPrestamos(Expression<Func<Prestamos, bool>> Criterio)
        {
            return contextos.Prestamos
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

        public List<Personas> GetPersonas(Expression<Func<Personas, bool>> Criterio)
        {
            return contextos.Personas
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
    }
}

