using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CdSkivorUppgift.Data;
using CdSkivorUppgift.Entities;

namespace CdSkivorUppgift.Pages.Records
{
    public class DeleteModel : PageModel
    {
        private readonly UppgiftHttpClient _client;

        public DeleteModel(UppgiftHttpClient client)
        {
            this._client = client;
        }

        [BindProperty]
      public Record Record { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            

            var record = _client.Client.GetFromJsonAsync<Record>($"api/Record/{id}").Result;

            if (record == null)
            {
                return NotFound();
            }
            else 
            {
                Record = record;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var record = _client.Client.GetFromJsonAsync<Record>($"api/Record/{id}").Result;

            if (record != null)
            {
                Record = record;
                await _client.Client.DeleteAsync($"api/Record/{Record.Id}");
            }

            return RedirectToPage("./Index");
        }
    }
}
