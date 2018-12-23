﻿using System.ComponentModel.DataAnnotations;

namespace FurnitureStore.Models.Entities.Manage
{
	public class DeleteUserViewModel
	{ 
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Это поле обязательно для заполнения")]
		[Display(Name = "Пароль")]
		[DataType(DataType.Password)]
		[StringLength(25, ErrorMessage = "Это поле должно быть от {2} до {1} символов", MinimumLength = 5)]
		public string Password { get; set; }
	}
}