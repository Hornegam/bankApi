﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly APIDBContext _context;

        public BankAccountController(APIDBContext context)
        {
            _context = context;
        }

        // GET: api/BankAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccounts()
        {
            return await _context.BankAccounts.ToListAsync();
        }

        // GET: api/BankAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetBankAccount(int id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);

            if (bankAccount == null)
            {
                return NotFound();
            }

            return bankAccount;
        }

        // PUT: api/BankAccounts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankAccount(int id, BankAccount bankAccount)
        {
            if (id != bankAccount.BankAccountID)
            {
                return BadRequest();
            }

            _context.Entry(bankAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BankAccounts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BankAccount>> PostBankAccount(BankAccount bankAccount)
        {
            _context.BankAccounts.Add(bankAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankAccount", new { id = bankAccount.BankAccountID }, bankAccount);
        }

        // DELETE: api/BankAccounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BankAccount>> DeleteBankAccount(int id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            _context.BankAccounts.Remove(bankAccount);
            await _context.SaveChangesAsync();

            return bankAccount;
        }

        private bool BankAccountExists(int id)
        {
            return _context.BankAccounts.Any(e => e.BankAccountID == id);
        }
    }
}
