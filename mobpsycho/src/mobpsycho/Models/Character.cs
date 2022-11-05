using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobpsycho.Models
{
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Id Autoincrement
        public int IdCharacter { get; set; }
        public string Name { get; set; } // Shigeo Kageyama
        public string Gender { get; set; } // Male
        public int Age { get; set; } // 14
        public DateTime BirthDate { get; set; } // 12th May
        public virtual ICollection<Abilitie> Abilities { get; set; } // Relationship = - To Many
    }
}
