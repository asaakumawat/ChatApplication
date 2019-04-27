﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FarmersStop.Common.Helpers
{
    public static class XMLHelper
    {
        #region Fields

        private static readonly XmlWriterSettings WriterSettings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
        private static readonly XmlSerializerNamespaces Namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

        #endregion

        #region Methods

        public static string Serialize(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            return DoSerialize(obj);
        }

        private static string DoSerialize(object obj)
        {
            using (var ms = new MemoryStream())
            using (var writer = XmlWriter.Create(ms, WriterSettings))
            {
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj, Namespaces);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static T Deserialize<T>(string data)
            where T : class
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            return DoDeserialize<T>(data);
        }

        private static T DoDeserialize<T>(string data) where T : class
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(ms);
            }
        }

        #endregion
    }
}
