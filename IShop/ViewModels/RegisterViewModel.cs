using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [Display(Name = "*Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "*Пароль")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают!!!")]
        [DataType(DataType.Password)]
        [Display(Name = "*Подтвердить пароль")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Не указано ФИО")]
        [Display(Name = "*ФИО")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        [Display(Name = "*Е-маил")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        [Display(Name = "*Телефон")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        [Display(Name = "*Адрес доставки")]
        public string Address { get; set; }
    }
}
