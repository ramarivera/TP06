using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EJ02
{
	public class CRUDPersonaFacade
	{
		public UnitOfWork iUnitOfWork;

		public CRUDPersonaFacade(UnitOfWork pUOW)
		{
			this.iUnitOfWork = pUOW;
		}

		public virtual void Create(Persona pPersona)
		{
				this.iUnitOfWork.PersonaRepository.Insert(pPersona);
				/*foreach (var item in pPersona.Telefonos)
				{
					this.iUnitOfWork.TelefonoRepository.Insert(item);
				}*/
				this.iUnitOfWork.Save();

		}

		public virtual void Update(Persona pPersona)
		{
				Persona lPersonaOriginal = this.iUnitOfWork.PersonaRepository.GetByID(pPersona.PersonaId);

				if (lPersonaOriginal != null)
				{
				// Entry<TEntity>(original).CurrentValues.SetValues(current)
				//this.iUnitOfWork.PersonaRepository.context.Entry<Persona>(lPersonaOriginal).CurrentValues.SetValues(pPersona);
					
					

					foreach (var telefono in pPersona.Telefonos)                    // Recorro los telefonos de pPersona para Actualizar / Agregar
				   {
					/*if (lPersonaOriginal.Telefonos.Contains(telefono))
					{
						this.iUnitOfWork.TelefonoRepository.Delete(telefono);
					}*/
					// if (lTemp.Telefonos.FirstOrDefault(t => t.TelefonoId == telefono.TelefonoId) == null)
					if (telefono.TelefonoId == 0)
						{
							// Agregar
							this.iUnitOfWork.TelefonoRepository.Insert(telefono);
						}
						else
						{
							// Actualizar
							this.iUnitOfWork.TelefonoRepository.Update(telefono);
						}
					}

                //IList<Telefono> listaAux = lPersonaOriginal.Telefonos;

                /*lPersonaOriginal.Telefonos.RemoveAll(
					t => pPersona.Telefonos.SingleOrDefault<Telefono>(t2 => t2.TelefonoId == t.TelefonoId) == null);*/
              /*  var eliminar = lPersonaOriginal.Telefonos.Except<Telefono>(
                    pPersona.Telefonos,
                    new IEqualityComparers.TelefonoIdComparer());

                foreach (Telefono tel in eliminar)
                {
                    this.iUnitOfWork.TelefonoRepository.Delete(tel);
                }*/

				    foreach (var telefono in lPersonaOriginal.Telefonos.ToArray<Telefono>())                       // Recorro los telefonos de lTemp par eliminar los que no esten en pPersona
					{
						if (!pPersona.Telefonos.Contains(telefono, new IEqualityComparers.TelefonoIdComparer()))	{
							this.iUnitOfWork.TelefonoRepository.Delete(telefono);
						}
					}
					

				   /* this.iUnitOfWork.PersonaRepository.context.Entry<Persona>(lPersonaOriginal).CurrentValues.SetValues(pPersona);
					this.iUnitOfWork.PersonaRepository.Update(lPersonaOriginal);
					*/
				   this.iUnitOfWork.PersonaRepository.Update(lPersonaOriginal);
					this.iUnitOfWork.Save();
				}
				else
				{
					// Si lTemp es nulo singifica  que la persona no esta cargada y por lo tanto hubo un error
				}
		}

		public virtual void Delete(Persona pPersona)
		{
				this.iUnitOfWork.PersonaRepository.Delete(pPersona.PersonaId);
				this.iUnitOfWork.Save();
		}

		public virtual List<Persona> GetAll()
		{
			List<Persona> lResultado = new List<Persona>();
			var query = this.iUnitOfWork.PersonaRepository.Queryable.AsNoTracking().Include(p => p.Telefonos);//.AsNoTracking();//.Select(p => p);
																											  // var query = (new AgendaContext()).Set<Persona>().Include(p => p.Telefonos);
																											  //query.Load();
			lResultado = query.ToList<Persona>();
			return lResultado;
		}

		public virtual Persona GetById(int pPersona)
		{
			Persona lResultado;
			var query = (from persona in this.iUnitOfWork.PersonaRepository.Queryable.AsNoTracking().Include(p => p.Telefonos)//;.AsNoTracking()
						 where persona.PersonaId == pPersona
						 select persona);

			lResultado = query.FirstOrDefault<Persona>();
			return lResultado;
		}

		/*public virtual List<Persona> GetAll()
		{
			List<Persona> lResultado = new List<Persona>();
				var query = this.iUnitOfWork.PersonaRepository.Queryable.Include(p => p.Telefonos);//.AsNoTracking();//.Select(p => p);
				// var query = (new AgendaContext()).Set<Persona>().Include(p => p.Telefonos);
				//query.Load();
				lResultado = query.ToList<Persona>();
			return lResultado;
		}

		public virtual Persona GetById(int pPersona)
		{
			Persona lResultado;
				var query = (from persona in this.iUnitOfWork.PersonaRepository.Queryable.Include(p => p.Telefonos)//;.AsNoTracking()
							 where persona.PersonaId == pPersona
							 select persona);

				lResultado = query.FirstOrDefault<Persona>();
			return lResultado;
		}*/
	}
}
