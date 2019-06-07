using ZMS.BLL.DTO;

namespace ZMS.WebApp.Infrastructure
{
    public class ValidationData
    {
        public bool IsValidate(AnimalDTO animal)
        {
            if (animal == null)
                return false;

            if (animal.Age < 0 ||
               animal.Age == null ||
               animal.Name == null ||
               animal.Class == null)
            {
                return false;
            }

            return true;
        }
    }
}
