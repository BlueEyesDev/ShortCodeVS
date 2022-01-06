		public static void RunAdmin()
		{
			if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
				try
				{
					Process.Start(new ProcessStartInfo() { UseShellExecute = true, WorkingDirectory = Environment.CurrentDirectory, FileName = Process.GetCurrentProcess().MainModule.FileName, Verb = "runas" });
					Process.GetCurrentProcess().Kill();
				}
				catch
				{
					Process.GetCurrentProcess().Kill();
				}
		}
