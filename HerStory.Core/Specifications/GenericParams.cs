namespace HerStory.Core.Specifications
{
    public class GenericParams
    {
        private const int MaxPageSize = 100;
        public int PageIndex {get; set;} = 1;

        private int _pageSize = 20;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        
        public string Sort { get; set; }
        private string _search;
        public string Search 
        { 
            get => _search;
            set => _search = value.ToLower();
        }
    }
}