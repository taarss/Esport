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
            string json = new WebClient().DownloadString(@$"https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{name}?api_key=RGAPI-8e8b1d3f-8834-4801-a030-c9dbbd77ea5b");
        }
    }
}
