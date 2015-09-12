/*
 * Created by SharpDevelop.
 * User: scott
 * Date: 8/29/2015
 * Time: 5:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

namespace RemoteControl
{
	public class RemoteControlService : ServiceBase
	{
		public const string MyServiceName = "RemoteControlService";
//		private IContainer components;
		RemoteControl rc;
//		private EventLog eventLog;
//		HttpInterface inter = new HttpInterface();
		
		public RemoteControlService()
		{
			InitializeComponent();
			this.AutoLog = false;
//			eventLog = new EventLog();
//			if (!EventLog.SourceExists("RemoteControl")){
//				EventLog.CreateEventSource("RemoteControl","Log");
//			}
//			eventLog.Source = "RemoteControl";
//			eventLog.Log = "Log";
		}
		
		private void InitializeComponent()
		{
			this.ServiceName = MyServiceName;
		}
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			// TODO: Add cleanup code here (if required)
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// Start this service.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			// TODO: Add start code here (if required) to start your service.
//			eventLog.WriteEntry("In OnStart");
//			inter.addApp(new Application("uTorrent",@"C:\Users\scott\AppData\Roaming\uTorrent\uTorrent.exe"));
			rc = new RemoteControl();
		}
		
		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			// TODO: Add tear-down code here (if required) to stop your service.
//			eventLog.WriteEntry("In OnStop");
			//inter.stop();
			rc.stop();
		}
	}
}
