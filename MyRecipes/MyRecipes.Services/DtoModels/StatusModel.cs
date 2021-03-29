namespace MyRecipes.Services.DtoModels
{
    public class StatusModel
    {
        public StatusModel()
        {
            IsSuccessful = true;
        }

        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
