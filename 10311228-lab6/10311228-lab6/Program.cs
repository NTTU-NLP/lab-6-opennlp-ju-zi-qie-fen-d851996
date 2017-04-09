using java.io;
using opennlp.tools.tokenize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10311228_lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] files = Directory.GetFiles(@"..\..\..\..\Dataset", "lab5result.txt");
            StreamWriter sw = new StreamWriter(@"..\..\..\..\lab6result.txt",false);
            foreach (string file in files)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    while (sr.Peek() != -1)
                    {
                        string line = sr.ReadLine();
                        string[] tokens;
                        InputStream modelIn = new FileInputStream(@"..\..\..\..\en-token.bin");
                        TokenizerModel model = new TokenizerModel(modelIn);
                        TokenizerME enTokenizer = new TokenizerME(model);
                        tokens = enTokenizer.tokenize(line);

                        for (int i = 0; i < tokens.Length; i++)
                        {
                          
                            sw.Write(tokens[i] + " ");
                            if (tokens[i].Equals("."))
                            {
                                sw.Write("\r\n");
                            }

                        }
                    }
                }
            }
            sw.Close();
        }
    }
}
