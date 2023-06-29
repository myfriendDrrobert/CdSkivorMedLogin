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
    public class DetailsModel : PageModel
    {
        private readonly UppgiftHttpClient _client;

        public DetailsModel(UppgiftHttpClient client)
        {
            this._client = client;
        }

        public Record Record { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var record =  _client.Client.GetFromJsonAsync<Record>($"api/Record/{id}").Result;
            if (record == null)
            {
                return NotFound();
            }
            else 
            {
                Record = record;
            }

            ViewData["Titles"] = _client.Client.GetFromJsonAsync<List<string>>($"api/Record/{id}/getTitles").Result;
            
            return Page();
        }
    }
}
