using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace DanalyzerControllerPrototype.Models.Readers
{
    public class CsvReader : ICsvReader
    {
        private string path;

        public CsvReader(string path)
        {
            this.path = path;
        }

        public List<Dictionary<string, string>> GetDictionaryFromCsv()
        {
            using (TextFieldParser parser = new TextFieldParser(this.path))
            {
                List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                string[] headers = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    var entry = new Dictionary<string, string>();

                    string[] fields = parser.ReadFields();
                    for(int i = 0; i < headers.Length; i++)
                    {
                        entry.Add(headers[i], fields[i]);
                    }
                    data.Add(entry);
                }

                return data;
            }
        }
    }
}
