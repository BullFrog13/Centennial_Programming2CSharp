using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Lab_10
{
    class Program
    {
        private static readonly Atom[] Elements = new Atom[110];

        static void Main()
        {
            try
            {
                Elements[0] = (Atom.Parse("Hydrogen 1 0 1.0079 H"));
                Elements[1] = (Atom.Parse("Helium 2 2 4.0026 He"));
                ;
                Elements[2] = (Atom.Parse("Lithium 3 4 6.941 Li"));
                ;
                Elements[3] = (Atom.Parse("Beryllium 4 5 9.0122 Be"));
                Elements[4] = (Atom.Parse("Boron 5 6 10.811 B"));
                Elements[5] = (Atom.Parse("Carbon 6 6 12.0107 C"));
                Elements[6] = (Atom.Parse("Nitrogen 7 7 14.0067 N"));
                Elements[7] = (Atom.Parse("Oxygen 8 8 15.9994 O"));
                Elements[8] = (Atom.Parse("Fluorine 9 10 18.9984 F"));
                Elements[9] = (Atom.Parse("Neon 10 10 20.1797 Ne"));
                Elements[10] = (Atom.Parse("Sodium 11 12 22.9897 Na"));
                Elements[11] = (Atom.Parse("Magnesium 12 12 24.305 Mg"));
                Elements[12] = (Atom.Parse("Aluminum 13 14 26.9815 Al"));
                Elements[13] = (Atom.Parse("Silicon 14 14 28.0855 Si"));
                Elements[14] = (Atom.Parse("Phosphorus 15 16 30.9738 P"));
                Elements[15] = (Atom.Parse("Sulfur 16 16 32.065 S"));
                Elements[16] = (Atom.Parse("Chlorine 17 18 35.453 Cl"));
                Elements[17] = (Atom.Parse("Potassium 19 20 39.0983 K"));
                Elements[18] = (Atom.Parse("Argon 18 22 39.948 Ar"));
                Elements[19] = (Atom.Parse("Calcium 20 20 40.078 Ca"));
                Elements[20] = (Atom.Parse("Scandium 21 24 44.9559 Sc"));
                Elements[21] = (Atom.Parse("Titanium 22 26 47.867 Ti"));
                Elements[22] = (Atom.Parse("Vanadium 23 28 50.9415 V"));

                Elements[23] = (Atom.Parse("Chromium 24 28 51.9961 Cr"));

                Elements[24] = (Atom.Parse("Manganese 25 30 54.938 Mn"));

                Elements[25] = (Atom.Parse("Iron 26 30 55.845 Fe"));

                Elements[27] = (Atom.Parse("Nickel 28 31 58.6934 Ni"));

                Elements[26] = (Atom.Parse("Cobalt 27 32 58.9332 Co"));

                Elements[28] = (Atom.Parse("Copper 29 35 63.546 Cu"));

                Elements[29] = (Atom.Parse("Zinc 30 35 65.39 Zn"));

                Elements[30] = (Atom.Parse("Gallium 31 39 69.723 Ga"));

                Elements[31] = (Atom.Parse("Germanium 32 41 72.64 Ge"));

                Elements[32] = (Atom.Parse("Arsenic 33 42 74.9216 As"));

                Elements[33] = (Atom.Parse("Selenium 34 45 78.96 Se"));

                Elements[34] = (Atom.Parse("Bromine 35 45 79.904 Br"));

                Elements[35] = (Atom.Parse("Krypton 36 48 83.8 Kr"));

                Elements[36] = (Atom.Parse("Rubidium 37 48 85.4678 Rb"));

                Elements[37] = (Atom.Parse("Strontium 38 50 87.62 Sr"));

                Elements[38] = (Atom.Parse("Yttrium 39 50 88.9059 Y"));

                Elements[39] = (Atom.Parse("Zirconium 40 51 91.224 Zr"));

                Elements[40] = (Atom.Parse("Niobium 41 52 92.9064 Nb"));

                Elements[41] = (Atom.Parse("Molybdenum 42 54 95.94 Mo"));

                Elements[42] = (Atom.Parse("Technetium 43 55 98 Tc"));

                Elements[43] = (Atom.Parse("Ruthenium 44 57 101.07 Ru"));

                Elements[44] = (Atom.Parse("Rhodium 45 58 102.9055 Rh"));

                Elements[45] = (Atom.Parse("Palladium 46 60 106.42 Pd"));

                Elements[46] = (Atom.Parse("Silver 47 61 107.8682 Ag"));

                Elements[47] = (Atom.Parse("Cadmium 48 64 112.411 Cd"));

                Elements[48] = (Atom.Parse("Indium 49 66 114.818 In"));

                Elements[49] = (Atom.Parse("Tin 50 69 118.71 Sn"));

                Elements[50] = (Atom.Parse("Antimony 51 71 121.76 Sb"));

                Elements[51] = (Atom.Parse("Iodine 53 74 126.9045 I"));

                Elements[52] = (Atom.Parse("Tellurium 52 76 127.6 Te"));

                Elements[53] = (Atom.Parse("Xenon 54 77 131.293 Xe"));

                Elements[54] = (Atom.Parse("Cesium 55 78 132.9055 Cs"));

                Elements[55] = (Atom.Parse("Barium 56 81 137.327 Ba"));

                Elements[56] = (Atom.Parse("Lanthanum 57 82 138.9055 La"));

                Elements[57] = (Atom.Parse("Cerium 58 82 140.116 Ce"));

                Elements[58] = (Atom.Parse("Praseodymium 59 82 140.9077 Pr"));

                Elements[59] = (Atom.Parse("Neodymium 60 84 144.24 Nd"));

                Elements[60] = (Atom.Parse("Promethium 61 84 145 Pm"));

                Elements[61] = (Atom.Parse("Samarium 62 88 150.36 Sm"));

                Elements[62] = (Atom.Parse("Europium 63 89 151.964 Eu"));

                Elements[63] = (Atom.Parse("Gadolinium 64 93 157.25 Gd"));

                Elements[64] = (Atom.Parse("Terbium 65 94 158.9253 Tb"));

                Elements[65] = (Atom.Parse("Dysprosium 66 97 162.5 Dy"));

                Elements[66] = (Atom.Parse("Holmium 67 98 164.9303 Ho"));

                Elements[67] = (Atom.Parse("Erbium 68 99 167.259 Er"));

                Elements[68] = (Atom.Parse("Thulium 69 100 168.9342 Tm"));

                Elements[69] = (Atom.Parse("Ytterbium 70 103 173.04 Yb"));

                Elements[70] = (Atom.Parse("Lutetium 71 104 174.967 Lu"));

                Elements[71] = (Atom.Parse("Hafnium 72 106 178.49 Hf"));

                Elements[72] = (Atom.Parse("Tantalum 73 108 180.9479 Ta"));

                Elements[73] = (Atom.Parse("Tungsten 74 110 183.84 W"));

                Elements[74] = (Atom.Parse("Rhenium 75 111 186.207 Re"));

                Elements[75] = (Atom.Parse("Osmium 76 114 190.23 Os"));

                Elements[76] = (Atom.Parse("Iridium 77 115 192.217 Ir"));

                Elements[77] = (Atom.Parse("Platinum 78 117 195.078 Pt"));

                Elements[78] = (Atom.Parse("Gold 79 118 196.9665 Au"));

                Elements[79] = (Atom.Parse("Mercury 80 121 200.59 Hg"));

                Elements[80] = (Atom.Parse("Thallium 81 123 204.3833 Tl"));

                Elements[81] = (Atom.Parse("Lead 82 125 207.2 Pb"));

                Elements[82] = (Atom.Parse("Bismuth 83 126 208.9804 Bi"));

                Elements[83] = (Atom.Parse("Polonium 84 125 209 Po"));

                Elements[84] = (Atom.Parse("Astatine 85 125 210 At"));

                Elements[85] = (Atom.Parse("Radon 86 136 222 Rn"));

                Elements[86] = (Atom.Parse("Francium 87 136 223 Fr"));

                Elements[87] = (Atom.Parse("Radium 88 138 226 Ra"));

                Elements[88] = (Atom.Parse("Actinium 89 138 227 Ac"));

                Elements[89] = (Atom.Parse("Protactinium 91 140 231.0359 Pa"));

                Elements[90] = (Atom.Parse("Thorium 90 142 232.0381 Th"));

                Elements[91] = (Atom.Parse("Neptunium 93 144 237 Np"));

                Elements[92] = (Atom.Parse("Uranium 92 146 238.0289 U"));

                Elements[94] = (Atom.Parse("Americium 95 148 243 Am"));

                Elements[93] = (Atom.Parse("Plutonium 94 150 244 Pu"));

                Elements[95] = (Atom.Parse("Curium 96 151 247 Cm"));

                Elements[96] = (Atom.Parse("Berkelium 97 150 247 Bk"));

                Elements[97] = (Atom.Parse("Californium 98 153 251 Cf"));

                Elements[98] = (Atom.Parse("Einsteinium 99 153 252 Es"));

                Elements[99] = (Atom.Parse("Fermium 100 157 257 Fm"));

                Elements[100] = (Atom.Parse("Mendelevium 101 157 258 Md"));

                Elements[101] = (Atom.Parse("Nobelium 102 157 259 No"));

                Elements[103] = (Atom.Parse("Rutherfordium 104 157 261 Rf"));

                Elements[102] = (Atom.Parse("Lawrencium 103 159 262 Lr"));

                Elements[104] = (Atom.Parse("Dubnium 105 157 262 Db"));

                Elements[106] = (Atom.Parse("Bohrium 107 157 264 Bh"));

                Elements[105] = (Atom.Parse("Seaborgium 106 160 266 Sg"));

                Elements[108] = (Atom.Parse("Meitnerium 109 159 268 Mt"));

                Elements[109] = (Atom.Parse("Roentgenium 111 161 272 Rg"));

                Elements[107] = (Atom.Parse("Hassium 108 169 277 Hs"));
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        static void Display()
        {
            foreach (var element in Elements)
            {
                Console.WriteLine(element);
            }
        }

        static void SaveFirstItem()
        {
            var serializer = new XmlSerializer(typeof(Atom));

            string xml;

            using (var sww = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sww))
                {
                    serializer.Serialize(writer, Elements[0]);
                    xml = sww.ToString();
                }
            }

            File.WriteAllText("test.xml", xml);
        }

        static void ReadFirstItem()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("");
        }
    }
}
