using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.Entities.Categories;
using System;

namespace Kab.DemirAjans.DataAccess.Categories;

public class CategoryDal(ISqlDataAccess db) : ICategoryDal
{
    private readonly ISqlDataAccess _db = db;

    public async Task<IEnumerable<CategoryDto>> GetListAsync() => await _db.LoadDataAsync<CategoryDto, dynamic>(storedProcedure: "dbo.spCategories_GetAll", new { });
    public async Task<CategoryDto?> GetAsync(int id) => (await _db.LoadDataAsync<CategoryDto, dynamic>(storedProcedure: "dbo.spCategories_Get", new { Id = id })).FirstOrDefault();
    public async Task InsertAsync(CategoryDto categoryDto) => await _db.SaveDataAsync(storedProcedure: "dbo.spCategories_Insert", new { categoryDto.Name, categoryDto.ImageName, categoryDto.CreationDate, categoryDto.LastModificationDate });
}