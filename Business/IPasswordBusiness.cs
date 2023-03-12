namespace Business
{
    public interface IPasswordBusiness
    {
        Task<int> goodPassword(string pwd);
    }
}