using System;
using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClarkCodingChallenge.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		private readonly IContactsService _contactsService;

		public ValuesController(IContactsService contactsService)
		{
			_contactsService = contactsService;
		}

		[HttpGet]
		public JsonResult Get(bool orderByDefault = true)
		{
			try
			{
				return Json(_contactsService.GetAll(orderByDefault));
			}
			catch (Exception ex)
			{
				return Json(ex.Message);
			}
		}

		public JsonResult GetContact(string email)
		{
			try
			{
				return Json(_contactsService.GetContactByEmail(email));
			}
			catch (Exception ex)
			{
				return Json(ex.Message);
			}
		}

		// POST api/<controller>
		[HttpPost]
		public JsonResult Post(ContactModel model)
		{
			try
			{
				return Json(_contactsService.Add(model));
			}
			catch (Exception ex)
			{
				return Json(ex.Message);
			}
		}

		[HttpDelete]
		public JsonResult Delete(string email)
		{
			try
			{
				return Json(_contactsService.Remove(email));
			}
			catch (Exception ex)
			{
				return Json(ex.Message);
			}
		}
	}
}
