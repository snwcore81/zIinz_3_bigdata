using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using zIinz_3_bigdata.Interfaces;

namespace zIinz_3_bigdata.Classes
{
    public static class XmlStorageTypes
    {
        private static readonly List<Type> KnowningTypes = new List<Type>();

        static XmlStorageTypes()
        {
            Register(typeof(object));
            Register(typeof(Exception));

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (!type.IsGenericType)
                {
                    foreach (var attr in type.GetCustomAttributes())
                    {
                        if (attr.GetType() == typeof(DataContractAttribute))
                        {
                            Register(type);
                            break;
                        }
                    }
                }
            }
        }

        public static void Register(Type type)
        {
            if (!KnowningTypes.Contains(type))
            {
                Console.WriteLine($"Zarejestrowano typ:{type.Name}");

                KnowningTypes.Add(type);
            }
        }

        public static Type[] GetArray() => KnowningTypes.ToArray();
    }

    [DataContract]
    public abstract class XmlStorage<T> : IXmlStorage where T : class
    {
        [IgnoreDataMember]
        public T BaseObject { get; protected set; }

        public abstract bool InitializeFromObject(T Object);
        public virtual bool FromXml(Stream Stream)
        {
            DataContractSerializer oSerializer = new DataContractSerializer(typeof(T),XmlStorageTypes.GetArray());

            using var oReader = XmlDictionaryReader.CreateTextReader(Stream, new XmlDictionaryReaderQuotas());

            return InitializeFromObject((T)oSerializer.ReadObject(oReader, false)) ;
        }

        public virtual MemoryStream ToXml()
        {
            DataContractSerializer oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var oStream = new MemoryStream();

            using var oWriter = XmlDictionaryWriter.CreateTextWriter(oStream, Encoding.UTF8);

            oSerializer.WriteObject(oWriter,this);

            return oStream;
        }
    }
}
