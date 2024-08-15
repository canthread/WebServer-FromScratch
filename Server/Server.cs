using System.Dynamic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Utilities.StringHelpers;

public static class Server{

    private static HttpListener listener; 

    // maximum number of connections a that can be made concurently
    private const int MaxNumOfConnections = 20;
    private static Semaphore sem = new Semaphore(MaxNumOfConnections, MaxNumOfConnections);
    // public Server(){
    // }

    /// <summary>
    /// return a list of ipv4 only IPAdresses assosiated with current host. 
    /// </summary>
    /// <returns></returns>
    public static List<IPAddress> GetIPAddresses(){
        IPHostEntry host;
        host = Dns.GetHostEntry(Dns.GetHostName());
        List<IPAddress> ret = host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToList();
        return ret;
    }

    /// <summary>
    /// Initializes HttpListener and takes in ipAddresses parameter and ands them to lister's prefixes
    /// </summary>
    /// <param name="iPAddresses"></param>
    /// <returns></returns>
    public static HttpListener InitializeListener(List<IPAddress> iPAddresses){
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost/");

        iPAddresses.ForEach(ip => listener.Prefixes.Add("http://" + ip.ToString() + "/"));
        foreach(var prefix in listener.Prefixes){
            Console.WriteLine("Listening on: " + prefix.ToString());
        } 

        return listener;
    } 

    private static void Start(HttpListener listener){
        listener.Start();
        Task.Run(() => RunServer(listener)); 
    }

    private static void RunServer(HttpListener listener){
        sem.WaitOne();
        while(true){
            sem.WaitOne();
            StartConnectionListener(listener);
        } 
    }
    private static async void StartConnectionListener(HttpListener listener){

        HttpListenerContext context = listener.GetContext();

        HttpListenerRequest request = context.Request;

        sem.Release();

        //log requets
        Log(context.Request);
        
        //break down http request for router paramerter come after '?' hence the string parsing on ?
        string path = request.RawUrl.LeftOf('?');
        string parms = request.RawUrl.RightOf('?');
        string verb = request.HttpMethod;
        Dictionary<string, string> kvParams = GetKeyValues(parms, null);

        string response = "<html><head><meta http-equiv='content-type' content='text/html; charset=utf-8'/> </ head > Hello Browser! </ html > ";
        byte[] encoded = Encoding.UTF8.GetBytes(response);
        context.Response.ContentLength64 = encoded.Length;
        context.Response.OutputStream.Write(encoded, 0, encoded.Length);
        context.Response.OutputStream.Close();
    }

    private static Dictionary<string, string> GetKeyValues(string data, Dictionary<string, string> kv = null)
     {
        if(kv == null){
            kv = new Dictionary<string, string>();
        }
        if(!string.IsNullOrEmpty(data)){
            var pairs = data.Split('&');
            foreach(var keyValue in pairs){
                var parts = keyValue.Split('=');
                if(parts.Count() == 2){
                    var key = parts[0];
                    var value = System.Uri.UnescapeDataString(parts[1]);
                    kv[key] = value;
                }
            }
        }
        return kv;
    }

    /// Starts the web server.
    /// </summary>
    public static void Start()
    {
        List<IPAddress> localHostIPs = GetIPAddresses();
        HttpListener listener = InitializeListener(localHostIPs);
        Start(listener);
    }

    /// <summary>
    /// Log requests.
    /// </summary>
    public static void Log(HttpListenerRequest request)
    {
        Console.WriteLine(request.RemoteEndPoint + " " + request.HttpMethod + " /" + request.Url.AbsoluteUri.ToString());
    }
}