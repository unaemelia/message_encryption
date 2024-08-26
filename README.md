# Caesar Cipher Web API

This project is a simple Web API implemented in C# using ASP.NET Core that demonstrates the Caesar Cipher encryption and decryption techniques. The API allows users to encrypt a message by shifting its characters and then decrypt the message back to its original form.

## Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Encryption and Decryption](#encryption-and-decryption)
- [Project Structure](#project-structure)

## Overview

The Caesar Cipher is a type of substitution cipher where each letter in the plaintext is shifted by a fixed number of positions down the alphabet. This project provides an API to perform encryption and decryption using this method. The API supports basic HTTP GET requests to encrypt and decrypt messages.

## Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) installed on your machine.

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/caesar_cipher_webapi.git
    ```
2. Navigate to the project directory:
    ```bash
    cd caesar_cipher_webapi
    ```
3. Build and run the project:
    ```bash
    dotnet run
    ```

## API Endpoints

### Root Endpoint
- **`GET /`**  
  Displays a welcome message and instructions on how to use the API.

### Encrypt Endpoint
- **`GET /encrypt/{message}/{shift}`**  
  Encrypts the given message using the specified shift value.
  - **Parameters**:
    - `message`: The plaintext message to be encrypted.
    - `shift`: The number of positions to shift each character in the message.
  - **Response**:
    - Returns the encrypted message encoded in Base64.

### Decrypt Endpoint
- **`GET /decrypt`**  
  Decrypts the previously encrypted message using the stored shift value.
  - **Response**:
    - Returns the original plaintext message.

### Example Usage
```markdown
  Encrypt a message: GET /encrypt/HelloWorld/3
  Response: Encrypted message: KhoorZruog
 
  Decrypt the message: GET /decrypt
  Response: Decrypted message: HelloWorld
```

## Encryption and Decryption

### Encryption

The Caesar Cipher encryption shifts each character in the message by a specified number of positions in the alphabet. For example, with a shift of 3:
- `A` becomes `D`
- `B` becomes `E`
- `Z` becomes `C`

### Decryption

The decryption process reverses the shift applied during encryption to restore the original message.

## Project Structure

- **Program.cs**: Contains the main logic for setting up the Web API and handling requests. It defines the API endpoints for encryption and decryption.
- **EncryptStringToBytes(string text, int shift)**: A method that implements Caesar Cipher encryption, converting the message to a byte array.
- **DecryptStringFromBytes(byte[] encryptedText, int shift)**: A method that decrypts the byte array back to the original string using the reverse Caesar Cipher process.



