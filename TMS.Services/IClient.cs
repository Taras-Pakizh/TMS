using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data;
using TMS.ViewModels;

namespace TMS.Services
{
    public interface IClient
    {
        bool IsAuthorizated { get; }

        bool Authorization(string username, string password);
        
        Role GetRole();

        Task<Role> GetRoleAsync();

        Task<UserView> GetCurrentUser(string login);

        string Register(string email, string password, string login, string roleName, string firstname, string lastname, int teamId);
        
        #region CRUD

        IEnumerable<Tview> GetAll<Tview>() where Tview : IViewBase;

        Task<IEnumerable<Tview>> GetAllAsync<Tview>() where Tview : IViewBase;

        Tview Get<Tview>(int id) where Tview : IViewBase;

        Task<Tview> GetAsync<Tview>(int id) where Tview : IViewBase;

        bool Add<Tview>(Tview model) where Tview : IViewBase;

        Task<bool> AddAsync<Tview>(Tview model) where Tview : IViewBase;

        bool Update<Tview>(Tview model) where Tview : IViewBase;

        Task<bool> UpdateAsync<Tview>(Tview model) where Tview : IViewBase;

        bool Delete<Tview>(int id) where Tview : IViewBase;

        Task<bool> DeleteAsync<Tview>(int id) where Tview : IViewBase;

        #endregion
    }
}
