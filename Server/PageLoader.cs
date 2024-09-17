
using System.Reflection.Metadata;
using System.Text;

public class PageLoader()
{
    private string _srcFiles = Path.Combine(Environment.CurrentDirectory, "src") ;
    internal static bool IsValidRequest(RequestInfo request)
    {
        throw new NotImplementedException();
    }
    
    private void GetRequestHandler(RequestInfo request){
        switch (request.ExtentionInfo){
            case ".html":
                string filePath = Path.Combine(_srcFiles, "html", request.Path);

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

    internal static void Respond()
    {
        throw new NotImplementedException();
    }
}