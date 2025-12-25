using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
namespace prototype_app_secu.Models
{
    public class BDD
    {
        private static List<login> logins ;
      public BDD()
        {
            logins = new List <login>();
            initlist();
        }
      private void initlist()

        {

                logins.Add(new login( "+21321667451",3703  ));
                logins.Add(new login( "+21321919808" ,8384  ));
                logins.Add(new login( "+21329681743" ,1634  ));
                logins.Add(new login( "+21337327744" ,3898  ));
                logins.Add(new login( "+21331818972" ,1503  ));
                logins.Add(new login( "+21338863566" ,6708  ));
                logins.Add(new login( "+21321381337" ,0378  ));
                logins.Add(new login( "+21331942018" ,4338  ));
                logins.Add(new login( "+21321309248" ,7987  ));
                logins.Add(new login( "+21334235794" ,7644  ));
            
        }
    }
}