using Kab.DemirAjans.Business.Mapper;
using Kab.DemirAjans.DataAccess.Activations;
using Kab.DemirAjans.Domain.Activations;
using Kab.DemirAjans.Entities.Activations;
using System;

namespace Kab.DemirAjans.Business.Activations;

public class ActivationManager(IActivationDal activationDal) : IActivationService
{
    private readonly IActivationDal _activationDal = activationDal;

    public async Task<ActivationDto?> GetByEmailAsync(string email) => await _activationDal.GetByEmailAsync(email);

    public async Task InsertAsync(ActivationCreateDto create)
    {
        var activation = new Activation(create.Email, create.Code, create.ExpirationDate);

        await _activationDal.InsertAsync(ObjectMapper.Mapper.Map<Activation, ActivationDto>(activation));
    }

    public async Task SendActivationCodeAsync(ActivationCreateDto create)
    {
        create.Code = string.Empty;
        while (create.Code.Length < 6)
            create.Code = string.Join("", create.Code, new Random().Next(0, 9).ToString());

        //todo send mail

        await InsertAsync(create);
    }

    public async Task VerifyActivationCodeAsync(VerifyActivationDto verify)
    {
        var activationDto = await GetByEmailAsync(verify.Email) ?? throw new ArgumentException("Aktivasyon kodu bulunamadı!");

        if (activationDto.ExpirationDate < DateTime.UtcNow)
            throw new ArgumentException("Doğrulama süresi doldu!");

        if (!string.Equals(activationDto.Code, verify.Code))
            throw new ArgumentException("Doğrulama kodu yanlış!");
    }
}