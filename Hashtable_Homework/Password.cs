using System;

namespace Hashtable_Homework
{
    class Password
    {
        private Dictionary<string, string> pass;

        public void SearchPass(string site)
        {
            Console.WriteLine(pass[site]);
        }

        public void Save(string text)
        {
            string[] siteAndPass = text.Split(' ');
            pass.Add(siteAndPass[0], siteAndPass[1]);
        }

        public Password()
        {
            pass = new Dictionary<string, string>();
        }

    }
    class Pro
    {
        static void Main()
        {
            Password password = new Password();
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            for (int i = 0; i < n; i++)
            {
                password.Save(Console.ReadLine());
            }
            for (int i = 0; i < m; i++)
            {
                password.SearchPass(Console.ReadLine());
            }
        }
    }
}
