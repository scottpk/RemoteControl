/*
 * Created by SharpDevelop.
 * User: scott
 * Date: 8/29/2015
 * Time: 5:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
//using System.Collections.Generic;
using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading;
using System.Linq;

namespace RemoteControl
{
	static class Program
	{
		[DllImport("Kernel32")]
		public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);
		public delegate bool HandlerRoutine(CtrlTypes CtrlType);
		static RemoteControl rc;
		public enum CtrlTypes
		{
			CTRL_C_EVENT = 0,
			CTRL_BREAK_EVENT,
			CTRL_CLOSE_EVENT,
			CTRL_LOGOFF_EVENT = 5,
			CTRL_SHUTDOWN_EVENT
		}
		/// <summary>
		/// This method starts the service.
		/// </summary>
		static void Main()
		{
			// To run more than one service you have to add them here
			//ServiceBase.Run(new ServiceBase[] { new RemoteControlService() });
			
			XmlWrapper xml = new XmlWrapper("apps.xml");
			
			rc = new RemoteControl(xml.getApps());
			//Thread.Sleep(10000);
			//rc.stop();
			SetConsoleCtrlHandler(new HandlerRoutine(Handler), true);//new EventHandler(Handler);
			
			while(true){}
		}
		private static bool Handler(CtrlTypes ctrlType){
			rc.stop();
			return true;
		}
	}
}
