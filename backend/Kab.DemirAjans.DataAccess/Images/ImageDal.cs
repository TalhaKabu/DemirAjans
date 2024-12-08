using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.Entities.Images;
using System;

namespace Kab.DemirAjans.DataAccess.Images;

public class ImageDal(ISqlDataAccess db) : IImageDal
{
    private readonly ISqlDataAccess _db = db;

    public async Task InsertAsync(ImageDto imageDto) => await _db.SaveDataAsync(storedProcedure: "spImages_Insert", new { imageDto.Id, imageDto.ProductId, imageDto.IsFrontImage, imageDto.CreationDate, imageDto.LastModificationDate });

    public async Task<IEnumerable<ImageDto>> GetListByProductIdAsync(int productId) => await _db.LoadDataAsync<ImageDto, dynamic>(storedProcedure: "spImages_GetByProductId", new { productId = productId });
}