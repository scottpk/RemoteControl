/*
 * Created by SharpDevelop.
 * User: scott
 * Date: 8/29/2015
 * Time: 5:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace RemoteControl
{
	/// <summary>
	/// Description of HttpInterface.
	/// </summary>
	public class HttpInterface
	{
		private List<Application> _appList;
		private string _templateFile;
				
		Thread responderThread;// = new Thread(responder);
		public List<Application> appList {
			get {
				return _appList;
			}
		}
		HttpListener listener = new HttpListener();
		public HttpInterface(string templateFile)
		{
			this._appList = new List<Application>();
			listener.Prefixes.Add("http://*:8080/");
			//listener.Prefixes.Add("https://*/");
			this._templateFile = templateFile;
			start();
		}
		public void addApp(Application app){
			_appList.Add(app);
		}
		private void start(){
			listener.Start();
			responderThread = new Thread(responder);
			responderThread.Start();
			while (!responderThread.IsAlive);
		}
		private void responder(){
			try {
				while (listener.IsListening){
					// Note: the GetContext method blocks while waiting for a request
					HttpListenerContext context = listener.GetContext();
					HttpListenerRequest request = context.Request;
					// Obtain a response object
					HttpListenerResponse response = context.Response;
					// Parse the request
					if (interpretRequest(request)){
					  response.Redirect("http://localhost:8080/");
					}
					// Construct response
					string responseString = buildResponse(request);//"<HTML><BODY>Hello world!</BODY></HTML>";
					byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
					response.ContentLength64 = buffer.Length;
					System.IO.Stream output = response.OutputStream;
					output.Write(buffer,0,buffer.Length);
					// You must close the output stream.
					output.Close();
				}
			}
			catch (HttpListenerException){}
			catch (System.NullReferenceException){}
		}
		public void stop(){
			foreach(Application app in appList){
				app.close();
			}
			if (listener != null){
  			if (listener.IsListening) {
  				listener.Stop();
  			}
			}
			responderThread.Join();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <returns>bool indicating to redirect</returns>
		public bool interpretRequest(HttpListenerRequest request){
			foreach(string s in request.QueryString.AllKeys){
				//responseStr += "<br />" + s + "&nbsp;" + request.QueryString[s];
				if (s.ToUpperInvariant() == "LAUNCH"){
					if (request.QueryString[s] != ""){
						foreach(Application app in appList){
							if(app.name == request.QueryString[s]){
								app.launch();
								return true;
							}
						}
					}
				}
			}
		  return false;
		}
		public string buildResponse(HttpListenerRequest request){
		  string responseStr = System.IO.File.ReadAllText(_templateFile);//"";
			string appTableStr = "";
//			responseStr = "<HTML><BODY>Hello World!";// + request.Url;// + "</BODY></HTML>";
//			responseStr += "<br />Applications:";
//			foreach(string s in request.QueryString.AllKeys){
//				responseStr += "<br />" + s + "&nbsp;" + request.QueryString[s];
//			}
			appTableStr += "<table>";
			foreach(Application app in appList){
				//appTableStr += "<br /><a href=\"http://localhost:8080/?LAUNCH=" + app.name + "\">";
				appTableStr += "<tr><td>";
				if (app.icon != null){
					System.Drawing.Bitmap bmp = app.icon.ToBitmap();
					System.IO.MemoryStream stream = new System.IO.MemoryStream();
					bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
					byte[] imageBytes = stream.ToArray();
					appTableStr += "<a href=\"http://localhost:8080/?LAUNCH=" + app.name + "\"><img src=\"data:image/png;base64," + Convert.ToBase64String(imageBytes) + "\" /></a>";
				}
				appTableStr += "</td><td><a href=\"http://localhost:8080/?LAUNCH=" + app.name + "\">" + app.name + "</a></tr>";
			}
			appTableStr += "</table>";
			//responseStr += appTableStr + "</BODY></HTML>";
			responseStr = responseStr.Replace("[!AppTable!]",appTableStr);
			return responseStr;
		}
	}
}
