using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagementSystem.Controllers
{
    public class BookingStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookingStatus
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookingStatuses.ToListAsync());
        }

        // GET: BookingStatus/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingStatus = await _context.BookingStatuses
                .FirstOrDefaultAsync(m => m.BookingStatusId == id);
            if (bookingStatus == null)
            {
                return NotFound();
            }

            return View(bookingStatus);
        }

        // GET: BookingStatus/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookingStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingStatusId,Status,Description")] BookingStatus bookingStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingStatus);
        }

        // GET: BookingStatus/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingStatus = await _context.BookingStatuses.FindAsync(id);
            if (bookingStatus == null)
            {
                return NotFound();
            }
            return View(bookingStatus);
        }

        // POST: BookingStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingStatusId,Status,Description")] BookingStatus bookingStatus)
        {
            if (id != bookingStatus.BookingStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingStatusExists(bookingStatus.BookingStatusId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookingStatus);
        }

        // GET: BookingStatus/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingStatus = await _context.BookingStatuses
                .FirstOrDefaultAsync(m => m.BookingStatusId == id);
            if (bookingStatus == null)
            {
                return NotFound();
            }

            return View(bookingStatus);
        }

        // POST: BookingStatus/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingStatus = await _context.BookingStatuses.FindAsync(id);
            _context.BookingStatuses.Remove(bookingStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingStatusExists(int id)
        {
            return _context.BookingStatuses.Any(e => e.BookingStatusId == id);
        }
    }
}
