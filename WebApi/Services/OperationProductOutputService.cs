using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class OperationProductOutputService : IOperationProductOutputRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public OperationProductOutputService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<OperationProductOutput> GetAll()
        {
            return _context.OperationProductOutput;
        }

        // Obtener elemento especifico
        public OperationProductOutput GetById(int id)
        {
            return _context.OperationProductOutput.Find(id);
        }

        // Insertar elementos en la base de datos
        public OperationProductOutput Insert(OperationProductOutput opOutput, string id)
        {
            // Guardar elemento
            opOutput.auditInsert(id);
            _context.OperationProductOutput.Add(opOutput);
            _context.SaveChanges();
            return opOutput;
        }

        // Actualizar elemento
        public OperationProductOutput Update(OperationProductOutputDto opOutputParam, string id)
        {
            // Buscamos elemento a modificar
            var opOutput = _context.OperationProductOutput.Find(opOutputParam.idOperationOutput);

            // verificamos q existe
            if (opOutput == null)
                throw new AppException("Operacion Producto de salida no existe.");

            // actualizamos dato
            opOutput.update(opOutputParam, _context);
            opOutput.auditUpdate(id);

            // Guardar cambios
            _context.OperationProductOutput.Update(opOutput);
            _context.SaveChanges();
            return opOutput;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public OperationProductOutput Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OperationProductOutput Insert(OperationProductOutput body)
        {
            throw new NotImplementedException();
        }

        public OperationProductOutput Update(OperationProductOutputDto body)
        {
            throw new NotImplementedException();
        }

        public OperationProductOutput Delete(int id, string ids)
        {
            throw new NotImplementedException();
        }
    }
}