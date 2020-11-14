using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;
using Common.ViewModels;
using Data.Repositories;

namespace Api.Controllers
{
    [Route("api/faq")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private IFaqRepository faqRepository;
        private readonly string getMessageOk = "Get FAQs successfully";
        private readonly string getMessageErr = "FAQs not found";
        private readonly string addMessageOk = "Add FAQ successfully";
        private readonly string addMessageErr = "Add FAQ failed";
        private readonly string updateMessageOk = "Update FAQ successfully";
        private readonly string updateMessageErr = "Update FAQ failed";
        private readonly string deleteMessageOk = "Delete FAQ successfully";
        private readonly string deleteMessageErr = "Delete FAQ failed";

        public FaqController(IFaqRepository faqRepository)
        {
            this.faqRepository = faqRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new RestResponse(true, getMessageOk, faqRepository.FindAll()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var rs = faqRepository.Find(id);

            if (rs == null)
            {
                return NotFound(new RestResponse(false, getMessageErr));
            }

            return Ok(new RestResponse(true, getMessageOk, rs));
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, Faq rqBody)
        {
            rqBody.Id = id;
            if (faqRepository.Update(rqBody))
                return Ok(new RestResponse(true, updateMessageOk));
            return Ok(new RestResponse(false, updateMessageErr));
        }

        [HttpPost]
        public IActionResult Post(Faq rqBody)
        {
            if (faqRepository.Add(rqBody))
                return Ok(new RestResponse(true, addMessageOk));
            return Ok(new RestResponse(false, addMessageErr));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (faqRepository.Delete(id))
                return Ok(new RestResponse(true, deleteMessageOk));
            return Ok(new RestResponse(false, deleteMessageErr));
        }
    }
}
