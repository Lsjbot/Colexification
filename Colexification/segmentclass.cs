using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Colexification
{
    class segmentclass
    {

        public static double[,] segdistmatrix;
        public static int totalseg = 0;
        public static double mindist = 0.2;

        public int segid = 0;
        public string goodseg = "";
        public string fullseg = "";
        public int nseg = 0;
        public string featurestring = "";

        public segmentclass(string line)
        {
            string[] words = line.Split('\t');
            if (words.Length >= 4)
            {
                segid = totalseg;
                totalseg++;
                goodseg = words[0];
                fullseg = words[1];
                featurestring = words[3];
            }
            else
                segid = -1;
        }

        public static List<segmentclass> read_segmentfile(string fn)
        {
            List<segmentclass> ls = new List<segmentclass>();

            using (StreamReader sr = new StreamReader(fn))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    ls.Add(new segmentclass(line));
                }
            }
            return ls;
        }

        public static void build_segdistmatrix(List<segmentclass> lseg)
        {
            segdistmatrix = new double[totalseg, totalseg];
            for (int i = 0; i < totalseg; i++)
                for (int j = 0; j < totalseg; j++)
                    segdistmatrix[i, j] = 1;

            foreach (segmentclass s1 in lseg)
            {
                if (s1.segid < 0)
                    continue;
                
                if ((s1.featurestring == "no") || (s1.featurestring == "0"))
                        continue;
                foreach (segmentclass s2 in lseg)
                {
                    if (s1.featurestring == s2.featurestring)
                        segdistmatrix[s1.segid, s2.segid] = 0;
                    else if ((s2.featurestring == "no") || (s2.featurestring == "0"))
                        segdistmatrix[s1.segid, s2.segid] = 1;
                    else
                    {
                        double k = s1.featurestring.Length;
                        double eachdiff = (1 - mindist) / k;
                        double cost = mindist;
                        for (int i = 0; i < s1.featurestring.Length; i++)
                            if (s1.featurestring[i] != s2.featurestring[i])
                                cost += eachdiff;
                        segdistmatrix[s1.segid, s2.segid] = cost;
                    }
                }
            }
        }
    }
}
