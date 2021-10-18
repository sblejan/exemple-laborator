using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucrarea2.Models
{
    public class ProdusDatasheet
    {
        int id_produs;
        int stoc;
        int pret;

        public ProdusDatasheet( int id_produs, int stoc, int pret)
        {
            this.id_produs = id_produs;
            this.stoc = stoc;
            this.pret = pret;

        }
        public int getid()
        {
            return id_produs;
        }

        public int getstoc()
        {
            return stoc;
        }

        public int getpret()
        {
            return pret;
        }
        public void setid(int id)
        {
            this.id_produs = id;
        }

        public void setstoc(int stoc)
        {
            this.stoc = stoc;
        }

        public void setpret(int pret)
        {
            this.pret = pret;
        }

    }


    
}
