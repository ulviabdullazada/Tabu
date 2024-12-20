using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Entities;
using Tabu.Exceptions.Language;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class LanguageService(TabuDbContext _context, IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguageExistException();
            var lang = _mapper.Map<Language>(dto);
            await _context.Languages.AddAsync(lang);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            var langs = await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGetDto>>(langs);
        }

        public Task<LanguageGetDto> GetByCode(string code)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(string code, LanguageUpdateDto dto)
        {
            var data = await _getByCode(code);
            if (data == null) throw new LanguageNotFoundException();
            _mapper.Map(dto,data);
            await _context.SaveChangesAsync();
        }

        async Task<Language?> _getByCode(string code)
            => await _context.Languages.FindAsync(code);
    }
}
