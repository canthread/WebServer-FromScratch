using System.Dynamic;
using Utilities.StringHelpers;

public class ExtentionInfo{
    public string extention { get; private set; }   

    public ExtentionInfo(string request){
        extention = GetExtentionInfo(request);
    }
    
    private string GetExtentionInfo(string request) {
        return StringHelpers.RightOf(request, '.');
    }
}