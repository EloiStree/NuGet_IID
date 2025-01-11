
using System.Net.Sockets;
using System.Text;

namespace Eloi.IID { 

public class SendUdpIID
{
    private string ivp4;
    private int port;
    private int ntpOffsetLocalToServerInMilliseconds;
    private UdpClient udpClient;
   // private IntegerTimeQueueHolder queueThread;

    public SendUdpIID(string ivp4, int port, bool useNtp, bool useQueueThread = false)
    {
        this.ivp4 = IIDUtility.GetIpv4(ivp4);
        this.port = port;
        this.ntpOffsetLocalToServerInMilliseconds = 0;

        // if (useQueueThread)
        // {
        //     this.queueThread = new IntegerTimeQueueHolder(PushBytes, 1);
        // }

        if (useNtp)
        {
            FetchNtpOffset();
        }

        this.udpClient = new UdpClient();
    }

    public int GetNtpOffset()
    {
        return this.ntpOffsetLocalToServerInMilliseconds;
    }

    public void PushIntegerAsShortcut(string text)
    {
        byte[] bytes = IIDUtility.TextShortcutToBytes(text);
        if (bytes != null)
        {
            this.udpClient.Send(bytes, bytes.Length, this.ivp4, this.port);
        }
    }

    public void PushBytes(byte[] bytes)
    {
        Console.WriteLine($"Push Bytes: {this.ivp4} {this.port} {BitConverter.ToString(bytes)}");
        this.udpClient.Send(bytes, bytes.Length, this.ivp4, this.port);
    }

    public void PushText(string text)
    {
        PushBytes(Encoding.UTF8.GetBytes(text));
    }

    public void PushInteger(int value)
    {
        PushBytes(IIDUtility.IntegerToBytes(value));
    }

    public void PushIndexInteger(int index, int value)
    {
        PushBytes(IIDUtility.IndexIntegerToBytes(index, value));
    }

    public void PushIndexIntegerDate(int index, int value, int date)
    {
        PushBytes(IIDUtility.IndexIntegerDateToBytes(index, value, date));
    }

    public void PushRandomInteger(int index, int fromValue, int toValue)
    {
        Random random = new Random();
        int value = random.Next(fromValue, toValue);
        PushIndexInteger(index, value);
    }

    public void PushRandomInteger100(int index)
    {
        PushRandomInteger(index, 0, 100);
    }

    public void PushRandomIntegerIntMax(int index)
    {
        PushRandomInteger(index, int.MinValue, int.MaxValue);
    }

    public void FetchNtpOffset(string ntpServer = "be.pool.ntp.org")
    {
        SetNtpOffsetTick(NtpOffsetFetcher.FetchNtpOffsetInMilliseconds(ntpServer));
        Console.WriteLine($"NTP Offset: {this.ntpOffsetLocalToServerInMilliseconds}");
    }

    public void SetNtpOffsetTick(int ntpOffsetLocalToServer)
    {
        this.ntpOffsetLocalToServerInMilliseconds = ntpOffsetLocalToServer;
    }

    public void PushIndexIntegerDateLocalNow(int index, int value)
    {
        int date = (int)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000);
        PushIndexIntegerDate(index, value, date);
    }

    public void PushIndexIntegerDateNtpNow(int index, int value)
    {
        int date = (int)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000) + this.ntpOffsetLocalToServerInMilliseconds;
        PushIndexIntegerDate(index, value, date);
    }

    public void PushIndexIntegerDateNtpInMilliseconds(int index, int value, int milliseconds)
    {
        int date = (int)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000) + this.ntpOffsetLocalToServerInMilliseconds + milliseconds / 1000;
        PushIndexIntegerDate(index, value, date);
    }

    public void PushIndexIntegerDateNtpInSeconds(int index, int value, int seconds)
    {
        PushIndexIntegerDateNtpInMilliseconds(index, value, seconds * 1000);
    }

        // public bool IsUsingQueueThread()
        // {
        //     return this.queueThread != null;
        // }

        // public void PushIntegerInQueue(int value, int delayInMilliseconds)
        // {
        //     this.queueThread.PushBytesToQueue(IIDUtility.IntegerToBytes(value), delayInMilliseconds);
        // }

        // public void PushIndexIntegerInQueue(int index, int value, int delayInMilliseconds)
        // {
        //     this.queueThread.PushBytesToQueue(IIDUtility.IndexIntegerToBytes(index, value), delayInMilliseconds);
        // }

        // public void ClearQueue()
        // {
        //     this.queueThread.ClearQueue();
        // }
    }
}