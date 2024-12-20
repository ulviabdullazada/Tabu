using Tabu.DTOs.Languages;

namespace Tabu.Services.Abstracts
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task<LanguageGetDto> GetByCode(string code);
        Task CreateAsync(LanguageCreateDto dto);
        Task DeleteAsync(string code);
        Task UpdateAsync(string code, LanguageUpdateDto dto);
    }
}
