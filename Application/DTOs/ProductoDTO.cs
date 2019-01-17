using System;

namespace Application.DTOs
{
    public class ProductoDTO
    {
        public Guid ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdCod { get; set; }
        public string ProdDesc { get; set; }
        public string ProdStock { get; set; }
        public string ProdBrand { get; set; }
        public string ProdPrice { get; set; }
        public Guid? FkUserUserId { get; set; }
    }
}
