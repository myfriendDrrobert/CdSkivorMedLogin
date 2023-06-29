using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CdSkivorUppgift.Data;
using CdSkivorUppgift.Entities;

namespace CdSkivorUppgift.Pages.Records
{
    public class CreateModel : PageModel
    {
        private readonly UppgiftHttpClient _client;

        public CreateModel(UppgiftHttpClient client)
        {
            this._client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Record Record { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Record == null)
            {
                return Page();
            }

            await _client.Client.PostAsJsonAsync<Record>("api/Record", Record);

            return RedirectToPage("./Index");
        }
    }
}
