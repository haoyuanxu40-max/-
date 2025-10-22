using System.ComponentModel.DataAnnotations;

namespace 系統端.Models
{
    public class Package
    {
        public int ID { get; set; }
        public string PID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool STA { get; set; }
        public DateTime Date { get; set; }
        public List<Package> Packages { get; set; }
    }
}
