using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class OperationProductEntryService : IOperationProductEntryRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public OperationProductEntryService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<OperationProductEntry> GetAll()
        {
            return _context.OperationProductEntry;
        }

        // Obtener elemento especifico
        public OperationProductEntry GetById(int id)
        {
            return _context.OperationProductEntry.Find(id);
        }

        // Insertar elementos en la base de datos
        public OperationProductEntry Insert(OperationProductEntry operationProductEntry, string id)
        {
            // Guardar elemento
            operationProductEntry.dateOperationEntry = DateTime.Now;
            operationProductEntry.auditInsert(id);
            _context.OperationProductEntry.Add(operationProductEntry);
            _context.SaveChanges();
            return operationProductEntry;
        }

        // Actualizar elemento
        public OperationProductEntry Update(OperationProductEntryDto operationProductEntryParam, string id)
        {
            // Buscamos elemento a modificar
            var operationProductEntry = _context.OperationProductEntry.Find(operationProductEntryParam.idOperationEntry);

            // verificamos q existe
            if (operationProductEntry == null)
                throw new AppException("Operacion de Producto de entrada no existe.");

            // actualizamos dato
            operationProductEntry.update(operationProductEntryParam, _context);

            // Guardar cambios
            operationProductEntry.auditUpdate(id);
            _context.OperationProductEntry.Update(operationProductEntry);
            _context.SaveChanges();
            return operationProductEntry;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public OperationProductEntry Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OperationProductEntry Insert(OperationProductEntry body)
        {
            throw new NotImplementedException();
        }

        public OperationProductEntry Update(OperationProductEntryDto body)
        {
            throw new NotImplementedException();
        }

        public OperationProductEntry Delete(int id, string ids)
        {
            throw new NotImplementedException();
        }
    }
}