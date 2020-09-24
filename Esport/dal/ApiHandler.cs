using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Esport.dal
{
    public class ApiHandler
    {
        public void getUser(string name)
        {
            string json = new WebClient().DownloadString(@$"https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{name}?api_key=RGAPI-f2f2f546-5d8c-4d7d-b4f4-67e01249f7b4");
        }
    }
}
