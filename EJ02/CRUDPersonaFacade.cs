using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EJ02
{
    class CRUDPersonaFacade
    {
        public UnitOfWork iUnitOfWork;


        public void Create(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork.PersonaRepository.Insert(pPersona);

                /*foreach (Telefono tel in pPersona.Telefonos)
                {
                    this.iUnitOfWork.TelefonoRepository.Insert(tel);
                }*/

                this.iUnitOfWork.Save();
            }

        }

        public void Update(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {

                foreach (Telefono tel in pPersona.Telefonos)
                {
                    Console.WriteLine(this.iUnitOfWork.TelefonoRepository.context.Entry(tel).State); //.Update(tel);
                }

                this.iUnitOfWork.PersonaRepository.Update(pPersona);

               

                this.iUnitOfWork.Save();
            }
        }

        public void Delete(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {

               /* foreach (Telefono tel in pPersona.Telefonos)
                {
                    this.iUnitOfWork.TelefonoRepository.Delete(tel);
                }*/

                this.iUnitOfWork.PersonaRepository.Delete(pPersona);

                this.iUnitOfWork.Save();
            }
        }

        public List<Persona> GetAll()
        {
            /*IQueryable<Persona> lListaPersonas;
            IQueryable<Telefono> lListaTelefonos;*/
            using (this.iUnitOfWork = new UnitOfWork())
            {
                return iUnitOfWork
                            .PersonaRepository
                            .Queryable
                            .Include("Telefonos")
                            .ToList<Persona>();
                //iUnitOfWork.TelefonoRepository.Queryable;
                //return lListaPersonas.ToList<Persona>();
            }
           
        }

        public Persona GetById(int pPersona)
        {
            //IQueryable<Persona> lListaPersonas;
            //IQueryable lListaTelefonos;
            Persona lPersona;
            using (this.iUnitOfWork = new UnitOfWork())
            {
                //lListaPersonas = iUnitOfWork.PersonaRepository.Queryable;
                //lListaTelefonos = iUnitOfWork.TelefonoRepository.Queryable;
                //this.iUnitOfWork.PersonaRepository.Ge
                lPersona = this.iUnitOfWork.PersonaRepository.GetByID(pPersona);
                lPersona.Telefonos = lPersona.Telefonos;
                //lPersona.Telefonos.ToList<Telefono>();
                //lPersona.Telefonos.
            }
            return lPersona;
        }
    }
}
