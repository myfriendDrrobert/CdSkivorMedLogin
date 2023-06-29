using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CdSkivorUppgift.Data;
using CdSkivorUppgift.Entities;

namespace CdSkivorUppgift.Pages.Songs
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
            ViewData["AlbumName"] = new SelectList(_client.Client.GetFromJsonAsync<List<Record>>("api/Record").Result, "Id", "AlbumName");
            return Page();
        }

        [BindProperty]
        public Song Song { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid ||  Song == null)
            {
                ViewData["AlbumName"] = new SelectList(_client.Client.GetFromJsonAsync<List<Record>>("api/Record").Result, "Id", "AlbumName");
                return Page();
            }

            await _client.Client.PostAsJsonAsync<Song>("api/Song/", Song);



            return RedirectToPage("./Index");
        }
    }
}
