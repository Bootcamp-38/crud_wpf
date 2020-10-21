using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_wpf.Models
{
    [Table("tb_m_Transaction")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }


        public Transaction()
        {

        }
        public Transaction(DateTime orderdate)
        {
            this.OrderDate = orderdate;
        }

    }

}
