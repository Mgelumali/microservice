﻿using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace BookStore.Endpoints.Oauth.Certificate
{
    static class Certificate
    {
        public static X509Certificate2 Get()
        {
            var assembly = typeof(Certificate).GetTypeInfo().Assembly;
            var names = assembly.GetManifestResourceNames();

            using var stream = assembly.GetManifestResourceStream("BookStore.Endpoints.Oauth.Certificate.idsrv3test.pfx");

            return new X509Certificate2(ReadStream(stream), "idsrv3test");
        }

        private static byte[] ReadStream(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using var ms = new MemoryStream();
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }
}
