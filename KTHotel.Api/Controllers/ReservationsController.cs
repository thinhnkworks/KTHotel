﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KTHotel.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTHotel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly PrimeDbContext primeDbContext;

        public ReservationsController(PrimeDbContext _primeDbContext)
        {
            primeDbContext = _primeDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Reservation>> Get()
        {
            return await primeDbContext.Reservations.Include(r => r.Room).AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation = await primeDbContext.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            await primeDbContext.Entry(reservation).Collection(r => r.Profiles).LoadAsync();
            await primeDbContext.Entry(reservation).Reference(r => r.Room).LoadAsync();

            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewReservation newReservation)
        {
            var room = await primeDbContext.Rooms.FirstOrDefaultAsync(r => r.Id == newReservation.RoomId);
            var guests = await primeDbContext.Profiles.Where(p => newReservation.GuestIds.Contains(p.Id)).ToListAsync();

            if (room == null || guests.Count != newReservation.GuestIds.Count)
            {
                return NotFound();
            }

            var reservation = new Reservation
            {
                Created = DateTime.UtcNow,
                From = newReservation.From.Value,
                To = newReservation.To.Value,
                Room = room,
                Profiles = guests
            };

            var createdReservation = await primeDbContext.Reservations.AddAsync(reservation);
            await primeDbContext.SaveChangesAsync();

            return Ok(createdReservation.Entity.Id);
        }
    }
}
