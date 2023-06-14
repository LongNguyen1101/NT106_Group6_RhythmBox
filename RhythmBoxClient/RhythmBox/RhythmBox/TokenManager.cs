using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmBox
{
    internal class TokenManager
    {
        private static string _accessToken;

        public static void SetAccessToken(string accessToken)
        {
            if (_accessToken == null)
                _accessToken = accessToken;
        }

        public static string GetAccessToken() { return _accessToken; }
    }
}
