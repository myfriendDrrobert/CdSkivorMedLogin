using System.Net.Http.Headers;

namespace CdSkivorUppgift.Data;

public class UppgiftHttpClient
{
    public HttpClient Client;

    public UppgiftHttpClient(HttpClient client)
    {
        this.Client = client;
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImJlYXRsIiwic3ViIjoiYmVhdGwiLCJqdGkiOiJiZWRhOGI2YSIsImF1ZCI6WyJodHRwOi8vbG9jYWxob3N0OjM1NTE2IiwiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMjkiLCJodHRwOi8vbG9jYWxob3N0OjUyMzEiLCJodHRwczovL2xvY2FsaG9zdDo3MTgwIl0sIm5iZiI6MTY4MzQwMzU0OSwiZXhwIjoxNjkxMzUyMzQ5LCJpYXQiOjE2ODM0MDM1NTAsImlzcyI6ImRvdG5ldC11c2VyLWp3dHMifQ.cnbqANcu1bsb8DXa6KLD_P5zInI_HU5hdb8-JyEOhIs");
    }


}
