namespace EmailLogin
{
    public interface ICryptoProvider
    {
        byte[] Encrypt(byte[] data, byte[] key);

        byte[] Decrypt(byte[] data, byte[] key);

        byte[] PublicKey { get; }

        byte[] PrivateKey { get; }
    }
}