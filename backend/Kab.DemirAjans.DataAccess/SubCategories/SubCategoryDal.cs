using Kab.DemirAjans.DataAccess.DbAccess;
using Kab.DemirAjans.Entities.SubCategories;
using System;

namespace Kab.DemirAjans.DataAccess.SubCategories;

public class SubCategoryDal(ISqlDataAccess db) : ISubCategoryDal
{
    private readonly ISqlDataAccess _db = db;

    public async Task<IEnumerable<SubCategoryDto>> GetListAsync() => await _db.LoadDataAsync<SubCategoryDto, dynamic>(storedProcedure: "dbo.spSubCategories_GetAll", new { });
    public async Task<IEnumerable<SubCategoryDto>> GetByCategoryIdAsync(int categoryId) => await _db.LoadDataAsync<SubCategoryDto, dynamic>(storedProcedure: "dbo.spSubCategories_GetByCategoryId", new { CategoryId = categoryId });
    public async Task<SubCategoryDto?> GetAsync(int id) => (await _db.LoadDataAsync<SubCategoryDto, dynamic>(storedProcedure: "dbo.spSubCategories_Get", new { Id = id })).FirstOrDefault();
    public async Task InsertAsync(SubCategoryDto subCategoryDto) => await _db.SaveDataAsync(storedProcedure: "dbo.spSubCategories_Insert",
        new { subCategoryDto.Name, subCategoryDto.CategoryId, subCategoryDto.Code, subCategoryDto.CreationDate, subCategoryDto.LastModificationDate });
    public async Task UpdateAsync(int id, SubCategoryDto subCategoryDto) => await _db.SaveDataAsync(storedProcedure: "dbo.spSubCategories_Update",
        new { Id = id, subCategoryDto.Name, subCategoryDto.CategoryId, subCategoryDto.Code, subCategoryDto.CreationDate, subCategoryDto.LastModificationDate });
}