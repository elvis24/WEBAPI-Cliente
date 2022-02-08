using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI_Cliente.Modelo
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public byte[] PaswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
