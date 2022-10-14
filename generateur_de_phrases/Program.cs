using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static string ObtenirElementAleatoire(string[] t)
        {
            Random r = new Random();
            int i = r.Next(t.Length);
            return t[i];
        }


        static void Main(string[] args)
        {
            var sujets = new string[]
            {   "Ysaya ",
                "Timothée ",
                "Hubert ",
                "Jack ",
                "Eneadya ",
                "Kalisce ",
                "Beth' ",
                "Leonel ",
                "Osmund ",
                "Johansen ",
                "Torgheim ",
                "Dame de Sylve ",
                "Luc ",
            };

            var verbes = new string[]
            {   "mange ",
                "détruit ",
                "écrase ",
                "décapite ",
                "attrape ",
                "savate ",
                "avale ",
                "prend ",
                "devient ",
                "se déguise en ",
                "s'accroche à ",
            };

            var compléments = new string[]
            {   "un orc",
                "Johnny Cash",
                "un kobold",
                "un dragon",
                "un troll",
                "un humain tout à fait respectable",
                "un griffon",
                "une noix de coco",
                "une tente",
                "l'Aube d'Acier",
                "un membre de la Horde",
                "un démoniste",
                "un voleur",
                "un tigre",
            };

            // sujet + verbe + complément
            //NB_PHRASES

            var phrasesUniques = new List<string>();
            const int NB_PHRASES = 100; //ATTENTION ! Le nombre de phrases uniques possible au maximum s'obtient en multipliant : sujets * verbes * compléments = 2002
                                         // Indiquer NB_PHRASES = 2003 pourrait engendrer une boucle infinie, car la dernière phrase ne pourra pas être unique
                                         // Car toutes les possibilités ont déjà été explorées.
            int doublonsEvites = 0;

            while(phrasesUniques.Count<NB_PHRASES)
            {
                var sujet = ObtenirElementAleatoire(sujets);
                var verbe = ObtenirElementAleatoire(verbes);
                var complément = ObtenirElementAleatoire(compléments);
                var phrase = sujet + verbe + complément;

                phrase = phrase.Replace("en le", "en");
                phrase = phrase.Replace("en la", "en");
                phrase = phrase.Replace("à le", "au");
                phrase = phrase.Replace("en une", "en"); // ATTENTION ! "en une" doit être remplacé avant "en un".
                                                         // Sinon, dans la phrase "se déguise en une tente", "en un" est remplacé par "en"
                                                         // et la phrase devient "se déguise ene tente"
                phrase = phrase.Replace("en un", "en");

                if (!phrasesUniques.Contains(phrase))
                {
                    phrasesUniques.Add(phrase);
                }
                else
                {
                    doublonsEvites++;
                }
            }

            foreach (var phrase in phrasesUniques)
            {
                Console.WriteLine(phrase);
            }

            Console.WriteLine("Nombre de phrases uniques : " + phrasesUniques.Count);
            Console.WriteLine("Nombre de doublons évités : " + doublonsEvites);

        }

    }
}