using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizaAmigos.Infra.Data.Repositories
{
    public class Token
    {
        public static bool GetToken(string token)
        {
            if(token == "token")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
