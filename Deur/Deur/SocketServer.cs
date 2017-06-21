using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace Deur
{
    class SocketServer
    {
        private readonly int _port;

        private StreamSocketListener listener;
        private SocketClient server;

        public delegate void DataOntvangenDelegate(string data);
        public DataOntvangenDelegate OnDataOntvangen;

        /// <summary>
        /// Initialiseer en start de server
        /// </summary>
        /// <param name="port"></param>
        /// <param name="host"></param>
        public SocketServer(int port, SocketClient host)
        {
            server = host;
            _port = port;
            Start();
        }

        /// <summary>
        /// Start de listner die luistert naar inkomende connecties
        /// </summary>
        public async void Start()
        {
            listener = new StreamSocketListener();
            listener.ConnectionReceived += Listener_ConnectionReceived;

            await listener.BindServiceNameAsync(_port.ToString());
        }

        /// <summary>
        /// Doe iets met de data die ontvangen is
        /// (nu alleen maar weergegeven in het output venster)
        /// </summary>
        /// <param name="data"></param>
        public void Server_OnDataOntvangen(string data)
        {
            Debug.WriteLine("Data ontvangen van server: " + data);
        }

        /// <summary>
        /// Zodra de listner een nieuwe connectie binnen krijgt, wordt deze methode aangeroepen
        /// Deze zal het bericht controleren op compleetheid en daarna doorsturen naar de OnDataOntvangen methode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void Listener_ConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        {
            var reader = new DataReader(args.Socket.InputStream);
            try
            {
                while (true)
                {
                    uint sizeFieldCount = await reader.LoadAsync(sizeof(uint));
                    if (sizeFieldCount != sizeof(uint)) return; //Disconnect
                    uint stringLength = reader.ReadUInt32();
                    uint actualStringLength = await reader.LoadAsync(stringLength);
                    if (stringLength != actualStringLength) return; //Disconnect

                    //Zodra data binnen is en er is een functie gekoppeld aan het event:                    
                    if (OnDataOntvangen != null)
                    {
                        //Trigger het event, zodat er iets gedaan wordt met de ontvangen data
                        OnDataOntvangen(reader.ReadString(actualStringLength));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
