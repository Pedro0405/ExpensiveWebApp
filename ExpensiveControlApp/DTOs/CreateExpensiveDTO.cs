using System.ComponentModel.DataAnnotations;

namespace ExpensiveControlApp.DTOs
{
    public class CreateExpensiveDTO
    {
        public CreateExpensiveDTO()
        {
            date = DateTime.Now;
        }

        [Required(ErrorMessage = "Descrição é obrigatorio")]
        public string descricao { get; set; }
        [Required(ErrorMessage = "Valor é obrigatorio")]
        [Range(0.011,99999999999,ErrorMessage = "O valor deve ser maior que 0 e menor que 99999999999")]
        public double valor { get; set; }
        [Required(ErrorMessage = "Data é obrigatorio")]
        public DateTime date { get; set; }
    }
}
