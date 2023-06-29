using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CdSkivorUppgift.Data;
using CdSkivorUppgift.Entities;
using static System.Net.WebRequestMethods;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Authorization;

namespace CdSkivorUppgift.Pages.Songs;

[Authorize]
public class IndexModel : PageModel
{

    private readonly UppgiftHttpClient _client;

    public IndexModel(UppgiftHttpClient client)
    {
        _client= client;
        
    }

    public List<Song> Song { get;set; } = default!;

    

    public async Task OnGetAsync()
    {


        Song =  _client.Client.GetFromJsonAsync<List<Song>>("api/Song").Result;











    }
}