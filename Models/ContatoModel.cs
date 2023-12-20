using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models
{
    public class ContatoModel // atributo
    {
        public int Id { get; set; } // codigo do contato
        

        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; } // nome
        

        [Required(ErrorMessage = "Digite o E-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; } // email
        
        
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é válido!")]
        public string Celular { get; set; } // celular
        
    }
}
