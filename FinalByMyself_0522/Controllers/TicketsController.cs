using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalByMyself_0522.Data;
using FinalByMyself_0522.Models;
using FinalByMyself_0522.Data.BLL;
using Microsoft.AspNetCore.Identity;

namespace FinalByMyself_0522.Controllers
{
    public class TicketsController : Controller
    {
        //    private readonly ApplicationDbContext _context;

        //    public TicketsController(ApplicationDbContext context)
        //    {
        //        _context = context;
        //    }

        private readonly UserManager<AppUser> userManager;//Index中使用
        private readonly AppUserBLL appUserBLL;
        private readonly ProjectBLL projectBLL;
        private readonly ProjectUserBLL projectUserBLL;
        private readonly RoleBLL roleBLL;
        private readonly TicketAttachmentBLL ticketAttachmentBLL;

        private readonly TicketBLL ticketBll;
        private readonly TicketCommentBLL ticketCommentBLL;
        private readonly TicketHistoryBLL ticketHistoryBLL;
        private readonly TicketNotificationBLL ticketNotificationBLL;

        public TicketsController(ApplicationDbContext context)
        {
            appUserBLL = new AppUserBLL(new Data.DAL.AppUserDAL(context));
            projectBLL = new ProjectBLL(new Data.DAL.ProjectDAL(context));
            projectUserBLL = new ProjectUserBLL(new Data.DAL.ProjectUserDAL(context));
            roleBLL = new RoleBLL(new Data.DAL.RoleDAL(context));
            ticketAttachmentBLL = new TicketAttachmentBLL(new Data.DAL.TicketAttachmentDAL(context));

            ticketBll = new TicketBLL(new Data.DAL.TicketDAL(context));
            ticketCommentBLL = new TicketCommentBLL(new Data.DAL.TicketCommentDAL(context));
            ticketHistoryBLL = new TicketHistoryBLL(new Data.DAL.TicketHistoryDAL(context));
            ticketNotificationBLL = new TicketNotificationBLL(new Data.DAL.TicketNotificationDAL(context));
        }



        //    // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ticket.Include(t => t.AssignedToUser).Include(t => t.OwnerUser).Include(t => t.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        //public async Task<IActionResult> Index(int projectid, string projectname, string searchString, string currentFilter, int? pageNumber)
        //{
        //    var userName = User.Identity.Name;
        //    var user = new AppUser();
        //    if(userName == null)
        //    {
        //        user = await userManager.FindByNameAsync(userName);
        //    }
        //    ViewBag.UserRole = await userManager.GetRolesAsync(user);
        //    ViewBag.UserId = user.Id;
        //    ViewData["CurrentFilter"] = searchString;//过滤当前
        //    ViewBag.ProjectName = projectname;
        //    ViewBag.ProjectId = projectid;
        //    ViewBag.IsProjectUser = false;
        //    // all users who assinged this project所有分配此项目的用户

        //    var projectUser = projectUserBLL.GetAll().FirstOrDefault(pu => pu.ProjectId == projectid && pu.UserId == user.Id);
        //    if(projectUser != null)
        //    {
        //        ViewBag.IsProjectUser = true;
        //    }
        //    if(searchString != null)
        //    {
        //        pageNumber = 1;
        //    }else
        //    {
        //        searchString = currentFilter;
        //    }
        //    var Tickets = ticketBll.GetAll().Where(t => t.ProjectId == projectid);
        //    var TicketsWithAssineUser = ticketBll.GetList(t => t.AssignedToUser != null);

        //    return View();
        //}

        //    // GET: Tickets/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null || _context.Ticket == null)
        //        {
        //            return NotFound();
        //        }

        //        var ticket = await _context.Ticket
        //            .Include(t => t.AssignedToUser)
        //            .Include(t => t.OwnerUser)
        //            .Include(t => t.Project)
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (ticket == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(ticket);
        //    }

        //    // GET: Tickets/Create
        //    public IActionResult Create()
        //    {
        //        ViewData["AssignedToUserId"] = new SelectList(_context.AppUser, "Id", "Id");
        //        ViewData["OwnerUserId"] = new SelectList(_context.AppUser, "Id", "Id");
        //        ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Id");
        //        return View();
        //    }

        //    // POST: Tickets/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("Id,Title,Description,Created,Updated,ProjectId,OwnerUserId,AssignedToUserId,TicketType,TicketPriority,TicketStatus")] Ticket ticket)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(ticket);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["AssignedToUserId"] = new SelectList(_context.AppUser, "Id", "Id", ticket.AssignedToUserId);
        //        ViewData["OwnerUserId"] = new SelectList(_context.AppUser, "Id", "Id", ticket.OwnerUserId);
        //        ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Id", ticket.ProjectId);
        //        return View(ticket);
        //    }

        //    // GET: Tickets/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null || _context.Ticket == null)
        //        {
        //            return NotFound();
        //        }

        //        var ticket = await _context.Ticket.FindAsync(id);
        //        if (ticket == null)
        //        {
        //            return NotFound();
        //        }
        //        ViewData["AssignedToUserId"] = new SelectList(_context.AppUser, "Id", "Id", ticket.AssignedToUserId);
        //        ViewData["OwnerUserId"] = new SelectList(_context.AppUser, "Id", "Id", ticket.OwnerUserId);
        //        ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Id", ticket.ProjectId);
        //        return View(ticket);
        //    }

        //    // POST: Tickets/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Created,Updated,ProjectId,OwnerUserId,AssignedToUserId,TicketType,TicketPriority,TicketStatus")] Ticket ticket)
        //    {
        //        if (id != ticket.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(ticket);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!TicketExists(ticket.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["AssignedToUserId"] = new SelectList(_context.AppUser, "Id", "Id", ticket.AssignedToUserId);
        //        ViewData["OwnerUserId"] = new SelectList(_context.AppUser, "Id", "Id", ticket.OwnerUserId);
        //        ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Id", ticket.ProjectId);
        //        return View(ticket);
        //    }

        //    // GET: Tickets/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null || _context.Ticket == null)
        //        {
        //            return NotFound();
        //        }

        //        var ticket = await _context.Ticket
        //            .Include(t => t.AssignedToUser)
        //            .Include(t => t.OwnerUser)
        //            .Include(t => t.Project)
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (ticket == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(ticket);
        //    }

        //    // POST: Tickets/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        if (_context.Ticket == null)
        //        {
        //            return Problem("Entity set 'ApplicationDbContext.Ticket'  is null.");
        //        }
        //        var ticket = await _context.Ticket.FindAsync(id);
        //        if (ticket != null)
        //        {
        //            _context.Ticket.Remove(ticket);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool TicketExists(int id)
        //    {
        //      return (_context.Ticket?.Any(e => e.Id == id)).GetValueOrDefault();
        //    }
    }
}
