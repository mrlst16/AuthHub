namespace AuthHub.Interfaces.Hashing
{
    public interface IHasher
    {
        byte[] HashPasswordWithSalt(byte[] password, byte[] salt, int length, int iterations = 100);
        (byte[], byte[]) HashPasswordWithSalt(byte[] password, int length, int saltLength = 10, int iterations = 100);
        (byte[], byte[]) HashPasswordWithSalt(string password, int length, int saltLength = 10, int iterations = 100);
    }
}
