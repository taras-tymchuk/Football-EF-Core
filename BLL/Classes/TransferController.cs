using DAL.Models;
using DAL.Unit_Of_Work;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Classes
{
    public class TransferController
    {
        private IUnitOfWork model;
        private TransferResult transferResult;

        public TransferController( IUnitOfWork model )
        {
            this.model = model;
        }

        public TransferResult TransferPlayer(
            string firstName, string lastName, string newClubName )
        {
            transferResult = new TransferResult();

            var players = model.Players
                .GetPlayerByFullName( firstName, lastName )
                .ToList();

            if ( players.Count == 0 )
            {
                transferResult.ErrorCode = ErrorCodeEnum.NotFoundPlayer;
            }
            else if ( players.Count > 1 )
            {
                transferResult.ErrorCode = ErrorCodeEnum.DuplicatePlayer;
            }
            else
            {
                OrganizeTransfer( players[0], newClubName );
            }

            return transferResult;
        }

        private void OrganizeTransfer( Player player, string newClubName )
        {
            List<Team> teams = model.Teams.GetTeamByName( newClubName )
                    .ToList();

            if ( teams.Count == 0 )
            {
                transferResult.ErrorCode = ErrorCodeEnum.NotFoundTeam;
            }
            else
            {
                UpdateTeam( player, teams[0] );
            }
        }

        private void UpdateTeam( Player player, Team newTeam )
        {
            Player updatedPlayer = new Player
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                Age = player.Age,
                Nationality = player.Nationality,
                Team = newTeam
            };

            model.Players.Remove( player );
            model.Players.Add( updatedPlayer );
            model.Save();
        }
    }
}
