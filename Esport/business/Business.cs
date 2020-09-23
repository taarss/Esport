using System;
using System.Collections.Generic;
using System.Text;
using Esport.entityLayer;

namespace Esport.business
{
    public class Business
    {
        private Player Player;

        public void CreatePlayer(string name, string ingameName, int rank, string phoneNumber, int sponserId)
        {
            Player = new Player(name, ingameName, rank, phoneNumber, sponserId);
        }
    }
}
