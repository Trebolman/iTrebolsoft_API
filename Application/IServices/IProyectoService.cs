using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IProyectoService
    {
        Guid Insert(ProyectoDTO entityDTO);
        IList<ProyectoDTO> GetAll();
        Guid Update(ProyectoDTO entityDTO);
        void Delete(Guid entityId);
        ProyectoDTO GetProyecto(Guid entityId);
    }
}
