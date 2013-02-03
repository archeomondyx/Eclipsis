using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;
using System.Threading;

namespace Eclipsis
{
    public class TCPConnectionService
    {
        TcpClient client = new TcpClient();
        IPEndPoint serverEndPoint;
        NetworkStream clientStream;
        BackgroundWorker listener = new BackgroundWorker();

        private void initializeListener()
        {
            if (listener == null)
                listener = new BackgroundWorker();
            listener.WorkerReportsProgress = true;
            listener.WorkerSupportsCancellation = true;

            listener.DoWork += new DoWorkEventHandler(listener_DoWork);
            listener.ProgressChanged += new ProgressChangedEventHandler(listener_ProgressChanged);
            listener.RunWorkerCompleted += new RunWorkerCompletedEventHandler(listener_RunWorkerCompleted);

        }

        void listener_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // todo 
        }

        void listener_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // todo
        }

        void listener_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            long timeout = Properties.Settings.Default.listener_timeout;
            long timePassed = 0;
            List<byte> buffer = new List<byte>();

            NetworkStream clientStream = (NetworkStream)e.Argument;
            while (!clientStream.DataAvailable)
            {
                Thread.Sleep(1);
                if(++timePassed > timeout)
                {
                    listener.CancelAsync();
                    // error while receiving data
                }

            }
            while (clientStream.DataAvailable)
            {
                buffer.Add((byte)clientStream.ReadByte());
            }

            
        }

        public TCPConnectionService(string serverIPAddress, uint port)
        {
            serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIPAddress), (int)port);
            try
            {
                client.Connect(serverEndPoint);
                clientStream = client.GetStream();
            }
            catch (SocketException exc)
            {
                // todo
            }
            catch (Exception exc)
            {
                // todo
            }
        }

        public EclipsisTransactionProtocol.EclipsisTransactionPacket getResponse(EclipsisTransactionProtocol.EclipsisTransactionPacket packet)
        {
            byte[] message = new byte[4096];
            message = EclipsisTransactionProtocol.TransactionOperations.RawSerialize(packet);
            clientStream.Write(message, 0, message.Length);
            clientStream.Flush();
            /*
            if (!listener.IsBusy)
                listener.RunWorkerAsync(clientStream);
            // send to background worker
            */
            long timeout = Properties.Settings.Default.listener_timeout;
            long timePassed = 0;
            List<byte> buffer = new List<byte>();

            while (!clientStream.DataAvailable)
            {
                Thread.Sleep(1);
                if (++timePassed > timeout)
                {
                    listener.CancelAsync();
                    // error while receiving data
                }

            }
            while (clientStream.DataAvailable)
            {
                buffer.Add((byte)clientStream.ReadByte());
            }

            EclipsisTransactionProtocol.EclipsisTransactionPacket response = new EclipsisTransactionProtocol.EclipsisTransactionPacket();
            response = (EclipsisTransactionProtocol.EclipsisTransactionPacket)EclipsisTransactionProtocol.TransactionOperations.RawDeserialize(buffer.ToArray(), response.GetType());

            return response;
        }

   
        
        /*
        byte[] buffer = encoder.GetBytes("text");

        clientStream.Write(buffer, 0 , buffer.Length);
        clientStream.Flush();
         */
    }
}
