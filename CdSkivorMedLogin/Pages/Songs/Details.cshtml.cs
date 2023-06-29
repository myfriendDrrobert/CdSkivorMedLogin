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
    public class DetailsModel : PageModel
    {
        private readonly UppgiftHttpClient _client;

        public DetailsModel(UppgiftHttpClient client)
        {
            this._client = client;
        }

        public Song Song { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {


            Song song = _client.Client.GetFromJsonAsync<Song>($"api/Song/{id}").Result;

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
    }
}
