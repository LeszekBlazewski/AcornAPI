﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using Acorn.BL.Models;
using Acorn.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcornAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadyAccountsController : ControllerBase
    {
        private readonly IReadyAccountService _readyAccountService;

        private readonly IMapper _mapper;

        public ReadyAccountsController(IReadyAccountService readyAccountService, IMapper mapper)
        {
            _readyAccountService = readyAccountService;
            _mapper = mapper;
        }

        // PUT: api/ReadyAccounts/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReadyAccount(int id, [FromBody]ReadyAccount readyAccount)
        {
            readyAccount.ReadyAccountId = id;
            try
            {
                await _readyAccountService.UpdateReadyAccountAsync(readyAccount);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/ReadyAccounts
        [HttpPost]
        public async Task<ActionResult> CreateReadyAccount([FromBody]ReadyAccount readyAccount)
        {
            try
            {
                await _readyAccountService.CreateNewReadyAccountAsync(readyAccount);
                //return CreatedAtAction(nameof(GetReadyAccountById), new { ReadyAccountId = readyaccount.ReadyAccountId }, readyAccount);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ReadyAccounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReadyAccount(int id)
        {
            try
            {
                await _readyAccountService.DeleteReadyAccountAsync(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ReadyAccounts
        [HttpGet]
        public async Task<ActionResult> GetAllReadyAccounts()
        {
            var readyAccounts = await _readyAccountService.GetAllReadyAccountsAsync();

            return Ok(readyAccounts);
        }

        // GET: api/ReadyAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadyAccount>> GetReadyAccountById(int id)
        {
            try
            {
                var readyAccount = await _readyAccountService.GetReadyAccountByIdAsync(id);

                return Ok(readyAccount);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}