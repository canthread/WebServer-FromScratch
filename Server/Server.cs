using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

public static class Server{

    private static HttpListener listener; 

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

        iPAddresses.ForEach(ip => listener.Prefixes.Add("http://" + ip.ToString + "/"));
        foreach(var prefix in listener.Prefixes){
            Console.WriteLine("Listening on: " + prefix.ToString());
        } 
        
        return listener;
    } 

    

}