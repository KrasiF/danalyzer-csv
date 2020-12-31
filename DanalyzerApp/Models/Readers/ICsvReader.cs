using System.Collections.Generic;

namespace DanalyzerControllerPrototype.Models.Readers
{
    interface ICsvReader
    {
        public List<Dictionary<string, string>> GetDictionaryFromCsv();
    }
}
