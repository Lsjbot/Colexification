using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Colexification
{
    public class wordclass
    {
        public int id;
        public string meaning;
        public string language;
        public string form;
        public string encodedform;


        static public void write_nexus(string fn, string src, Dictionary<string, Dictionary<int, List<int>>> cogclassdict,List<string> languagelist, List<wordclass> wordlist)
        {
            //Dictionary<int, List<wordclass>> classdict = new Dictionary<int, List<wordclass>>();
            string fnnex = fn.Replace("swadesh", "truecognate-" + src).Replace(".txt", ".nex");
            using (StreamWriter swnex = new StreamWriter(fnnex))
            {
                swnex.WriteLine("#NEXUS");
                swnex.WriteLine("BEGIN TAXA;");
                swnex.WriteLine("\tDimensions NTax=" + (languagelist.Count) + ";");
                StringBuilder sbtax = new StringBuilder("\tTaxLabels");

                foreach (string lc in languagelist)
                    sbtax.Append(" " + lc);
                sbtax.Append(";");
                swnex.WriteLine(sbtax.ToString());
                swnex.WriteLine("END;");
                swnex.WriteLine();

                swnex.WriteLine("BEGIN CHARACTERS;");
                swnex.WriteLine("\tDimensions NChar=" + cogclassdict.Count + ";");
                swnex.WriteLine("\tformat datatype=standard symbols=\"A~Z\" gap =-;");
                StringBuilder sbchar = new StringBuilder("\tcharlabels ");
                Dictionary<int, Dictionary<int, char>> symboldict = new Dictionary<int, Dictionary<int, char>>();
                Dictionary<int, char> maxsymbdict = new Dictionary<int, char>();// char maxsymb = '@'; // A-1
                Dictionary<string, int> cogindex = new Dictionary<string, int>();
                int k = 0;
                foreach (string mm in cogclassdict.Keys)
                {
                    sbchar.Append(" '" + mm + "'");
                    cogindex.Add(mm, k);
                    k++;
                }
                sbchar.Append(";");
                swnex.WriteLine(sbchar.ToString());

                Dictionary<string, int> langindex = new Dictionary<string, int>();
                for (int i = 0; i < languagelist.Count; i++)
                    langindex.Add(languagelist[i], i);
                char[,] matrix = new char[languagelist.Count, cogclassdict.Count];
                for (int i = 0; i < languagelist.Count; i++)
                    for (int j = 0; j < cogclassdict.Count; j++)
                        matrix[i, j] = '-';
                foreach (string mm in cogclassdict.Keys)
                {
                    List<wordclass> qw = (from c in wordlist where c.meaning == mm select c).ToList();
                    int im = cogindex[mm];
                    foreach (int cogclass in cogclassdict[mm].Keys)
                    {
                        char cc = (char)((int)'A' + cogclass);
                        foreach (int w in cogclassdict[mm][cogclass])
                        {
                            wordclass ww = qw[w];// (from c in qw where c.id == w select c).First();
                            int il = langindex[ww.language];
                            matrix[il, im] = cc;
                        }
                    }
                }
                swnex.WriteLine("\tMatrix");
                for (int i = 0; i < languagelist.Count; i++)
                {
                    StringBuilder sb = new StringBuilder("\t" + languagelist[i] + " ");
                    for (int j = 0; j < cogclassdict.Count; j++)
                        sb.Append(matrix[i, j]);
                    swnex.WriteLine(sb.ToString());
                }

                swnex.WriteLine(";");
                swnex.WriteLine("END;");
                swnex.WriteLine();
                swnex.WriteLine("BEGIN PAUP;");
                swnex.WriteLine("\tset criterion=parsimony;");
                swnex.WriteLine("\thsearch nreps=25;");
                swnex.WriteLine("\tdescribe 1 / plot=phylogram;");
                swnex.WriteLine("\tsavetrees file=" + fnnex.Replace(".nex", ".tre") + " brlens;");
                swnex.WriteLine("\tcontree /treeFile=" + fnnex.Replace(".nex", "-consensus.nex;"));
                //swnex.WriteLine("QUIT;");
                swnex.WriteLine("END;");

            }


        }


    }


}
