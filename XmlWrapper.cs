/*
 * Created by SharpDevelop.
 * User: scott
 * Date: 9/12/2015
 * Time: 12:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Xml;

namespace RemoteControl
{
  /// <summary>
  /// Description of XmlWrapper.
  /// </summary>
  public class XmlWrapper
  {
    XmlDocument xmlDoc;
    public XmlWrapper(string documentLocation)
    {
      xmlDoc = new XmlDocument();
      xmlDoc.Load(documentLocation);
//      foreach(XmlNode xmlNode in xmlDoc.DocumentElement.GetElementsByTagName("app")){
//          Console.WriteLine(xmlNode.Attributes["appName"].Value + ": " + xmlNode.Attributes["appPath"].Value);
//          Console.ReadKey();
//      }
    }
    public string[][] getApps(){
      List<string[]> apps = new List<string[]>();
      foreach(XmlNode xmlNode in xmlDoc.DocumentElement.GetElementsByTagName("app")){
        string[] appInfo = new string[2];
//        Console.WriteLine(xmlNode.Attributes["appName"].Value + ": " + xmlNode.Attributes["appPath"].Value);
//        Console.ReadKey();
        appInfo[0] = xmlNode.Attributes["appName"].Value;
        appInfo[1] = xmlNode.Attributes["appPath"].Value;
        apps.Add(appInfo);
      }
      return apps.ToArray();
    }
  }
}
