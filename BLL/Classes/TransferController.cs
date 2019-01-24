using DAL.Models;
using DAL.Unit_Of_Work;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Classes
{
    public class TransferController
    {
        private IUnitOfWork _model;
        private TransferResult _transferResult;

        public TransferController( IUnitOfWork model )
        {
            _model = model;
        }

        public TransferResult TransferPlayer(
            string firstName, string lastName, string newClubName )
        {
            _transferResult = new TransferResult();

            var players = _model.Players.GetPlayerByFullName( firstName, lastName )
                .ToList();

            if ( players.Count == 0 )
            {
                _transferResult.ErrorCode = ErrorCodeEnum.NotFoundPlayer;
            }
            else if ( players.Count > 1 )
            {
                _transferResult.ErrorCode = ErrorCodeEnum.DuplicatePlayer;
            }
            else
            {
                OrganizeTransfer( players[0], newClubName );
            }

            return _transferResult;
        }

        private void OrganizeTransfer( Player player, string newClubName )
        {
            List<Team> teams = _model.Teams.GetTeamByName( newClubName )
                    .ToList();

            if ( teams.Count == 0 )
            {
                _transferResult.ErrorCode = ErrorCodeEnum.NotFoundTeam;
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

            _model.Players.Remove( player );
            _model.Players.Add( updatedPlayer );
            _model.Save();
        }
    }
}
