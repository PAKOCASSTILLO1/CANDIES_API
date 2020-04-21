using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class StatusMachineService : IStatusMachineRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public StatusMachineService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<StatusMachine> GetAll()
        {
            return _context.StatusMachine;
        }

        // Obtener elemento especifico
        public StatusMachine GetById(int id)
        {
            return _context.StatusMachine.Find(id);
        }

        // Insertar elementos en la base de datos
        public StatusMachine Insert(StatusMachine statusMachine, string id)
        {
            // Validar si ya existe
            if (_context.StatusMachine.Any(x => x.description == statusMachine.description))
                throw new AppException("El rol \"" + statusMachine.description + "\" ya existe.");

            // Guardar elemento
            statusMachine.auditInsert(id);
            _context.StatusMachine.Add(statusMachine);
            _context.SaveChanges();
            return statusMachine;
        }

        // Actualizar elemento
        public StatusMachine Update(StatusMachineDto statusMachineParam, string id)
        {
            // Buscamos elemento a modificar
            var statusMachine = _context.StatusMachine.Find(statusMachineParam.idStatusMachine);

            // verificamos q existe
            if (statusMachine == null)
                throw new AppException("Rol no existe.");

            // Verificamos si los datos ya existen
            if (statusMachineParam.description != statusMachine.description)
            {
                // statusMachineName has changed so check if the new statusMachineName is already taken
                if (_context.StatusMachine.Any(x => x.description == statusMachineParam.description))
                    throw new AppException("El statusMachine " + statusMachineParam.description + " ya existe");
            }

            // actualizamos dato
            statusMachine.update(statusMachineParam);
            statusMachine.auditUpdate(id);

            // Guardar cambios
            _context.StatusMachine.Update(statusMachine);
            _context.SaveChanges();
            return statusMachine;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public StatusMachine Delete(int id)
        {
            throw new NotImplementedException();
        }

        public StatusMachine Insert(StatusMachine body)
        {
            throw new NotImplementedException();
        }

        public StatusMachine Update(StatusMachineDto body)
        {
            throw new NotImplementedException();
        }

        public StatusMachine Delete(int id, string ids)
        {
            throw new NotImplementedException();
        }
    }
}