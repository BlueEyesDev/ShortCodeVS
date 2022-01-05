public static (string String, byte[] Bytes) AES(object Data, bool encrypt, byte[] SetKey = null, byte[] SetIv = null) {
            try
            {
				if (Data is byte[] == false && (((string)Data).Length % 4 == 0) && Regex.IsMatch((string)Data, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None))
					Data = Convert.FromBase64String((string)Data);
				AesManaged aes = new AesManaged();
				aes.Key = (SetKey != null) ? SetKey : aes.Key;
				aes.IV = (SetIv != null) ? SetIv : aes.IV;
				if (encrypt)
				{
					using (MemoryStream ms = new MemoryStream())
					{
						using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
						using (StreamWriter sw = new StreamWriter(cs))
							sw.Write((string)Data);
						return (Convert.ToBase64String(ms.ToArray()), ms.ToArray());
					}
				}
				else
				{
					using (MemoryStream ms = new MemoryStream((byte[])Data))
					using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
					using (StreamReader reader = new StreamReader(cs))
						Data = reader.ReadToEnd();
					return ((string)Data, UTF8Encoding.UTF8.GetBytes((string)Data));
				}
			}
            catch (Exception ex) {

                throw ex;
            }
		}
