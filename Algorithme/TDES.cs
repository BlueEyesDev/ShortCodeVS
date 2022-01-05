public static (string String, byte[] Bytes) TDES(object Data, object Key, CipherMode Cipher, PaddingMode Padding, bool Encrypt)
		{
		
			try {
				if (Data is byte[] == false && (((string)Data).Length % 4 == 0) && Regex.IsMatch((string)Data, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None))
					Data = Convert.FromBase64String((string)Data); 
				else if (Data is byte[] == false)
					Data = UTF8Encoding.UTF8.GetBytes((string)Data);

				if (Key is byte[] == true && ((byte[])Key).Length != 16)
					Key = new MD5CryptoServiceProvider().ComputeHash((byte[])Key);
				else if (Key is string)
					Key = new MD5CryptoServiceProvider().ComputeHash(UTF8Encoding.UTF8.GetBytes((string)Key));

				TripleDESCryptoServiceProvider ServiceProvider = new TripleDESCryptoServiceProvider()
				{
					Key = (byte[])Key,
					Mode = Cipher,
					Padding = Padding
				};
				if (Encrypt)
				{
					byte[] FinalBlock = ServiceProvider.CreateEncryptor().TransformFinalBlock((byte[])Data, 0, ((byte[])Data).Length);
					return (Convert.ToBase64String(FinalBlock), FinalBlock);
				}
				else
				{
					byte[] FinalBlock = ServiceProvider.CreateDecryptor().TransformFinalBlock((byte[])Data, 0, ((byte[])Data).Length);
					return (UTF8Encoding.UTF8.GetString(FinalBlock), FinalBlock);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
