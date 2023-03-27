namespace EvidencePojisteni
    {
    internal class Program
        {
        private static void Main(string[] args)
            {
            //Inicializace objektu Aplikace
            Aplikace aplikace = new Aplikace();

            //Cyklus celého programu. Opakuje se, dokud uživatel neukončí program - tedy: aplikace.pokracovat = false
            while (aplikace .pokracovat)
                {
                Console .WriteLine("-----------------------------------------");
                Console .WriteLine("Konzolová Aplikace - Evidence pojištěných");
                Console .WriteLine("-----------------------------------------");
                Console .WriteLine("\nVolbou číselné hodnoty si vyberte akci:");
                Console .WriteLine("-----------------------------------------");
                Console .WriteLine("1 - Přidat nového pojištěného");
                Console .WriteLine("2 - Vypsat všechny pojištěné");
                Console .WriteLine("3 - Vyhledat pojištěného");
                Console .WriteLine("4 - Vymazat pojištěného");
                Console .WriteLine("5 - Ukončit program");
                Console .WriteLine("-----------------------------------------");

                //Uživatelský vstup pro metodu switch
                int volba = 0;

                //Cyklus se opakuje dokud není zadáno číslo od 1 do 5
                while (!(int .TryParse(Console .ReadLine() .Trim() , out volba) && volba >= 1 && volba <= 5))
                    {
                    Console .WriteLine("\nNeplatná volba. Zadejte prosím platnou hodnotu.");
                    }
                //Metoda switch na základě uživatelského vstupu 'volba'
                switch (volba)
                    {
                    case 1: //Vytvoření nového pojištěného
                    aplikace .VytvoreniPojisteneho();
                    aplikace .Pokracovani();
                    break;

                    case 2: //Vypsání všech pojištěných
                    aplikace .VypsaniPojistenych();
                    aplikace .Pokracovani();
                    break;

                    case 3: //Hledání pojištěného
                    aplikace .HledaniPojisteneho();
                    aplikace .Pokracovani();
                    break;

                    case 4: //Vymazání pojištěného
                    aplikace .VymazaniPojisteneho();
                    aplikace .Pokracovani();
                    break;

                    case 5: //Ukončení celého programu
                    aplikace .UkonceniAplikace();
                    break;

                    default:
                    Console .WriteLine("Nastala chyba. Zavřete aplikaci");
                    break;
                    }
                }
            }
        }
    }