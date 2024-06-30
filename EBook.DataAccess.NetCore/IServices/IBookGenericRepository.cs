﻿using EBook.DataAccess.NetCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.IServices
{
    public interface IBookGenericRepository: IGenericRepository<Book>
    {
    }
}