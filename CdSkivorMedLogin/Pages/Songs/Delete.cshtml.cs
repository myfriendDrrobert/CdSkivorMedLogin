using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CdSkivorUppgift.Data;
using CdSkivorUppgift.Entities;

namespace CdSkivorUppgift.Pages.Songs
{
    public class DeleteModel : PageModel
    {
        private readonly UppgiftHttpClient _client;

        public DeleteModel(UppgiftHttpClient client)
        {
            this._client = client;
        }

        [BindProperty]
      public Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var song = _client.Client.GetFromJsonAsync<Song>($"api/Song/{id}").Result;

            if (song == null)
            {
                return NotFound();
            }
            else 
            {
                Song = song;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var song = _client.Client.GetFromJsonAsync<Song>($"api/Song/{id}").Result;

            if (song != null)
            {
                Song = song;
               await _client.Client.DeleteAsync($"api/Song/{Song.Id}");


            }

            return RedirectToPage("./Index");
        }
    }
}
