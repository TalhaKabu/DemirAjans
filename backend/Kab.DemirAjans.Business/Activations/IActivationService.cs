using Kab.DemirAjans.Entities.Activations;

namespace Kab.DemirAjans.Business.Activations
{
    public interface IActivationService
    {
        Task<ActivationDto?> GetByEmailAsync(string email);
        Task InsertAsync(ActivationCreateDto create);
        Task SendActivationCodeAsync(ActivationCreateDto create);
    }
}