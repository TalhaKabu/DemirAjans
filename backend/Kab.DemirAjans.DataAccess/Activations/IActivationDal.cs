using Kab.DemirAjans.Entities.Activations;

namespace Kab.DemirAjans.DataAccess.Activations
{
    public interface IActivationDal
    {
        Task<ActivationDto?> GetByEmailAsync(string email);
        Task InsertAsync(ActivationDto activationDto);
    }
}