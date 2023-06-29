using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CdSkivorUppgift.Data;
using CdSkivorUppgift.Entities;
using Microsoft.AspNetCore.Authorization;

namespace CdSkivorUppgift.Pages.Records
{
    
    public class EditModel : PageModel
    {
        
        private readonly UppgiftHttpClient _client;

        public EditModel(UppgiftHttpClient client)
        {
            this._client = client;
        }

        [BindProperty]
        public Record Record { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var record = _client.Client.GetFromJsonAsync<Record>($"api/Record/{id}").Result;
            if (record == null)
            {
                return NotFound();
            }
            Record = record;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            try
            {
                await _client.Client.PutAsJsonAsync($"api/Record/{Record.Id}", Record);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(Record.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecordExists(int id)
        {
          if (_client.Client.GetFromJsonAsync<Record>($"api/Record/{id}").Result == null)
            {
                return false;
            }
            return true;
        }
    }
}
