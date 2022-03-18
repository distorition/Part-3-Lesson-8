using Microsoft.IdentityModel.Tokens;
using Part_3_Lesson_4.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_Lesson_4
{
    public class UserService:IUserServices
    {
        /// <summary>
        /// представлен процесс регистрации
        /// </summary>
        private IDictionary<string, AuthPEsponse> users = new Dictionary<string, AuthPEsponse>()
        {
            {"test",new AuthPEsponse(){Password="test" } }
        };
        public  const string SecreteCode = "aaaaa";
    //public string Authentication(string name , string pass)
    //    {
    //        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pass))
    //        {
    //            return string.Empty;
    //        }
    //        int i = 0;
    //        foreach( var item in users)
    //        {
    //            i++;
    //            if (string.CompareOrdinal(item.Key, name) == 0 || string.CompareOrdinal(item.Key, pass) == 0)
    //            {
    //                return GenerateJwToken(i);
    //            }
    //        }
    //        return string.Empty;
    //    }

        public string GenerateJwToken(int id)
        {
            JwtSecurityTokenHandler jwt = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecreteCode);//переводим в байты наш секретный код
            SecurityTokenDescriptor securityToken = new SecurityTokenDescriptor()//класс который описывает наш токен (что он будет делать)
            {
                Subject = new ClaimsIdentity(new Claim[]//все что может делать пользователь храниться вв паре ключ значений 
                {
                    new Claim(ClaimTypes.Name, id.ToString())// а вот и наша пара имя и ид
                }),
                Expires = DateTime.UtcNow.AddMinutes(2),//время жизни токена 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)// применяем алгоритмы шифрования к нашему ключу 


            };

            SecurityToken security = jwt.CreateToken(securityToken);
            return jwt.WriteToken(security);
        }

        public  REsponseToken Authentication(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user)||string.IsNullOrWhiteSpace(password))
            {
                //throw new ArgumentException("логин или пароль не совпадает ");
                return null;
            }

            REsponseToken rEsponse = new REsponseToken();
            int i = 0;
            foreach (KeyValuePair<string, AuthPEsponse> pair in users)
            {
                i++;
                if (string.CompareOrdinal(pair.Key, user) == 0 || string.CompareOrdinal(pair.Value.Password, password) == 0)
                {
                    rEsponse.Token = GenerateJwToken(i, 15);
                    RegreshToken regresh = GenerateRefreshToken(i);
                    pair.Value.LatesToken = regresh;
                    rEsponse.Refreshtoken = regresh.Toke;
                    return rEsponse;

                }
            }

            return null;
        }

        private string GenerateJwToken(int id, int minute)
        {
            JwtSecurityTokenHandler jwtSecurity = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecreteCode);
            SecurityTokenDescriptor securityToken = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(minute),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            SecurityToken security = jwtSecurity.CreateToken(securityToken);
            return jwtSecurity.WriteToken(security);
        }
        public RegreshToken GenerateRefreshToken(int id)
        {
            RegreshToken regreshToken = new RegreshToken();
            regreshToken.Expires = DateTime.UtcNow.AddMinutes(360);
            regreshToken.Toke = GenerateJwToken(id, 360);
            return regreshToken;
        }
        public string REfreshToken(string token)
        {
            int i = 0;
            foreach(KeyValuePair<string,AuthPEsponse> pair in users)
            {
                i++;
                if(string.CompareOrdinal(pair.Value.LatesToken.Toke,token)==0&&pair.Value.LatesToken.isExpires is false)

                {
                    pair.Value.LatesToken = GenerateRefreshToken(i);
                    return pair.Value.LatesToken.Toke;
                }
            }
            return string.Empty;
        }
    }
}
