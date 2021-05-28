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

        public string UserId { get; set; }

        public EnumStatus? Status { get; set; }

        [ForeignKey("DeliveryId")]
        [Display(Name = "Dostawa")]
        public virtual Delivery Delivery { get; set; }

        [ForeignKey("UserId")]
        [Display(Name = "Klient")]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Suborder> Suborders { get; set; }

        public Order(string userId, Delivery delivery, ApplicationUser user):base()
        {
            UserId = userId;
            Delivery = delivery;
            User = user;
        }

        public Order():base()
        {
        }
    }
}
