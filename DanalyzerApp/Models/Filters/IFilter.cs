using System.Collections.Generic;

namespace DanalyzerControllerPrototype.Models.Filters
{
    public interface IFilter
    {
        public List<Dictionary<string, string>> GetFilteredData(List<Dictionary<string, string>> data);
    }
}
