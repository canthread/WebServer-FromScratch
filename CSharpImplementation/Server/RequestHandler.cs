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

        HandleRequest(requestInfo, context);
    }

    private static bool HandleRequest(RequestInfo request , HttpListenerContext context){
        //for now i am assuming i will only receive GET rquests. 

        if(request.Verb == "get"){
            if(PageLoader.IsValidRequest(request)){
               SendResponse(PageLoader.LoadData(request), context);
            }
            else{
                SendResponse(PageLoader.LoadData("notfound.html"), context);
            }
        }
        return true;
    }

    private static void SendResponse(byte [] data, HttpListenerContext context){
        context.Response.ContentLength64 = data.Length;
        context.Response.OutputStream.Write(data, 0, data.Length);
        context.Response.OutputStream.Close();
    }

}