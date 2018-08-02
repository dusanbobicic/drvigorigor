namespace CldMedAPI.Data
{
    public class Perscription
    {
        private User _usr;
        private int _id;
        private int _count;
        private Medication _med;
        private string _usage;
        private string _dose;
        private string _interval;


        public int Count { get => _count; set => _count = value; }
        public string Usage { get => _usage; set => _usage = value; }
        public string Dose { get => _dose; set => _dose = value; }
        public string Interval { get => _interval; set => _interval = value; }
        public Medication Med { get => _med; set => _med = value; }
        public User Usr { get => _usr; set => _usr = value; }
        public int Id { get => _id; set => _id = value; }
    }
}
