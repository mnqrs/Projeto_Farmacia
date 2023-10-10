using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Final.Model
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Tipo { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string? Descricao { get; set; }

        [InverseProperty("Categoria")]
        public virtual ICollection<Produto>? Produtos { get; set; }

    }
}
