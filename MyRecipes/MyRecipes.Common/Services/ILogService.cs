using MyRecipes.Common.Models;

namespace MyRecipes.Common.Services
{
    public interface ILogService
    {
        void Log(LogData logData);
    }
}
