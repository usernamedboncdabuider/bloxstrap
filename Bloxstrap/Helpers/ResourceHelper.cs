﻿using System.IO;
using System.Reflection;

namespace Bloxstrap.Helpers
{
    internal class ResourceHelper
    {
        static Assembly assembly = Assembly.GetExecutingAssembly();
        static string[] resourceNames = assembly.GetManifestResourceNames();

        public static async Task<byte[]> Get(string name)
        {
            string path = resourceNames.Single(str => str.EndsWith(name));

            using (Stream stream = assembly.GetManifestResourceStream(path)!)
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
