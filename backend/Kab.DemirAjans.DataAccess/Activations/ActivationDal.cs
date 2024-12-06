using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.Entities.Activations;
using System;

namespace Kab.DemirAjans.DataAccess.Activations;

public class ActivationDal(ISqlDataAccess db) : IActivationDal
{
    private readonly ISqlDataAccess _db = db;

    public async Task<ActivationDto?> GetByEmailAsync(string email) => (await _db.LoadDataAsync<ActivationDto, dynamic>(storedProcedure: "spActivations_GetByMail", new { Email = email })).FirstOrDefault();
    public async Task InsertAsync(ActivationDto activationDto) => await _db.SaveDataAsync(storedProcedure: "spActivations_Insert",
        new { activationDto.Code, activationDto.Email, activationDto.ExpirationDate, activationDto.CreationDate, activationDto.LastModificationDate });
}