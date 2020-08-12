using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeApp.Data;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var employeeDbContext = _context.Employees.Include(e => e.Roles);
            return View(await employeeDbContext.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Roles)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["Roles"] = _context.Roles.ToList();
            ViewData["Skills"] = _context.Skills.ToList();
            ViewData["Hobbies"] = _context.Hobbies.ToList();
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Address,BirthDate,Joindate,Gender,RoleId,About")] Employee employee,IFormCollection fc)
        {
            if (ModelState.IsValid)
            {

                var emp=await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                List<EmployeeHobbies> Hobbies = new List<EmployeeHobbies>();
                foreach (var i in fc["hobbies"])
                {
                    var hobbies = new EmployeeHobbies()
                    {
                        HobbyId = Convert.ToInt32(i),
                        EmployeeId = emp.Entity.EmployeeId
                    };
                    Hobbies.Add(hobbies);
                }
                List<EmployeeSkills> skills = new List<EmployeeSkills>();

                foreach (var i in fc["skills"])
                {
                    var skill = new EmployeeSkills()
                    {
                        SkillId = Convert.ToInt32(i),
                        EmployeeId = emp.Entity.EmployeeId
                    };
                    skills.Add(skill);
                }
                _context.EmployeeSkills.AddRange(skills);
                _context.EmployeeHobbies.AddRange(Hobbies);

                _context.SaveChanges();
            }
            ViewData["Roles"] = _context.Roles.ToList();
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", employee.RoleId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,Address,BirthDate,Joindate,Gender,RoleId,About")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", employee.RoleId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Roles)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
