
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;

public class PageLoader()
{
    private static string _srcFiles = Path.Combine(Environment.CurrentDirectory, "src") ;

    internal static bool IsValidRequest(RequestInfo request)
    {
        return File.Exists(request.Path);
    }

    public static byte [] LoadData(RequestInfo requestInfo){
       return GetRequestHandler(requestInfo);
    }

    public static byte [] LoadData(string filePath){
        return Load(Path.Combine(_srcFiles, filePath));
    }
    
    private static byte [] GetRequestHandler(RequestInfo request){
        switch (request.ExtentionInfo)
        {
            case "html":
                return Load(Path.Combine(_srcFiles, request.Path));
                break;
            default:
                return Load(Path.Combine(_srcFiles, "notfound"));
                break;
        }
    }

    private string OpenFile(string filePath){

            return File.ReadAllText(filePath);
    }

    private bool IsValidExtention()
    {
        
        throw new NotImplementedException();
    }

    internal static byte[] HtmlLoader(string filePath){
        
    }
    internal static byte[] Load(string filePath)
    {
        return File.ReadAllBytes(filePath);
    }
}