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

namespace CdSkivorUppgift.Pages.Songs
{
    public class EditModel : PageModel
    {
        private readonly UppgiftHttpClient _client;

        public EditModel(UppgiftHttpClient client)
        {
            this._client= client;
        }

        [BindProperty]
        public Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {

            ViewData["AlbumName"] = new SelectList(_client.Client.GetFromJsonAsync<List<Record>>("api/Record").Result , "Id", "AlbumName");
            Song song =  _client.Client.GetFromJsonAsync<Song>($"api/Song/{id}").Result;    
            if (song == null)
            {
                return NotFound();
            }
            Song = song;
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
                await _client.Client.PutAsJsonAsync($"api/Song/{Song.Id}", Song);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(Song.Id))
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

        private bool SongExists(int id)
        {
            if (_client.Client.GetFromJsonAsync<Song>($"api/Song/{id}").Result == null)
            {
                return false;
            }
            return true;
        }
    }
}
