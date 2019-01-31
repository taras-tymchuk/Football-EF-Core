using DAL.Models;

namespace BLL.Interfaces
{
    public interface IAgeChecker
    {
        bool IsYoungerThan( Player player, int age );
    }
}
