using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Net;
using System;

public class UdpReciever : MonoBehaviour
{
    private UdpClient udpClient;
    private int port = 5005;
    public static float UDPSineValue;

    void Start()
    {
        udpClient = new UdpClient(port);
        udpClient.BeginReceive(new System.AsyncCallback(ReceiveCallback), null);
    }

    void ReceiveCallback(System.IAsyncResult result)
    {
        try
        {
            byte[] receivedData;
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);
            receivedData = udpClient.EndReceive(result, ref remoteEndPoint);
            string receivedString = Encoding.ASCII.GetString(receivedData);
            float floatValue = float.Parse(receivedString);
            UDPSineValue = floatValue;


/*            int intValue;
            byte[] intBytes = new byte[4];
            Buffer.BlockCopy(receivedData, 0, intBytes, 0, 4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(intBytes);
            }
            intValue = BitConverter.ToInt32(intBytes, 0);
            Debug.Log("Received: " + intValue);*/
        }

        catch (Exception ex)
        {
            Debug.LogError("UDP receive error: " + ex.Message);
        }
        finally
        {
            udpClient.BeginReceive(new System.AsyncCallback(ReceiveCallback), null);
        }
    }

    void OnDestroy()
    {
        udpClient.Close();
    }
}