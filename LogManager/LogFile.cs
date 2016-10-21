using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LogManager {
    static class LogFile {
		static LogFile() {
			/*
			Thread th = new Thread(new ThreadStart(check));
			th.IsBackground=true;	
			th.Start();
			MessageBox.Show("正在运行1");
			*/
			new Thread(new ThreadStart(check)).Start();
			for (int i = 0; i < 100000;i++ ) {
				Console.WriteLine("1");
			}
		}
		static void check() {
			for (int i = 0; i < 100000; i++) {
				Console.WriteLine("2");
			}
		}
		static void Main() {
			MessageBox.Show("正在运行3");
		}
    }
}
