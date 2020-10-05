using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SNAKE
{
    class RandomNumberGenerator
    {
        public int GetRandomIntegerInRange(int lowestValue, int highestValue)
        {

            int range = (highestValue - lowestValue)+1;
            int offset = lowestValue;
            int randomNumber;

            RNGCryptoServiceProvider CryptoRNG = new RNGCryptoServiceProvider();
            byte[] fourBytes = new byte[4];
            CryptoRNG.GetBytes(fourBytes);
            UInt32 scale = BitConverter.ToUInt32(fourBytes, 0);
            randomNumber = ((int)(range * (scale / (uint.MaxValue + 1.0))));
            randomNumber += offset;
            return randomNumber;

        }

    }
}
