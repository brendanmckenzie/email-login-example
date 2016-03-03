using System;
using System.Linq;
using System.Collections.Generic;

namespace EmailLogin.Web
{
    public class AuthController
    {
        readonly IEmailProvider _emailProvider;
        readonly IUserProvider _userProvider;
        readonly ICryptoProvider _cryptoProvider;
        readonly IAuthProvider _authProvider;

        public AuthController(IEmailProvider emailProvider, IUserProvider userProvider, ICryptoProvider cryptoProvider, IAuthProvider authProvider)
        {
            _emailProvider = emailProvider;
            _userProvider = userProvider;
            _cryptoProvider = cryptoProvider;
            _authProvider = authProvider;
        }

        public ChallengeResponse Challenge(ChallengeRequest request)
        {
            // This accepts an email address and public key
            // then sends an email to the user

            var user = _userProvider.GetUser(request.Email);
            if (user == null)
            {
                return new ChallengeResponse
                {
                    Errors = new [] { "User not found" }
                };
            }

            var token = Guid.NewGuid().ToString();
            var challenge = _authProvider.StoreChallenge(user.Id, token);

            return new ChallengeResponse
            {
                PublicKey = Convert.ToBase64String(_cryptoProvider.PublicKey),
                Token = _cryptoProvider.Encrypt(token, Convert.FromBase64String(request.PublicKey)),
                Id = challenge
            };
        }

        public VerifyResponse Verify(VerifyRequest request)
        {
            // This is where the user is directed to after
            // clicking the link in the email

            var token = _authProvider.GetChallengeToken(request.Id);

            var providedToken = _cryptoProvider.Decrypt(Convert.FromBase64String(request.Token), _cryptoProvider.PrivateKey);

            if (token == providedToken)
            {
                return new VerifyResponse { };
            }
            else
            {
                return new VerifyResponse { Errors = new [] { "Invalid authentication token" } };
            }
        }
    }

    public abstract class BaseRespose
    {
        public bool Success { get { return Errors == null; } }

        public IEnumerable<string> Errors { get; set; }
    }

    public class ChallengeRequest
    {
        public string Email { get; set; }
        public string PublicKey { get; set; }
    }

    public class ChallengeResponse : BaseRespose
    {
        public string PublicKey { get; set; }

        public string Token { get; set; }
        public Guid Id { get; set; }
    }

    public class VerifyRequest
    {
        public Guid Id { get; set; }
        public string Token { get; set; }

    }

    public class VerifyResponse : BaseRespose
    {

    }
}