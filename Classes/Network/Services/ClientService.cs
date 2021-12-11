using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static zIinz_3_bigdata.Interfaces.INetworkAction;

namespace zIinz_3_bigdata.Classes.Network.Services
{
    public class ClientService : NetworkService
    {
        private readonly TcpClient m_oNetObject;

        public ClientService(Socket a_oSocket, int a_iBufferLength = 100000) :
            base(ModeEnum.Client, a_iBufferLength)
        {
            m_oNetObject = new TcpClient
            {
                Client = a_oSocket
            };
        }

        public ClientService(IPAddress Address, int Port, int a_iBufferLength = 100000) :
            base(ModeEnum.Client, Address, Port, a_iBufferLength)
        {
            m_oNetObject = new TcpClient();
        }
        public override bool IsConnected => (m_oNetObject?.Client?.Connected ?? false);

        public override Socket NetworkSocket => m_oNetObject?.Client ?? null;

        public override void Establish()
        {
            if (IsConnected)
                return;

            try
            {
                m_oNetObject.BeginConnect(Address, Port, new AsyncCallback(ConnectCallback), this);

                NetworkAction?.NetworkStateChanged(NetworkState.Connecting, new StateObject(this));

                return;
            }
            catch (Exception)
            {
            }

            NetworkAction?.NetworkStateChanged(NetworkState.Error, new StateObject(this));
        }

        protected virtual void ConnectCallback(IAsyncResult ar)
        {
            var _obj = ar.AsyncState as ClientService;

            try
            {
                _obj.NetworkSocket.EndConnect(ar);

                _obj?.NetworkAction?.NetworkStateChanged(NetworkState.Connected, new StateObject(this));

                return;
            }
            catch (Exception)
            {
            }

            _obj?.NetworkAction?.NetworkStateChanged(NetworkState.Error, new StateObject(this));
        }

        public virtual void AsyncSend(NetworkData a_oData)
        {
            try
            {
                NetworkAction?.NetworkStateChanged(NetworkState.Sending, new StateObject(this, a_oData));

                NetworkSocket?.BeginSend(a_oData.Buffer, 0, a_oData.DataLength(true), SocketFlags.None, new AsyncCallback(SendCallback), this);
            }
            catch (Exception)
            {
                NetworkAction?.NetworkStateChanged(NetworkState.Error, new StateObject(this));
            }
        }

        public virtual void AsyncReceive()
        {
            Data?.Clear();

            try
            {
                NetworkAction?.NetworkStateChanged(NetworkState.Receiving, new StateObject(this));

                NetworkSocket?.BeginReceive(Data.Buffer, 0, Data.BufferLength, SocketFlags.None, new AsyncCallback(ReceiveCallback), this);
            }
            catch (Exception)
            {
                NetworkAction?.NetworkStateChanged(NetworkState.Error, new StateObject(this));
            }
        }

        public virtual StateObject SyncReceive()
        {
            try
            {
                Data?.Clear();

                NetworkSocket?.Receive(Data.Buffer, SocketFlags.None);

                return new StateObject(this, Data);
            }
            catch (Exception)
            {
            }

            NetworkAction?.NetworkStateChanged(NetworkState.Error);

            return null;
        }

        protected virtual void SendCallback(IAsyncResult ar)
        {
            ClientService _obj = ar.AsyncState as ClientService;

            try
            {
                if (_obj.NetworkSocket.EndSend(ar) > 0)
                {
                    _obj.NetworkAction?.NetworkStateChanged(NetworkState.Sent, new StateObject(this));

                    return;
                }
            }
            catch (Exception)
            {
            }

            _obj.NetworkAction?.NetworkStateChanged(NetworkState.Error);
        }

        protected virtual void ReceiveCallback(IAsyncResult ar)
        {
            ClientService _obj = ar.AsyncState as ClientService;

            try
            {
                int _iSize = _obj.NetworkSocket.EndReceive(ar);

                if (_iSize > 0 && (_obj.Data?.HasAnyData ?? false))
                {
                    _obj.NetworkAction?.NetworkStateChanged(NetworkState.Received, new StateObject(this, Data));

                    return;
                }
            }
            catch (Exception)
            {
            }

            _obj.NetworkAction?.NetworkStateChanged(NetworkState.Error, new StateObject(this));
        }

    }
}
