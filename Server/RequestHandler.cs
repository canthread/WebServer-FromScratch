using System.Dynamic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Utilities.StringHelpers;

public class RequestHandler
{
    public static void HandleRequest(HttpListenerContext context)
    {
        var request = context.Request;

        RequestInfo requestInfo = new RequestInfo(request);


        HandleRequest(requestInfo);
    }

    private static bool HandleRequest(RequestInfo requestInfo){
        return true;
    }
}