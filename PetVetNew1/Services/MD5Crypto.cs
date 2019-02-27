using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PetVET.Services
{
    public class MD5Crypto : IMD5Crypto
    {
        IConfiguration configuration;

        public MD5Crypto(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Decrypt(string input)
        {
            throw new NotImplementedException();
        }

        public string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                return Encoding.ASCII.GetString(result);
            }
        }
    }
}
