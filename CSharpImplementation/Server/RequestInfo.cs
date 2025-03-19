using System.Net;
using System.Text;
using Utilities.StringHelpers;

public class RequestInfo
{
    public string Path{ get; private set; }
    public string Parms { get; private set; }
    public string Verb { get; private set; }
    public string ExtentionInfo { get; private set; }

    public RequestInfo(HttpListenerRequest request)
    {
        //break down http request for router paramerter come after '?' hence the string parsing on ?
        Path = request.RawUrl.LeftOf('?');
        Parms = request.RawUrl.RightOf('?');
        Verb = request.HttpMethod.ToLower();
        ExtentionInfo =  StringHelpers.RightOf(Parms, '.');
    }

    

    public string ToString()
    {
        StringBuilder sb = new StringBuilder();
        return string.Empty;
    }
}
