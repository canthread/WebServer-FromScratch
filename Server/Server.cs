using System.Net;
using System.Net.Sockets;

public class Server{
    public Server(){

    }

    public List<IPAddress> GetIPAddresses(){
        IPHostEntry host;
        host = Dns.GetHostEntry(Dns.GetHostName());
        List<IPAddress> ret = host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToList();
        return ret;
    }
}