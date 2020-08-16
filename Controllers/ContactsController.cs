using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelloWorldService.Models;
using System.Collections;

namespace HelloWorldService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public static List<Contact> contacts = new List<Contact>();

        // GET: api/Contacts
        [HttpGet]
        public IEnumerable Get()
        {
            return contacts;
        }

        // GET: api/Contacts/5
        [HttpGet("{id}", Name = "Get")]
        public Contact Get(int id)
        {
            return contacts.FirstOrDefault(t => t.Id == id);
        }

        private static int nextId = 1;

        // POST: api/Contacts
        [HttpPost]
        public IActionResult Post([FromBody] Contact value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }

            value.Id = nextId++;
            value.DateAdded = DateTime.Now;
            contacts.Add(value);

            var result = new { Id = value.Id, Candy = true };

            // Look at the Headers in the response output in Postman
            return CreatedAtAction(nameof(Post), new { id = value.Id }, value);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contact value)
        {
            var contact = contacts.FirstOrDefault( t => t.Id == id);
            contact.Id = id;
            contact.Email = value.Email;
            contact.Password = value.Password;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contactsRemoved = contacts.RemoveAll(t => t.Id == id);
            if (contactsRemoved == 0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}