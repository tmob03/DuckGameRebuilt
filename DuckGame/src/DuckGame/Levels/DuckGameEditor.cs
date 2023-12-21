﻿namespace DuckGame
{
    public class DuckGameEditor : Editor
    {
        public override void RunTestLevel(string name)
        {
            LevGenType genType = LevGenType.Any;
            if (_currentLevelData.proceduralData.enableSingle && !_currentLevelData.proceduralData.enableMulti)
                genType = LevGenType.SinglePlayer;
            else if (!_currentLevelData.proceduralData.enableSingle && _currentLevelData.proceduralData.enableMulti)
                genType = LevGenType.Deathmatch;
            if (_levelThings.Exists(x => x is ChallengeMode))
            {
                foreach (Profile prof in Profiles.active)
                {
                    if (prof.team != null)
                        prof.team.Leave(prof);
                }
                Profiles.experienceProfile.team = Teams.Player1;
                current = new ChallengeLevel(name);
            }
            else if (_levelThings.Exists(x => x is ImportMachine))
                current = new ArcadeLevel(DuckFile.contentDirectory + "Levels/arcade_machine_preview.lev")
                {
                    genType = LevGenType.CustomArcadeMachine,
                    customMachine = name,
                    editor = this
                };
            else if (_levelThings.Exists(x => x is ArcadeMode))
            {
                foreach (Profile prof in Profiles.active)
                {
                    if (prof.team != null)
                        prof.team.Leave(prof);
                }
                Profiles.experienceProfile.team = Teams.Player1;
                current = new ArcadeLevel(name)
                {
                    editor = this
                };
            }
            else
            {
                foreach (Profile prof in Profiles.active)
                {
                    if (prof.team != null)
                        prof.team.Leave(prof);
                }
                Profiles.experienceProfile.team = Teams.Player1;
                for(int i = 1; i < DG.MaxPlayers; i++)
                {
                    Profiles.GetProfile(i).team = Teams.core.teams[i];
                }
                current = new DuckGameTestArea(this, name, _procSeed, _centerTile, genType);
            }
            current.AddThing(new EditorTestLevel(this));
        }

        public override void Update() => base.Update();
    }
}
