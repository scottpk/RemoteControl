/*
 * Created by SharpDevelop.
 * User: scott
 * Date: 8/29/2015
 * Time: 6:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace RemoteControl
{
	/// <summary>
	/// Description of RemoteControl.
	/// </summary>
	public class RemoteControl
	{
		public const string MyServiceName = "RemoteControl";
		//private IContainer components;
//		private EventLog eventLog;
		HttpInterface inter = new HttpInterface("template.html");
		
		public RemoteControl()
		{
			inter.addApp(new Application("uTorrent",@"C:\Users\scott\AppData\Roaming\uTorrent\uTorrent.exe"));
			inter.addApp(new Application("Steam",@"C:\Program Files (x86)\Steam\Steam.exe"));
		}
		
		public RemoteControl(string[][] apps){
		  foreach(string[] app in apps){
		    //string name = System.IO.Path.GetFileNameWithoutExtension(app[1]);
		    inter.addApp(new Application(app[0],app[1]));
		  }
		}
		
		public void stop(){
			inter.stop();
		}
	}
}
