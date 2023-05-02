using System.ComponentModel.DataAnnotations;

namespace ExpensiveControlApp.Models.Expensives
{
    public class Expensive
    {
        [Key]
        public int id { get; set; }

        [MaxLength(100)]
        public string descricao { get; set; }
        public double valor { get; set; }
        public DateTime date { get; set; }
    }
}
