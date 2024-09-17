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

    private static bool HandleRequest(RequestInfo request){
        //for now i am assuming i will only receive GET rquests. 

        if(request.Verb == "get"){
            if(PageLoader.IsValidRequest(request))
                PageLoader.Respond(); 
            else{
                ResponseHandler.SendNotFound();
            }
        }
        return true;
    }
}