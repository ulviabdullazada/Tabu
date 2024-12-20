using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tabu.DAL;
using Tabu.DTOs.Words;
using Tabu.Entities;
using Tabu.Exceptions.Word;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class WordService(TabuDbContext _context) : IWordService
    {
        public async Task<int> CreateAsync(WordCreateDto dto)
        {
            if (await _context.Words.AnyAsync(w=> w.LanguageCode == dto.Language && w.Text == dto.Text))
            {
                //TODO: Custom exception yaz
                throw new Exception();
            }
            if (dto.BannedWords.Count() != 6)
                throw new InvalidBannedWordCountExcpetion();
            Word word = new Word
            {
                LanguageCode = dto.Language,
                Text = dto.Text,
                BannedWords = dto.BannedWords.Select(x=> new BannedWord
                {
                    Text = x
                }).ToList()
            };
            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync();
            return word.Id;
        }

        public async Task<IEnumerable<Word>> GetAllAsync()
        {
            return await _context.Words.ToListAsync();
        }
    }
}
