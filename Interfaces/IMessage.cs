using System;
using System.Collections.Generic;
using System.Text;
using zIinz_3_bigdata.Classes.Network;

namespace zIinz_3_bigdata.Interfaces
{
    public interface IMessage
    {
        IMessage ProcessRequest(StateObject Object = null);
        IMessage ProcessResponse(StateObject Object = null);

        NetworkData AsNetworkData(int a_iDataSize = NetworkService.BUFFER_SIZE);
    }
}
