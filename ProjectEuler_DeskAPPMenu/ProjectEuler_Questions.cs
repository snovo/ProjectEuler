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

		private string ExtractHtmlQuestion(string strQuestionPage, string strDivID)
		{
			string strResult = String.Empty ;
			HtmlAgilityPack.HtmlNode divNode = null;
			HtmlAgilityPack.HtmlDocument htmlDoc = null;

			try
			{
				htmlDoc = new HtmlAgilityPack.HtmlDocument();
				htmlDoc.LoadHtml (strQuestionPage);
				divNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='" + strDivID + "']");
				strResult = divNode.OuterHtml;
			}
			catch(Exception ex)
			{
				strResult = ex.Message;
			}

			return strResult;
		}

		private string ExtractTextQuestion(string strQuestionPage, string strDivID)
		{
			string strResult = String.Empty ;
			HtmlAgilityPack.HtmlNode divNode = null;
			HtmlAgilityPack.HtmlDocument htmlDoc = null;
			
			try
			{
				htmlDoc = new HtmlAgilityPack.HtmlDocument();
				htmlDoc.LoadHtml (strQuestionPage);
				divNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='" + strDivID + "']");
				strResult = divNode.InnerText;
			}
			catch(Exception ex)
			{
				strResult = ex.Message;
			}
			
			return strResult;
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
				result = ExtractTextQuestion( sr.ReadToEnd(), "content");
				sr.Close();
				myResponse.Close();
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show (ex.Message );
			}
			return result;
		}
	}
}

