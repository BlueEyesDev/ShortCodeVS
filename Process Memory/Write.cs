		private static void Write(IntPtr Offset, byte[] Wbytes, IntPtr WprocessHandle) {
			int bytesWritten = 0;
			WriteProcessMemory((int)WprocessHandle, Offset, Wbytes, Wbytes.Length, ref bytesWritten);
		}
