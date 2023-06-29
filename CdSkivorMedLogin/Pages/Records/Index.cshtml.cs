using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CdSkivorUppgift.Data;
using CdSkivorUppgift.Entities;
using Microsoft.AspNetCore.Authorization;

namespace CdSkivorUppgift.Pages.Records
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UppgiftHttpClient _client;

        public IndexModel(UppgiftHttpClient client)
        {
            _client = client;

        }

        public IList<Record> Record { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_client.Client.GetFromJsonAsync<List<Record>>("api/Record").Result != null)
            {
                Record = _client.Client.GetFromJsonAsync<List<Record>>("api/Record").Result;
            }
            
        }
    }
}
