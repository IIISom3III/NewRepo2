namespace EvidencePojisteni
    {
    internal class Pojistenec
        {
        public string Jmeno
            {
            get; private set;
            }

        public string Prijmeni
            {
            get; private set;
            }

        public int Vek
            {
            get; private set;
            }

        public string TelefonniCislo
            {
            get; private set;
            }

        //Konstuktor objektu Pojistenec
        public Pojistenec(string jmeno , string prijmeni , int vek , string telefonniCislo)
            {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            TelefonniCislo = telefonniCislo;
            }

        //Vrací string z parametru s uppercase prvním písmenem
        public string VelkePismeno(string str)
            {
            return char .ToUpper(str[0]) + str .Substring(1);
            }

        //Vrací hodnoty vlastností objektu s odsazením a zarovnáním
        public override string ToString()
            {
            return string .Format("{0,-10}\t{1,-10}\t{2,10}\t{3,-10}" , VelkePismeno(Jmeno) , VelkePismeno(Prijmeni) , Vek , TelefonniCislo);
            }
        }
    }