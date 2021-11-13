using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using zIinz_3_bigdata.Interfaces;
using static zIinz_3_bigdata.Interfaces.INetworkAction;

namespace zIinz_3_bigdata.Classes.Network
{
    public abstract class NetworkService
    {
        public const int BUFFER_SIZE = 1000000;

        public enum ModeEnum
        {
            Client = 0x001,
            Server = 0x002
        }
        public string Identifier { get; set; }
        public ModeEnum Mode { get; protected set; }
        public INetworkAction NetworkAction { get; set; }
        public IPAddress Address { get; protected set; }
        public int Port { get; protected set; }
        public NetworkData Data { get; protected set; }
        public NetworkService RegisteredServer { get; set; }

        public NetworkService(ModeEnum Mode, int a_iBufferSize = BUFFER_SIZE)
        {
            this.Identifier = GetHashCode().ToString("X8");
            this.Mode = Mode;
            this.Data = new NetworkData(a_iBufferSize);
            this.NetworkAction = null;
            this.RegisteredServer = null;
        }
        public NetworkService(ModeEnum Mode, IPAddress Address, int Port, int a_iBufferSize = BUFFER_SIZE) :
            this(Mode, a_iBufferSize)
        {
            this.Address = Address;
            this.Port = Port;
        }
        public abstract bool IsConnected { get; }
        public abstract Socket NetworkSocket { get; }
        public abstract void Establish();
        public override string ToString() => $"Identifier={Identifier}[{GetType().Name.CleanType()}={NetworkSocket?.LocalEndPoint}]";
        public virtual bool HasRegisteredServer => RegisteredServer != null;
        public virtual T GetRegisteredServer<T>() where T : NetworkService
        {
            return (T)RegisteredServer;
        }
    }
}
