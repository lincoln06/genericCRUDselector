namespace CRUDSelector
{
    public interface ICrud
    {
        public abstract User Login(string email, string password);
        public abstract void Register(User user);
    }
}