Namespace Crypto
    Public Class Hash
        Public Function MD5(ByVal strToEncrypt As String) As String
            Dim ue As Text.UTF8Encoding = New Global.System.Text.UTF8Encoding
            Dim bytes As Byte() = ue.GetBytes(strToEncrypt)
            Dim l_md5 As Global.System.Security.Cryptography.MD5CryptoServiceProvider = New Global.System.Security.Cryptography.MD5CryptoServiceProvider
            Dim hashBytes As Byte() = l_md5.ComputeHash(bytes)
            Dim hashString As String = ""
            Dim i As Integer = 0
            While i < hashBytes.Length
                hashString += Convert.ToString(hashBytes(i), 16).PadLeft(2, "0"c)
                Global.System.Math.Min(Global.System.Threading.Interlocked.Increment(i), i - 1)
            End While
            Return hashString.PadLeft(32, "0"c)
        End Function
        Public Function SHA1(ByVal strToEncrypt As String) As String
            Dim ue As Text.UTF8Encoding = New Global.System.Text.UTF8Encoding
            Dim bytes As Byte() = ue.GetBytes(strToEncrypt)
            Dim l_sha1 As Global.System.Security.Cryptography.SHA1CryptoServiceProvider = New Global.System.Security.Cryptography.SHA1CryptoServiceProvider
            Dim hashBytes As Byte() = l_sha1.ComputeHash(bytes)
            Dim hashString As String = ""
            Dim i As Integer = 0
            While i < hashBytes.Length
                hashString += Convert.ToString(hashBytes(i), 16).PadLeft(2, "0"c)
                Global.System.Math.Min(Global.System.Threading.Interlocked.Increment(i), i - 1)
            End While
            Return hashString.PadLeft(32, "0"c)
        End Function
        Public Function SHA256(ByVal strToEncrypt As String) As String
            Dim ue As Text.UTF8Encoding = New Global.System.Text.UTF8Encoding
            Dim bytes As Byte() = ue.GetBytes(strToEncrypt)
            Dim l_sha256 As Global.System.Security.Cryptography.SHA256 = New Global.System.Security.Cryptography.SHA256Managed
            Dim hashBytes As Byte() = l_sha256.ComputeHash(bytes)
            Dim hashString As String = ""
            Dim i As Integer = 0
            While i < hashBytes.Length
                hashString += Convert.ToString(hashBytes(i), 16).PadLeft(2, "0"c)
                Global.System.Math.Min(Global.System.Threading.Interlocked.Increment(i), i - 1)
            End While
            Return hashString.PadLeft(32, "0"c)
        End Function
        Public Function SHA384(ByVal strToEncrypt As String) As String
            Dim ue As Text.UTF8Encoding = New Global.System.Text.UTF8Encoding
            Dim bytes As Byte() = ue.GetBytes(strToEncrypt)
            Dim l_sha384 As Global.System.Security.Cryptography.SHA384 = New Global.System.Security.Cryptography.SHA384Managed
            Dim hashBytes As Byte() = l_sha384.ComputeHash(bytes)
            Dim hashString As String = ""
            Dim i As Integer = 0
            While i < hashBytes.Length
                hashString += Convert.ToString(hashBytes(i), 16).PadLeft(2, "0"c)
                Global.System.Math.Min(Global.System.Threading.Interlocked.Increment(i), i - 1)
            End While
            Return hashString.PadLeft(32, "0"c)
        End Function
        Public Function SHA512(ByVal strToEncrypt As String) As String
            Dim ue As Text.UTF8Encoding = New Global.System.Text.UTF8Encoding
            Dim bytes As Byte() = ue.GetBytes(strToEncrypt)
            Dim l_sha512 As Global.System.Security.Cryptography.SHA512 = New Global.System.Security.Cryptography.SHA512Managed
            Dim hashBytes As Byte() = l_sha512.ComputeHash(bytes)
            Dim hashString As String = ""
            Dim i As Integer = 0
            While i < hashBytes.Length
                hashString += Convert.ToString(hashBytes(i), 16).PadLeft(2, "0"c)
                Global.System.Math.Min(Global.System.Threading.Interlocked.Increment(i), i - 1)
            End While
            Return hashString.PadLeft(32, "0"c)
        End Function
        Public Function RIPEMD160(ByVal strToEncrypt As String) As String
            Dim ue As Text.UTF8Encoding = New Global.System.Text.UTF8Encoding
            Dim bytes As Byte() = ue.GetBytes(strToEncrypt)
            Dim l_RIPEMD160 As Global.System.Security.Cryptography.RIPEMD160 = New Global.System.Security.Cryptography.RIPEMD160Managed
            Dim hashBytes As Byte() = l_RIPEMD160.ComputeHash(bytes)
            Dim hashString As String = ""
            Dim i As Integer = 0
            While i < hashBytes.Length
                hashString += Convert.ToString(hashBytes(i), 16).PadLeft(2, "0"c)
                Global.System.Math.Min(Global.System.Threading.Interlocked.Increment(i), i - 1)
            End While
            Return hashString.PadLeft(32, "0"c)
        End Function
    End Class
    Public Class Crypto
        Public Shared Function EncryptTripleDES(ByVal sIn As String, ByVal sKey As String) As String
            Dim DES As New Global.System.Security.Cryptography.TripleDESCryptoServiceProvider
            Dim hashMD5 As New Global.System.Security.Cryptography.MD5CryptoServiceProvider
            ' scramble the key
            sKey = ScrambleKey(sKey)
            ' Compute the MD5 hash.
            DES.Key = hashMD5.ComputeHash(Global.System.Text.ASCIIEncoding.ASCII.GetBytes(sKey))
            ' Set the cipher mode.
            DES.Mode = Global.System.Security.Cryptography.CipherMode.ECB
            ' Create the encryptor.
            Dim DESEncrypt As Global.System.Security.Cryptography.ICryptoTransform = DES.CreateEncryptor()
            ' Get a byte array of the string.
            Dim Buffer As Byte() = Global.System.Text.ASCIIEncoding.ASCII.GetBytes(sIn)
            ' Transform and return the string.
            Return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length))
        End Function

        Public Shared Function DecryptTripleDES(ByVal sOut As String, ByVal sKey As String) As String
            Dim DES As New Global.System.Security.Cryptography.TripleDESCryptoServiceProvider
            Dim hashMD5 As New Global.System.Security.Cryptography.MD5CryptoServiceProvider
            ' scramble the key
            sKey = ScrambleKey(sKey)
            ' Compute the MD5 hash.
            DES.Key = hashMD5.ComputeHash(Global.System.Text.ASCIIEncoding.ASCII.GetBytes(sKey))
            ' Set the cipher mode.
            DES.Mode = Global.System.Security.Cryptography.CipherMode.ECB
            ' Create the decryptor.
            Dim DESDecrypt As Global.System.Security.Cryptography.ICryptoTransform = DES.CreateDecryptor()
            Dim Buffer As Byte() = Convert.FromBase64String(sOut)
            ' Transform and return the string.
            Return Global.System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length))
        End Function

        Public Shared Function ScrambleKey(ByVal v_strKey As String) As String

            Dim sbKey As New Global.System.Text.StringBuilder
            Dim intPtr As Integer
            For intPtr = 1 To v_strKey.Length
                Dim intIn As Integer = v_strKey.Length - intPtr + 1
                sbKey.Append(Mid(v_strKey, intIn, 1))
            Next

            Dim strKey As String = sbKey.ToString

            Return sbKey.ToString

        End Function
    End Class
End Namespace

