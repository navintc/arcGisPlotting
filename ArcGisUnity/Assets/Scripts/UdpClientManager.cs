using System.Net.Sockets;
using UnityEngine;

public class UdpClientManager : MonoBehaviour
{
    private static UdpClient udpClient;

    public static UdpClient GetUdpClient()
    {
        if (udpClient == null)
        {
            udpClient = new UdpClient();
        }
        return udpClient;
    }

    public static void DisposeUdpClient()
    {
        if (udpClient != null)
        {
            udpClient.Close();
            udpClient.Dispose();
            udpClient = null;
        }
    }
}
