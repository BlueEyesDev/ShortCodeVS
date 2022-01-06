		public static (string String, byte[] Bytes, string Base64) Xor(object Data, object Key)
		{
			char[] Xor;
			try
			{
				if (Data is byte[] == true)
					Data = UTF8Encoding.UTF8.GetString((byte[])Data);
				else if (Data is byte[] == false && (((string)Data).Length % 4 == 0) && Regex.IsMatch((string)Data, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None))
					Data = UTF8Encoding.UTF8.GetString(Convert.FromBase64String((string)Data));
				Xor = ((string)Data).ToCharArray();
				if (Key is byte[])
					Key = Data = UTF8Encoding.UTF8.GetString((byte[])Data);

				if (Key is string)
				{
					if (((string)Key).Length != ((string)Data).Length)
					{
						while (((string)Key).Length < ((string)Data).Length)
							Key += ((string)Key);

						for (int i = 0; i < ((string)Data).Length; i++)
							Xor[i] = (char)(((string)Data)[i] ^ ((string)Key)[i]);
					}
				}
				else if (Key is char || Key is int)
				{
					for (int i = 0; i < ((string)Data).Length; i++)
						Xor[i] = (char)(((string)Data)[i] ^ (char)Key);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return (new string(Xor), UTF8Encoding.UTF8.GetBytes(Xor), Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(Xor)));
		}
