using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
//using ValuePadClassLibrary.BLL;

//using System.Messaging;
using System.Web.Security;
using System.Diagnostics;

namespace SIMS.Utility
{
    public class CommonUtility
    {

        #region Enums

        public enum UserType
        {
            Admin = 1
        }

        #endregion

        #region Common Methods

        public static string EncryptPassword(string ClearText)
        {
            if (string.IsNullOrEmpty(ClearText))
                return string.Empty;
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(ClearText);
            SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
            MemoryStream ms = new MemoryStream();

            byte[] rgbIV = Encoding.ASCII.GetBytes(ConfigUtility.IntializationVector);
            byte[] key = Encoding.ASCII.GetBytes(ConfigUtility.EncryptionKey);

            CryptoStream cs = new CryptoStream(ms, rijn.CreateEncryptor(key, rgbIV), CryptoStreamMode.Write);
            cs.Write(clearTextBytes, 0, clearTextBytes.Length);
            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string DecryptPassword(string EncryptedText)
        {
            if (string.IsNullOrEmpty(EncryptedText))
                return string.Empty;
            byte[] encryptedTextBytes = Convert.FromBase64String(EncryptedText);
            MemoryStream ms = new MemoryStream();
            SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();

            byte[] rgbIV = Encoding.ASCII.GetBytes(ConfigUtility.IntializationVector);
            byte[] key = Encoding.ASCII.GetBytes(ConfigUtility.EncryptionKey);

            CryptoStream cs = new CryptoStream(ms, rijn.CreateDecryptor(key, rgbIV),
            CryptoStreamMode.Write);
            cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
            cs.Close();

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        #endregion

        #region Check Authenticated User

        public static Boolean CheckUserAuthenticated()
        {
            try
            {
                if (HttpContext.Current.User != null)
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        if (HttpContext.Current.User.Identity is FormsIdentity)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

    }
    public class JqGridClass<T>
    {
        public int totalpages { get; set; }
        public int currpage { get; set; }
        public int currrecords { get; set; }
        public T rows { get; set; }
    }
}