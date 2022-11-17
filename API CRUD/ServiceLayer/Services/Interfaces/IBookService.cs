﻿using DomainLayer.Entities;
using ServiceLayer.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IBookService
    {
        Task CreateAsync(BookCreateDbo book);
        Task<List<BookListDto>> GetAllAsync();
        Task DeleteAsync(int id);

    }
}
