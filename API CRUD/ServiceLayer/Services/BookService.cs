using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Book;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;
        public BookService(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    
        public async Task CreateAsync(BookCreateDbo book)
        {
           await _repo.Create(_mapper.Map<Book>(book));
        }

        public async Task<List<BookListDto>> GetAllAsync()
        {
            
            return _mapper.Map<List<BookListDto>>(await _repo.GetAll());
        }
        public async Task DeleteAsync(int id) 
        {
            Book book = await _repo.Get(id);
            if (book == null) throw new NullReferenceException();
            await _repo.Delete(book);
        }
    }
}
