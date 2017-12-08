using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nearest_Pharmacy.Models
{
    public interface IPharmacyService
    {

        Task<IEnumerable<Product>> GetProduct();

        Task<UserInfo> Add(UserInfo user);

        Task<User> Login(User user);
        Task<List<UserInfo>> GetUserInfo(string login);
        Task<int> GetSync();
    }
}