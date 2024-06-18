namespace MenuManagement.Domain.Menus
{
    public interface IMenuRepository
    {
        Task<Menu?> GetAsync(Guid id);
        Task AddAsync(Menu menu);
        Task DeleteAsync(Menu menu);
    }
}
