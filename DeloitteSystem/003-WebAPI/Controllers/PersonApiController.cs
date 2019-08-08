using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DeloitteSystem
{
	[EnableCors("*", "*", "*")]
	[RoutePrefix("api")]
	public class PersonApiController : ApiController
    {
		private PersonsLogic logic = new PersonsLogic();

		private static int count= 0;


		[HttpGet]
		[Route("personsByString/{search}")]
		public HttpResponseMessage GetAllPersonsByString(string search)
		{
			try
			{
				List<PersonModel> allPersons = logic.GetAllPersonsByString(search);
				return Request.CreateResponse(HttpStatusCode.OK, allPersons);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("personsByString")]
		public HttpResponseMessage GetAllPersons()
		{
			try
			{
				List<PersonModel> allPersons = logic.GetAllPersons();
				return Request.CreateResponse(HttpStatusCode.OK, allPersons);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}
	}
}
