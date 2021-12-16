using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Domain.Entities
{
    public enum OrderState
    {
        [Display(Name = "لغو شده")]
        Canceled = 0,

        [Display(Name = "پرداخت شده")]
        Paid = 1,

        [Display(Name = "در حال پردازش")]
        Processing = 2,
     
        [Display(Name = "تحویل داده شده")]
        Delivered = 3
    }
}
