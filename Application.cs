/*
 * Created by SharpDevelop.
 * User: scott
 * Date: 8/29/2015
 * Time: 5:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace RemoteControl
{
	/// <summary>
	/// Description of Application.
	/// </summary>
	public class Application
	{
		private string _name;
		private string _launchPath;
		private System.Diagnostics.Process p = null;
		public string name {
			get {
				return _name;
			}
		}
		public string launchPath {
			get {
				return _launchPath;
			}
		}
		public Icon icon {
			get {
				if (launchPath != "") return Icon.ExtractAssociatedIcon(launchPath);
				else return null;
			}
		}
		public Application(string appName, string launchPath)
		{
			this._name = appName;
			this._launchPath = launchPath;
		}
		public void launch(){
			if (p == null){
				p = System.Diagnostics.Process.Start(launchPath);
			}
			else if (p.HasExited){
				p = System.Diagnostics.Process.Start(launchPath);
			}
		}
		public void close(){
			if (p != null){
				p.Close();
			}
		}
	}
}
