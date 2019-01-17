using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IProyectoService
    {
        void Insert(ProyectoDTO entityDTO);
        IList<ProyectoDTO> GetAll();
        void Update(ProyectoDTO entityDTO);
        void Delete(Guid entityId);
        ProyectoDTO GetProyecto(Guid entityId);
    }
}
