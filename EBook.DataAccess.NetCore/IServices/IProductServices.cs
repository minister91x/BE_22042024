﻿using EBook.DataAccess.NetCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.IServices
{
    public interface IProductServices
    {
        Task<List<Product>> ProductGetList();
        Task<ProductInsertReturnData> ProductInsertUpdate(ProductInsertUpdateRequestData requestData);

        Task<Product_DeleteReturnData> Product_Delete(Product_DeleteRequestData requestData);
    }
}
