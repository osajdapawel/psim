using Domain.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum EnumStatus
    {
        UNPAID,
        PAID
    }

    public class Order : BaseEntity
    {
        [Display(Name = "Dostawa")]
        public Guid? DeliveryId { get; set; }

        public Guid UserId { get; set; }

        public EnumStatus? Status { get; set; }

        [ForeignKey("OrderSuborder")]
        [Display(Name = "Dostawa")]
        public virtual Delivery Delivery { get; set; }

        [ForeignKey("OrderUser")]
        [Display(Name = "Dostawa")]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Suborder> Suborders { get; set; }
    }
}
