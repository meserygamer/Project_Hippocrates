namespace Project_Hippocrates.TestEntityRepositories.Extensions;

public static class IntExtension
{
    public static Guid ToGuid(this int number)
    {
        byte[] bytes = new byte[16];
        BitConverter.GetBytes(number).CopyTo(bytes, 0);
        return new Guid(bytes);
    }
}