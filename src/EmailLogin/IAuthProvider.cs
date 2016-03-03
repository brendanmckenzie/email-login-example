using System;

namespace EmailLogin
{
    public interface IAuthProvider
    {
        Guid StoreChallenge(Guid user, string token);

        string GetChallengeToken(Guid id);
    }
}