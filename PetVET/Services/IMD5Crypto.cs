using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetVET.Services
{
    public interface IMD5Crypto
    {
        

        string MD5Hash(string input);

        string Decrypt(string input);
    }
}
