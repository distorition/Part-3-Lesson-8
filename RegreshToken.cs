using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4
{
    public sealed class RegreshToken//из чего состоит сам токен 
    {
        /// <summary>
        /// наш токен обновления
        /// </summary>
        public string Toke { get; set; }//имя токена 
        public DateTime Expires { get; set; }//времени токена 
        public bool isExpires => DateTime.UtcNow >= Expires;//
    }

    internal sealed class AuthPEsponse
    {
        public string Password { get; set; }
        public RegreshToken LatesToken { get; set; }
    }


    public sealed class REsponseToken
    {
        public string Token { get; set; }
        public string Refreshtoken { get; set; }
    }
}
