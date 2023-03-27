using System .Text .RegularExpressions;

namespace EvidencePojisteni
    {
    internal class Aplikace
        {
        //Private list objektů Pojistenec
        private List<Pojistenec> pojistenci = new List<Pojistenec>();

        //Bool pro cyklus celého programu. V případě false se program ukončí
        public bool pokracovat = true;

        //Metoda pro vytvoření nového objektu Pojistenec
        public void VytvoreniPojisteneho()
            {
            Console .WriteLine("\nZadejte jméno nového pojištěného:");
            string jmeno = NactiJmeno();
            string prijmeni = NactiPrijmeni();
            int vek = NactiVek();
            string telefonniCislo = NactiTelefonniCislo();
            //Konstruktor s validovanými parametry
            Pojistenec pojistenec = new Pojistenec(
                jmeno,
                prijmeni,
                vek,
                telefonniCislo
            );
            //Vložení objektu Pojistenec do kolekce list
            pojistenci .Add(pojistenec);
            Console .WriteLine("\nData uložena.");
            }

        //Metoda pro vypsání všech pojištěných
        public void VypsaniPojistenych()
            {
            //V případě, že kolekce list není prázdný
            if (pojistenci .Count() > 0)
                {
                //Vypsání "hlavičky" seznamu
                Console .WriteLine(ToString());
                //LINQ dotaz - seřazení podle abecedy podle jména a příjmení
                var vypsaniPojistenych = from u in pojistenci
                                         orderby u.Jmeno, u.Prijmeni
                                         select u;
                //Výpis jednotlivých pojištěnců
                foreach (Pojistenec p in vypsaniPojistenych)
                    {
                    Console .WriteLine(p);
                    }
                }
            else
                {
                Console .WriteLine("\nNemáme žádné pojištěné.");
                }
            }

        //Metoda pro hledání konkrétního pojištěného
        public void HledaniPojisteneho()
            {
            Console .WriteLine("\nZadejte jméno pojištěného:");
            string jmenoValidovano = NactiJmeno();
            string prijmeniValidovano = NactiPrijmeni();

            //LINQ dotaz - nalezení pojištěných podle zadaného jména, příjmení, seřazení podle abecedy
            var hledaniPojistenych = from u in pojistenci
                                     where (u.Jmeno == jmenoValidovano && u.Prijmeni == prijmeniValidovano)
                                     orderby u.Jmeno, u.Prijmeni
                                     select u;

            //V případě, že kolekce z LINQ dotazu není prázdná
            if (hledaniPojistenych .Count() > 0)
                {
                //Vypsání "hlavičky" seznamu
                Console .WriteLine(ToString());
                //Výpis nalezených pojištěnců
                foreach (Pojistenec p in hledaniPojistenych)
                    Console .WriteLine(p);
                }
            else
                {
                Console .WriteLine("\nHledání neodpovídá žádný záznam.");
                }
            }

        //Metoda pro hledání konkrétního pojištěného
        public void VymazaniPojisteneho()
            {
            Console .WriteLine("\nZadejte jméno pojištěného k vymazání:");
            string jmenoValidovano = NactiJmeno();
            string prijmeniValidovano = NactiPrijmeni();
            int vekValidovano = NactiVek();
            string telefonniCisloValidovano = NactiTelefonniCislo();

            //LINQ dotaz - nalezení pojištěných podle zadaného jména, příjmení, věku i telefonního čísla. Musí se shodovat vše.
            var pojistenecKVymazani = pojistenci.SingleOrDefault(
                s => s.Jmeno == jmenoValidovano
                && s.Prijmeni == prijmeniValidovano
                && s.Vek == vekValidovano
                && s.TelefonniCislo == telefonniCisloValidovano
            );

            //V případě, že kolekce z LINQ dotazu není prázdná.
            if (pojistenecKVymazani != null)
                {
                Console .WriteLine("\nZáznam tohoto pojištence bude vymazán.");
                Console .WriteLine(ToString());  //Vypsání "hlavičky" seznamu
                Console .WriteLine(pojistenecKVymazani); //Výpis nalezeného pojištěnce
                Console .WriteLine("\nJste si opravdu jisti?");
                Console .WriteLine("\nZadejte:");
                Console .WriteLine("\"ANO\" - pro vymazání záznamu");
                Console .WriteLine("\"NE\" - pro ponechání záznamu a návrat do hlavní nabídky");
                //Uživatelský vstup převeden na velká písmena a odstraněny bílé znaky
                string vstup = Console.ReadLine().ToUpper().Trim();
                //V případě, že uživatel zadá "ano", dojde k vymazání. Po jakémkoliv jiném vstupu budo data ponechána
                if (vstup == "ANO")
                    {
                    pojistenci .Remove(pojistenecKVymazani);
                    Console .WriteLine("\nData vymazána.");
                    }
                else
                    {
                    Console .WriteLine("\nData ponechána.");
                    }
                }
            else
                {
                Console .WriteLine("\nHledání nedpovídá žádný záznam.");
                }
            }

        //Metoda pro ukončení aplikace - volba: 5, bool pokracovat = false
        public void UkonceniAplikace()
            {
            pokracovat = false;
            Console .WriteLine("\n-------------------------------------");
            Console .WriteLine("Děkujeme za použití našeho programu.");
            Console .WriteLine("\nStiskem libovolné klávesy program ukončíte.");
            Console .ReadKey();
            }

        //Metoda pro pokračování do "hlavního menu"
        public void Pokracovani()
            {
            Console .WriteLine("\nPokračujte stiskem libovolné klávesy.");
            Console .ReadKey();
            Console .Clear();
            }

        //Metoda pro načtení a validaci jmena
        public string NactiJmeno()
            {
            //Regulární výraz pro jméno - nesmí obsahovat číslice a speciální znaky
            Regex rx = new Regex(@"^\b[^\d\W]+\b$");
            bool spravnyVstup = false;
            string jmeno = "";
            //V případě, že vstup odpovídá regulárnímu výrazu, cyklus skončí
            while (!spravnyVstup)
                {
                //Uživatelský vstup převeden na malá písmena a odstraněny bílé znaky
                jmeno = Console .ReadLine() .ToLower() .Trim();
                if (rx .IsMatch(jmeno))
                    {
                    spravnyVstup = true;
                    }
                else
                    {
                    Console .WriteLine("\nJméno nesmí obsahovat číslice a speciální znaky.\nZadejte jméno:");
                    }
                }
            return jmeno;
            }

        //Metoda pro načtení a validaci příjmení
        public string NactiPrijmeni()
            {
            Console .WriteLine("Zadejte příjmeni:");
            //Regulární výraz pro příjmení - nesmí obsahovat číslice a speciální znaky
            Regex rx = new Regex(@"^\b[^\d\W]+\b$");
            bool spravnyVstup = false;
            string prijmeni = "";
            //V případě, že vstup odpovídá regulárnímu výrazu, cyklus skončí
            while (!spravnyVstup)
                {
                //Uživatelský vstup převeden na malá písmena a odstraněny bílé znaky
                prijmeni = Console .ReadLine() .ToLower() .Trim();
                if (rx .IsMatch(prijmeni))
                    {
                    spravnyVstup = true;
                    }
                else
                    {
                    Console .WriteLine("\nPříjmení nesmí obsahovat číslice a speciální znaky.\nZadejte Příjmení:");
                    }
                }
            return prijmeni;
            }

        //Metoda pro načtení a validaci věku
        public int NactiVek()
            {
            Console .WriteLine("Zadejte věk:");
            int vstup = 0;
            int vek = 0;
            //Cyklus se opakuje dokud není zadáno číslo od 0 do 99
            while (!(int .TryParse(Console .ReadLine() .Trim() , out vstup) && vstup >= 0 && vstup <= 99))
                {
                Console .WriteLine("\nNeplatné číslo. Zadejte věk v rozmezí 0-99.");
                }
            vek = vstup;
            return vek;
            }

        //Metoda pro načtení a validaci telefonního čísla
        public string NactiTelefonniCislo()
            {
            //Regulární výraz pro telefonní číslo - smí obsahovat přesně 9 číslic 0-9
            Regex rx = new Regex(@"^[0-9]{9}$");
            bool spravnyVstup = false;
            string telefonniCislo = "";
            //V případě, že vstup odpovídá regulárnímu výrazu, cyklus skončí
            while (!spravnyVstup)
                {
                Console .WriteLine("Zadejte telefonní číslo ve formátu 123456789:");
                //Uživatelský vstup převeden na malá písmena a odstraněny bílé znaky
                telefonniCislo = Console .ReadLine() .ToLower() .Trim();
                if (rx .IsMatch(telefonniCislo))
                    {
                    spravnyVstup = true;
                    }
                else
                    {
                    Console .WriteLine("\nNeplatný formát telefonního čísla.");
                    }
                }
            return telefonniCislo;
            }

        //Vrací "hlavičku" seznamu pro výpis
        public override string ToString()
            {
            return String .Format("\n{0,-10}\t{1,-10}\t{2,10}\t{3,-10}" , "Jméno" , "Příjmení" , "Věk" , "Telefonní číslo");
            }
        }
    }