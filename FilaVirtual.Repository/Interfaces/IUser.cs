using System.Security.Claims;

namespace FilaVirtual.Business.Interface
{
    public interface IUser
    {
        public string Name { get; }
        public Guid GetUserId();
        public string GetUserEmail();
        public bool IsAuthenticated();
        public bool IsinRule(string role);
        public string GetUserClaim(string claimType);

        IEnumerable<Claim> GetClaimsIdentity();

    }
}
