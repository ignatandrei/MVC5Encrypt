namespace MVCEncrypt
{
    public interface IEncryptDecrypt
    {
        string EncryptString(string value);
        string DecryptString(string value);
    }
}
