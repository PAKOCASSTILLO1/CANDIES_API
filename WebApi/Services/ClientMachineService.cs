using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class ClientMachineService : IClientMachineRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public ClientMachineService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<ClientMachine> GetAll()
        {
            List<ClientMachine> clientMachines = _context.ClientMachine.ToList();
            List<ClientMachine> clientMachines2 = _context.ClientMachine.ToList();
            foreach (ClientMachine clientMachine in clientMachines)
            {
                if (clientMachine.state == false)
                {
                    // Eliminar elementos inactivos
                    clientMachines2.Remove(clientMachine);
                }
            }
            return clientMachines2;
        }

        // Obtener elemento especifico
        public ClientMachine GetById(int id)
        {
            return _context.ClientMachine.Find(id);
        }

        // Insertar elementos en la base de datos
        public ClientMachine Insert(ClientMachine clientMachine, string id)
        {
            clientMachine.auditInsert(id);
            // Guardar elemento
            _context.ClientMachine.Add(clientMachine);
            _context.SaveChanges();
            return clientMachine;
        }

        // Actualizar elemento
        public ClientMachine Update(ClientMachineDto clientMachineParam, string id)
        {
            // Buscamos elemento a modificar
            var clientMachine = _context.ClientMachine.Find(clientMachineParam.idClientMachine);

            // verificamos q existe
            if (clientMachine == null)
                throw new AppException("Cliente Maquina no existe.");

            // actualizamos dato
            clientMachine.update(clientMachineParam, _context);
            clientMachine.auditUpdate(id);
            // Guardar cambios
            _context.ClientMachine.Update(clientMachine);
            _context.SaveChanges();
            return clientMachine;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public ClientMachine Delete(int id, string ids)
        {
            // Buscamos elemento a eliminar
            var clientMachine = _context.ClientMachine.Find(id);

            // verificamos que el elemnto existe
            if (clientMachine == null || clientMachine.state == false)
            {
                throw new AppException("Cliente Maquina no existe.");
            }

            // cambiamos estado
            clientMachine.state = false;
            clientMachine.auditUpdate(ids);

            // Guardamos cambios
            _context.ClientMachine.Update(clientMachine);
            _context.SaveChanges();
            return clientMachine;
        }

        public ClientMachine Insert(ClientMachine body)
        {
            throw new NotImplementedException();
        }

        public ClientMachine Update(ClientMachineDto body)
        {
            throw new NotImplementedException();
        }

        public ClientMachine Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}