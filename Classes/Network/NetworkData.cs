using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zIinz_3_bigdata.Classes.Exceptions;

namespace zIinz_3_bigdata.Classes.Network
{
    public class NetworkData
    {
        private readonly byte[] m_oBuffer;

        public NetworkData(int a_iBufferSize)
        {
            m_oBuffer = new byte[a_iBufferSize];
            Clear();
        }

        public void Clear()
        {
            Array.Fill<byte>(m_oBuffer, 0);
        }

        public int BufferLength => m_oBuffer.Length;

        public int DataLength(bool a_bWithZero = false)
        {
            int iIndex = m_oBuffer.ToList().FindIndex(x => x == 0);

            if (a_bWithZero)
                iIndex++;

            return iIndex;
        }

        public bool HasAnyData => DataLength() > 0;

        public byte[] Buffer
        {
            get => m_oBuffer;
            set
            {
                if (value == null)
                    throw new NetworkDataBufferIsEmpty("Wejściowy");

                if (value.Length > BufferLength)
                    throw new NetworkDataBufferToLarge("Wejściowy", value.Length, BufferLength);

                Clear();

                Array.Copy(value, m_oBuffer, value.Length);
            }
        }

        public byte[] BufferWithData => Buffer.Take(DataLength()).ToArray();

        public override string ToString()
        {
            string sResult = "Buffer=";

            foreach (var oByte in m_oBuffer)
            {
                sResult += $"[{oByte}] ";
            }

            return sResult;
        }
    }
}
