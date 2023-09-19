using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDolgozat
{
    internal class Fuvar
    {
        public Fuvar(int iD, string indulas, int idotartam, double tavolsag, double vitelDij, double borravalo, string fizetesiMod)
        {
            ID = iD;
            Indulas = indulas;
            Idotartam = idotartam;
            Tavolsag = tavolsag;
            VitelDij = vitelDij;
            Borravalo = borravalo;
            FizetesiMod = fizetesiMod;
        }

        public int ID { get; set; }
        public string Indulas { get; set; }
        public int Idotartam { get; set; }
        public double Tavolsag { get; set; }
        public double VitelDij { get; set; }
        public double Borravalo { get; set; }
        public string FizetesiMod { get; set; }
    }
}
