		private static (string String, byte[] Bytes, int Int, float Float, double Double) Read(IntPtr Offset, int Size, IntPtr HprocessHandle)
		{
			int bytesRead = 0;
			byte[] ReadByte = new byte[Size];
			ReadProcessMemory((int)HprocessHandle, Offset, ReadByte, ReadByte.Length, ref bytesRead);
			return (UTF8Encoding.ASCII.GetString(ReadByte), ReadByte, Convert.ToInt32(ReadByte), Convert.ToSingle(ReadByte), Convert.ToDouble(ReadByte));
		}
