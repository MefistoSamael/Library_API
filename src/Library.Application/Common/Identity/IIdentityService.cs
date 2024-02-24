namespace Library.Application.Common.Identity
{
    public interface IIdentityService
    {
        public string GetJwtToken(string username);
    }
}
