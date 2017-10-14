using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TutorialServer.Models;

namespace TutorialServer.Controllers
{
    public class FhOrderDetailsController : Controller
    {
        private readonly StoreDataContext _context;

        public FhOrderDetailsController(StoreDataContext context)
        {
            _context = context;
        }

        // GET: FhOrderDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.FhOrderDetail.ToListAsync());
        }

        // GET: FhOrderDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fhOrderDetail = await _context.FhOrderDetail
                .SingleOrDefaultAsync(m => m.PortalId == id);
            if (fhOrderDetail == null)
            {
                return NotFound();
            }

            return View(fhOrderDetail);
        }

        // GET: FhOrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FhOrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendorId,PortalId,OrderNumber,PurchaseOrder,OrderDate,Contact,Name,Addr1,Addr2,City,State,Zip,Country,Carrier,Scac,PolineNum,Sku,Upc,Descr,Quantity,Processed,InsertDate,TransDetailId")] FhOrderDetail fhOrderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fhOrderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fhOrderDetail);
        }

        // GET: FhOrderDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fhOrderDetail = await _context.FhOrderDetail.SingleOrDefaultAsync(m => m.PortalId == id);
            if (fhOrderDetail == null)
            {
                return NotFound();
            }
            return View(fhOrderDetail);
        }

        // POST: FhOrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VendorId,PortalId,OrderNumber,PurchaseOrder,OrderDate,Contact,Name,Addr1,Addr2,City,State,Zip,Country,Carrier,Scac,PolineNum,Sku,Upc,Descr,Quantity,Processed,InsertDate,TransDetailId")] FhOrderDetail fhOrderDetail)
        {
            if (id != fhOrderDetail.PortalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fhOrderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FhOrderDetailExists(fhOrderDetail.PortalId))
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
            return View(fhOrderDetail);
        }

        // GET: FhOrderDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fhOrderDetail = await _context.FhOrderDetail
                .SingleOrDefaultAsync(m => m.PortalId == id);
            if (fhOrderDetail == null)
            {
                return NotFound();
            }

            return View(fhOrderDetail);
        }

        // POST: FhOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fhOrderDetail = await _context.FhOrderDetail.SingleOrDefaultAsync(m => m.PortalId == id);
            _context.FhOrderDetail.Remove(fhOrderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FhOrderDetailExists(string id)
        {
            return _context.FhOrderDetail.Any(e => e.PortalId == id);
        }
    }
}
