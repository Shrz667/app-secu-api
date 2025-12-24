using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prototype_app_secu.Models
{
    public class login
    {// ca sert a rien les setter puisque mahach yetbdlo 
        private string  numero {get;}
        private int password {get;}

public login( string numero , int password)
        {
            this.numero = numero;
            this.password = password;
        }
    }
}