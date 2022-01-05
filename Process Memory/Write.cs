[DllImport("kernel32.dll", SetLastError = true)]
public static extern bool WriteProcessMemory(int hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWrite);
private static void Write(IntPtr Offset, byte[] Wbytes, IntPtr WprocessHandle)
{
  int bytesWritten = 0;
  WriteProcessMemory((int)WprocessHandle, Offset, Wbytes, Wbytes.Length, ref bytesWritten);
}
