using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobpsycho.Models
{
    public class Abilitie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Id Autoincrement
        public int IdAbilitie { get; set; }
        public string Name { get; set; } = null!; // Telekinesis
        public string Description { get; set; } = null!;  // Shigeo possesses immeasurably potent telekinesis. With it, he can move extremely heavy objects, such as entire buildings, pin an entire crowd to a ceiling, create nearly impenetrable force-fields, fly, augment his physical strength and speed, disassemble matter and reconstruct it on a molecular level.
        public int IdCharacter { get; set; }
        [ForeignKey("IdCharacter")]
        public Character? Character { get; set; } // Relationship = One -
    }
}
