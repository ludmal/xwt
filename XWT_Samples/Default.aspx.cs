using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void XWTButtonControl1_Click(object sender, EventArgs e) {

    }

    //public static class BitlyApi {
    //    private const string apiKey = "[add api key here]";
    //    private const string login = "[add login name here]";

    //    public static BitlyResults ShortenUrl(string longUrl) {
    //        XmlDocument doc = new XmlDocument();

    //        var url =
    //            string.Format("http://api.bit.ly/shorten?format=xml&version=2.0.1&longUrl={0}&login={1}&apiKey={2}",
    //                          HttpUtility.UrlEncode(longUrl), login, apiKey);
    //        var resultXml = doc.Load(url);
    //        var x = (from result in resultXml.Descendants("nodeKeyVal")
    //                 select new BitlyResults {
    //                     UserHash = result.Element("userHash").Value,
    //                     ShortUrl = result.Element("shortUrl").Value
    //                 }
    //                );
    //        return x.Single();
    //    }
    public class BitlyResults {
        public string UserHash { get; set; }

        public string ShortUrl { get; set; }
    }
}
