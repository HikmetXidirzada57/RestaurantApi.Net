using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public enum PaymentMethod
    {
        CreditCard = 1,
        PayPal = 2,
        [Display(Name = "Çatdırılma zamanı nağd ödəniş")]
        CashOnDelivery = 3
    }
}
