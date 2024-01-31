using TestAdo_querries_.Models;

namespace TestAdo_querries_.Interfaces
{
    public interface IUsers
    {
        List<UserDTO> DisplayUsers();
        string AddUser(UserDTO user);
    }
}
