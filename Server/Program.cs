using System.Net;

public class Program{
    public static void Main(){
        Server server = new Server();

        List<IPAddress> addresses = server.GetIPAddresses();
        foreach(var ip in addresses){
            Console.WriteLine(ip.ToString());
        }
    }
}
