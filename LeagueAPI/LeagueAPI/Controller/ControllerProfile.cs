using LeagueAPI.API;
using LeagueAPI.Model;
using LeagueAPI.Utils;
using LeagueAPI.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAPI.Controller
{
    public class ControllerProfile
    {
        public object GetContext()
        {
            var summoner = Constants.Summoner;

            var position = GetPosition(summoner);

            return new viewModelProfile(summoner.Name, summoner.ProfileIconId,
                summoner.SummonerLevel, position.Tier, position.Rank,
                position.Wins, position.Losses);
        }

        private PositionDTO GetPosition(SummonerDTO summoner)
        {
            League_V4 league = new League_V4(Constants.Region);

            var position = league.GetPositions(summoner.Id).Where(p=>p.QueueType.Equals("RANKED_SOLO_5x5")).FirstOrDefault();



            return position ?? new PositionDTO();
        }

        public void OpenMain()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
