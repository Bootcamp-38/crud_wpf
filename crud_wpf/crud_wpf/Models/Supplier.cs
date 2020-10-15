using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_wpf.Models
{
    [Table("tb_m_Supplier")]
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
