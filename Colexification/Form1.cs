using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Colexification
{
    public partial class Form1 : Form
    {
        public static CLICS3 db;
        public static LangdbV1 dbl;
        static string connectionstring = "Data Source=DESKTOP-JOB29A9;Initial Catalog=\"CLICS3\";Integrated Security=True";
        static string langconnectionstring = "Data Source=DESKTOP-JOB29A9;Initial Catalog=\"langdb v1\";Integrated Security=True";
        static string folder = @"G:\clics\";
        static List<segmentclass> segmentlist;
        static string allstring = "--all--";

        List<string> semanticlist = new List<string>();
        List<string> familylist = new List<string>();
        List<string> cyrilliclist = new List<string>();

        Dictionary<int, string> ConcepticonSemantics = new Dictionary<int, string>();
        public Form1()
        {
            InitializeComponent();
            db = new CLICS3(connectionstring);
            dbl = new LangdbV1(langconnectionstring);

            fill_lists();

            fill_cyrIPA();


            foreach (ConcepticonTable ct in db.ConcepticonTable)
            {
                ConcepticonSemantics.Add(ct.ID, ct.Semantic_Field);
            }

            memo("Read segment file");
            segmentlist = segmentclass.read_segmentfile(folder + "segments.txt");
            memo("Build segment matrix");
            segmentclass.build_segdistmatrix(segmentlist);
            memo("Segment matrix done");
        }



        public void fill_lists()
        {
            semanticlist.Add("Agriculture and vegetation");
            semanticlist.Add("Animals");
            semanticlist.Add("Basic actions and technology");
            semanticlist.Add("Clothing and grooming");
            semanticlist.Add("Cognition");
            semanticlist.Add("Emotions and values");
            semanticlist.Add("Food and drink");
            semanticlist.Add("Kinship");
            semanticlist.Add("Law");
            semanticlist.Add("Miscellaneous function words");
            semanticlist.Add("Modern world");
            semanticlist.Add("Motion");
            semanticlist.Add("Possession");
            semanticlist.Add("Quantity");
            semanticlist.Add("Religion and belief");
            semanticlist.Add("Sense perception");
            semanticlist.Add("Social and political relations");
            semanticlist.Add("Spatial relations");
            semanticlist.Add("Speech and language");
            semanticlist.Add("The body");
            semanticlist.Add("The house");
            semanticlist.Add("The physical world");
            semanticlist.Add("Time");
            semanticlist.Add("Warfare and hunting");
            semanticlist.Add("");

            LB_semantics.Items.Add(allstring);
            foreach (string s in semanticlist)
                LB_semantics.Items.Add(s);


            familylist.Add("Nuclear Trans New Guinea");
            familylist.Add("Austronesian");
            familylist.Add("Sino-Tibetan");
            familylist.Add("Indo-European");
            familylist.Add("Pama-Nyungan");
            familylist.Add("Atlantic-Congo");
            familylist.Add("Timor-Alor-Pantar");
            familylist.Add("Nakh-Daghestanian");
            familylist.Add("Afro-Asiatic");
            familylist.Add("Tai-Kadai");
            familylist.Add("Austroasiatic");
            familylist.Add("Uralic");
            familylist.Add("Lakes Plain");
            familylist.Add("Eastern Trans-Fly");
            familylist.Add("Nuclear Torricelli");
            familylist.Add("Lower Sepik-Ramu");
            familylist.Add("Hmong-Mien");
            familylist.Add("Turkic");
            familylist.Add("Sepik");
            familylist.Add("Tupian");
            familylist.Add("South Bird's Head Family");
            familylist.Add("Anim");
            familylist.Add("Tucanoan");
            familylist.Add("Arawakan");
            familylist.Add("Dogon");
            familylist.Add("Mailuan");
            familylist.Add("Ndu");
            familylist.Add("Pano-Tacanan");
            familylist.Add("Angan");
            familylist.Add("Kiwaian");
            familylist.Add("Eleman");
            familylist.Add("East Strickland");
            familylist.Add("Manubaran");
            familylist.Add("East Bird's Head");
            familylist.Add("Koiarian");
            familylist.Add("Chapacuran");
            familylist.Add("Bosavi");
            familylist.Add("Chocoan");
            familylist.Add("Cariban");
            familylist.Add("West Bomberai");
            familylist.Add("Chibchan");
            familylist.Add("Tor-Orya");
            familylist.Add("Border");
            familylist.Add("Barbacoan");
            familylist.Add("Piawi");
            familylist.Add("Left May");
            familylist.Add("Nuclear-Macro-Je");
            familylist.Add("Guahiboan");
            familylist.Add("Kartvelian");
            familylist.Add("West Bird's Head");
            familylist.Add("Nimboranic");
            familylist.Add("Greater Kwerba");
            familylist.Add("Ambakich");
            familylist.Add("Abkhaz-Adyge");
            familylist.Add("Morehead-Wasur");
            familylist.Add("Teberan");
            familylist.Add("Huitotoan");
            familylist.Add("Dravidian");
            familylist.Add("Matacoan");
            familylist.Add("Tungusic");
            familylist.Add("Turama-Kikori");
            familylist.Add("Pauwasi");
            familylist.Add("Geelvink Bay");
            familylist.Add("Kwalean");
            familylist.Add("Baining");
            familylist.Add("Abun");
            familylist.Add("Bilua");
            familylist.Add("Sentanic");
            familylist.Add("Dagan");
            familylist.Add("Kayagaric");
            familylist.Add("Mpur");
            familylist.Add("Guaicuruan");
            familylist.Add("Inanwatan");
            familylist.Add("Eskimo-Aleut");
            familylist.Add("Yuat");
            familylist.Add("Maybrat-Karon");
            familylist.Add("Suki-Gogodala");
            familylist.Add("Kamula-Elevala");
            familylist.Add("Mongolic");
            familylist.Add("Boran");
            familylist.Add("North Halmahera");
            familylist.Add("Nambiquaran");
            familylist.Add("Senagi");
            familylist.Add("Konda-Yahadian");
            familylist.Add("Kolopom");
            familylist.Add("Hatam-Mansim");
            familylist.Add("Walioic");
            familylist.Add("Chonan");
            familylist.Add("Kaure-Narau");
            familylist.Add("Cayubaba");
            familylist.Add("Mande");
            familylist.Add("Lengua-Mascoy");
            familylist.Add("Ap Ma");
            familylist.Add("Chukotko-Kamchatkan");
            familylist.Add("Sko");
            familylist.Add("Yukaghir");
            familylist.Add("Mombum-Koneraw");
            familylist.Add("Amto-Musan");
            familylist.Add("Jodi-Saliban");
            familylist.Add("Songhay");
            familylist.Add("Fasu");
            familylist.Add("Quechuan");
            familylist.Add("Touo");
            familylist.Add("Bookkeeping");
            familylist.Add("Bulaka River");
            familylist.Add("Yanomamic");
            familylist.Add("Mayan");
            familylist.Add("Kakua-Nukak");
            familylist.Add("Otomanguean");
            familylist.Add("Nadahup");
            familylist.Add("Uto-Aztecan");
            familylist.Add("Goilalan");
            familylist.Add("Mairasic");
            familylist.Add("Salishan");
            familylist.Add("Molof");
            familylist.Add("Purari");
            familylist.Add("Pidgin");
            familylist.Add("Dibiyaso");
            familylist.Add("Marori");
            familylist.Add("Peba-Yagua");
            familylist.Add("Dem");
            familylist.Add("Sause");
            familylist.Add("Tsimshian");
            familylist.Add("Kunza");
            familylist.Add("Saharan");
            familylist.Add("Itonama");
            familylist.Add("East Kutubu");
            familylist.Add("Aikanã");
            familylist.Add("Chiquitano");
            familylist.Add("Zamucoan");
            familylist.Add("Wakashan");
            familylist.Add("Wiru");
            familylist.Add("Pahoturi");
            familylist.Add("Usku");
            familylist.Add("Bangime");
            familylist.Add("Mawes");
            familylist.Add("Puinave");
            familylist.Add("Nivkh");
            familylist.Add("Kwaza");
            familylist.Add("Pawaia");
            familylist.Add("Burmeso");
            familylist.Add("Cofán");
            familylist.Add("Ainu");
            familylist.Add("Papi");
            familylist.Add("Yámana");
            familylist.Add("Kehu");
            familylist.Add("Movima");
            familylist.Add("Basque");
            familylist.Add("Kol (Papua New Guinea)");
            familylist.Add("Tanahmerah");
            familylist.Add("Uru-Chipaya");
            familylist.Add("Páez");
            familylist.Add("Haida");
            familylist.Add("Kapori");
            familylist.Add("Yareban");
            familylist.Add("Koreanic");
            familylist.Add("Athabaskan-Eyak-Tlingit");
            familylist.Add("Elamite");
            familylist.Add("Tambora");
            familylist.Add("Elseng");
            familylist.Add("Namla-Tofanma");
            familylist.Add("Trumai");
            familylist.Add("Taulil-Butam");
            familylist.Add("Karok");
            familylist.Add("Tabo");
            familylist.Add("Lavukaleve");
            familylist.Add("Camsá");
            familylist.Add("Kawesqar");
            familylist.Add("Mor (Bomberai Peninsula)");
            familylist.Add("Damal");
            familylist.Add("Nubian");
            familylist.Add("Kibiri");
            familylist.Add("Odiai");
            familylist.Add("Yuracaré");
            familylist.Add("Chicham");
            familylist.Add("Puelche");
            familylist.Add("Araucanian");
            familylist.Add("Seri");
            familylist.Add("Yawa-Saweru");
            familylist.Add("Kaki Ae");
            familylist.Add("Burushaski");
            familylist.Add("Japonic");
            familylist.Add("Yale");
            familylist.Add("Mosetén-Chimané");
            familylist.Add("Somahai");
            familylist.Add("Kuot");
            familylist.Add("Kosadle");
            familylist.Add("Yeniseian");
            familylist.Add("Arafundi");
            familylist.Add("Doso-Turumsa");
            familylist.Add("Aymaran");
            familylist.Add("Hruso");
            familylist.Add("Zuni");
            familylist.Add("Savosavo");
            familylist.Add("Duna");
            familylist.Add("Waorani");
            familylist.Add("Yetfa");
            familylist.Add("Pumé");
            familylist.Add("Bogaya");
            familylist.Add("Pyu");
            familylist.Add("Leco");

            LB_family.Items.Add(allstring);
            foreach (string s in familylist)
                LB_family.Items.Add(s);

            cyrilliclist.Add("Ossetian (Iron)");
            cyrilliclist.Add("Batsbi");
            cyrilliclist.Add("Chechen");
            cyrilliclist.Add("Kryz");
            cyrilliclist.Add("Lezgian");
            cyrilliclist.Add("Khwarshi");
            cyrilliclist.Add("Ingush");
            cyrilliclist.Add("Udi");
            cyrilliclist.Add("Beshta");
            cyrilliclist.Add("Khinalug");
            cyrilliclist.Add("Budukh");
            cyrilliclist.Add("Avar");
            cyrilliclist.Add("Andi");
            cyrilliclist.Add("Lak");
            cyrilliclist.Add("Dargwa");
            cyrilliclist.Add("Kumyk");
            cyrilliclist.Add("Tabasaran");
            cyrilliclist.Add("Aghul");
            cyrilliclist.Add("Tsakhur");
            cyrilliclist.Add("Rutul");
            cyrilliclist.Add("Azerbaijani");
            cyrilliclist.Add("Tsez (Mokok dialect) ");
            cyrilliclist.Add("Lezgian (Quba dialect)");
            cyrilliclist.Add("Avar (Batlukh dialect)");
            cyrilliclist.Add("Avar (Hid dialect)");
            cyrilliclist.Add("Avar (Andalal dialect)");
            cyrilliclist.Add("Avar (Antsukh dialect)");
            cyrilliclist.Add("Avar (Zakataly dialect)");
            cyrilliclist.Add("Avar (Karakh dialect)");
            cyrilliclist.Add("Andi (Muni dialect)");
            cyrilliclist.Add("Avar (Khunzakh dialect)");
            cyrilliclist.Add("Avar (Salatav dialect)");
            cyrilliclist.Add("Akhvakh (Northern dialect)");
            cyrilliclist.Add("Bagvalal");
            cyrilliclist.Add("Botlikh");
            cyrilliclist.Add("Godoberi");
            cyrilliclist.Add("Karata");
            cyrilliclist.Add("Karata (Tokitin dialect)");
            cyrilliclist.Add("Khwarshi (Khwarshi dialect)");
            cyrilliclist.Add("Hinuq");
            cyrilliclist.Add("Tindi");
            cyrilliclist.Add("Aghul (Koshan dialect)");
            cyrilliclist.Add("Chamalal (Gigatli dialect)");
            cyrilliclist.Add("Dargwa (Chirag dialect)");
            cyrilliclist.Add("Chamalal");
            cyrilliclist.Add("Dargwa (Tsudakhar dialect, Tanty subdialect)");
            cyrilliclist.Add("Dargwa (Urakhi dialect)");
            cyrilliclist.Add("Bezhta (Khasharkhota dialect)");
            cyrilliclist.Add("Hunzib");
            cyrilliclist.Add("Rutul (Ikhrek dialect)");
            cyrilliclist.Add("Rutul (Shinaz dialect)");
            cyrilliclist.Add("Bezhta (Tlyadal dialect, Karauzek subdialect)");
            cyrilliclist.Add("Archi (variety 2)");
            cyrilliclist.Add("Khwarshi (Inkhokvari dialect)");
            cyrilliclist.Add("Tsez (Sagada dialect)");
            cyrilliclist.Add("Dargwa (Itsari dialect)");
            cyrilliclist.Add("Dargwa (Kubachi dialect)");
            cyrilliclist.Add("Dargwa (Khajdak dialect)");
            cyrilliclist.Add("Tabasaran (Southern dialect)");
            cyrilliclist.Add("Nogai");
            cyrilliclist.Add("Judeo-Tat");

        }

        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }



        private void Quitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Countbutton_Click(object sender, EventArgs e)
        {
            int cs = (from c in db.CognateSource select c).Count();
            memo("Cognate source\t" + cs);
            cs = (from c in db.CognateTable select c).Count();
            memo("Cognate table\t" + cs);
            cs = (from c in db.FormSource select c).Count();
            memo("Form source\t" + cs);
            cs = (from c in db.FormTable select c).Count();
            memo("Form table\t" + cs);
            cs = (from c in db.LanguageTable select c).Count();
            memo("Language table\t" + cs);
            cs = (from c in db.LanguageTable2 select c).Count();
            memo("Language table 2\t" + cs);
            cs = (from c in db.ParameterTable select c).Count();
            memo("Parameter table\t" + cs);
            cs = (from c in db.SourceTable select c).Count();
            memo("Source table\t" + cs);
            cs = (from c in db.ValueSource select c).Count();
            memo("Value source\t" + cs);
            cs = (from c in db.ValueTable select c).Count();
            memo("Value table\t" + cs);
            cs = (from c in db.ColexForm select c).Count();
            memo("Colex form\t" + cs);
            cs = (from c in db.ColexTable select c).Count();
            memo("Colex table\t" + cs);
            cs = (from c in db.ConcepticonLink select c).Count();
            memo("Concepticon link\t" + cs);
            cs = (from c in db.ConcepticonTable select c).Count();
            memo("Concepticon table\t" + cs);
            cs = (from c in db.LinkLanguage select c).Count();
            memo("LinkLanguage\t" + cs);
            cs = (from c in db.RandomwalkLink select c).Count();
            memo("RandomwalLink\t" + cs);
            cs = (from c in db.CodedFormTable select c).Count();
            memo("CodedFormTable\t" + cs);


        }

        private void Concepticonbutton_Click(object sender, EventArgs e)
        {
            //for (int i=0;i<5000;i++)
            //{
            //    var q = from c in db.ParameterTable where c.Concepticon_ID == i.ToString() select c;
            //    int n = q.Count();
            //    if (n > 0)
            //        memo(i + "\t" +q.First().Concepticon_Gloss+"\t"+ n);
            //}

            bool filldb = ((from c in db.ConcepticonTable select c).Count() == 0);
            int ctid = 0;

            Dictionary<string, int> ccdict = new Dictionary<string, int>();
            foreach (ParameterTable pt in db.ParameterTable)
            {
                string key = pt.Concepticon_ID + "\t" + pt.Concepticon_Gloss;
                if (ccdict.ContainsKey(key))
                    ccdict[key]++;
                else
                {
                    ccdict.Add(key, 1);
                    if (filldb)
                    {
                        ConcepticonTable ct = new ConcepticonTable();
                        ctid++;
                        ct.ID = ctid;
                        ct.Concepticon_ID = pt.Concepticon_ID;
                        ct.Concepticon_Gloss = pt.Concepticon_Gloss;
                        ct.Ontological_Category = pt.Ontological_Category;
                        ct.Semantic_Field = pt.Semantic_Field;
                        db.ConcepticonTable.InsertOnSubmit(ct);
                        db.SubmitChanges();
                    }
                }

            }
            foreach (string key in ccdict.Keys)
                memo(key + "\t" + ccdict[key]);

            //foreach (string key in ccdict.Keys)
            //{
            //    string cid = key.Split('\t')[0];
            //    var qpt = from c in db.ParameterTable
            //              where c.Concepticon_ID == cid
            //              select c;

            //}

        }

        public int GetLanguageID2(LanguageTable lt)
        {
            if (lt == null)
                return -1;
            var q = from c in db.LanguageTable2
                    where c.Glottocode == lt.Glottocode
                    select c;
            if (q.Count() == 1)
                return q.First().ID;
            else
            {
                var qq = from c in db.LanguageTable2
                         where c.Name == lt.Name
                         select c;
                if (qq.Count() == 1)
                    return qq.First().ID;
            }
            return -1;
        }

        public int GetConcepticonID(ParameterTable pt)
        {
            var q = from c in db.ConcepticonTable
                    where c.Concepticon_ID == pt.Concepticon_ID
                    select c;
            if (q.Count() == 1)
                return q.First().ID;
            else
                return -1;
        }

        private void Findcolexbylang(LanguageTable2 lt2)
        {
            memo("Language " + lt2.Name);

            IEnumerable<FormTable> qft;
            if (lt2.Glottocode != null)
                qft = from c in db.FormTable
                      where c.LanguageTable.Glottocode == lt2.Glottocode
                      select c;
            else
                qft = from c in db.FormTable
                      where c.LanguageTable.Name == lt2.Name
                      select c;

            Dictionary<string, int> formdict = new Dictionary<string, int>();

            foreach (FormTable ft in qft)
            {
                if (formdict.ContainsKey(ft.Form))
                    formdict[ft.Form]++;
                else
                    formdict.Add(ft.Form, 1);
            }

            int fmax = formdict.Values.Max();

            if (fmax > 10)
            {
                memo(lt2.Name + "\t" + fmax);

                return;
            }


            int n = 0;
            int ctid = (from c in db.ColexTable select c).Count() + 1;
            int cfid = (from c in db.ColexForm select c).Count() + 1;
            //int clid = (from c in db.ConcepticonLink select c).Count() + 1;
            //int llid = (from c in db.LinkLanguage select c).Count() + 1;


            List<string> donevalues = new List<string>();
            donevalues.Add("–"); //skip dash "values"

            foreach (FormTable ft in qft)
            {
                if (donevalues.Contains(ft.Form))
                    continue;

                var qft2 = from c in qft
                           where c.Form == ft.Form
                           select c;
                if (qft2.Count() > 1) //colexification found!
                {
                    String s = "";
                    int ngood = 0;
                    List<string> concepticonlist = new List<string>();
                    foreach (FormTable ft2 in qft2)
                    {
                        s += "\t";
                        if (ft2.ParameterTable != null)
                        {
                            ngood++;
                            if (ft2.ParameterTable.Concepticon_ID != null)
                            {
                                if (!concepticonlist.Contains(ft2.ParameterTable.Concepticon_ID))
                                    concepticonlist.Add(ft2.ParameterTable.Concepticon_ID);
                                s += ft2.ParameterTable.Concepticon_ID;
                            }
                        }
                    }
                    if (concepticonlist.Count < 2)
                        continue;
                    memo("Colex found!\t" + ft.Value + "\t" + ft.Form +"\t"+ s);
                    //foreach (char c in ft.Form.ToCharArray())
                    //    memo(c + "\t" + ((int)c).ToString());
                    n++;
                    //if (n > 3)
                    //    break;
                    ColexTable ct = new ColexTable();
                    ct.ID = ctid;
                    ctid++;
                    ct.Language = lt2.ID;//GetLanguageID2(ft.LanguageTable);
                    ct.Value = ft.Form;
                    db.ColexTable.InsertOnSubmit(ct);
                    db.SubmitChanges();
                    donevalues.Add(ft.Form);

                    concepticonlist.Clear();

                    foreach (FormTable ft2 in qft2)
                    {
                        if (ft2.ParameterTable == null)
                            continue;
                        if (concepticonlist.Contains(ft2.ParameterTable.Concepticon_ID))
                            continue; //only add each type once, even if it has two form entries
                        concepticonlist.Add(ft2.ParameterTable.Concepticon_ID);

                        ColexForm cf = new ColexForm();
                        cf.ID = cfid;
                        cfid++;
                        cf.Colex = ct.ID;
                        cf.Concepticon = GetConcepticonID(ft2.ParameterTable);
                        cf.Form = ft2.ID;
                        cf.FormDataset = ft2.Dataset_ID;
                        db.ColexForm.InsertOnSubmit(cf);
                        db.SubmitChanges();
                    }
                }
            }

            memo("====================================");
            memo("   Done " + lt2.Name);
            memo("====================================");

        }

        private void FindcolexButton_Click(object sender, EventArgs e)
        {
            int ntot = db.LanguageTable2.Count();
            int n = 0;

            foreach (LanguageTable2 lt2 in db.LanguageTable2)
            {
                string lang = lt2.Name;
                //string lang_dataset = "";
                Findcolexbylang(lt2);
                n++;
                memo(n + " of " + ntot);
            }
        }

        private void Langtab2button_Click(object sender, EventArgs e)
        {
            Dictionary<string, LanguageTable2> lt2dict = new Dictionary<string, LanguageTable2>();

            int lt2id = 1;

            foreach (LanguageTable lt in db.LanguageTable)
            {
                string key = lt.Name;
                if (lt.Glottocode != null)
                    key = lt.Glottocode;
                if (!lt2dict.ContainsKey(key))
                {
                    lt2dict.Add(key, new LanguageTable2());
                    lt2dict[key].Name = lt.Name;
                    lt2dict[key].ID = lt2id;
                    lt2id++;
                }

                if (lt.ISO639P3code != null)
                    lt2dict[key].Iso = lt.ISO639P3code;

                if (lt.Glottocode != null)
                    lt2dict[key].Glottocode = lt.Glottocode;
                if (lt.Macroarea != null)
                    lt2dict[key].Macroarea = lt.Macroarea;
                if (lt.Latitude != null)
                    lt2dict[key].Latitude = lt.Latitude;
                if (lt.Longitude != null)
                    lt2dict[key].Longitude = lt.Longitude;
                if (lt.Family != null)
                    lt2dict[key].Family = lt.Family;

            }

            foreach (string s in lt2dict.Keys)
                db.LanguageTable2.InsertOnSubmit(lt2dict[s]);
            db.SubmitChanges();
        }

        private void DeleteColexButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Really delete everything from the colex part of the database?", "Clear database?", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
                return;
            db.LinkLanguage.DeleteAllOnSubmit(from c in db.LinkLanguage select c);
            db.SubmitChanges();
            db.ConcepticonLink.DeleteAllOnSubmit(from c in db.ConcepticonLink select c);
            db.SubmitChanges();
            db.ColexForm.DeleteAllOnSubmit(from c in db.ColexForm select c);
            db.SubmitChanges();
            db.ColexTable.DeleteAllOnSubmit(from c in db.ColexTable select c);
            db.SubmitChanges();

        }

        private void Fixletterbutton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> fixdict = new Dictionary<string, string>();
            fixdict.Add("a°", "å");
            fixdict.Add("a¨", "ä");
            fixdict.Add("o¨", "ö");
            fixdict.Add("u¨", "ü");

            foreach (string orig in fixdict.Keys)
            {
                var q = from c in db.FormTable
                        where c.Value.Contains(orig)
                        select c;
                memo(orig + ": " + q.Count());
                foreach (FormTable ft in q)
                    ft.Value = ft.Value.Replace(orig, fixdict[orig]);
                db.SubmitChanges();
            }
        }

        private void BuildConceptbutton_Click(object sender, EventArgs e)
        {
            //Dictionary representing a sparse matrix of concepticon x concepticon, 
            //with a list of languages for each cell.
            Dictionary<int, Dictionary<int, List<int>>> linkdict = new Dictionary<int, Dictionary<int, List<int>>>();

            Dictionary<string, Dictionary<string, int>> semanticsdict = new Dictionary<string, Dictionary<string, int>>();

            bool doall = true;
            string sem = "";
            if (LB_semantics.SelectedItem != null)
            {
                sem = LB_semantics.SelectedItem.ToString();
                memo("Selected field: " + sem);
                doall = (sem == "--all--");
            }

            memo(DateTime.Now.ToShortTimeString());
            foreach (string s1 in semanticlist)
            {
                semanticsdict.Add(s1, new Dictionary<string, int>());
                foreach (string s2 in semanticlist)
                    semanticsdict[s1].Add(s2, 0);
            }

            int n = 0;
            foreach (ColexTable ct in db.ColexTable)
            {
                var qcf = (from c in db.ColexForm
                           where c.Colex == ct.ID
                           select c).OrderBy(c => c.Concepticon);
                foreach (ColexForm cf1 in qcf)
                    foreach (ColexForm cf2 in qcf)
                    {
                        if (cf1.Concepticon > cf2.Concepticon)
                        {
                            int c1 = cf1.Concepticon;
                            int c2 = cf2.Concepticon;
                            semanticsdict[ConcepticonSemantics[c1]][ConcepticonSemantics[c2]]++;
                            if (!linkdict.ContainsKey(c1))
                            {
                                linkdict.Add(c1, new Dictionary<int, List<int>>());
                            }
                            if (!linkdict[c1].ContainsKey(c2))
                            {
                                linkdict[c1].Add(c2, new List<int>());
                            }
                            linkdict[c1][c2].Add(ct.Language);
                        }
                    }

                n++;
                //if (n > 1000)
                //    break;
                if (n % 1000 == 0)
                    memo(n.ToString());
                        
            }

            memo(DateTime.Now.ToShortTimeString());

            StringBuilder sbtop = new StringBuilder("");
            foreach (string s2 in semanticlist)
            {
                sbtop.Append("\t" + s2);
            }
            memo(sbtop.ToString());

            foreach (string s1 in semanticlist)
            {
                StringBuilder sb = new StringBuilder(s1);
                foreach (string s2 in semanticlist)
                {
                    sb.Append("\t"+semanticsdict[s1][s2].ToString());
                }
                memo(sb.ToString());
            }


            int clid = (from c in db.ConcepticonLink select c).Count() + 1;
            int llid = (from c in db.LinkLanguage select c).Count() + 1;

            n = 0;
            memo("linkdict " + linkdict.Count);

            foreach (int c1 in linkdict.Keys)
            {
                foreach (int c2 in linkdict[c1].Keys)
                {
                    //string s = c1 + "\t" + c2;
                    //foreach (int ll in linkdict[c1][c2])
                    //    s += "\t" + ll;
                    //memo(s);
                    ConcepticonLink cl = new ConcepticonLink();
                    cl.ID = clid;
                    clid++;
                    cl.Concepticon1 = c1;
                    cl.Concepticon2 = c2;
                    cl.Strength = linkdict[c1][c2].Count;
                    db.ConcepticonLink.InsertOnSubmit(cl);
                    db.SubmitChanges();

                    foreach (int lang in linkdict[c1][c2])
                    {
                        LinkLanguage ll = new LinkLanguage();
                        ll.ID = llid;
                        llid++;
                        ll.ConcepticonLink = cl.ID;
                        ll.Language = lang;
                        db.LinkLanguage.InsertOnSubmit(ll);
                    }
                    db.SubmitChanges();
                }
                n++;
                if (n % 1000 == 0)
                    memo(n.ToString());
            }


            memo("====================================");
            memo("   Done building concept links");
            memo(DateTime.Now.ToShortTimeString());
            memo("====================================");

        }

        private void ClearCLICSbutton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Really delete everything from the CLIC3 part of the database?", "Clear database?", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
                return;
            db.ValueSource.DeleteAllOnSubmit(from c in db.ValueSource select c);
            db.SubmitChanges();
            db.ValueTable.DeleteAllOnSubmit(from c in db.ValueTable select c);
            db.SubmitChanges();
            db.CognateSource.DeleteAllOnSubmit(from c in db.CognateSource select c);
            db.SubmitChanges();
            db.CognateTable.DeleteAllOnSubmit(from c in db.CognateTable select c);
            db.SubmitChanges();
            db.FormSource.DeleteAllOnSubmit(from c in db.FormSource select c);
            db.SubmitChanges();
            db.FormTable.DeleteAllOnSubmit(from c in db.FormTable select c);
            db.SubmitChanges();
            db.SourceTable.DeleteAllOnSubmit(from c in db.SourceTable select c);
            db.SubmitChanges();
            db.ParameterTable.DeleteAllOnSubmit(from c in db.ParameterTable select c);
            db.SubmitChanges();
            db.Datasetmeta.DeleteAllOnSubmit(from c in db.Datasetmeta select c);
            db.SubmitChanges();
            db.Dataset.DeleteAllOnSubmit(from c in db.Dataset select c);
            db.SubmitChanges();
            db.LanguageTable.DeleteAllOnSubmit(from c in db.LanguageTable select c);
            db.SubmitChanges();

        }

        private void ColexStatButton_Click(object sender, EventArgs e)
        {
            StringBuilder sbtop = new StringBuilder("");
            foreach (string s2 in semanticlist)
            {
                sbtop.Append("\t" + s2);
            }
            memo(sbtop.ToString());

            foreach (string s1 in semanticlist)
            {
                StringBuilder sb = new StringBuilder(s1);
                foreach (string s2 in semanticlist)
                {
                    var q = from c in db.ConcepticonLink
                            where c.ConcepticonTable.Semantic_Field == s1
                            where c.Concepticon2ConcepticonTable.Semantic_Field == s2
                            select c;
                    sb.Append("\t"+q.Count().ToString());
                }
                memo(sb.ToString());
            }
        }

        private void Findmaxbutton_Click(object sender, EventArgs e)
        {
            if (CB_random.Checked)
            {
                var q = from c in db.RandomwalkLink
                        orderby c.Strength descending
                        select c;

                int n = 0;
                int nmax = 100;

                foreach (RandomwalkLink cl in q)
                {
                    string c1 = cl.ConcepticonTable.Concepticon_Gloss;
                    string c2 = cl.Concepticon2ConcepticonTable.Concepticon_Gloss;

                    memo(c1 + "\t" + c2 + "\t" + (double)cl.Strength/cl.Walks);

                    n++;
                    if (n > nmax)
                        break;
                }

            }
            else
            {
                var q = from c in db.ConcepticonLink
                        orderby c.Strength descending
                        select c;

                int n = 0;
                int nmax = 100;

                foreach (ConcepticonLink cl in q)
                {
                    string c1 = cl.ConcepticonTable.Concepticon_Gloss;
                    string c2 = cl.Concepticon2ConcepticonTable.Concepticon_Gloss;

                    memo(c1 + "\t" + c2 + "\t" + cl.Strength);

                    n++;
                    if (n > nmax)
                        break;
                }
            }
                    
        }

        public static string unusedfilename(string fn0)
        {
            int n = 1;
            string fn = fn0;
            while (File.Exists(fn))
            {
                fn = fn0.Replace(".", n.ToString() + ".");
                n++;
            }
            return fn;
        }

        public static string initialcap(string orig)
        {
            if (String.IsNullOrEmpty(orig))
                return "";

            int initialpos = 0;
            if (orig.IndexOf("[[") == 0)
            {
                if ((orig.IndexOf('|') > 0) && (orig.IndexOf('|') < orig.IndexOf(']')))
                    initialpos = orig.IndexOf('|') + 1;
                else
                    initialpos = 2;
            }
            string s = orig.Substring(initialpos, 1);
            s = s.ToUpper();
            string final = orig.ToLower();
            final = final.Remove(initialpos, 1).Insert(initialpos, s);
            //s += orig.Remove(0, 1);
            return final;
        }



        private void GEPHIbutton_Click(object sender, EventArgs e)
        {
            if (LB_semantics.SelectedItem == null)
            {
                memo("No semantic field selected!");
                return;
            }
            string sem = LB_semantics.SelectedItem.ToString();
            memo(sem);

            string fam = "";
            if (LB_family.SelectedItem != null && LB_family.SelectedItem.ToString() != "--all--")
                fam = LB_family.SelectedItem.ToString();

            List<int> conlist = new List<int>();
            string fran = "";
            if (CB_random.Checked)
            {
                fran = "Randomwalk";
                if (!String.IsNullOrEmpty(fam))
                    memo("Family not supported with random walk data");
                fam = "";
            }
            string fn2 = unusedfilename(folder + sem + fran+fam + @"_edges.csv");
            memo(fn2);
            using (StreamWriter sw = new StreamWriter(fn2))
            {

                sw.WriteLine("Source;Target;Weight");

                if (CB_random.Checked)
                {
                    var q = from c in db.RandomwalkLink
                            where c.ConcepticonTable.Semantic_Field == sem
                            where c.Concepticon2ConcepticonTable.Semantic_Field == sem
                            select c;
                    foreach (RandomwalkLink cl in q)
                    {
                        bool written = false;
                        if (fam == "")
                        {
                            sw.WriteLine(cl.Concepticon1 + ";" + cl.Concepticon2 + ";" + (10*(double)cl.Strength/cl.Walks).ToString().Replace(",","."));
                            written = true;
                        }
                        if (written)
                        {
                            if (!conlist.Contains(cl.Concepticon1))
                                conlist.Add(cl.Concepticon1);
                            if (!conlist.Contains(cl.Concepticon2))
                                conlist.Add(cl.Concepticon2);
                        }
                    }
                }
                else
                {
                    var q = from c in db.ConcepticonLink
                            where c.ConcepticonTable.Semantic_Field == sem
                            where c.Concepticon2ConcepticonTable.Semantic_Field == sem
                            select c;
                    foreach (ConcepticonLink cl in q)
                    {
                        bool written = false;
                        if (fam == "")
                        {
                            sw.WriteLine(cl.Concepticon1 + ";" + cl.Concepticon2 + ";" + cl.Strength);
                            written = true;
                        }
                        else
                        {

                            int famstrength = (from c in cl.LinkLanguage
                                               where c.LanguageTable2 != null
                                               where c.LanguageTable2.Family == fam
                                               select c).Count();
                            if (famstrength > 0)
                            {
                                sw.WriteLine(cl.Concepticon1 + ";" + cl.Concepticon2 + ";" + famstrength);
                                written = true;
                            }
                        }
                        if (written)
                        {
                            if (!conlist.Contains(cl.Concepticon1))
                                conlist.Add(cl.Concepticon1);
                            if (!conlist.Contains(cl.Concepticon2))
                                conlist.Add(cl.Concepticon2);
                        }
                    }

                }
            }
            string fn = unusedfilename(folder + sem + fam + @"_nodes.csv");
            memo(fn);
            using (StreamWriter sw = new StreamWriter(fn))
            {

                sw.WriteLine("Id;Label;Color");

                //List<int> dummy = authordict.Keys.ToList();

                var q = from c in db.ConcepticonTable
                        where c.Semantic_Field == sem
                        select c;

                foreach (ConcepticonTable ct in q)
                {
                    if (conlist.Contains(ct.ID))
                        sw.WriteLine(ct.ID + ";" + initialcap(ct.Concepticon_Gloss) + ";#FF0000");
                }

            }
            memo("====================================");
            memo("   Done writing GEPHI files");
            memo("====================================");

        }

        private void WeirdEnglishbutton_Click(object sender, EventArgs e)
        {
            string lang = "English";
            var q1 = from c in db.LinkLanguage
                    where c.LanguageTable2.Name == lang
                    select c;

            memo(q1.Count() + " "+lang+" colexifications");

            memo("Unusual colexifications in " + lang+":");
            foreach (LinkLanguage ll in q1)
            {
                if (ll.ConcepticonLinkConcepticonLink.Strength == 1)
                {
                    ConcepticonTable ct1 = ll.ConcepticonLinkConcepticonLink.ConcepticonTable;
                    ConcepticonTable ct2 = ll.ConcepticonLinkConcepticonLink.Concepticon2ConcepticonTable;
                    string s1 = "";
                    var qff1 = from c in ct1.ColexForm
                              where c.FormTable.LanguageTable.Name == lang
                              select c;
                    if (qff1.Count() > 0)
                        s1 = qff1.First().FormTable.Value;
                    memo("Unique colex:\t" + s1 + "\t"+ ll.ConcepticonLinkConcepticonLink.ConcepticonTable.Concepticon_Gloss + "\t" + ll.ConcepticonLinkConcepticonLink.Concepticon2ConcepticonTable.Concepticon_Gloss);
                }
            }

            var q = from c in db.ConcepticonLink
                    orderby c.Strength descending
                    select c;

            int n = 0;
            int nmax = 100;

            foreach (ConcepticonLink cl in q)
            {
                string c1 = cl.ConcepticonTable.Concepticon_Gloss;
                string c2 = cl.Concepticon2ConcepticonTable.Concepticon_Gloss;

                var qe = from c in cl.LinkLanguage where c.LanguageTable2.Name == lang select c;
                if (qe.Count() > 0)
                    continue;

                memo(c1 + "\t" + c2 + "\t" + cl.Strength);

                n++;
                if (n > nmax)
                    break;
            }

        }



        public static bool is_latin(string name)
        {
            return (get_alphabet(name) == "latin");
        }

        public static string get_alphabet(string name)
        {
            char[] letters = name.ToCharArray();
            //char[] letters = remove_disambig(name).ToCharArray();
            int n = 0;
            int sum = 0;
            //int nlatin = 0;
            Dictionary<string, int> alphdir = new Dictionary<string, int>();
            foreach (char c in letters)
            {
                int uc = Convert.ToInt32(c);
                sum += uc;
                string alphabet = "none";
                if (uc <= 0x0040) alphabet = "none";
                //else if ((uc >= 0x0030) && (uc <= 0x0039)) alphabet = "number";
                //else if ((uc >= 0x0020) && (uc <= 0x0040)) alphabet = "punctuation";
                else if ((uc >= 0x0041) && (uc <= 0x007F)) alphabet = "latin";
                else if ((uc >= 0x00A0) && (uc <= 0x00FF)) alphabet = "latin";
                else if ((uc >= 0x0100) && (uc <= 0x017F)) alphabet = "latin";
                else if ((uc >= 0x0180) && (uc <= 0x024F)) alphabet = "latin";
                else if ((uc >= 0x0250) && (uc <= 0x02AF)) alphabet = "phonetic";
                else if ((uc >= 0x02B0) && (uc <= 0x02FF)) alphabet = "spacing modifier letters";
                else if ((uc >= 0x0300) && (uc <= 0x036F)) alphabet = "combining diacritical marks";
                else if ((uc >= 0x0370) && (uc <= 0x03FF)) alphabet = "greek and coptic";
                else if ((uc >= 0x0400) && (uc <= 0x04FF)) alphabet = "cyrillic";
                else if ((uc >= 0x0500) && (uc <= 0x052F)) alphabet = "cyrillic";
                else if ((uc >= 0x0530) && (uc <= 0x058F)) alphabet = "armenian";
                else if ((uc >= 0x0590) && (uc <= 0x05FF)) alphabet = "hebrew";
                else if ((uc >= 0x0600) && (uc <= 0x06FF)) alphabet = "arabic";
                else if ((uc >= 0x0700) && (uc <= 0x074F)) alphabet = "syriac";
                else if ((uc >= 0x0780) && (uc <= 0x07BF)) alphabet = "thaana";
                else if ((uc >= 0x0900) && (uc <= 0x097F)) alphabet = "devanagari";
                else if ((uc >= 0x0980) && (uc <= 0x09FF)) alphabet = "bengali";
                else if ((uc >= 0x0A00) && (uc <= 0x0A7F)) alphabet = "gurmukhi";
                else if ((uc >= 0x0A80) && (uc <= 0x0AFF)) alphabet = "gujarati";
                else if ((uc >= 0x0B00) && (uc <= 0x0B7F)) alphabet = "oriya";
                else if ((uc >= 0x0B80) && (uc <= 0x0BFF)) alphabet = "tamil";
                else if ((uc >= 0x0C00) && (uc <= 0x0C7F)) alphabet = "telugu";
                else if ((uc >= 0x0C80) && (uc <= 0x0CFF)) alphabet = "kannada";
                else if ((uc >= 0x0D00) && (uc <= 0x0D7F)) alphabet = "malayalam";
                else if ((uc >= 0x0D80) && (uc <= 0x0DFF)) alphabet = "sinhala";
                else if ((uc >= 0x0E00) && (uc <= 0x0E7F)) alphabet = "thai";
                else if ((uc >= 0x0E80) && (uc <= 0x0EFF)) alphabet = "lao";
                else if ((uc >= 0x0F00) && (uc <= 0x0FFF)) alphabet = "tibetan";
                else if ((uc >= 0x1000) && (uc <= 0x109F)) alphabet = "myanmar";
                else if ((uc >= 0x10A0) && (uc <= 0x10FF)) alphabet = "georgian";
                else if ((uc >= 0x1100) && (uc <= 0x11FF)) alphabet = "korean";
                else if ((uc >= 0x1200) && (uc <= 0x137F)) alphabet = "ethiopic";
                else if ((uc >= 0x13A0) && (uc <= 0x13FF)) alphabet = "cherokee";
                else if ((uc >= 0x1400) && (uc <= 0x167F)) alphabet = "unified canadian aboriginal syllabics";
                else if ((uc >= 0x1680) && (uc <= 0x169F)) alphabet = "ogham";
                else if ((uc >= 0x16A0) && (uc <= 0x16FF)) alphabet = "runic";
                else if ((uc >= 0x1700) && (uc <= 0x171F)) alphabet = "tagalog";
                else if ((uc >= 0x1720) && (uc <= 0x173F)) alphabet = "hanunoo";
                else if ((uc >= 0x1740) && (uc <= 0x175F)) alphabet = "buhid";
                else if ((uc >= 0x1760) && (uc <= 0x177F)) alphabet = "tagbanwa";
                else if ((uc >= 0x1780) && (uc <= 0x17FF)) alphabet = "khmer";
                else if ((uc >= 0x1800) && (uc <= 0x18AF)) alphabet = "mongolian";
                else if ((uc >= 0x1900) && (uc <= 0x194F)) alphabet = "limbu";
                else if ((uc >= 0x1950) && (uc <= 0x197F)) alphabet = "tai le";
                else if ((uc >= 0x19E0) && (uc <= 0x19FF)) alphabet = "khmer";
                else if ((uc >= 0x1D00) && (uc <= 0x1D7F)) alphabet = "phonetic";
                else if ((uc >= 0x1E00) && (uc <= 0x1EFF)) alphabet = "latin";
                else if ((uc >= 0x1F00) && (uc <= 0x1FFF)) alphabet = "greek and coptic";
                else if ((uc >= 0x2000) && (uc <= 0x206F)) alphabet = "none";
                else if ((uc >= 0x2070) && (uc <= 0x209F)) alphabet = "none";
                else if ((uc >= 0x20A0) && (uc <= 0x20CF)) alphabet = "none";
                else if ((uc >= 0x20D0) && (uc <= 0x20FF)) alphabet = "combining diacritical marks for symbols";
                else if ((uc >= 0x2100) && (uc <= 0x214F)) alphabet = "letterlike symbols";
                else if ((uc >= 0x2150) && (uc <= 0x218F)) alphabet = "none";
                else if ((uc >= 0x2190) && (uc <= 0x21FF)) alphabet = "none";
                else if ((uc >= 0x2200) && (uc <= 0x22FF)) alphabet = "none";
                else if ((uc >= 0x2300) && (uc <= 0x23FF)) alphabet = "none";
                else if ((uc >= 0x2400) && (uc <= 0x243F)) alphabet = "none";
                else if ((uc >= 0x2440) && (uc <= 0x245F)) alphabet = "optical character recognition";
                else if ((uc >= 0x2460) && (uc <= 0x24FF)) alphabet = "enclosed alphanumerics";
                else if ((uc >= 0x2500) && (uc <= 0x257F)) alphabet = "none";
                else if ((uc >= 0x2580) && (uc <= 0x259F)) alphabet = "none";
                else if ((uc >= 0x25A0) && (uc <= 0x25FF)) alphabet = "none";
                else if ((uc >= 0x2600) && (uc <= 0x26FF)) alphabet = "none";
                else if ((uc >= 0x2700) && (uc <= 0x27BF)) alphabet = "none";
                else if ((uc >= 0x27C0) && (uc <= 0x27EF)) alphabet = "none";
                else if ((uc >= 0x27F0) && (uc <= 0x27FF)) alphabet = "none";
                else if ((uc >= 0x2800) && (uc <= 0x28FF)) alphabet = "braille";
                else if ((uc >= 0x2900) && (uc <= 0x297F)) alphabet = "none";
                else if ((uc >= 0x2980) && (uc <= 0x29FF)) alphabet = "none";
                else if ((uc >= 0x2A00) && (uc <= 0x2AFF)) alphabet = "none";
                else if ((uc >= 0x2B00) && (uc <= 0x2BFF)) alphabet = "none";
                else if ((uc >= 0x2E80) && (uc <= 0x2EFF)) alphabet = "chinese/japanese";
                else if ((uc >= 0x2F00) && (uc <= 0x2FDF)) alphabet = "chinese/japanese";
                else if ((uc >= 0x2FF0) && (uc <= 0x2FFF)) alphabet = "none";
                else if ((uc >= 0x3000) && (uc <= 0x303F)) alphabet = "chinese/japanese";
                else if ((uc >= 0x3040) && (uc <= 0x309F)) alphabet = "chinese/japanese";
                else if ((uc >= 0x30A0) && (uc <= 0x30FF)) alphabet = "chinese/japanese";
                else if ((uc >= 0x3100) && (uc <= 0x312F)) alphabet = "bopomofo";
                else if ((uc >= 0x3130) && (uc <= 0x318F)) alphabet = "korean";
                else if ((uc >= 0x3190) && (uc <= 0x319F)) alphabet = "chinese/japanese";
                else if ((uc >= 0x31A0) && (uc <= 0x31BF)) alphabet = "bopomofo";
                else if ((uc >= 0x31F0) && (uc <= 0x31FF)) alphabet = "chinese/japanese";
                else if ((uc >= 0x3200) && (uc <= 0x32FF)) alphabet = "chinese/japanese";
                else if ((uc >= 0x3300) && (uc <= 0x33FF)) alphabet = "chinese/japanese";
                else if ((uc >= 0x3400) && (uc <= 0x4DBF)) alphabet = "chinese/japanese";
                else if ((uc >= 0x4DC0) && (uc <= 0x4DFF)) alphabet = "none";
                else if ((uc >= 0x4E00) && (uc <= 0x9FFF)) alphabet = "chinese/japanese";
                else if ((uc >= 0xA000) && (uc <= 0xA48F)) alphabet = "chinese/japanese";
                else if ((uc >= 0xA490) && (uc <= 0xA4CF)) alphabet = "chinese/japanese";
                else if ((uc >= 0xAC00) && (uc <= 0xD7AF)) alphabet = "korean";
                else if ((uc >= 0xD800) && (uc <= 0xDB7F)) alphabet = "high surrogates";
                else if ((uc >= 0xDB80) && (uc <= 0xDBFF)) alphabet = "high private use surrogates";
                else if ((uc >= 0xDC00) && (uc <= 0xDFFF)) alphabet = "low surrogates";
                else if ((uc >= 0xE000) && (uc <= 0xF8FF)) alphabet = "private use area";
                else if ((uc >= 0xF900) && (uc <= 0xFAFF)) alphabet = "chinese/japanese";
                else if ((uc >= 0xFB00) && (uc <= 0xFB4F)) alphabet = "alphabetic presentation forms";
                else if ((uc >= 0xFB50) && (uc <= 0xFDFF)) alphabet = "arabic";
                else if ((uc >= 0xFE00) && (uc <= 0xFE0F)) alphabet = "variation selectors";
                else if ((uc >= 0xFE20) && (uc <= 0xFE2F)) alphabet = "combining half marks";
                else if ((uc >= 0xFE30) && (uc <= 0xFE4F)) alphabet = "chinese/japanese";
                else if ((uc >= 0xFE50) && (uc <= 0xFE6F)) alphabet = "small form variants";
                else if ((uc >= 0xFE70) && (uc <= 0xFEFF)) alphabet = "arabic";
                else if ((uc >= 0xFF00) && (uc <= 0xFFEF)) alphabet = "halfwidth and fullwidth forms";
                else if ((uc >= 0xFFF0) && (uc <= 0xFFFF)) alphabet = "specials";
                else if ((uc >= 0x10000) && (uc <= 0x1007F)) alphabet = "linear b";
                else if ((uc >= 0x10080) && (uc <= 0x100FF)) alphabet = "linear b";
                else if ((uc >= 0x10100) && (uc <= 0x1013F)) alphabet = "aegean numbers";
                else if ((uc >= 0x10300) && (uc <= 0x1032F)) alphabet = "old italic";
                else if ((uc >= 0x10330) && (uc <= 0x1034F)) alphabet = "gothic";
                else if ((uc >= 0x10380) && (uc <= 0x1039F)) alphabet = "ugaritic";
                else if ((uc >= 0x10400) && (uc <= 0x1044F)) alphabet = "deseret";
                else if ((uc >= 0x10450) && (uc <= 0x1047F)) alphabet = "shavian";
                else if ((uc >= 0x10480) && (uc <= 0x104AF)) alphabet = "osmanya";
                else if ((uc >= 0x10800) && (uc <= 0x1083F)) alphabet = "cypriot syllabary";
                else if ((uc >= 0x1D000) && (uc <= 0x1D0FF)) alphabet = "byzantine musical symbols";
                else if ((uc >= 0x1D100) && (uc <= 0x1D1FF)) alphabet = "musical symbols";
                else if ((uc >= 0x1D300) && (uc <= 0x1D35F)) alphabet = "tai xuan jing symbols";
                else if ((uc >= 0x1D400) && (uc <= 0x1D7FF)) alphabet = "none";
                else if ((uc >= 0x20000) && (uc <= 0x2A6DF)) alphabet = "chinese/japanese";
                else if ((uc >= 0x2F800) && (uc <= 0x2FA1F)) alphabet = "chinese/japanese";
                else if ((uc >= 0xE0000) && (uc <= 0xE007F)) alphabet = "none";

                bool ucprint = false;
                if (alphabet != "none")
                {
                    n++;
                    if (!alphdir.ContainsKey(alphabet))
                        alphdir.Add(alphabet, 0);
                    alphdir[alphabet]++;
                }
                else if (uc != 0x0020)
                {
                    //Console.Write("c=" + c.ToString() + ", uc=0x" + uc.ToString("x5") + "|");
                    //ucprint = true;
                }
                if (ucprint)
                    Console.WriteLine();
            }

            int nmax = 0;
            string alphmax = "none";
            foreach (string alph in alphdir.Keys)
            {
                //Console.WriteLine("ga:" + alph + " " + alphdir[alph].ToString());
                if (alphdir[alph] > nmax)
                {
                    nmax = alphdir[alph];
                    alphmax = alph;
                }
            }

            if (letters.Length > 2 * n) //mostly non-alphabetic
                return "none";
            else if (nmax > n / 2) //mostly same alphabet
                return alphmax;
            else
                return "mixed"; //mixed alphabets
        }


        private void Countformbutton_Click(object sender, EventArgs e)
        {
            int n = 0;
            foreach (ConcepticonTable ct in db.ConcepticonTable)
            {
                var q = from c in db.ParameterTable
                        where c.Concepticon_ID == ct.Concepticon_ID
                        select c;
                int nf = 0;
                foreach (ParameterTable pt in q)
                {
                    nf += pt.FormTable.Count();
                }
                ct.Forms = nf;

                ct.Colexifications = ct.ColexForm.Count();

                n++;
                if (n % 100 == 0)
                    memo(n.ToString());
            }
            db.SubmitChanges();

        }

        Random rnd = new Random();

        private List<int> RandomWalk(ConcepticonTable ct, int steps)
        {
            //memo(steps + ": " + ct.Concepticon_Gloss);
            if (steps == 0)
                return new List<int>() { ct.ID };

            while ((rnd.Next((int)ct.Forms) > ct.Colexifications) && (steps > 0))
            {
                steps--;
            }
            if ( steps > 0)
            {
                int icf = rnd.Next((int)ct.ColexForm.Count());
                ColexForm cf = ct.ColexForm[icf];
                int ict = cf.ColexTable.ID;
                var qcf = from c in db.ColexForm
                          where c.Colex == ict
                          select c;
                if (qcf.Count() < 2)
                    memo("Something wrong with cf " + cf.ID+"; qcf = "+qcf.Count());
                else
                {
                    foreach (ColexForm cf2 in qcf)
                    {
                        if (cf2.ID == cf.ID)
                            continue;
                        List<int> ls = RandomWalk(cf2.ConcepticonTable, steps - 1);
                        ls.Add(ct.ID);
                        return ls;
                    }
                }
            }
            else
            {
                return new List<int>() { ct.ID };
            }

            return new List<int>();

        }

        private void Randombutton_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> conceptdict = new Dictionary<int, string>();
            foreach (ConcepticonTable ctt in db.ConcepticonTable)
                conceptdict.Add(ctt.ID, ctt.Concepticon_Gloss);

            //Dictionary<int, Dictionary<int, int>> linkdict = new Dictionary<int, Dictionary<int, int>>();

            int nstep = 20;
            int nwalk = 300;

            int rlid = 1;
            var qid = from c in db.RandomwalkLink select c.ID;
            if (qid.Count() > 0)
                rlid = qid.Max() + 1;

            int nct = 0;
            foreach (ConcepticonTable ct in db.ConcepticonTable)
            {
                if (ct.ColexForm.Count == 0)
                    continue;
                Dictionary<int, int> linkdict = new Dictionary<int, int>();
                nct++;
                //if (nct < 240)
                //    continue;
                //if (nct > 10)
                //    break;
                memo(nct+": "+ct.Concepticon_Gloss);
                //if (!linkdict.ContainsKey(ct.ID))
                //{
                //    linkdict.Add(ct.ID, new Dictionary<int, int>());
                //}

                DateTime oldtime = DateTime.Now;
                for (int iwalk = 0; iwalk < nwalk; iwalk++)
                {
                    List<int> clist = RandomWalk(ct, nstep);
                    foreach (int i in clist)
                    {
                        //if (iwalk % 100 == 0)
                        //    memo(i + ": " + conceptdict[i]);
                        if (!linkdict.ContainsKey(i))
                            linkdict.Add(i, 1);
                        else
                            linkdict[i]++;
                    }
                }
                memo("Elapsed time: "+(DateTime.Now-oldtime).ToString());
                memo("Links:" + linkdict.Count);
                //foreach (int j in linkdict[ct.ID].Keys)
                //    memo(conceptdict[j] + ": " + linkdict[ct.ID][j]);
                var q = from c in db.RandomwalkLink where c.Concepticon1 == ct.ID select c;
                foreach (int j in linkdict.Keys)
                {
                    if (j == ct.ID)
                        continue;
                    RandomwalkLink rl = (from c in q where c.Concepticon2 == j select c).FirstOrDefault();
                    if ( rl == null)
                    {
                        rl = new RandomwalkLink();
                        rl.ID = rlid;
                        rlid++;
                        rl.Concepticon1 = ct.ID;
                        rl.Concepticon2 = j;
                        rl.Strength = linkdict[j];
                        rl.Walks = nwalk;
                        db.RandomwalkLink.InsertOnSubmit(rl);
                    }
                    else
                    {
                        rl.Strength += linkdict[j];
                        rl.Walks += nwalk;
                    }
                }
                foreach (RandomwalkLink rl in ct.RandomwalkLink)
                {
                    if (!linkdict.ContainsKey(rl.Concepticon2))
                        rl.Walks += nwalk;
                }
                db.SubmitChanges();
                memo("Elapsed time (db): " + (DateTime.Now - oldtime).ToString());
                richTextBox1.Refresh();
            }

            memo("==============");
            memo("  DONE");
            memo("==============");
        }

        private void Walkcountbutton_Click(object sender, EventArgs e)
        {
            foreach (ConcepticonTable ct in db.ConcepticonTable)
            {
                if (ct.RandomwalkLink.Count() > 0)
                {
                    int? nmax = (from c in db.RandomwalkLink
                                where c.Concepticon1 == ct.ID
                                select c.Walks).Max();
                    if (nmax != null)
                    {
                        memo(nmax + ": " + ct.Concepticon_Gloss);
                        foreach (RandomwalkLink rl in ct.RandomwalkLink)
                        {
                            if (rl.Walks < nmax)
                                rl.Walks = (int)nmax;
                        }
                        db.SubmitChanges();
                    }
                }
            }
        }

        private Dictionary<char, string> cyrIPA = new Dictionary<char, string>();

        private void fill_cyrIPA()
        {
            cyrIPA.Add('а', "a");
            cyrIPA.Add('б', "b");
            cyrIPA.Add('в', "v");
            cyrIPA.Add('г', "g");
            cyrIPA.Add('д', "d");
            cyrIPA.Add('е', "e");
            cyrIPA.Add('ё', "yo");
            cyrIPA.Add('ж', "ʒ");
            cyrIPA.Add('з', "z");
            cyrIPA.Add('и', "i");
            cyrIPA.Add('й', "j");
            cyrIPA.Add('к', "k");
            cyrIPA.Add('л', "l");
            cyrIPA.Add('м', "m");
            cyrIPA.Add('н', "n");
            cyrIPA.Add('о', "o");
            cyrIPA.Add('п', "p");
            cyrIPA.Add('р', "r");
            cyrIPA.Add('с', "s");
            cyrIPA.Add('т', "t");
            cyrIPA.Add('у', "u");
            cyrIPA.Add('ф', "f");
            cyrIPA.Add('х', "χ");
            cyrIPA.Add('ц', "t͡s");
            cyrIPA.Add('ч', "ç");
            cyrIPA.Add('ш', "ʃ");
            cyrIPA.Add('щ', "ʃç");
            cyrIPA.Add('ъ', "j");
            cyrIPA.Add('ы', "ʏ");
            cyrIPA.Add('ь', "j");
            cyrIPA.Add('э', "e");
            cyrIPA.Add('ю', "yu");
            cyrIPA.Add('я', "ya");
            cyrIPA.Add('А', "A");
            cyrIPA.Add('Б', "B");
            cyrIPA.Add('В', "V");
            cyrIPA.Add('Г', "G");
            cyrIPA.Add('Д', "D");
            cyrIPA.Add('Е', "E");
            cyrIPA.Add('Ё', "Yo");
            cyrIPA.Add('Ж', "ʒ");
            cyrIPA.Add('З', "Z");
            cyrIPA.Add('И', "I");
            cyrIPA.Add('Й', "J");
            cyrIPA.Add('К', "K");
            cyrIPA.Add('Л', "L");
            cyrIPA.Add('М', "M");
            cyrIPA.Add('Н', "N");
            cyrIPA.Add('О', "O");
            cyrIPA.Add('П', "P");
            cyrIPA.Add('Р', "R");
            cyrIPA.Add('С', "S");
            cyrIPA.Add('Т', "T");
            cyrIPA.Add('У', "U");
            cyrIPA.Add('Ф', "F");
            cyrIPA.Add('Х', "H");
            cyrIPA.Add('Ц', "t͡s");
            cyrIPA.Add('Ч', "ç");
            cyrIPA.Add('Ш', "ʃ");
            cyrIPA.Add('Щ', "ʃç");
            cyrIPA.Add('Ъ', "J");
            cyrIPA.Add('Ы', "I");
            cyrIPA.Add('Ь', "J");
            cyrIPA.Add('Э', "E");
            cyrIPA.Add('Ю', "Yu");
            cyrIPA.Add('Я', "Ya");
        }

        private string cyrillic_to_phonetic(string s)
        {
            StringBuilder sb = new StringBuilder("");
            foreach (char c in s.ToCharArray())
                if (cyrIPA.ContainsKey(c))
                    sb.Append(cyrIPA[c]);
                else
                    sb.Append(c);
            return sb.ToString();
        }

        private Dictionary<string, int> alphabetdict = new Dictionary<string, int>();
        private Dictionary<char, int> characterdict = new Dictionary<char, int>();
        private Dictionary<string, List<string>> oddlangdict = new Dictionary<string, List<string>>();
        private void Findalphabetbylang(LanguageTable2 lt2)
        {
            memo("====== Language " + lt2.Name);

            IEnumerable<FormTable> qft;
            if (lt2.Glottocode != null)
                qft = from c in db.FormTable
                      where c.LanguageTable.Glottocode == lt2.Glottocode
                      select c;
            else
                qft = from c in db.FormTable
                      where c.LanguageTable.Name == lt2.Name
                      select c;

            Dictionary<string, int> langalphdict = new Dictionary<string, int>();
            int n = 0;
            int nmax = 9999;
            int nprintmax = 10;
            int nprint = 0;
            foreach (FormTable ft in qft)
            {
                string alph = get_alphabet(ft.Form);
                if (alph != "latin")
                {
                    nprint++;
                    if (nprint < nprintmax)
                        memo(alph + "\t" + ft.Form);
                    if (!langalphdict.ContainsKey(alph))
                        langalphdict.Add(alph, 1);
                    else
                        langalphdict[alph]++;
                }
                if (!alphabetdict.ContainsKey(alph))
                    alphabetdict.Add(alph, 1);
                else
                    alphabetdict[alph]++;
                foreach (char c in ft.Form.ToCharArray())
                {
                    if (!characterdict.ContainsKey(c))
                        characterdict.Add(c, 1);
                    else
                        characterdict[c]++;
                }
                n++;
                if (n >= nmax)
                    break;
            }

            if (langalphdict.Count > 0)
                if (langalphdict.Values.Max() > n / 4)
                {
                    foreach (KeyValuePair<string, int> kp in langalphdict)
                        if (kp.Value > n / 4)
                        {
                            if (!oddlangdict.ContainsKey(kp.Key))
                            {
                                oddlangdict.Add(kp.Key, new List<string>() { lt2.Name });
                            }
                            else
                            {
                                oddlangdict[kp.Key].Add(lt2.Name);
                            }
                        }
                }


            //memo("====================================");
            //memo("   Done " + lt2.Name);
            //memo("====================================");


        }

        private void Alphabetbutton_Click(object sender, EventArgs e)
        {
            int ntot = db.LanguageTable2.Count();
            int n = 0;

            foreach (LanguageTable2 lt2 in db.LanguageTable2)
            {
                string lang = lt2.Name;
                //string lang_dataset = "";
                Findalphabetbylang(lt2);
                n++;
                memo(n + " of " + ntot);
            }

            memo("==============================================");
            foreach (string alph in alphabetdict.Keys)
                memo(alph + "\t" + alphabetdict[alph]);
            foreach (char c in characterdict.Keys)
                memo(c + "\t" + (int)c + "\t" + characterdict[c]);
            foreach (string s in oddlangdict.Keys)
            {
                memo(s);
                foreach (string lang in oddlangdict[s])
                    memo("\t" + lang);
            }
        }

        private void LB_semantics_SelectedIndexChanged(object sender, EventArgs e)
        {
            LB_concepts.Items.Clear();
            LB_concepts.Items.Add(allstring);
            string sem = LB_semantics.SelectedItem.ToString();
            var q = from c in db.ConcepticonTable
                    where c.Semantic_Field == sem
                    select c.Concepticon_Gloss;
            foreach (string s in q)
                LB_concepts.Items.Add(s);
            
        }

        private void Formconceptbutton_Click(object sender, EventArgs e)
        {
            if (LB_concepts.SelectedItem == null)
            {
                memo("No concept selected");
                return;
            }

            string concept = LB_concepts.SelectedItem.ToString();
            var q = from c in db.FormTable
                    where c.ParameterTable.Concepticon_Gloss == concept
                    select c;

            memo(concept+": "+q.Count() + " forms");

            foreach (FormTable ft in q)
            {
                memo(ft.Form + "\t" + ft.LanguageTable.Name);
            }

            memo(q.Count() + " forms");
        }

        private void Cognatestatbutton_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> cognatesetdict = new Dictionary<string, int>();
            Dictionary<int?, int> doubtdict = new Dictionary<int?, int>();

            int n = 0;
            foreach (CognateTable ct in db.CognateTable)
            {
                if (ct.Doubt != null)
                {
                    if (!doubtdict.ContainsKey(ct.Doubt))
                        doubtdict.Add(ct.Doubt, 1);
                    else
                        doubtdict[ct.Doubt]++;
                }
                if (!cognatesetdict.ContainsKey(ct.Cognateset_ID))
                    cognatesetdict.Add(ct.Cognateset_ID, 1);
                else
                    cognatesetdict[ct.Cognateset_ID]++;
                n++;
                //if (n > 1000)
                //    break;
            }

            foreach (string s in cognatesetdict.Keys)
                memo(s + "\t" + cognatesetdict[s]);
            foreach (int? x in doubtdict.Keys)
                memo(x + "\t" + doubtdict[x]);


        }

        private void Distconceptbutton_Click(object sender, EventArgs e)
        {
            hbookclass samefamhist = new hbookclass("Same family");
            samefamhist.SetBins(0, 1, 20);
            hbookclass difffamhist = new hbookclass("Different family");
            difffamhist.SetBins(0, 1, 20);

            if (LB_concepts.SelectedItem == null)
            {
                memo("No concept selected");
                return;
            }

            string selectedconcept = LB_concepts.SelectedItem.ToString();

            List<string> conceptlist = new List<string>();
            if (selectedconcept == allstring)
            {
                foreach (string ss in LB_concepts.Items)
                    conceptlist.Add(ss);
            }
            else
            {
                conceptlist.Add(selectedconcept);

            }
            foreach (string concept in conceptlist)
            {

                //string[] codedforms = new string[q.Count()];
                //string[] formfamily = new string[q.Count()];
                //int ift = 0;
                //foreach (FormTable ft in q)
                //{
                //    codedforms[ift] = EncodeForm(ft);
                //    formfamily[ift] = ft.LanguageTable.Family;
                //    ift++;

                //}
                memo(DateTime.Now.ToString());
                if (CB_weighteddist.Checked)
                {
                    var q = from c in db.CodedFormTable
                            where c.ConcepticonTable.Concepticon_Gloss == concept
                            select c;
                    memo(q.Count() + " forms");

                    foreach (CodedFormTable cf1 in q)
                    {
                        if (String.IsNullOrEmpty(cf1.CodedForm))
                            continue;
                        foreach (CodedFormTable cf2 in q)
                        {
                            if (cf2.ID <= cf1.ID)
                                continue;
                            if (String.IsNullOrEmpty(cf2.CodedForm))
                                continue;
                            double dist = Levenshtein.WeightedDistance(cf1.CodedForm, cf2.CodedForm, segmentclass.segdistmatrix) / (double)(cf1.CodedForm.Length + cf2.CodedForm.Length);
                            if (Double.IsNaN(dist))
                                memo("IsNaN! " + cf1.CodedForm + "|||" + cf2.CodedForm + "|||");
                            if (cf1.Family == cf2.Family)
                                samefamhist.Add(dist);
                            else
                            {
                                difffamhist.Add(dist);
                            }
                        }
                    }
                }
                else
                {
                    var q = from c in db.FormTable
                            where c.ParameterTable.Concepticon_Gloss == concept
                            select c;
                    memo(concept + ": " + q.Count() + " forms");
                    List<string> donelist = new List<string>();

                    foreach (FormTable ft1 in q)
                    {
                        string form1 = cyrilliclist.Contains(ft1.LanguageTable.Name) ? ft1.AlternativeValue : ft1.Form;
                        if (form1 == null)
                            form1 = ft1.Clics_form;
                        //memo(ft1.Form + "\t" + ft1.LanguageTable.Name);

                        foreach (FormTable ft2 in q)
                        {
                            if (ft1.ID == ft2.ID)
                                continue;
                            if (donelist.Contains(ft2.ID))
                                continue;
                            string form2 = cyrilliclist.Contains(ft2.LanguageTable.Name) ? ft2.AlternativeValue : ft2.Form;
                            if (form2 == null)
                                form2 = ft2.Clics_form;
                            double dist = (double)Levenshtein.EditDistance(form1, form2) / (double)(form1.Length + form2.Length);
                            if (ft1.LanguageTable.Family == ft2.LanguageTable.Family)
                                samefamhist.Add(dist);
                            else
                            {
                                difffamhist.Add(dist);
                                if ( dist == 0)
                                {
                                    memo(ft1.Form + "\t" + ft1.LanguageTable.Name + "("+ft1.LanguageTable.Family+")\t"+ft2.LanguageTable.Name+ "(" + ft2.LanguageTable.Family + ")");
                                }
                            }
                        }
                        donelist.Add(ft1.ID);
                    }
                }
                memo(DateTime.Now.ToString());
            }
            memo(samefamhist.GetDHist());
            memo(difffamhist.GetDHist());
        }

        private string EncodeForm(FormTable ft)
        {
            return EncodeForm(ft.Segments);
        }

        private string EncodeForm(string segstring)
        {
            StringBuilder sb = new StringBuilder("");
            string[] segs = segstring.Split();
            foreach (string ss in segs)
            {
                string s = ss.Trim(new char[] { ' ', '?', '+', '_' });
                if (String.IsNullOrEmpty(s))
                    continue;
                var qk = from c in segmentlist where c.fullseg == s select c;
                if (qk.Count() > 0)
                {
                    int k = qk.First().segid;
                    sb.Append((char)k);
                }
            }
            return sb.ToString();

        }

        public string DecodeForm(string codedform, string gap)
        {
            StringBuilder sb = new StringBuilder("");

            foreach (char k in codedform.ToCharArray())
            {
                var qk = from c in segmentlist where c.segid == (int)k select c;
                if (qk.Count() > 0)
                {
                    sb.Append(qk.First().fullseg + gap);
                }
            }
            return sb.ToString();
        }



        private void Segmentbutton_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> segdict = new Dictionary<string, int>();

            int n = 0;
            int nmax = 99999999;

            foreach (FormTable ft in db.FormTable)
            {
                string[] segs = ft.Segments.Split();
                foreach (string ss in segs)
                {
                    string s = ss.Trim(new char[] { ' ', '?' ,'+','_'});
                    if (String.IsNullOrEmpty(s))
                        continue;
                    if (!segdict.ContainsKey(s))
                        segdict.Add(s, 1);
                    else
                        segdict[s]++;
                }
                n++;
                if (n > nmax)
                    break;
            }

            foreach (string s in segdict.Keys)
            {
                var q = from c in dbl.Sound where c.IPA == s select c;
                string dblok = "no";
                string sgood = s;
                if (q.Count() > 0)
                    dblok = q.First().Featurestring;
                else if (s.Contains("/"))
                {
                    foreach (string ss in s.Split('/'))
                    {
                        q = from c in dbl.Sound where c.IPA == ss select c;
                        if (q.Count() > 0)
                        {
                            dblok = q.First().Featurestring;
                            sgood = ss;
                            break;
                        }
                    }
                }
                memo(sgood + "\t" + s + "\t" + segdict[s] + "\t" + dblok);
            }
        }

        private void segtestbutton_Click(object sender, EventArgs e)
        {
            int segstart = 600;
            int segend = segstart+50;

            StringBuilder sbhead = new StringBuilder("");
            for (int i=segstart;i<=segend;i++)
            {
                segmentclass sg = (from c in segmentlist where c.segid == i select c).FirstOrDefault();
                string ss = (sg == null) ? "null" : sg.fullseg;
                sbhead.Append("\t" + ss);
            }
            memo(sbhead.ToString());

            for (int i = segstart; i <= segend; i++)
            {
                segmentclass sg = (from c in segmentlist where c.segid == i select c).FirstOrDefault();
                string si = (sg == null) ? "null" : sg.fullseg;
                StringBuilder sb = new StringBuilder(si);
                for (int j=segstart;j<=segend;j++)
                {
                    segmentclass sgj = (from c in segmentlist where c.segid == j select c).FirstOrDefault();
                    string sj = (sg == null) ? "null" : segmentclass.segdistmatrix[i,j].ToString();
                    sb.Append("\t" + sj);
                }
                memo(sb.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //var qq = from c in db.FormTable
            //         where c.ParameterTable == null
            //         select c;
            //foreach (FormTable ft in qq)
            //    memo(ft.Parameter_ID + " missing from ParameterTable");
            //return;
            int icf = 1;
            if (db.CodedFormTable.Count() > 0)
                icf = (from c in db.CodedFormTable select c.ID).Max() + 1;
            foreach (FormTable ft in db.FormTable)
            {
                CodedFormTable cf = new CodedFormTable();
                cf.ID = icf;
                icf++;
                cf.CodedForm = EncodeForm(ft);
                cf.Form = ft.ID;
                cf.FormDataset = ft.Dataset_ID;
                string concept = "";
                if (ft.ParameterTable == null)
                {
                    if (ft.Parameter_ID == "213_thesethings")
                        concept = "THIS";
                    else if (ft.Parameter_ID == "218_thosethings")
                        concept = "THIS";
                    else
                    {
                        memo(ft.Parameter_ID+" missing from ParameterTable");
                    }
                }
                else
                {
                    concept = ft.ParameterTable.Concepticon_Gloss;
                }
                if (!String.IsNullOrEmpty(concept))
                {
                    ConcepticonTable ct = (from c in db.ConcepticonTable where c.Concepticon_Gloss == concept select c).First();
                    cf.Concepticon = ct.ID;
                    cf.Semantic_Field = ct.Semantic_Field;
                    cf.Language = GetLanguageID2(ft.LanguageTable);
                    if (cf.Language >= 0)
                    {
                        cf.Family = ft.LanguageTable == null ? "" : ft.LanguageTable.Family;
                        db.CodedFormTable.InsertOnSubmit(cf);
                    }
                    else
                    {
                        memo("##Language "+ft.LanguageTable.Name+" not found!");
                    }
                }
                if (icf % 100 == 0)
                {
                    memo(icf.ToString());
                    db.SubmitChanges();
                }
            }
        }

        private void Randomstatbutton_Click(object sender, EventArgs e)
        {
            hbookclass rwhist = new hbookclass("Random walk probability distribution");
            rwhist.SetBins(0, 1, 100);

            int n = 0;
            foreach (RandomwalkLink rw in db.RandomwalkLink)
            {
                rwhist.Add((double)rw.Strength / rw.Walks);
                n++;
                //if (n > 100)
                //    break;
            }
            memo(rwhist.GetDHist());
        }

        private void numberbutton_Click(object sender, EventArgs e)
        {
            List<string> conceptlist = new List<string>() { "ONE", "TWO", "THREE", "FOUR", "FIVE" };
            List<int> swadeshlist = new List<int>() { 63, 88, 126, 116, 113 };

            int[] concepts = new int[5];
            for (int i=0;i<5;i++)
            {
                var q = from c in db.ConcepticonTable where c.Concepticon_Gloss == conceptlist[i] select c.ID;
                concepts[i] = q.First();
            }

            List<int> donelangs = new List<int>();

            foreach (LanguageTable2 lang in (from c in db.LanguageTable2 select c))
            {
                if (lang.Family == null)
                    lang.Family = lang.Name;
                string iso = "";
                if (!String.IsNullOrEmpty(lang.Iso))
                    iso = lang.Iso;
                string glotto = "";
                if (!String.IsNullOrEmpty(lang.Glottocode))
                    glotto = lang.Glottocode;
                StringBuilder sb = new StringBuilder(lang.Name + "\t" + lang.Family + "\t" + iso + "\t" + glotto + "\ts");
                string slat = "";
                string familystring = "\t";
                if (!string.IsNullOrEmpty(iso))
                {
                    Language ll = (from c in dbl.Language where c.Iso == iso select c).FirstOrDefault();
                    if (ll != null)
                    {
                        slat = "\t" + ll.Country + "\t" + ll.Region + "\t" + ll.Latitude + "\t" + ll.Longitude;
                        int? fn = ll.Family_near;
                        if (fn != null)
                        {
                            Family ffn = (from c in dbl.Family where c.Id == fn select c).First();
                            familystring = "\t" + ffn.Fullstring;
                        }
                    }

                }
                if (String.IsNullOrEmpty(slat))
                    slat = "\t\t\t\t";
                sb.Append(familystring + slat);

                int ifound = 0;
                for (int i = 0; i < 5; i++)
                {
                    var q = from c in db.CodedFormTable
                            where c.Language == lang.ID
                            where c.Concepticon == concepts[i]
                            select c;
                    bool found = false;
                    sb.Append("\t");

                    foreach (CodedFormTable cf in q)
                    {
                        if (!String.IsNullOrEmpty(cf.CodedForm))
                        {
                            if (found)
                                sb.Append("; ");
                            found = true;
                            sb.Append(DecodeForm(cf.CodedForm, ""));
                        }
                    }
                    if (found)
                        ifound++;
                }
                if (ifound > 2)
                {
                    memo(sb.ToString());
                    donelangs.Add(lang.ID);
                }
            }
            Dictionary<int, Dictionary<string, List<FormTable>>> qdict = new Dictionary<int, Dictionary<string, List<FormTable>>>();
            for (int i = 0; i < 5; i++)
                qdict.Add(i, new Dictionary<string, List<FormTable>>());
            memo("=========================================");
            foreach (LanguageTable2 lang in (from c in db.LanguageTable2 select c))
            {
                if (donelangs.Contains(lang.ID))
                    continue;
                if (lang.Family == null)
                    lang.Family = lang.Name;
                string iso = "";
                if (!String.IsNullOrEmpty(lang.Iso))
                    iso = lang.Iso;
                string glotto = "";
                if (!String.IsNullOrEmpty(lang.Glottocode))
                    glotto = lang.Glottocode;
                StringBuilder sb = new StringBuilder(lang.Name + "\t" + lang.Family + "\t" + iso + "\t" + glotto + "\tf");
                string slat = "";
                string familystring = "\t";
                if (!string.IsNullOrEmpty(iso))
                {
                    Language ll = (from c in dbl.Language where c.Iso == iso select c).FirstOrDefault();
                    if (ll != null)
                    {
                        slat = "\t" + ll.Country + "\t" + ll.Region + "\t" + ll.Latitude + "\t" + ll.Longitude;
                        int? fn = ll.Family_near;
                        if (fn != null)
                        {
                            Family ffn = (from c in dbl.Family where c.Id == fn select c).First();
                            familystring = "\t" + ffn.Fullstring;
                        }
                    }
                    
                }
                if (String.IsNullOrEmpty(slat))
                    slat = "\t\t\t\t";
                sb.Append(familystring+slat);

                int ifound = 0;
                for (int i = 0; i < 5; i++)
                {
                    List<FormTable> qf;
                    if (qdict[i].ContainsKey(lang.Family))
                        qf = qdict[i][lang.Family];
                    else
                    {
                        qf = (from c in db.FormTable
                             where c.ParameterTable.Concepticon_Gloss == conceptlist[i]
                             where c.LanguageTable.Family == lang.Family
                             select c).ToList();
                        qdict[i].Add(lang.Family, qf);
                    }
                    sb.Append("\t");
                    bool found = false;
                    int nf = 1;
                    foreach (FormTable ft in qf)
                    {
                        if (GetLanguageID2(ft.LanguageTable) != lang.ID)
                            continue;
                        if (nf > 1)
                            sb.Append(" ! ");
                        nf++;
                        string ss = ft.Value;
                        if (String.IsNullOrEmpty(ss))
                            ss = ft.Form;
                        else if (!String.IsNullOrEmpty(ft.Form) && ft.Form != ss)
                            ss += "; " + ft.Form;
                        if (!String.IsNullOrEmpty(ss))
                        {
                            found = true;
                            sb.Append(ss);
                            break;
                        }
                    }
                    if (found)
                        ifound++;
                }
                if (ifound > 2)
                {
                    memo(sb.ToString());
                    donelangs.Add(lang.ID);
                }

            }
            memo("==============Swadesh:===========================");

            foreach (LanguageTable2 lang in (from c in db.LanguageTable2 select c))
            {
                if (donelangs.Contains(lang.ID))
                    continue;
                if (lang.Family == null)
                    lang.Family = lang.Name;
                string iso = "";
                if (!String.IsNullOrEmpty(lang.Iso))
                    iso = lang.Iso;
                string glotto = "";
                if (!String.IsNullOrEmpty(lang.Glottocode))
                    glotto = lang.Glottocode;
                StringBuilder sb = new StringBuilder(lang.Name + "\t" + lang.Family + "\t" + iso + "\t" + glotto + "\tf");
                string slat = "";
                string familystring = "\t";
                if (!string.IsNullOrEmpty(iso))
                {
                    Language ll = (from c in dbl.Language where c.Iso == iso select c).FirstOrDefault();
                    if (ll != null)
                    {
                        slat = "\t" + ll.Country + "\t" + ll.Region + "\t" + ll.Latitude + "\t" + ll.Longitude;
                        int? fn = ll.Family_near;
                        if (fn != null)
                        {
                            Family ffn = (from c in dbl.Family where c.Id == fn select c).First();
                            familystring = "\t" + ffn.Fullstring;
                        }
                    }

                }
                if (String.IsNullOrEmpty(slat))
                    slat = "\t\t\t\t";
                sb.Append(familystring + slat);

                int ifound = 0;
                for (int i = 0; i < 5; i++)
                {
                    var q = from c in dbl.Swadesh_language
                            where c.Term == swadeshlist[i]
                            where c.Language == iso
                            select c;
                    Swadesh_language sl = q.FirstOrDefault();
                    if (sl == null)
                        continue;
                    sb.Append("\t" + sl.Name);
                    ifound++;
                }
                if (ifound > 2)
                {
                    memo(sb.ToString());
                    donelangs.Add(lang.ID);
                }

            }

            memo("================= DONE ========================");
        }

        private void show_cogclasses(Dictionary<int, List<int>> cc, List<wordclass> wl, Dictionary<int,int> truecogdict, hbookclass truesplithist, hbookclass purityhist)
        {
            List<int> donelist = new List<int>();
            Dictionary<int, int> truecogspread = new Dictionary<int, int>();
            foreach (int i in cc.Keys)
            {
                Dictionary<int, int> truecogs = new Dictionary<int, int>();
                memo(i + ":");
                StringBuilder sb = new StringBuilder("\t");
                foreach (int j in cc[i])
                {
                    sb.Append(wl[j].form + ", ");
                    donelist.Add(j);
                    if (!truecogs.ContainsKey(truecogdict[wl[j].id]))
                        truecogs.Add(truecogdict[wl[j].id], 1);
                    else
                        truecogs[truecogdict[wl[j].id]]++;
                }
                memo(sb.ToString());
                StringBuilder sbt = new StringBuilder("\tTrue cognate classes: ");
                int ttmax = -1;
                int truecogmax = -1;
                int truecogsum = 0;
                foreach (int tt in truecogs.Keys)
                {
                    sbt.Append(tt + ":" + truecogs[tt] + ", ");
                    truecogsum += truecogs[tt];
                    if (truecogspread.ContainsKey(tt))
                        truecogspread[tt]++;
                    else
                        truecogspread.Add(tt, 1);
                    if (truecogs[tt] > truecogmax)
                    {
                        truecogmax = truecogs[tt];
                        ttmax = tt;
                    }
                }
                memo(sbt.ToString());
                purityhist.Add(1-((double)truecogmax / truecogsum));

            }
            memo("Unassigned:");
            StringBuilder sb2 = new StringBuilder("\t");
            for (int i=0;i<wl.Count;i++)
            {
                if (!donelist.Contains(i))
                sb2.Append(wl[i].form + ":"+truecogdict[wl[i].id]+", ");
                if (truecogspread.ContainsKey(truecogdict[wl[i].id]))
                    truecogspread[truecogdict[wl[i].id]]++;
                else
                    truecogspread.Add(truecogdict[wl[i].id], 1);
            }
            memo(sb2.ToString());
            foreach (int tc in truecogspread.Keys)
                truesplithist.Add(truecogspread[tc]);
        }

        private Dictionary<int, List<int>> findcognates(List<wordclass> wordlist, int nmax, float maxmergedist)
        {
            memo("Find cognates; wordlist.Count = " + wordlist.Count);
            Dictionary<int, List<int>> cogclasses = new Dictionary<int, List<int>>();

            List<wordclass> wl = wordlist.Count > nmax ? samplelist(wordlist, nmax) : wordlist;

            float[,] distmat = make_distmatrix(wl,float.MaxValue);

            float distmax = -1;
            hbookclass disthist = new hbookclass("Dist, all");
            hbookclass disthistsame = new hbookclass("Dist, same meaning");
            hbookclass disthistdiff = new hbookclass("Dist, different meaning");
            disthist.SetBins(0, 1, 20);
            disthistsame.SetBins(0, 1, 20);
            disthistdiff.SetBins(0, 1, 20);
            for (int i = 0; i < wl.Count - 1; i++)
                for (int j = i + 1; j < wl.Count; j++)
                {
                    disthist.Add(distmat[i, j]);
                    if (distmat[i, j] > distmax)
                        distmax = distmat[i, j];
                    if (wl[i].meaning == wl[j].meaning)
                        disthistsame.Add(distmat[i, j]);
                    else
                        disthistdiff.Add(distmat[i, j]);
                }
            memo("distmax = " + distmax);
            memo(disthist.GetDHist());
            memo(disthistsame.GetDHist());
            memo(disthistdiff.GetDHist());

            //float maxmergedist = (float)0.2;
            List<int> donelist = new List<int>();

            int nmerge;
            do
            {
                nmerge = 0;
                float mindist = maxmergedist;
                int imin = -1;
                int jmin = -1;

                for (int i=0;i<wl.Count-1;i++)
                {
                    if (!donelist.Contains(i))
                    {
                        for (int j=i+1;j<wl.Count;j++)
                        {
                            if (distmat[i,j]< mindist)
                            {
                                mindist = distmat[i, j];
                                imin = i;
                                jmin = j;
                            }
                        }
                    }
                }
                if (imin >= 0)
                {
                    //memo("Merging " + imin + ", " + jmin);
                    nmerge++;
                    if (!cogclasses.ContainsKey(imin))
                    {
                        cogclasses.Add(imin, new List<int>());
                        cogclasses[imin].Add(imin);
                    }
                    if (!cogclasses.ContainsKey(jmin))
                        cogclasses[imin].Add(jmin);
                    else
                    {
                        foreach (int kk in cogclasses[jmin])
                            cogclasses[imin].Add(kk);
                        cogclasses.Remove(jmin);
                    }
                    for (int k=imin+1;k<wl.Count;k++)
                    {
                        if (!donelist.Contains(k))
                            distmat[imin, k] = Math.Min(distmat[imin, k], distmat[jmin, k]);
                        distmat[imin, jmin] = float.MaxValue;
                        //distmat[imin, k] = (float)0.5 * (distmat[imin, k] + distmat[jmin, k]);
                        //distmat[jmin, k] = float.MaxValue;
                    }
                    donelist.Add(jmin);
                }
            }
            while (nmerge > 0);

            //show_cogclasses(cogclasses, wl);

            return cogclasses;
        }

        private float[,] make_distmatrix(List<wordclass> wordlist, float diagonalvalue)
        {
            float[,] distmat = new float[wordlist.Count, wordlist.Count];

            for (int i = 0; i < wordlist.Count; i++)
                distmat[i, i] = diagonalvalue;

            for (int i=0;i<wordlist.Count-1;i++)
                for (int j=i+1;j<wordlist.Count;j++)
                {
                    float dist = (float)Levenshtein.WeightedDistance(wordlist[i].encodedform, wordlist[j].encodedform, segmentclass.segdistmatrix);
                    if (Double.IsNaN(dist))
                        memo("IsNaN! " + wordlist[i].encodedform + "|||" + wordlist[j].encodedform + "|||");
                    else
                        dist = dist/Math.Max(wordlist[i].encodedform.Length, wordlist[j].encodedform.Length);
                    distmat[i, j] = dist;
                    distmat[j, i] = dist;
                }

            return distmat;
        }

        private List<wordclass> samplelist(List<wordclass> wl, int nmax)
        {
            if (wl.Count <= nmax)
                return wl;
            List<wordclass> newlist = new List<wordclass>();
            int factor = (wl.Count / nmax) + 1;
            Random rnd = new Random();
            foreach (wordclass w in wl)
            {
                if (rnd.Next(factor) == 0)
                    newlist.Add(w);
            }
            return newlist;
        }

        //private void fillcogclasshists(Dictionary<int, List<int>> cc, hbookclass truesplithist,hbookclass purityhist)
        //{
        //    foreach (int i in cc.Keys)
        //    {
        //        Dictionary<int, int> truecogs = new Dictionary<int, int>();
        //        StringBuilder sb = new StringBuilder("\t");
        //        foreach (int j in cc[i])
        //        {
        //            sb.Append(wl[j].form + ", ");
        //            donelist.Add(j);
        //            if (!truecogs.ContainsKey(truecogdict[wl[j].id]))
        //                truecogs.Add(truecogdict[wl[j].id], 1);
        //            else
        //                truecogs[truecogdict[wl[j].id]]++;
        //        }
        //    }

        //}

        private void AutoCognButton_Click(object sender, EventArgs e)
        {
            List<string> meaninglist = new List<string>();
            List<string> languagelist = new List<string>();
            openFileDialog1.Title = "Open CLDF file";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fn = openFileDialog1.FileName;
                List<wordclass> wordlist = new List<wordclass>();
                using (StreamReader sr = new StreamReader(fn))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] words = line.Split('\t');
                        wordclass w = new wordclass();
                        w.id = util.tryconvert(words[0]);
                        w.meaning = words[1];
                        if (!meaninglist.Contains(w.meaning))
                            meaninglist.Add(w.meaning);
                        w.language = words[2];
                        if (!languagelist.Contains(w.language))
                            languagelist.Add(w.language);
                        w.form = words[3];
                        w.encodedform = EncodeForm(w.form);
                        wordlist.Add(w);
                    }
                }
                Dictionary<int, int> truecogdict = new Dictionary<int, int>();
                string fntrue = fn.Replace("CLDF", "true");
                using (StreamReader sr = new StreamReader(fntrue))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] words = line.Split('\t');
                        if (words.Length < 2)
                            continue;
                        if (!truecogdict.ContainsKey(util.tryconvert(words[0])))
                            truecogdict.Add(util.tryconvert(words[0]), util.tryconvert(words[1]));
                    }
                }

                hbookclass truesplithist = new hbookclass("#reconstructed classes that one true class is spread over");
                hbookclass purityhist = new hbookclass("Fraction non-majority true class per reconstrcuted class");
                purityhist.SetBins(0, 0.5, 50);

                Dictionary<string, Dictionary<int, List<int>>> cogclassdict = new Dictionary<string, Dictionary<int, List<int>>>();
                foreach (string mm in meaninglist)
                {
                    memo(mm);
                    List<wordclass> wl = (from c in wordlist where c.meaning == mm select c).ToList();
                    Dictionary<int, List<int>> cogclasses = findcognates(wl, 10000, (float)0.25);
                    show_cogclasses(cogclasses, wl, truecogdict,truesplithist,purityhist);
                    cogclassdict.Add(mm, cogclasses);
                }
                memo(truesplithist.GetIHist());
                memo(purityhist.GetDHist());
                wordclass.write_nexus(fn.Replace("CLDF", "CLDF-ACD"), "ACD",cogclassdict,languagelist, wordlist);
            }
        }
    }
}
