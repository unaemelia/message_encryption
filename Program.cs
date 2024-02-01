using System;
using System.IO;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Memory storage for encrypted message
byte[] encryptedMessage = null;

app.MapGet("/", () => "Hello World!");

app.MapGet("/encrypt/{message}", (string message) =>
{
    // Encrypt message using AES
    encryptedMessage = EncryptStringToBytes(message, GetAesKey(), GetAesIV());

    return $"Encrypted message: {Convert.ToBase64String(encryptedMessage)}";
});

// Todo add decrypt method here
app.MapGet("/decrypt", () => "Add dencrypt function!");

app.Run();

// Generate random AES key
byte[] GetAesKey()
{
    using (Aes aesAlg = Aes.Create())
    {
        aesAlg.GenerateKey();
        return aesAlg.Key;
    }
}

// Generate random AES IV
byte[] GetAesIV()
{
    using (Aes aesAlg = Aes.Create())
    {
        aesAlg.GenerateIV();
        return aesAlg.IV;
    }
}

// Encrypt a string using AES
byte[] EncryptStringToBytes(string text, byte[] Key, byte[] IV)
{
    using (Aes aesAlg = Aes.Create())
    {
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(text);
                }
            }
            return msEncrypt.ToArray();
        }
    }
}

// Todo: Decrypt a string using AES