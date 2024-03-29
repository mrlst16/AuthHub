﻿namespace AuthHub.Interfaces.Hashing
{
    public interface IHasher
    {
        public byte[] HashUsernameAndPasswordWithSalt(byte[] password, byte[] salt, int length, int iterations = 100);
    }
}
