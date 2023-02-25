using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEshop.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(300)]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "آیا ادمین است؟")]
        public bool IsAdmin { get; set; }

        public List<Order> Orders { get; set; }
    }
}
