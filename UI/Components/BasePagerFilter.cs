namespace UI.Components
{
    public class BasePagerFilter
    {
        public int Page { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Search { get; set; } = string.Empty;

        public void UpdateTotalPages(int count)
        {
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
        }

        public bool PreviousPageExist
        {
            get
            {
                return (Page > 1);
            }
            set { }
        }

        public bool NextPageExist
        {
            get
            {
                return (Page < TotalPages);
            }
            set { }
        }
    }
}
