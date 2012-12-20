using System;
using System.Net;
using System.IO;

namespace ProjectEuler_DeskAPPMenu
{
	public class ProjectEuler_Questions
	{
		private string _strURLPref = String.Empty;

		public ProjectEuler_Questions (string strURLPref)
		{
			_strURLPref = strURLPref;
		}

		private string ExtractQuestion(string strQuestionPage)
		{
			string strBodyPattern = String.Empty, strContentPattern = String.Empty ;
			strBodyPattern = ".*<body[^>]*>(.*)</body>.*";
			strContentPattern = ".*<div id=\"content\">.*</div>.*";
			return System.Text.RegularExpressions.Regex.Replace(strQuestionPage, strContentPattern,"SAPOI", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
		}

		public string GetQuestion(int iProblem)
		{
			HttpWebRequest myRequest = null;
			WebResponse myResponse = null;
			StreamReader sr = null;
			string result = string.Empty;

			try
			{
				myRequest = (HttpWebRequest)WebRequest.Create(_strURLPref + iProblem.ToString ());
				myRequest.Method = "GET";
				myResponse = myRequest.GetResponse();

				sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.GetEncoding(1252)); //System.Text.Encoding.UTF8);
				result = ExtractQuestion( sr.ReadToEnd());
				sr.Close();
				myResponse.Close();
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show (ex.Message );
			}
			return "";
		}
	}
}

