using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LogManager {
    static class LogFile {
		[DllImport("kernel32")]
		private static extern int WaitForSingleObject(int hHandle, int dwMilliseconds);
		private static int ThreadId;
		static LogFile() {
			/*
			Thread th = new Thread(new ThreadStart(check));
			th.IsBackground=true;	
			th.Start();
			MessageBox.Show("正在运行1");
			*/
			ThreadId = Thread.CurrentThread.ManagedThreadId;
			new Thread(new ThreadStart(check)).Start();

			for (int i = 0; i < 100000;i++ ) {
				Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
			}
		}
		private static void check() {
			while (true) {
				if (0 == WaitForSingleObject(ThreadId, 100)) {
					Console.WriteLine("安全退出");
					return;
				}
				Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
			}
		}
		static void Main() {
			MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
		}
    }
}
