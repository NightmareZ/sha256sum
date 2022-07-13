using System.Security.Cryptography;
using System.Text;

static string ByteArrayToString(byte[] array)
{
    var sb = new StringBuilder();

    foreach (var b in array)
    {
        sb.Append(string.Format($"{b:X2}"));
    }

    return sb.ToString().Trim().ToLowerInvariant();
}

static string CalculateHashForFile(string fileName)
{
    using SHA256 sha256 = SHA256.Create();
    using FileStream fileStream = File.OpenRead(fileName);
    fileStream.Position = 0;
    byte[] hashValue = sha256.ComputeHash(fileStream);
    return ByteArrayToString(hashValue);
}

string fileName = args[0];
string hash = CalculateHashForFile(fileName);
Console.WriteLine(hash);
