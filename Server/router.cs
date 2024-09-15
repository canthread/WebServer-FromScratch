using System.ComponentModel;

public class Router{
    public string WebsitePath { get; private set; }

    public Router(){
        WebsitePath = Directory.GetCurrentDirectory();
    }

    private void InitializeRouter(){
        WebsitePath = Directory.GetCurrentDirectory();
    }

    Router.HandlerRequest()
}


