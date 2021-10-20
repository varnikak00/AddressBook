namespace CSVFileDemo
{
    internal class AddressData
    {
        internal bool lastnsme;

        public string firstname { get; set; }
        public string lastname { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }
        
        public string code { get; set; }
        public bool Code { get; internal set; }
    }
}